using System;
using System.Formats.Asn1;
using TeamProject_TextRPG.BattleSystem;
using TeamProject_TextRPG.SkillSystem;
using TeamProject_TextRPG.ModifierSystem;

namespace TeamProject_TextRPG.GameObject
{
    public class Player : Entity, IUnit
    {
        private List<Skill> skillList = new();

        public string ClassName { get; }
        public float Stress { get; set; } = 0.0f;
        public float MaxStress { get; set; } = 100.0f;

        public Player(string name, string className, float att, float def, float maxHp, float maxMp, float avoid, params Skill[] skills)
        {
            this.level = 1;

            this.name = name;
            this.ClassName = className;
            this.attackPower = att;
            this.defensivePower = def;
            this.maxHp = maxHp;
            this.hp = maxHp;
            this.maxMp = maxMp;
            this.mp = maxMp;
            this.avoidAblility = avoid;

            foreach (var iter in skills)
            {
                AddSkill(iter);
            }
        }

        public void CastTarget(IBattle battle, FactionType faction, Action<IUnit> action)
        {
            var units = battle.GetUnits(faction);

            var selecter = OptionSelecter.Create();

            selecter.SetExceptionMessage("잘못된 입력입니다");
            selecter.AddOption(string.Empty, "0", () => SelectAction(battle));

            Action<IUnit> tryCast = (u) =>
            {
                if (u.IsDead())
                {
                    selecter.Exception("\n대상을 선택해주세요.\n >>  ");
                }
                else
                {
                    action?.Invoke(u);
                }
            };

            for (int i = 0; i < units?.Count; i++)
            {
                int target = i;

                selecter.AddOption(string.Empty, (i + 1).ToString(), () => tryCast(units[target]));
                Console.Write($"[{(i + 1).ToString()}] ");
                units[i].DisplayStatus();
            }

            DisplayStatus();
            Utils.Console.WriteLine("\n0. 취소", ConsoleColor.Red);

            selecter.Select("\n대상을 선택해주세요.\n>>  ");
        }

        #region 전투 액션
        private void SelectAction(IBattle battle)
        {
            Console.Clear();
            Utils.Console.WriteLine("Battle!!\n", ConsoleColor.DarkYellow);
            foreach (var iter in battle.GetUnits(FactionType.Enemy) ?? Enumerable.Empty<IUnit>())
            {
                iter.DisplayStatus();
            }
            DisplayStatus();

            var selecter = OptionSelecter.Create();
            selecter.SetExceptionMessage("잘못된 입력입니다");
            selecter.AddOption("\n1. 공격", "1", () => CastAttack(battle));
            selecter.AddOption("2. 스킬", "2", () => SelectSkill(battle));

            selecter.Display();
            selecter.Select("\n원하시는 행동을 입력해주세요.\n>>  ");
        }

        private void CastAttack(IBattle battle)
        {
            var units = battle.GetUnits(FactionType.Enemy);

            if (units == null)
                return;

            Console.Clear();
            Utils.Console.WriteLine("Battle!\n", ConsoleColor.DarkYellow);

            CastTarget(battle, FactionType.Enemy, (u) => Attacking(u));
        }

        private void Attacking(IUnit unit)
        {
            Console.Clear();
            Utils.Console.WriteLine("Battle!!\n", ConsoleColor.DarkYellow);
            Console.Write("Lv.{0} ", level);
            Utils.Console.Write(name, ConsoleColor.Green);
            Console.WriteLine(" 의 공격!");
            //Console.WriteLine($"{name} 의 공격!");
            unit.GetDamage(new Damage(Attack));

            var selecter = OptionSelecter.Create();
            selecter.SetExceptionMessage("잘못된 입력입니다");
            selecter.AddOption("\n0. 다음", "0");
            selecter.Display();
            selecter.Select("\n>>  ");
        }

        private void SelectSkill(IBattle battle)
        {
            Console.Clear();

            var selecter = OptionSelecter.Create();
            selecter.SetExceptionMessage("잘못된 입력입니다");

            for (int i = 0; i < skillList.Count; i++)
            {
                var skill = skillList[i];

                selecter.AddOption($"{(i + 1)}. {skill.SkillName()} - {skill.SkillDescription()}", (i + 1).ToString(), () => Skill(battle, skill));
                //스킬 조건 체크 Action
            }
            selecter.AddOption(string.Empty, "0", () => SelectAction(battle));

            selecter.Display();
            Utils.Console.WriteLine("\n0. 취소", ConsoleColor.Red);
            selecter.Select("\n원하시는 스킬을 선택해주세요..\n>>  ");
        }

        private void Skill(IBattle battle, Skill skill)
        {
            Console.Clear();

            if (!skill.CastSkill(battle))
            {
                SelectAction(battle);
            }

            var selecter = OptionSelecter.Create();
            selecter.SetExceptionMessage("잘못된 입력입니다");
            selecter.AddOption("\n0. 다음", "0");
            selecter.Display();
            selecter.Select();
        }

        #endregion

        #region IUnit 인터페이스
        public void DoAction(IBattle battle)
        {
            SelectAction(battle);
        }

        public override void Update()
        {
            mediator.Update();
        }

        public void GetDamage(Damage damage)
        {
            float originHp = hp;
            damage.SetAvoid(Avoid);
            int fDamage = damage.CalculateDamage();

            if (fDamage <= 0)
            {
                Console.Write("Lv.{0} ", level);
                Utils.Console.Write("{0}", ConsoleColor.Green, true, name);
                Console.WriteLine(" 은(는) 회피했습니다.\n");
                return;
            }

            Console.Write("Lv.{0} ", level);
            Utils.Console.Write("{0}", ConsoleColor.Green, true, name);
            Console.Write(" 을 맞췄습니다.[{0}]\n\n", fDamage);
            Console.WriteLine($"Lv.{level} {name} 을(를) 맞췄습니다. [{fDamage}]\n");
            //데미지를 계산 로직
            hp -= fDamage;

            Stress += fDamage / 2; // 데미지 양에 따라 스트레스 증가
            DisplayStatus();
        }

        public void DisplayStatus()
        {
            Console.WriteLine("\n[내 정보]");
            Console.WriteLine($"Lv.{level} {name} ({ClassName})");

            Utils.Console.ConsoleGauge(hp, maxHp, 20, '■',
            ConsoleColor.Red, ConsoleColor.Red, ConsoleColor.Red, ConsoleColor.Red);
            Console.WriteLine($" HP : {hp / maxHp * 100f:F0}%");

            Utils.Console.ConsoleGauge(mp, maxMp, 20, '■',
            ConsoleColor.Blue, ConsoleColor.Blue, ConsoleColor.Blue, ConsoleColor.Blue);
            Console.WriteLine($" MP : {mp / maxMp * 100f:F0}%");

            Utils.Console.ConsoleGauge(Stress, MaxStress, 20, '■',
            ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Red);
            Console.WriteLine($" 스트레스 : {Stress / MaxStress * 100f:F0}%");
            Console.WriteLine("\n스트레스가 많으면 안좋은 일이 일어납니다!!");
        }

        public bool IsDead()
        {
            return hp <= 0;
        }

        #endregion

        public void AddSkill(Skill skill)
        {
            skill.SetOrder(this);
            skillList.Add(skill);
        }

        public void AddModifier()
        {
            StatModifier mod = new StatModifier(StatType.Attack, new MultiplyOperation(1.1f), 3);

            mod.Dispose();
        }

    }
}