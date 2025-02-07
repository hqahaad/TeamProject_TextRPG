using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject_TextRPG.BattleSystem
{
     public class Battle
     {
          private List<IBattler> battlerList = new();
          private List<IBattler> playerList = new();
          private List<IBattler> enemyList = new();

          private BattleState battleState = BattleState.None;

          public void SetPlayer(IBattler battler)
          {
               playerList.Add(battler);
               battlerList.Add(battler);
          }
          public void SetEnemy(IBattler battler)
          {
               enemyList.Add(battler);
               battlerList.Add(battler);
          }

          public void DoBattle()
          {
               battleState = BattleState.Battle;

               while (battleState == BattleState.Battle)
               {
                    //모든 배틀러 리스트 순회하기
                    foreach (IBattler battler in battlerList)
                    {
                         if (battler.IsPlayer())
                         {
                              battler.DoAction(enemyList);
                              bool isDeadAll = playerList.All(b => b.IsDead());
                              if (isDeadAll)
                              {
                                   //플레이어가 모두 사망하면 패배처리 후 루틴 종료
                                   battleState = BattleState.Defeat;
                                   break;
                              }
                         }
                         else
                         {
                              battler.DoAction(playerList);
                              bool isDeadAll = enemyList.All(b => b.IsDead());

                              if (isDeadAll)
                              {
                                   //적이 모두 사망하면 패배처리 후 루틴 종료
                                   battleState = BattleState.Victory;
                                   break;
                              }
                         }
                    }
                    //배틀 종료
               }
          }

          public BattleState Result()
          {
               return battleState;
          }
     }

     public enum BattleState
     {
          None,
          Battle,
          Victory,
          Defeat
     }
}
