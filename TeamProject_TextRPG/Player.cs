using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject_TextRPG.BattleSystem;

namespace TeamProject_TextRPG
{
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
