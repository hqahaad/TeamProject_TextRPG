using System;
using TeamProject_TextRPG.GameTables;
using TeamProject_TextRPG.InventorySystem;

namespace TeamProject_TextRPG.Scenes
{
    public class InventoryScene : IScene
    {
        public void Awake()
        {
            var inven = PlayerManager.Instance.inventory;
          
            inven.AddItem(Table<Weapon>.Get().Load("나무몽둥이"));
            inven.AddItem(Table<Armor>.Get().Load("티셔츠"));
            inven.AddItem(Table<Potion>.Get().Load("콜라"));
            inven.AddItem(Table<Potion>.Get().Load("사이다"));
            inven.RemoveItem(Table<Potion>.Get().Load("콜라"));
        }
        
        
        public void Start()
        {
           ShowInventory();        
            
        }
        public void End()
        {

        }
        public void ShowInventory()
        {
                       
           var selecter = OptionSelecter.Create();
           Console.Clear();

           Console.WriteLine("인벤토리");
           Console.WriteLine("[아이템 목록]");
           if (PlayerManager.Instance.inventory.Inven.Count == null)
            {
                Console.WriteLine($"인벤토리가 비어있습니다.");
                selecter.AddOption("\n0 나가기", "0", () => SceneManager.Instance.LoadScene("로비 씬"));
                selecter.SetExceptionMessage("잘못된 입력입니다.");
                selecter.Display();
                selecter.Select("\n원하시는 행동을 입력해주세요.\n>>  ");
                return;
            }
            if (PlayerManager.Instance.inventory.EquippedWeapon == null) Console.WriteLine($"무기: 없음");
            else Console.WriteLine($"무기: {PlayerManager.Instance.inventory.EquippedWeapon.Name}");
            if (PlayerManager.Instance.inventory.EquippedArmor == null) Console.WriteLine($"갑옷: 없음");
            else Console.WriteLine($"갑옷: {PlayerManager.Instance.inventory.EquippedArmor.Name}");

            for (int i = 0; i < PlayerManager.Instance.inventory.Inven.Count; i++)
            {
                var slot = PlayerManager.Instance.inventory.Inven[i];
                Console.WriteLine(slot.SlotItem.Name + " | "+ slot.Count + "개 | " + slot.SlotItem.Description);
                //selecter.AddOption($"2.전투 시작", ToString().i,() => SceneManager.Instance.LoadScene("배틀 씬"));
            }
            selecter.AddOption("\n1 장비 장착", "1", ItemEquip);
            selecter.AddOption("2 포션 사용", "2", DrinkPotion);
            selecter.AddOption("\n0 나가기", "0", () => SceneManager.Instance.LoadScene("로비 씬"));
            selecter.SetExceptionMessage("잘못된 입력입니다.");
            selecter.Display();
            selecter.Select("\n원하시는 행동을 입력해주세요.\n>>  ");
                       
        }
        private void ItemEquip()
        {
            var selecter = OptionSelecter.Create();
            Console.Clear();
            var searchItem = PlayerManager.Instance.inventory.Inven.FindAll(e => e.SlotItem.ItemType == ItemType.Equipment);
            

            for (int i = 0; i < searchItem.Count; i++)
            {
                var slot = searchItem[i];                                
                selecter.AddOption($"{i + 1}. {slot.SlotItem.Name} |  + {slot.Count} + 개 |  + {slot.SlotItem.Description}", (i + 1).ToString(), () => PlayerManager.Instance.inventory.EquipItem((EquipmentItem)slot.SlotItem));
                
            }
            selecter.AddOption("\n0 나가기", "0", () => SceneManager.Instance.LoadScene("인벤토리 씬" +
                ""));
            selecter.SetExceptionMessage("잘못된 입력입니다.");
            selecter.Display();
            selecter.Select("\n원하시는 행동을 입력해주세요.\n>>  ");
            
        }
        private void DrinkPotion()
        {
            var selecter = OptionSelecter.Create();
            Console.Clear();
            var searchItem = PlayerManager.Instance.inventory.Inven.FindAll(e => e.SlotItem.ItemType == ItemType.Potion);
            
            for (int i = 0; i < searchItem.Count; i++)
            {
                var slot = searchItem[i];

                // Console.WriteLine(slot.SlotItem.Name + " | " + slot.Count + "개 | " + slot.SlotItem.Description);
                selecter.AddOption($"{i + 1}. {slot.SlotItem.Name} |  + {slot.Count} + 개 |  + {slot.SlotItem.Description}", (i + 1).ToString(), () => PlayerManager.Instance.inventory.UsePotion(slot.SlotItem));
                //selecter.AddOption($"2.전투 시작", ToString().i,() => SceneManager.Instance.LoadScene("배틀 씬"));
            }
            selecter.AddOption("\n0 나가기", "0", () => SceneManager.Instance.LoadScene("인벤토리 씬"));
            selecter.SetExceptionMessage("잘못된 입력입니다.");
            selecter.Display();
            selecter.Select("\n원하시는 행동을 입력해주세요.\n>>  ");
        }
        

    }

    
}
