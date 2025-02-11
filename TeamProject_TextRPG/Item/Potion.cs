namespace TeamProject_TextRPG.Item
{
    public class Potion : PotionItem
    {
        public Potion(string name, int stat, int price, string description)
        {
            Name = name;
            Stat = stat;
            Price = price;
            Description = description;

            ItemType = ItemType.Potion;
        }
    }
}
