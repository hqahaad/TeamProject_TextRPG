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
               //(임시) 단일 플레이어만 공격
               battlers.First().GetDamage(new Damage(attackPower));
          }

          public void GetDamage(Damage damage)
          {
               //hp -= (int)battler.Damage();
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
