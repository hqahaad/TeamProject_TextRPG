using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject_TextRPG.Scenes;

namespace TeamProject_TextRPG
{
     public class Game
     {
          public void Start()
          {
               SceneManager.Instance.AddScene("타이틀 씬", new TitleScene());
               SceneManager.Instance.AddScene("배틀 씬", new BattleScene());

               SceneManager.Instance.LoadScene("타이틀 씬");
          }

          public void End()
          {
               Console.WriteLine("Game End");
          }
     }
}
