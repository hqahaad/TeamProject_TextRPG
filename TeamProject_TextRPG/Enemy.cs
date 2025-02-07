using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject_TextRPG.BattleSystem;

namespace TeamProject_TextRPG
{
     public class Enemy : IBattler, IDamageable
     {


          public void Attack(IBattler battler)
          {
               battler.GetDamage(this);
          }

          public IBattler AttackCaster(List<IBattler> battler)
          {
               return null;
          }

          public float Damage()
          {
               return 15f;
          }

          public void GetDamage(IDamageable damage)
          {

          }

          public bool IsPlayer()
          {
               return false;
          }
     }
}
