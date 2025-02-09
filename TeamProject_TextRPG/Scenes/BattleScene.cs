using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject_TextRPG.BattleSystem;

namespace TeamProject_TextRPG.Scenes
{
     public class BattleScene : IScene
     {
          public void Awake()
          {

          }

          public void Start()
          {
               Player player = new Player();
               player.name = "스파르타";
               player.hp = 10;
               player.attackPower = 5;
               Enemy enemy1 = new Enemy();
               enemy1.name = "슬라임";
               enemy1.hp = 15;
               Enemy enemy2 = new Enemy();
               enemy2.name = "골렘";
               enemy2.hp = 20;
               Enemy enemy3 = new Enemy();
               enemy3.name = "박쥐";
               enemy3.hp = 6;

               Spawner spawner = new Spawner();
               List<Enemy> enemyList = spawner.Spawn(5, 10, enemy1, enemy2, enemy3);
               Battle battle = new Battle();

               battle.AddUnit(player, FactionType.Player);
               foreach (var iter in enemyList)
               {
                    battle.AddUnit(iter, FactionType.Enemy);
               }

               battle.DoBattle();

               if (battle.Result() == BattleState.Defeat)
               {
                    //패배! 게임 종료 로직
               }
               else
               {
                    Console.WriteLine("승리했습니다!");
                    //승리! 보상 획득 로직
               }
          }

          public void End()
          {

          }
     }

     public class Test : Player
     { }

}
