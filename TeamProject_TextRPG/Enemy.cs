using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject_TextRPG.BattleSystem;

namespace TeamProject_TextRPG
{
     public class Enemy : GameObject, IBattler
     {
          public void DoAction(List<IBattler> battlers)
          {
               Console.WriteLine($"Lv.{level} {name}의 공격!");
               //(임시) 단일 플레이어만 공격
               battlers.First().GetDamage(new Damage(attackPower));
          }

          public void GetDamage(Damage damage)
          {
               float originHp = hp;
               Console.WriteLine($"Lv.{level} {name} 을(를) 맞췄습니다. [{damage.damage}]\n");
               //데미지를 계산 로직

               //
               Console.WriteLine($"Lv.{level} {name}\nHP {originHp}→{hp}");
          }

          public void DisplayStatus()
          {

          }

          public bool IsPlayer()
          {
               return false;
          }

          public bool IsDead()
          {
               return hp < 0;
          }
     }
}
