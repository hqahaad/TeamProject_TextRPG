using System;
using TeamProject_TextRPG.GameObject;
using TeamProject_TextRPG.GameTables;
using TeamProject_TextRPG.InventorySystem;

namespace TeamProject_TextRPG.Scenes
{
    public class InventoryScene : IScene
    {
        private Inventory? inventory = null;
        private Player? player;

        public void Awake()
        {
            inventory = User.Instance.GetInventory();
            User.Instance.GetPlayer();
        }

        public void Start()
        {
            DisplayInventory();
        }

        public void End()
        {

        }

        public void DisplayInventory()
        {
            var selecter = OptionSelecter.Create();
            Console.Clear();

            Utils.Console.WriteLine("[인벤토리]", ConsoleColor.Yellow);
            Console.WriteLine("아이템 목록이 표시됩니다.\n");

            Console.WriteLine("보유한 골드 ");
            Utils.Console.WriteLine("{0}G\n", ConsoleColor.Yellow, true, User.Instance.userDate.gold);


            Utils.Console.WriteLine("\n[장착한 장비]", ConsoleColor.Magenta);
            if (inventory.EquippedWeapon == null)
            {
                Console.Write(Utils.String.PadLeft(18, "-Weapon") + "◆  ");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"{Utils.String.PadLeft(18, "-Weapon")}◆  {inventory.EquippedWeapon.Name}");
            }
            if (inventory.EquippedArmor == null)
            {
                Console.Write(Utils.String.PadLeft(18, "-Armor") + "◆  ");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"{Utils.String.PadLeft(18, "-Armor")}◆  {inventory.EquippedArmor.Name}");
            }
            Console.WriteLine();
            Utils.Console.WriteLine("\n[보유한 아이템]", ConsoleColor.Green);

            if (inventory?.Inven.Count == 0)
            {
                Console.WriteLine("\n인벤토리가 비어있습니다.");
                selecter.AddOption("\n0. 나가기", "0", () => SceneManager.Instance.LoadScene("로비 씬"));
                selecter.SetExceptionMessage("잘못된 입력입니다.");
                selecter.Display();
                selecter.Select("\n원하시는 행동을 입력해주세요.\n>>  ");
            }

            foreach (var iter in inventory.Inven)
            {
                Console.Write(Utils.String.PadLeft(16, iter.SlotItem.Name));
                Console.Write("  |  ");
                Console.Write(Utils.String.PadLeft(4, iter.Count.ToString() + "개"));
                Console.Write("  |  ");
                Console.Write(Utils.String.PadLeft(12, iter.SlotItem.Description));
                Console.WriteLine();
            }

            selecter.AddOption("\n[1] 장착 관리", "1", DisplayEquipped);
            selecter.AddOption("[2] 회복아이템 사용", "2", DisplayUsePotion);
            selecter.AddOption("\n0. 나가기", "0", () => SceneManager.Instance.LoadScene("로비 씬"));
            selecter.SetExceptionMessage("잘못된 입력입니다.");
            selecter.Display();
            selecter.Select("\n원하시는 행동을 입력해주세요.\n>>  ");
        }

        private void DisplayEquipped()
        {
            Console.Clear();

            Utils.Console.WriteLine("[인벤토리 - 장착 관리]", ConsoleColor.Yellow);
            Console.WriteLine("장비 목록이 표시됩니다.\n");

            var searchSlot = inventory?.Inven.FindAll(e => e.SlotItem.ItemType == ItemType.Equipment);
            var selecter = OptionSelecter.Create();

            for (int i = 0; i < searchSlot.Count; i++)
            {
                var slot = searchSlot[i];

                Console.Write(Utils.String.PadLeft(16, "[" + (i + 1).ToString() + "] " + slot.SlotItem.Name));
                Console.Write("  |  ");
                Console.Write(Utils.String.PadLeft(12, slot.SlotItem.Description));
                Console.WriteLine();

                selecter.AddOption(string.Empty, (i + 1).ToString(), () => inventory?.EquipItem(slot.SlotItem as EquipmentItem));
            }
            selecter.AddOption("\n0. 나가기", "0", DisplayInventory);
            selecter.SetExceptionMessage("잘못된 입력입니다.");
            selecter.Display();
            selecter.Select("\n장착할 장비의 번호를 선택해주세요.\n>>  ");

            DisplayInventory();
        }

        private void DisplayUsePotion()
        {
            Console.Clear();

            Utils.Console.WriteLine("[인벤토리 - 회복 아이템 관리]", ConsoleColor.Yellow);
            Console.WriteLine("장비 목록이 표시됩니다.\n");

            var searchSlot = inventory?.Inven.FindAll(e => e.SlotItem.ItemType == ItemType.Potion);
            var selecter = OptionSelecter.Create();

            for (int i = 0; i < searchSlot.Count; i++)
            {
                var slot = searchSlot[i];

                Console.Write(Utils.String.PadLeft(16, "[" + (i + 1).ToString() + "] " + slot.SlotItem.Name));
                Console.Write("  |  ");
                Console.Write(Utils.String.PadLeft(12, slot.SlotItem.Description));
                Console.WriteLine();

                selecter.AddOption(string.Empty, (i + 1).ToString(), () => inventory?.UsePotion(slot.SlotItem as Potion));
            }
            selecter.AddOption("\n0. 나가기", "0", DisplayInventory);
            selecter.SetExceptionMessage("잘못된 입력입니다.");
            selecter.Display();
            selecter.Select("\n사용할 회복아이템의 번호를 선택해주세요.\n>>  ");

            DisplayInventory();
        }
    }


}
