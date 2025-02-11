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
        private float damage;
        public int CalculateDamage()
        {
            return CalculateAttack(damage);
        }
        public Damage(float damage)
        {
            this.damage = damage;
        }
        private int CalculateAttack(float baseAttack)
        {

            float variance = baseAttack * 0.10f;

            int cell = (int)MathF.Ceiling(variance);

            int minAttack = (int)baseAttack - cell;
            int maxAttack = (int)baseAttack + cell;

            Random random = new Random();
            return random.Next(minAttack, maxAttack + 1);





        }
    }

}
