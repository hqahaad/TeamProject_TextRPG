using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject_TextRPG.BattleSystem;

namespace TeamProject_TextRPG
{
     public class Player : GameObject, IBattler
     {
          public void Attack(IBattler battler)
          {

          }

          public IBattler AttackCaster(List<IBattler> battler)
          {
               return null;
          }

          public void GetDamage(IDamageable damage)
          {

          }

          public bool IsPlayer()
          {
               return true;
          }
     }
}