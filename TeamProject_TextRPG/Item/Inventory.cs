using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject_TextRPG.Item
{
    public class Inventory
    {
       
        public List<InventorySlot> Inven { get; private set; } = new(); 

        public Inventory()
        {
            CreateInventory();
        }

        public void CreateInventory()
        {
            for(int i = 0; i < 50; i++)
            {
                Inven.Add(new InventorySlot());
            }
        }

        public void AddItem(IItem item)
        {
            if (item is Potion)
            {
                
                Inven.Add();
            Console.WriteLine($"{item.GetName} 획득!");
            }
            else
            {
            Inven.Add(InventorySlot());
            Console.WriteLine($"{item.GetName} 획득!");
            }
        }
        public void RemoveItem(IItem item)
        {
            if(item is Potion)
            {
                
                Console.WriteLine($"{item.GetName}을 사용했습니다.");
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
        IItem item;
        int count;
        //인벤토리 중복이 있을 시 x (개수) 기록
    }
}
