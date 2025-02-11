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
        private bool isCritical;
        public int CalculateDamage()
        {
            if (IsMissed())
            {
                Console.WriteLine("회피!");
                return 0;  // 공격 실패 시 데미지 0
            }

            int calculatedDamage = CalculateAttack(damage);

            if (IsCritical())
            {
                isCritical = true;
                calculatedDamage = (int)(calculatedDamage * 1.5f); // 크리티컬 데미지 1.5배
                Console.WriteLine("크리티컬!");
            }

            return calculatedDamage;
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
        private bool IsMissed()
        {
            Random random = new Random();
            return random.NextDouble() < 0.1;
        }

        private bool IsCritical() //크리티컬 추가
        {
            Random random = new Random();
            return random.NextDouble() < 0.2; //20%
        }

        public bool GetIsCritical() //외부에서 엑세스 하기위함
        {
            return isCritical;
        }
    }

}
