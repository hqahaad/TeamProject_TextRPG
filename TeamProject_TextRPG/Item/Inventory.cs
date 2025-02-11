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
        public Weapon EquipW { get; private set; }
        public Armor EquipA { get; private set; }

        public Inventory()
        {
            Inven = new List<InventorySlot>();
        }

        
        public void AddItem(IItem item , int count)
        {
            //스택 가능한 포션이면
            if (item.GetItemType() == ItemType.Potion) // 포션 종류만 스택이 되니까
            {
                InventorySlot existingSlot = Inven.Find(slot => slot.Item.GetName == item.GetName); // 같은 이름 있는지 확인
                if (existingSlot != null)
                {
                    existingSlot.Count += count; // 포션 추가
                    return;
                }
            }
            // 포션 아닌경우 인벤토리 슬롯에 추가
            Inven.Add(new InventorySlot(item, count));

        }
        public void RemoveItem(IItem item)
        {
            int removeItem = 1;
            if(item.GetItemType() == ItemType.Potion)
            {
                InventorySlot slot = Inven.Find(s => s.Item == item); // 같은 이름 있는지 확인
                if (slot.Item.GetItemType() == ItemType.Potion)
                {
                    if (slot.Count <= 1)
                        Inven.Remove(slot);
                    else
                        slot.Count -= removeItem;
                }                               
            }
            
        }

        //public void EquipItem(IItem item)
        //{
        //    if (item is Weapon weapon)
        //    {
        //        if ()
        //        {
        //            // item.GetStat 만큼 공격력 저하
        //            Console.WriteLine($"{item.GetDescription}무기 장착 해제");
        //        }

        //        else
        //        {
        //            // item.GetStat 만큼 공격력 상승
        //            Console.WriteLine($"{item.GetDescription}무기 장착");
        //        }

        //    }
        //    else if (item is Armor armor)
        //    {
        //        if (IsEquip)
        //        {
        //            // item.GetStat 만큼 방어력 저하
        //            Console.WriteLine($"방어구 장착 해제");
        //        }
        //        else
        //        {
        //            // item.GetStat 만큼 방어력 상승
        //            Console.WriteLine($"방어구 장착");
        //        }

        //    }
        //}
        public void UsePotion(IItem item)
        {
            if (item is Potion potion)
            {
                // 힐링하는 기능
                Console.WriteLine($"포션을 사용해 {item.GetStat} HP 힐링!");
            }
        }
    }
    public class InventorySlot
    {
        public IItem Item { get; set; }
        public int Count { get; set; }
        
        public InventorySlot(IItem item, int count)
        {
            Item = item; // 슬롯 해당 아이템
            Count = count; 
        }

        public override string ToString()
        {
            string equippedTag = (Item is Weapon w && w.IsEquip || Item is Armor a && a.IsEquip) ? "E" : "";
            return $"{equippedTag} {Item.GetName} x {Count} | {Item.GetDescription()}";
        }
    }
}
