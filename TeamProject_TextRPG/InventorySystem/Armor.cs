﻿namespace TeamProject_TextRPG.InventorySystem
{
    public class Armor : EquipmentItem
    {
        public Armor(string name, int stat, int price, string description)
        {
            Name = name;
            Stat = stat;
            Price = price;
            Description = description;

            ItemType = ItemType.Equipment;
            EquipmentType = EquipmentType.Armor;
        }
    }
}