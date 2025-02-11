using System;
using System.Formats.Asn1;
using TeamProject_TextRPG.BattleSystem;
using TeamProject_TextRPG.SkillSystem;


namespace TeamProject_TextRPG
{
    public class Player : Unit, IUnit
    {
        private List<Skill> skillList = new();

        public string className;
        public int mp = 100;

        private StressGauge stressGauge = new StressGauge(100); // 스트레스 게이지 추가

        #region 플레이어의 행동
        private void SelectAction(Battle battle)
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

        private void CastAttack(Battle battle)
        {
            var units = battle.GetUnits(FactionType.Enemy);

            if (units == null)
                return;

            Console.Clear();
            Utils.Console.WriteLine("Battle!\n", ConsoleColor.DarkYellow);

            var selecter = OptionSelecter.Create();
            selecter.SetExceptionMessage("잘못된 입력입니다");
            selecter.AddOption(string.Empty, "0", () => SelectAction(battle));

            Action<IUnit> tryAttack = (u) =>
            {
                if (u.IsDead())
                {
                    selecter.Exception("\n대상을 선택해주세요.\n >>  ");
                }
                else
                {
                    Attack(u);
                }
            };

            for (int i = 0; i < units.Count; i++)
            {
                int target = i;

                selecter.AddOption(string.Empty, (i + 1).ToString(), () => tryAttack(units[target]));
                Console.Write($"[{(i + 1).ToString()}] ");

                units[i].DisplayStatus();
            }
            DisplayStatus();
            Utils.Console.WriteLine("\n0. 취소", ConsoleColor.Red);

            selecter.Select("\n대상을 선택해주세요.\n>>  ");
        }

        private void Attack(IUnit unit)
        {
            Console.Clear();
            Utils.Console.WriteLine("Battle!!\n", ConsoleColor.DarkYellow);
            Console.Write("Lv.{0} ", level);
            Utils.Console.Write(name, ConsoleColor.Green);
            Console.WriteLine(" 의 공격!");
            //Console.WriteLine($"{name} 의 공격!");
            unit.GetDamage(new Damage(attackPower));

            var selecter = OptionSelecter.Create();
            selecter.SetExceptionMessage("잘못된 입력입니다");
            selecter.AddOption("\n0. 다음", "0");
            selecter.Display();
            selecter.Select();
        }

        private void SelectSkill(Battle battle)
        {
            Console.Clear();

            var selecter = OptionSelecter.Create();
            selecter.SetExceptionMessage("잘못된 입력입니다");

            for (int i = 0; i < skillList.Count; i++)
            {
                var skill = skillList[i];

                selecter.AddOption($"1. {skill.SkillName()} - {skill.SkillDescription()}", (i + 1).ToString(), () => Skill(battle, skill));
                //스킬 조건 체크 Action
            }
            selecter.AddOption(string.Empty, "0", () => SelectAction(battle));

            selecter.Display();
            Utils.Console.WriteLine("\n0. 취소", ConsoleColor.Red);
            selecter.Select("\n원하시는 스킬을 선택해주세요..\n>>  ");
        }

        private void Skill(Battle battle, Skill skill)
        {
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

        public void DoAction(Battle battle)
        {
            if (battle.GetFaction(FactionType.Enemy).IsAllDead())
            {
                return;
            }

            SelectAction(battle);
        }

        public void GetDamage(Damage damage)
        {
            

            float originHp = hp;
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
            //Console.WriteLine($"Lv.{level} {name} 을(를) 맞췄습니다. [{fDamage}]\n");
            //데미지를 계산 로직
            hp -= fDamage;
            //
            int stressIncreaseAmount = fDamage/2; // 데미지 양에 따라 스트레스 증가
            stressGauge.IncreaseStress(stressIncreaseAmount);

            Console.WriteLine($"Lv.{level} {name}\nHP {originHp}→{hp}");

            
        }

        public void DisplayStatus()
        {
            Console.WriteLine("\n[내 정보]");
            Console.WriteLine($"Lv.{level} {name} ({className})");
            Console.WriteLine($"HP : {hp}");
            double stressPercentage = stressGauge.GetStressPercentage() * 100;
            
            stressGauge.UpdateDisplay(); // 스트레스 게이지 업데이트
            Console.WriteLine($"스트레스 : {stressPercentage:F0}%");
            Console.WriteLine("스트레스가 많으면 안좋은 일이 일어납니다!!");
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
    }
}