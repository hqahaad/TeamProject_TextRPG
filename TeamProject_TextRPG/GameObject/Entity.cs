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

        protected string name;
        protected int level;
        protected float maxHp;
        protected float hp;
        protected float maxMp;
        protected float mp;
        protected float attackPower;
        protected float defensivePower;

        public abstract void Update();

        public string Name
        {
            get
            {
                return name;
            }
        }

        public int Level
        {
            get { return level; }
        }

        public float Hp
        {
            get
            {
                return Math.Clamp(hp, 0, maxHp);
            }
            set
            {
                hp = Math.Clamp(value, 0, maxHp);
            }
        }

        public float Mp
        {
            get
            {
                return Math.Clamp(mp, 0, maxMp);
            }
            set
            {
                mp = Math.Clamp(value, 0, maxMp);
            }
        }

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
    }

    public enum StatType
    {
        Attack,
        Defensive
    }
}
