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
               Table<Enemy>.Get()?.Add("대포미니언", new Enemy("대포미니언", 1, 10, 5, 5));
               Table<Enemy>.Get()?.Add("공허충", new Enemy("공허충", 1, 10, 5, 5));
               Table<Enemy>.Get()?.Add("슬라임", new Enemy("슬라임", 1, 10, 5, 5));
               Table<Enemy>.Get()?.Add("걷는 버섯", new Enemy("걷는 버섯", 1, 10, 5, 5));
               Table<Enemy>.Get()?.Add("거대전갈", new Enemy("거대전갈", 1, 10, 5, 5));
               Table<Enemy>.Get()?.Add("땅거미", new Enemy("땅거미", 1, 10, 5, 5));
               Table<Enemy>.Get()?.Add("바하무트", new Enemy("바하무트", 1, 10, 5, 5));
               Table<Enemy>.Get()?.Add("도적", new Enemy("도적", 1, 10, 5, 5));
               Table<Enemy>.Get()?.Add("지나가던 개발자", new Enemy("지나가던 개발자", 1, 10, 5, 5));
          }
     }
}
