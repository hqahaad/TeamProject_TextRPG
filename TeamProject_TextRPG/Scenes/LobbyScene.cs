using TeamProject_TextRPG.GameTables;
using TeamProject_TextRPG.InventorySystem;

namespace TeamProject_TextRPG.Scenes
{
    public class LobbyScene : IScene
    {
        public void Awake()
        {

        }

        public void Start()
        {
            Console.Clear();
            Utils.Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.", ConsoleColor.Gray);
            Console.WriteLine("이제 전투를 시작할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.\n");

            var selecter = OptionSelecter.Create();

            selecter.AddOption("[1] 상태 보기", "1", DisplayPlayerStat);
            selecter.AddOption("[2] 전투 시작", "2", () => SceneManager.Instance.LoadScene("배틀 씬"));
            selecter.AddOption("[3] 인벤토리", "3", () => SceneManager.Instance.LoadScene("인벤토리 씬"));
            selecter.AddOption(string.Empty, "rtan2", () => {
                User.Instance.GetInventory().AddItem(Table<Item>.Get()?.Load("대화수단"));
                SceneManager.Instance.LoadScene("인벤토리 씬");
                }
            );
            selecter.SetExceptionMessage("잘못된 입력입니다.");
            selecter.Display();
            selecter.Select("\n원하시는 행동을 입력해주세요.\n>>  ");
        }

        private void DisplayPlayerStat()
        {
            var player = User.Instance.GetPlayer();

            Console.Clear();
            Utils.Console.WriteLine("[상태보기]", ConsoleColor.Yellow);
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
            //시연용
            Console.WriteLine("◆ LV - {0}", 1);
            Console.WriteLine("◆ {0} ({1})", player.Name, player.ClassName);
            Console.WriteLine("◆ 공격력 - {0}", player.Attack);
            Console.WriteLine("◆ 방어력 - {0}", player.Defensive);
            Console.WriteLine("◆ 체력 - {0}", player.Hp);
            Console.WriteLine("◆ Gold - {0} G", User.Instance.userDate.gold);

            var selecter = OptionSelecter.Create();
            selecter.AddOption("\n0.나가기", "0", Start);
            selecter.Display();
            selecter.Select("\n원하시는 행동을 입력해주세요.\n>>  ");
        }

        public void End()
        {

        }
    }
}
