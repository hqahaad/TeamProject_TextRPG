namespace TeamProject_TextRPG
{
    public class Damage
    {
        private static readonly float criticalProbability = 0.2f;
        private static readonly float criticalMultipler = 1.5f;

        private float avoid = 0f;

        private float damage;

        private bool isCritical;

        public int CalculateDamage()
        {
            if (IsMissed())
            {
                Utils.Console.WriteLine("회피!", ConsoleColor.Blue);
                return 0;  // 공격 실패 시 데미지 0
            }

            int calculatedDamage = CalculateAttack(damage);

            if (IsCritical())
            {
                isCritical = true;
                calculatedDamage = (int)(calculatedDamage * criticalMultipler); // 크리티컬 데미지 1.5배
                Utils.Console.WriteLine("크리티컬!", ConsoleColor.Yellow);
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
            return random.NextDouble() < (avoid * 0.01f);
        }

        private bool IsCritical() //크리티컬 추가
        {
            Random random = new Random();
            return random.NextDouble() < criticalProbability; //20%
        }

        public void SetAvoid(float avoid)
        {
            this.avoid = avoid;
        }

        public bool GetIsCritical() //외부에서 엑세스 하기위함
        {
            return isCritical;
        }
    }
}
