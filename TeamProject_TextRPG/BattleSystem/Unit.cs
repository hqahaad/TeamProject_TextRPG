namespace TeamProject_TextRPG.BattleSystem
{
    public interface IUnit
    {
        void DoAction(IBattle battle);
        void GetDamage(Damage damage);
        void DisplayStatus();
        bool IsDead();
    }

    public class Unit
    {
        public string? name;
        public int level;
        public int hp;
        public float attackPower;
        public float defensivePower;
    }
}
