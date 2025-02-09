using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject_TextRPG.BattleSystem;

namespace TeamProject_TextRPG
{
     public class Enemy : Unit, IUnit
     {
          public void DoAction(Battle battle)
          {
               //Console.WriteLine($"Lv.{level} {name}의 공격!");
               ////(임시) 단일 플레이어만 공격
               //targets.First().GetDamage(new Damage(attackPower));
          }

          public void GetDamage(Damage damage)
          {
               float originHp = hp;
               Console.WriteLine($"Lv.{level} {name} 을(를) 맞췄습니다. [{damage.damage}]\n");
               //데미지를 계산 로직
               hp -= (int)damage.damage;
               //
               Console.WriteLine($"Lv.{level} {name}\nHP {originHp}→{hp}");
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
