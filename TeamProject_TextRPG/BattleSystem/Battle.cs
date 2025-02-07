using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject_TextRPG.BattleSystem
{
     public class Battle
     {
          private Queue<IBattler> battleQueue = new();
          private BattleState battleState = BattleState.None;

          public void AddBattler(IBattler battler)
          {
               battleQueue.Enqueue(battler);
          }

          public void StartBattle()
          {
               battleState = BattleState.Battle;

               while (battleState == BattleState.Battle)
               {
                    
               }
          }

          public enum BattleState
          {
               None,
               Battle,
               Victory,
               Defeat,
               End
          }
     }
}
