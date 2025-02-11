namespace TeamProject_TextRPG.Item
{
    public class Weapon : Equipment, IItem
    {
        public string Name { get; set; }
        public int Stat { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public bool IsSold { get; set; }
        public bool IsEquip { get; set; }

        public Weapon(string name, int stat, int price, string description)
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
            string str = IsEquip ? "[E]" : "";
            str += $" | Attack: {Stat} | {Description} | Price: {Price}G";
            return str;
        }
        public int GetStat() => Stat;

        public bool GetBool()
        {
            return IsEquip;
        }
        public ItemType GetItemType() => ItemType.Weapon;
        public string GetName() => Name;

        public void SetEquipped(bool equip)
        {
            IsEquip = equip;
        }
    }
}
