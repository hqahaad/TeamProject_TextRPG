namespace TeamProject_TextRPG.Item
{
    public class Armor : IItem
    {
        public string Name { get; set; }
        public int Stat { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public bool IsSold { get; set; }
        public bool IsEquip { get; set; }

        public Armor(string name, int stat, int price, string description)
        {
            Name = name;
            Stat = stat;
            Price = price;
            Description = description;
            IsSold = false;
            IsEquip = false;
        }
        public string GetDescription()
        {

            string str = $"{Name} | Defense: {Stat} | {Description} | Price: {Price}G";
            return str;
        }
        
        public int GetStat()
        {
            return Stat;
        }
        public bool GetBool()
        {
            return IsEquip;
        }
    }
}
