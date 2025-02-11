using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject_TextRPG.BattleSystem
{
    public interface IBattleCondition
    {
        void Update(IBattle battle);
    }

    public class VictoryPlayer : IBattleCondition
    {
        private readonly Action action;

        public VictoryPlayer(Action action)
        {
            this.action = action;
        }

        public void Update(IBattle battle)
        {
            if (battle.IsAllDead(FactionType.Enemy))
            {
                action?.Invoke();
            }
        }
    }

    public class DefeatPlayer : IBattleCondition
    {
        private readonly Action action;

        public DefeatPlayer(Action action)
        {
            this.action = action;
        }

        public void Update(IBattle battle)
        {
            if (battle.IsAllDead(FactionType.Player))
            {
                action?.Invoke();
            }
        }
    }
}
