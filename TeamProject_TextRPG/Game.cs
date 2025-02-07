using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject_TextRPG
{
     public class Game
     {
          public void Start()
          {
               Player player = new Player();

               player.Display();
          }

          public void End()
          {
               Console.WriteLine("Game End");
          }
     }
}
