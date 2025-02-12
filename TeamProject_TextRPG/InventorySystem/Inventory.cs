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
        public Player? player = PlayerManager.Instance.player;

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
                        slot.Count -= 1;
                    }
                }                               
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
                UnEquipped(EquipmentType.Weapon);
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
            var selecter = OptionSelecter.Create();

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
