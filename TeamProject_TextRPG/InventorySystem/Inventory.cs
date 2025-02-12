using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject_TextRPG.Scenes;
using TeamProject_TextRPG.ModifierSystem;
using TeamProject_TextRPG.GameTables;

namespace TeamProject_TextRPG.InventorySystem
{
    public class Inventory
    {
        public List<InventorySlot> Inven { get; private set; }
        public EquipmentItem? EquippedWeapon { get; private set; }
        public EquipmentItem? EquippedArmor { get; private set; }

        public OptionSelecter selecter = OptionSelecter.Create();

        public Inventory()
        {
            Inven = new List<InventorySlot>();

            var a = Table<Item>.Get()?.Load("나무몽둥이");
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
                InventorySlot? slot = Inven.Find(s => s.SlotItem.Name == item.Name); // 같은 이름 있는지 확인
                if (slot?.SlotItem.ItemType == ItemType.Potion)
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
            var player = PlayerManager.Instance.player;
            if (item.EquipmentType == EquipmentType.Weapon)
            {
                if(EquippedWeapon != null)
                {
                    if(EquippedWeapon.Name == item.Name)
                    {
                        Console.WriteLine($"{item.Name} 장착 해제");
                        //var modifier = new StatModifier(StatType.Attack, new RemoveOperation(item.Stat));
                        EquippedWeapon = null;
                    }
                    else
                    {
                        Console.WriteLine($"{item.Name} 무기칸에 장착");
                        var modifier = new StatModifier(StatType.Attack, new AddOperation(item.Stat));
                        PlayerManager.Instance.player.mediator.AddModifier(modifier);
                        EquippedWeapon = item;
                    }
                    return;
                }                
                else
                {
                    Console.WriteLine($"{item.Name} 무기칸에 장착");
                    var modifier = new StatModifier(StatType.Attack, new AddOperation(item.Stat));
                    PlayerManager.Instance.player.mediator.AddModifier(modifier);
                    EquippedWeapon = item;
                }             
            }
            else if (item.EquipmentType == EquipmentType.Armor)
            {
                if (EquippedArmor != null)
                {
                    if (EquippedArmor.Name == item.Name)
                    {
                        Console.WriteLine($"{item.Name} 장착 해제");
                        // var modifier = new StatModifier(StatType.Defensive, new RemoveOperation(item.Stat));
                        EquippedArmor = null;
                    }
                    else
                    {
                        Console.WriteLine($"{item.Name} 갑옷칸에 장착");
                        var modifier = new StatModifier(StatType.Defensive, new AddOperation(item.Stat));
                        PlayerManager.Instance.player.mediator.AddModifier(modifier);
                        EquippedArmor = item;
                    }
                    return;                   
                }
                else
                {
                    Console.WriteLine($"{item.Name} 갑옷칸에 장착");
                    var modifier = new StatModifier(StatType.Defensive, new AddOperation(item.Stat));
                    PlayerManager.Instance.player.mediator.AddModifier(modifier);
                    EquippedArmor = item;
                }
            }
            selecter.AddOption("\n0 나가기", "0", () => SceneManager.Instance.LoadScene("로비 씬"));
            selecter.SetExceptionMessage("잘못된 입력입니다.");
            selecter.Display();
            selecter.Select("\n원하시는 행동을 입력해주세요.\n>>  ");
        }

        public void UsePotion(Item item)
        {
            Console.WriteLine($"포션을 사용해 {item.Stat} HP 힐링!");
            RemoveItem(item);
            selecter.AddOption("\n0 나가기", "0", () => SceneManager.Instance.LoadScene("로비 씬"));
            selecter.SetExceptionMessage("잘못된 입력입니다.");
            selecter.Display();
            selecter.Select("\n원하시는 행동을 입력해주세요.\n>>  ");
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
