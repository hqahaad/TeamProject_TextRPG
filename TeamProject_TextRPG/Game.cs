using TeamProject_TextRPG.Scenes;

namespace TeamProject_TextRPG
{
    public class Game
    {
        public void Start()
        {
            SceneManager.Instance.AddScene("직업 씬", new JobScene());
            SceneManager.Instance.AddScene("타이틀 씬", new TitleScene());
            SceneManager.Instance.AddScene("배틀 씬", new BattleScene());

            SceneManager.Instance.LoadScene("직업 씬");
        }

        public void End()
        {
            Console.WriteLine("Game End");
        }
    }
}
