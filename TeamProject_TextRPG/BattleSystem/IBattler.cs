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
     }

     public struct Damage
     {
          public float Value;

          public void AA()
          {
               Value = 1f;
          }
     }
}
