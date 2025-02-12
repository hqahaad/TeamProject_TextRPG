namespace TeamProject_TextRPG.BattleSystem
{
    public interface IUnit
    {
        void DoAction(IBattle battle);
        void GetDamage(Damage damage);
        void DisplayStatus();
        void Update();
        bool IsDead();
    }
<<<<<<< Updated upstream
=======

    public class Unit
    {
        public string? name;
        public int level;
        public int hp { get; set; }
        public int maxHp;
        public float attackPower;
        public float defensivePower;
    }
>>>>>>> Stashed changes
}
