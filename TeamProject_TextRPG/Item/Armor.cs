namespace TeamProject_TextRPG.Item
{
    public class Armor : EquipmentItem
    {
        public Armor(string name, int stat, int price, string description)
        {
            Name = name;
            Stat = stat;
            Price = price;
            Description = description;
            IsEquip = false;

            ItemType = ItemType.Equipment;
            EquipmentType = EquipmentType.Armor;
        }
    }
}