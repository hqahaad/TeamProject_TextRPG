using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject_TextRPG.BattleSystem
{
     public interface IUnit
     {
          void DoAction(Battle battle);
          void GetDamage(Damage damage);
          void DisplayStatus();
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
