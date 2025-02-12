using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject_TextRPG.ModifierSystem
{
    public class Stats
    {
        readonly BaseStats stats = new();
        public readonly StatMediator mediator = new();

        public int Attack
        {
            get
            {
                var q = new Query(StatType.Att, stats.att);
                mediator.PerformQuery(this, q);
                return q.Value;
            }
        }
    }

    public class BaseStats
    {
        public int hp = 20;
        public int att = 10;
    }
}
