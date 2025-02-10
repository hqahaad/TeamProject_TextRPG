namespace TeamProject_TextRPG.BattleSystem
{
    public interface IUnit
    {
        void DoAction(Battle battle);
        void GetDamage(Damage damage);
        void DisplayStatus();
        bool IsDead();
    }

    public class Damage
    {
        public float damage;

        public Damage(float damage)
        {
            this.damage = damage;
        }
    }
}
