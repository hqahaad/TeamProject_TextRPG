using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject_TextRPG.GameTables
{
     public class EnemyTable
     {
          public EnemyTable() 
          {
               Table<Enemy>.Get()?.Add("미니언", new Enemy("미니언", 1, 10, 5, 5));

               Table<Enemy>.Get().Load("미니언");
          }
     }
}
