namespace TeamProject_TextRPG.Scenes
{
    public class JobScene : IScene
    {
        public void Awake()
        {

        }
        public void Start()
        {
            Console.WriteLine("이름을 적어주세요:");

            string name = Console.ReadLine();
            Console.Clear();

            var selecter = OptionSelecter.Create();
            Console.WriteLine("직업을 선택하세요:");
            selecter.AddOption("1.전사", "1");
            selecter.AddOption("2.마법사", "2");
            selecter.AddOption("3.도적", "3");
            selecter.AddOption("4.성직자", "4");
            selecter.SetExceptionMessage("잘못된 입력입니다.");
            selecter.Display();
            selecter.Select("\n원하시는 직업을 입력해주세요.\n>>  ");
            SceneManager.Instance.LoadScene("타이틀 씬");
        }
        public void End()
        {

        }
    }
}
