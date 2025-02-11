namespace TeamProject_TextRPG.BattleSystem
{
    public class Unit
    {
        public string? name;
        public int level;
        public int hp;
        public float attackPower;
        public float defensivePower;
    }

    public interface IUnit
    {
        void DoAction(Battle battle);
        void GetDamage(Damage damage);
        void DisplayStatus();
        bool IsDead();
    }
}
