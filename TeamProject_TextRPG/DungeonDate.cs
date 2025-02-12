using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject_TextRPG
{
    public class DungeonDate
    {
        public List<string> enemyKeys = new List<string>();
        public List<string> rewardKeys = new List<string>();
        public int amount = 0;

        public DungeonDate()
        {

        }

        public void AddEnemy(params string[] keys)
        {
            foreach (string key in keys)
            {
                enemyKeys.Add(key);
            }
        }

        public void AddReward(params string[] keys)
        {
            foreach (string key in keys)
            {
                rewardKeys.Add(key);
            }
        }
    }
}
