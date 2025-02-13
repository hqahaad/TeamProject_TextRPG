using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject_TextRPG.Scenes;
using TeamProject_TextRPG.ModifierSystem;
using TeamProject_TextRPG.GameTables;
using TeamProject_TextRPG.GameObject;

namespace TeamProject_TextRPG.InventorySystem
{
    public class Inventory
    {
        public Player? player = User.Instance.GetPlayer();

        public List<InventorySlot> Inven { get; private set; }

        public Weapon? EquippedWeapon { get; private set; }
        public Armor? EquippedArmor { get; private set; }

        public event Action<EquipmentItem> OnEquipped = delegate { };
        public event Action<EquipmentItem> OnUnEquipped = delegate { };

        private StatModifier? weaponModifier;
        private StatModifier? armorModifier;

        public Inventory()
        {
            Inven = new List<InventorySlot>();

            OnEquipped += (e) =>
            {
                if (e.EquipmentType == EquipmentType.Weapon)
                {
                    weaponModifier = new StatModifier(StatType.Attack, new AddOperation(e.Stat));
                    player.mediator.AddModifier(weaponModifier);
                }
                else
                {
                    armorModifier = new StatModifier(StatType.Defensive, new AddOperation(e.Stat));
                    player.mediator.AddModifier(armorModifier);
                }
            };

            OnUnEquipped += (e) =>
            {
                if (e.EquipmentType == EquipmentType.Weapon)
                {
                    weaponModifier?.Dispose();
                    weaponModifier = null;
                }
                else
                {
                    armorModifier?.Dispose();
                    armorModifier = null;
                }
            };

        }


        public void AddItem(Item item)
        {
            if (item.ItemType == ItemType.Potion)
            {
                InventorySlot? existingSlot = Inven.Find(slot => slot.SlotItem.Name == item.Name);
                if (existingSlot != null)
                {
                    existingSlot.Count += 1;
                    return;
                }
            }
            // 포션 아닌경우 인벤토리 슬롯에 추가
            Inven.Add(new InventorySlot(item));
        }

        public void RemoveItem(Item item)
        {
            if (item.ItemType == ItemType.Potion)
            {
                InventorySlot? slot = Inven.Find(s => s.SlotItem.Name == item.Name);

                if (slot?.SlotItem.ItemType == ItemType.Potion)
                {
                    if (slot.Count <= 1)
                    {
                        Inven.Remove(slot);
                    }
                    else
                    {
                        slot.Count -= 1;
                    }
                }
            }
            else
            {
                var slot = Inven.Find(s => s.SlotItem.Name == item.Name);

                Inven.Remove(slot);
            }
        }

        public void EquipItem(EquipmentItem equipment)
        {

            if (equipment.EquipmentType == EquipmentType.Weapon)
            {
                UnEquipped(EquipmentType.Weapon);
                Equipped(EquipmentType.Weapon, equipment);
            }
            else
            {
                UnEquipped(EquipmentType.Armor);
                Equipped(EquipmentType.Armor, equipment);
            }

        }

        private void Equipped(EquipmentType equipmentType, EquipmentItem equipment)
        {

            if (equipment == null)
                return;

            if (equipmentType == EquipmentType.Weapon)
            {
                EquippedWeapon = equipment as Weapon;
            }
            else
            {
                EquippedArmor = equipment as Armor;
            }

            OnEquipped?.Invoke(equipment);
            RemoveItem(equipment);

        }

        private void UnEquipped(EquipmentType equipmentType)
        {
            if (equipmentType == EquipmentType.Weapon)
            {
                if (EquippedWeapon != null)
                {
                    //스탯 감소
                    OnUnEquipped?.Invoke(EquippedWeapon);
                    AddItem(EquippedWeapon);
                    EquippedWeapon = null;
                }
            }
            else
            {
                if (EquippedArmor != null)
                {
                    //스탯 감소
                    OnUnEquipped?.Invoke(EquippedArmor);
                    AddItem(EquippedArmor);
                    EquippedArmor = null;
                }
            }

            //Add Item, Stat 감소

        }

        public void UsePotion(Item item)
        {
            User.Instance.GetPlayer().Hp += item.Stat;
            RemoveItem(item);
        }
    }
    public class InventorySlot
    {
        public Item SlotItem { get; set; }

        public EquipmentItem SlotEquipment { get; set; }
        public int Count { get; set; }

        public InventorySlot(Item item)
        {
            SlotItem = item; // 슬롯 해당 아이템
            Count = 1;
        }
    }
}
