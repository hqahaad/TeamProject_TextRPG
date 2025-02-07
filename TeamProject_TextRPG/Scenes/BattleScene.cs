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
               player.hp = 100;
               Enemy enemy1 = new Enemy();
               enemy1.name = "슬라임";
               enemy1.hp = 100;
               Enemy enemy2 = new Enemy();
               enemy2.name = "골렘";
               enemy2.hp = 150;
               Enemy enemy3 = new Enemy();
               enemy3.name = "박쥐";
               enemy3.hp = 5;

               Spawner spawner = new Spawner();
               List<Enemy> enemyList = spawner.Spawn(5, 10, enemy1, enemy2, enemy3);
               Battle battle = new Battle();

               battle.SetPlayer(player);
               foreach (var iter in enemyList)
               {
                    battle.SetEnemy(iter);
               }

               battle.DoBattle();
          }

          public void End()
          {

          }
     }

     public class Test : Player
     { }

}
