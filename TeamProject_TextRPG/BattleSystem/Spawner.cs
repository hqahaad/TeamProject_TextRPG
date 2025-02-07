using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject_TextRPG.BattleSystem
{
    public class Spawner
    {
        public void Spawn()
        {
            Random rnd = new Random();
            int num = rnd.Next(1, 5); // 1에서 4까지 생성

            for (int i = 0; i < num; i++) // 루프 통해 1~4마리에 몬스터 추가 + 생성
            {
                // 여기에 Enemy type 만들면 4개까지 Spawn하는 기능 추가
                SetEnemy(enemyList[i]);
            }
        }

    }
}

