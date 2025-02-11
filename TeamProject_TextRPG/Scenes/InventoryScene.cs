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
        public List<IItem> Inventory { get; private set; } = new(); // 임시. 이거 플레이어한테서 불러와야 플레이어 당 인벤토리가 주어진다.
        
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
            if (Inventory.Count == 0)
            {
                Console.WriteLine($"인벤토리가 비어있습니다.");
                selecter.AddOption("\n0 나가기", "0", () => SceneManager.Instance.LoadScene("로비 씬"));
                selecter.SetExceptionMessage("잘못된 입력입니다.");
                selecter.Display();
                selecter.Select("\n원하시는 행동을 입력해주세요.\n>>  ");
                return;
            }
                
            for (int i = 0; i < Inventory.Count; i++)
            {      
                selecter.AddOption($"\n{i + 1}.{Inventory[i].GetDescription()}", i.ToString(), Start);
            }
            selecter.AddOption("\n0 나가기", "0", () => SceneManager.Instance.LoadScene("로비 씬"));
            selecter.SetExceptionMessage("잘못된 입력입니다.");
            selecter.Display();
            selecter.Select("\n원하시는 행동을 입력해주세요.\n>>  ");

            Console.ReadLine();
        }
    }

    
}
