namespace TeamProject_TextRPG.Item
{
    public class Item
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ItemType ItemType { get; set; }
        public int Price { get; set; }
        public int Stat { get; set; }
    }

    public class EquipmentItem : Item
    {
        public bool IsEquip { get; set; }
        public EquipmentType EquipmentType { get; set; }
    }

    public class PotionItem : Item
    {

    }

    public enum ItemType
    {
        Equipment, 
        Potion
    }

    public enum EquipmentType
    {
        Weapon,
        Armor
    }
}
