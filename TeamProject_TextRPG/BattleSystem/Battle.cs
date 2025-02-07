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

               Random rnd = new Random();
               int num = rnd.Next(1, 5); // 1에서 사까지 생성
               for (int i = 0; i < num; i++) // 루프 통해 1~4마리에 몬스터 추가 + 생성
               {
                    enemyList.Add(battler);
                    battleQueue.Enqueue(battler);
               }


          }

          public void StartBattle()
          {
               battleState = BattleState.Battle;

               while (battleState == BattleState.Battle)
               {
                    IBattler currentTurn = battleQueue.Dequeue(); // 자기 턴이니까 Queue에서 배제
                    IBattler target = null; // 공격하는 타깃 지정 변수. 자기 아니도록.

                    foreach (var iter in battleQueue)
                    {

                         if (!iter.IsPlayer())
                         {
                              target = iter; // 이거 공격하도록 만들기
                              break;
                         }

                    }
                    if (target != null)
                    {
                         currentTurn.Attack(target);
                         //if () 이 공격으로 타깃이 죽었으면
                         {
                              battleQueue = new Queue<IBattler>(battleQueue);
                         }

                    }
                    // if(currentTurn)  살아있으면
                    battleQueue.Enqueue(currentTurn);


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
