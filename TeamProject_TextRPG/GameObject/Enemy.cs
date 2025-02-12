using TeamProject_TextRPG.BattleSystem;

namespace TeamProject_TextRPG.GameObject
{
    public class Enemy : Entity, IUnit
    {
        public Enemy() { }

        public Enemy(string name, int level, float hp, float attackPower, float defensivePower)
        {
            this.name = name;
            this.level = level;
            this.hp = hp;
            this.attackPower = attackPower;
            this.defensivePower = defensivePower;
        }

        public void DoAction(IBattle battle)
        {
            Console.Clear();
            Utils.Console.WriteLine("Battle!!\n", ConsoleColor.DarkYellow);
            Console.Write("Lv.{0} ", level);
            Utils.Console.Write(name, ConsoleColor.Red);
            Console.WriteLine(" 의 공격!");
            ////(임시) 단일 플레이어만 공격
            battle.GetUnits(FactionType.Player)?.First().GetDamage(new Damage(attackPower));

            var selecter = OptionSelecter.Create();
            selecter.SetExceptionMessage("잘못된 입력입니다");
            selecter.AddOption("\n0. 다음", "0");
            selecter.Display();
            selecter.Select();
        }

        public override void Update()
        {
            mediator.Update();
        }

        public static Enemy Clone(Enemy origin)
        {
            Enemy enemy = new Enemy();
            enemy.name = origin.name;
            enemy.level = origin.level;
            enemy.hp = origin.hp;
            enemy.attackPower = origin.attackPower;
            enemy.defensivePower = origin.defensivePower;

            return enemy;
        }

        public void GetDamage(Damage damage)
        {
            float originHp = hp;
            damage.SetAvoid(Avoid);
            int fDamage = damage.CalculateDamage();
            if (fDamage <= 0)
            {
                Console.Write("Lv.{0} ", level);
                Utils.Console.Write("{0}", ConsoleColor.Red, true, name);
                Console.WriteLine(" 은(는) 회피했습니다.\n");
                return;
            }
            Console.Write("Lv.{0} ", level);
            Utils.Console.Write("{0}", ConsoleColor.Red, true, name);
            Console.Write(" 을 맞췄습니다.[{0}]\n", fDamage);
            //데미지를 계산 로직
            hp -= fDamage;
            //
            Console.WriteLine($"Lv.{level} {name}\nHP {originHp}→{hp}\n");
        }

        public void DisplayStatus()
        {
            if (IsDead())
            {
                Utils.Console.WriteLine($"Lv.{level} {name} [Dead]", ConsoleColor.DarkGray);
            }
            else
            {
                Console.WriteLine($"Lv.{level} {name} HP {hp}");
            }
        }

        public bool IsDead()
        {
            return hp <= 0;
        }
    }
}
