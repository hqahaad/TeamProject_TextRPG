using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject_TextRPG.BattleSystem;


namespace TeamProject_TextRPG
{
     public class Player : GameObject
     {
          private string? className;
        private int gold;
        public int Gold { get { return gold; } set { gold = value; } }

        public Player(string name, int level, int hp, float attackPower, float defensivePower, string className, int gold) 
        {
            
            this.name = name;
            this.level = level; 
            this.hp = hp;   
            this.attackPower = attackPower;
            this.defensivePower = defensivePower;
            this.className = className;
            this.gold = gold;
        }
        

        public void Display()
          {
            Console.WriteLine("정보보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
            Console.WriteLine("Lv. {0:D2}",level);
            Console.WriteLine("{0} ( {1} )",name,className);
            Console.WriteLine("공격력 : {0}", attackPower);
            Console.WriteLine("방어력 : {0}", defensivePower);
            Console.WriteLine("체 력 : {0}", hp);
            Console.WriteLine("Gold : {0}G\n",gold);
        }
     public class Player : IBattler
     {
          //수정
          int hp = 100;
          int att = 10;

          public void Attack(IBattler battler)
          {
               throw new NotImplementedException();
          }

          public IBattler AttackCaster(List<IBattler> battler)
          {
               throw new NotImplementedException();
          }

          public void GetDamage(IDamageable damage)
          {
               throw new NotImplementedException();
          }

          public bool IsPlayer()
          {
               return true;
          }
     }
}
