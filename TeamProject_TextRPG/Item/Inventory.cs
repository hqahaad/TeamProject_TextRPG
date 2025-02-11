using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject_TextRPG.Item
{
    public class Inventory
    {
        
        public List<InventorySlot> Inven { get; private set; }
        public EquipmentItem? EquippedWeapon { get; private set; }
        public EquipmentItem? EquippedArmor { get; private set; }

        public Inventory()
        {
            Inven = new List<InventorySlot>();
        }
 
        public void AddItem(Item item)
        {
            //스택 가능한 포션이면
            if (item.ItemType == ItemType.Potion) // 포션 종류만 스택이 되니까
            {
                InventorySlot? existingSlot = Inven.Find(slot => slot.SlotItem.Name == item.Name); // 같은 이름 있는지 확인
                if (existingSlot != null)
                {
                    existingSlot.Count += 1; // 포션 추가
                    return;
                }
            }
            // 포션 아닌경우 인벤토리 슬롯에 추가
            Inven.Add(new InventorySlot(item));
        }

        public void RemoveItem(Item item)
        {
            int removeItem = 1;

            if(item.ItemType == ItemType.Potion)
            {
                InventorySlot slot = Inven.Find(s => s.SlotItem.Name == item.Name); // 같은 이름 있는지 확인
                if (slot.SlotItem.ItemType == ItemType.Potion)
                {
                    if (slot.Count <= 1)
                    {
                        Inven.Remove(slot);
                    }
                    else
                    {
                        slot.Count -= removeItem;
                    }
                }                               
            }
            
        }

        public void EquipItem(EquipmentItem item)
        {
            if (item.EquipmentType == EquipmentType.Weapon)
            {
                if(EquippedWeapon != null)
                {
                    if(EquippedWeapon.Name == item.Name)
                    {
                        EquippedWeapon = item;
                    }                    
                    return;
                }                
                else
                {
                    EquippedWeapon = item;
                }
                
            }
            else if (item.EquipmentType == EquipmentType.Armor)
            {
                if (EquippedArmor != null)
                {
                    if (EquippedArmor.Name == item.Name)
                    {
                        EquippedArmor = (Armor)item;
                    }
                    return;
                }
                else
                {
                    EquippedArmor = (Armor)item;
                }
            }
        }

        public void UsePotion(Item item)
        {
             Console.WriteLine($"포션을 사용해 {item.Stat} HP 힐링!");
        }
    }
    public class InventorySlot
    {
        public Item SlotItem { get; set; }
        public int Count { get; set; }
        
        public InventorySlot(Item item)
        {
            SlotItem = item; // 슬롯 해당 아이템
            Count = 1;
        }
    }
}
