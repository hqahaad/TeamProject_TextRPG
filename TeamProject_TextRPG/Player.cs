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
          public void DoAction(List<IBattler> battlers)
          {
               var ops = OptionSelecter.Create();
          }

          public void GetDamage(Damage damage)
          {

          }

          public bool IsPlayer()
          {
               return true;
          }
     }
}