using System;
using TeamProject_TextRPG.GameTables;
using TeamProject_TextRPG.InventorySystem;

namespace TeamProject_TextRPG.Scenes
{
    public class InventoryScene : IScene
    {
        private Inventory? inventory;
        private Player? player;

        public void Awake()
        {
            inventory = PlayerManager.Instance.inventory;
            player = PlayerManager.Instance.player;

            Item testItem = Table<Item>.Get()?.Load("나무몽둥이");
            Item testItem2 = Table<Item>.Get()?.Load("대화수단");

            inventory.AddItem(testItem);

            Console.WriteLine("Player " + player.Attack);

            inventory.EquipItem(testItem as EquipmentItem);

            Console.WriteLine("Player " + player.Attack);

            inventory.EquipItem(testItem2 as EquipmentItem);

            Console.WriteLine("Player " + player.Attack);

            Console.ReadLine();
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

            if (inventory?.Inven.Count == 0)
            {
                Console.WriteLine($"인벤토리가 비어있습니다.");
                selecter.AddOption("\n0 나가기", "0", () => SceneManager.Instance.LoadScene("로비 씬"));
                selecter.SetExceptionMessage("잘못된 입력입니다.");
                selecter.Display();
                selecter.Select("\n원하시는 행동을 입력해주세요.\n>>  ");
            }

            if (inventory.EquippedWeapon == null) Console.WriteLine($"무기: 없음");
            else Console.WriteLine($"무기: {inventory.EquippedWeapon.Name}");
            if (inventory.EquippedArmor == null) Console.WriteLine($"갑옷: 없음");
            else Console.WriteLine($"갑옷: {inventory.EquippedArmor.Name}");

            for (int i = 0; i < inventory.Inven.Count; i++)
            {
                var slot = PlayerManager.Instance.inventory.Inven[i];
                Console.WriteLine(slot.SlotItem.Name + " | " + slot.Count + "개 | " + slot.SlotItem.Description);
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
