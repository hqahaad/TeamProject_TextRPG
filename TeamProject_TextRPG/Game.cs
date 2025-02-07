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
            Player myPlayer = new Player("전사", 1, 500, 10.0f, 10.0f, "Warrior");

            myPlayer.Display();
          }

          public void End()
          {
               Console.WriteLine("Game End");
          }
     }
}
