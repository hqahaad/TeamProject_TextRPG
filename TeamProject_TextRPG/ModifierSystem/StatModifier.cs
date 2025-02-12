using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject_TextRPG.ModifierSystem
{
    public class StatModifier : IDisposable
    {
        public StatType Type { get; }
        public IOperationStrategy Strategy { get; }
        public bool MarkedForRemoval { get; set; }

        public event Action<StatModifier> OnDispose = delegate { };

        private int turnTimer;

        public StatModifier(StatType type, IOperationStrategy strategy, int duration = 0)
        {
            Type = type;
            Strategy = strategy;

            turnTimer = duration;
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
            turnTimer--;

            if (turnTimer == 0)
            {
                MarkedForRemoval = true;
            }
        }

        public void Dispose()
        {
            OnDispose?.Invoke(this);
        }
    }


}
