namespace TeamProject_TextRPG
{
    public class Unit
    {
        public string? name;
        public int level;
        public int hp;
        public float attackPower;
        public float defensivePower;

        public Unit()
        {
            name = Console.ReadLine();
            
            level = 1;
            hp = 10;
            attackPower = 10;
            defensivePower = 10;
        }
    }
}
