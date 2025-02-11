using System;

namespace TeamProject_TextRPG.Scenes
{
    public class InventoryScene : IScene
    {
        public void Awake()
        {

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
           if (PlayerManager.Instance.inventory.Count == null)
            {
                Console.WriteLine($"인벤토리가 비어있습니다.");
                selecter.AddOption("\n0 나가기", "0", () => SceneManager.Instance.LoadScene("로비 씬"));
                selecter.SetExceptionMessage("잘못된 입력입니다.");
                selecter.Display();
                selecter.Select("\n원하시는 행동을 입력해주세요.\n>>  ");
                return;
            }
            if (PlayerManager.Instance.inventory.EquippedWeapon == null) Console.WriteLine($"무기: 없음");
            else Console.WriteLine($"무기: {PlayerManager.Instance.inventory.EquippedWeapon}");
            if (PlayerManager.Instance.inventory.EquippedArmor == null) Console.WriteLine($"갑옷: 없음");
            else Console.WriteLine($"갑옷: {PlayerManager.Instance.inventory.EquippedArmor}");

            for (int i = 0; i < PlayerManager.Instance.inventory.Count; i++)
            {
                //selecter.AddOption($"2.전투 시작", ToString().i,() => SceneManager.Instance.LoadScene("배틀 씬"));
            }
            selecter.AddOption("\n0 나가기", "0", () => SceneManager.Instance.LoadScene("로비 씬"));
            selecter.SetExceptionMessage("잘못된 입력입니다.");
            selecter.Display();
            selecter.Select("\n원하시는 행동을 입력해주세요.\n>>  ");

            Console.ReadLine();
        }

        

    }

    
}
