namespace TeamProject_TextRPG.Scenes
{
    public class TitleScene : IScene
    {
        public void Awake()
        {
        }

        public void Start()
        {
            Console.Clear();
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("이제 전투를 시작할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.\n");

            var selecter = OptionSelecter.Create();

            selecter.AddOption("1.상태 보기", "1",DisplayPlayer);
            selecter.AddOption("2.전투 시작", "2", () => SceneManager.Instance.LoadScene("배틀 씬"));
            selecter.SetExceptionMessage("잘못된 입력입니다.");

            selecter.Display();
            selecter.Select("\n원하시는 행동을 입력해주세요.\n>>  ");
        }

        public void End()
        {
        }

        private void DisplayPlayer()
        {
            Player dplayer = new Player();
            
            Utils.Console.WriteLine("상태보기", ConsoleColor.Cyan);
            Console.WriteLine("캐릭터의 정보가 표시 됩니다");

            Console.WriteLine($"{dplayer.name}: ({dplayer.className})");
            Console.WriteLine($"공격력: {dplayer.attackPower}");
            Console.WriteLine($"방어력: {dplayer.defensivePower}");
            Console.WriteLine($"체력: {dplayer.hp}");
            Console.WriteLine($"Gold:1500 G");

            var selecter = OptionSelecter.Create();
            selecter.AddOption("0.나가기", "0", () => SceneManager.Instance.LoadScene("타이틀 씬"));
            selecter.SetExceptionMessage("잘못된 입력입니다.");

            selecter.Display();
            selecter.Select("\n원하시는 행동을 입력해주세요.\n>>  ");
        }

    }
}
