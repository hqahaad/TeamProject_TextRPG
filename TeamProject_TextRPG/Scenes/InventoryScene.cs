using TeamProject_TextRPG.BattleSystem;
using TeamProject_TextRPG.GameTables;
using TeamProject_TextRPG.Item;
namespace TeamProject_TextRPG.Scenes
{
    public class InventoryScene : IScene
    {
        public void Awake()
        {

        }
        public List<IItem> Inventory { get; private set; } // 임시. 이거 플레이어한테서 불러와야 플레이어 당 인벤토리가 주어진다.

        public void Start()
        {
            ShowInventory();        
            
        }
        public void End()
        {

        }
        public void ShowInventory()
        {
            Console.Clear();
            Console.WriteLine("인벤토리");
            Console.WriteLine("[아이템 목록]");
            if (Inventory.Count == 0)
                return;
            for (int i = 0; i < Inventory.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{Inventory[i].GetDescription()}");
            }
        }
    }

    
}
