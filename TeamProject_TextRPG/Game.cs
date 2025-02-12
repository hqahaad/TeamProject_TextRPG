using TeamProject_TextRPG.GameTables;
using TeamProject_TextRPG.Scenes;

namespace TeamProject_TextRPG
{
    public class Game
    {
        public void Start()
        {
            Utils.Console.ConsoleGauge(50, 100, duration: 20, '■', ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Red);

            Console.ReadLine();

            new WeaponTable();
            new ArmorTable();
            new PotionTable();
            new EnemyTable();

            SceneManager.Instance.AddScene("테스트 씬", new TestScene());
            SceneManager.Instance.AddScene("타이틀 씬", new TitleScene());
            SceneManager.Instance.AddScene("배틀 씬", new BattleScene());
            SceneManager.Instance.AddScene("로비 씬", new LobbyScene());
            SceneManager.Instance.AddScene("인벤토리 씬", new InventoryScene());

            SceneManager.Instance.LoadScene("타이틀 씬");
        }

        public void End()
        {
            Console.WriteLine("Game End");
        }
    }
}
