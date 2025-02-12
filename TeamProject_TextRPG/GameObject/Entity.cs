using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject_TextRPG.ModifierSystem;

namespace TeamProject_TextRPG.GameObject
{
    public abstract class Entity
    {
        public readonly StatMediator mediator = new();

        public string? name;
        public int level;
        public float maxHp = 100.0f;
        public float hp = 0.0f;
        public float maxMp = 100.0f;
        public float mp = 0.0f;
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
