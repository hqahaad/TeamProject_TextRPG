namespace TeamProject_TextRPG.InventorySystem
{
    public class Weapon : EquipmentItem
    {
        public Weapon(string name, int stat, int price, string description)
        {
            Name = name;
            Stat = stat;
            Price = price;
            Description = description;

            ItemType = ItemType.Equipment;
            EquipmentType = EquipmentType.Weapon;
        }

    }
}
