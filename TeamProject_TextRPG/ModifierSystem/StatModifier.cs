using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject_TextRPG.ModifierSystem
{
    public abstract class StatModifier
    {
        public StatType Type { get; }
        public IOperationStrategy Strategy { get; }
        public bool MarkedForRemoval { get; set; }

        public event Action<StatModifier> OnDispose = delegate { };

        readonly int turnTimer;

        protected StatModifier(StatType type, IOperationStrategy strategy, float duration)
        {
            Type = type;
            Strategy = strategy;

            if (duration <= 0)
            {
                return;
            }
        }

        public void Handle(object sender, Query query)
        {
            if (query.StatType == Type)
            {
                query.Value = Strategy.Culculate(query.Value);
            }
        }

        public void Update()
        {

        }
    }


}
