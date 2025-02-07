using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject_TextRPG.BattleSystem
{
     public interface IBattler
     {
          void DoAction(List<IBattler> battlers);
          void GetDamage(Damage damage);
          void DisplayStatus();
          bool IsPlayer();
          bool IsDead();
     }

     public class Damage
     {
          public float damage;

          public Damage(float damage)
          {
               this.damage = damage;
          }
     }
}
