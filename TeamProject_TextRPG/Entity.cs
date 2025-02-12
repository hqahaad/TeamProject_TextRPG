using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject_TextRPG.ModifierSystem;

namespace TeamProject_TextRPG
{
    public abstract class Entity
    {
        public readonly StatMediator mediator = new();

        public string? name;
        public int level;
        public float maxHp;
        public float hp;
        public float attackPower;
        public float defensivePower;

        public float Attack
        {
            get
            {
                var q = new Query(StatType.Attack, attackPower);
                mediator.PerformQuery(this, q);
                return q.Value;
            }
        }

        public float Defensive
        {
            get
            {
                var q = new Query(StatType.Defensive, defensivePower);
                mediator.PerformQuery(this, q);
                return q.Value;
            }
        }

        public abstract void Update();
    }

    public enum StatType
    {
        Attack,
        Defensive
    }
}
