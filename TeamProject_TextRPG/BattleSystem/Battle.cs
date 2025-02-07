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

          private List<IBattler> playerList = new();
          private List<IBattler> enemyList = new();

          private BattleState battleState = BattleState.None;

          public void SetPlayer(IBattler battler)
          {
               playerList.Add(battler);
               battleQueue.Enqueue(battler);
          }

          public void SetEnemy(IBattler battler)
          {
               playerList.Add(battler);
               battleQueue.Enqueue(battler);
          }

          public void StartBattle()
          {
               battleState = BattleState.Battle;

               while (battleState == BattleState.Battle)
               {
                    foreach (var iter in battleQueue)
                    {
                         if (iter.IsPlayer())
                         {

                         }
                         else
                         {

                         }
                    }
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
