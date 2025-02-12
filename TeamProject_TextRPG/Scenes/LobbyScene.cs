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
            Utils.Console.TypingWriteLine("스파르타 던전에 오신 여러분 환영합니다.", ConsoleColor.Gray, 4);
            Console.WriteLine("이제 전투를 시작할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.\n");

            var selecter = OptionSelecter.Create();

            selecter.AddOption("[1] 상태 보기", "1",DisplayPlayer) ;
            selecter.AddOption("[2] 전투 시작", "2", () => SceneManager.Instance.LoadScene("배틀 씬"));
            selecter.AddOption("[3] 인벤토리", "3", () => SceneManager.Instance.LoadScene("인벤토리 씬"));
            selecter.SetExceptionMessage("잘못된 입력입니다.");
            selecter.Display();
            selecter.Select("\n원하시는 행동을 입력해주세요.\n>>  ");
        }

        private void DisplayPlayer()
        {
            Console.Clear();
            Utils.Console.WriteLine("[상태보기]",ConsoleColor.Yellow);
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
            Console.WriteLine("◆ LV - {0}", PlayerManager.Instance.player.level);
            Console.WriteLine("◆ {0} ({1})", PlayerManager.Instance.player.name, PlayerManager.Instance.player.className);
            Console.WriteLine("◆ 공격력 - {0}", PlayerManager.Instance.player.attackPower);
            Console.WriteLine("◆ 방어력 - {0}", PlayerManager.Instance.player.defensivePower);
            Console.WriteLine("◆ 체력 - {0}", PlayerManager.Instance.player.hp);
            Console.WriteLine("◆ Gold - 1500 G");

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
