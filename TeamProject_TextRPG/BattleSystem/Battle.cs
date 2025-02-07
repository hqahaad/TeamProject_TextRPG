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
