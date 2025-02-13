using TeamProject_TextRPG.BattleSystem;
using TeamProject_TextRPG.GameObject;
using TeamProject_TextRPG.GameTables;
using TeamProject_TextRPG.InventorySystem;

namespace TeamProject_TextRPG.Scenes
{
    public class BattleScene : IScene
    {
        public void Awake()
        {

        }

        public void Start()
        {
            EnemySpawner spawner = new EnemySpawner();
            List<Enemy> enemyList = spawner.Spawn(2, 5, Table<Enemy>.Get().Load("미니언"), Table<Enemy>.Get().Load("공허충"), Table<Enemy>.Get().Load("대포미니언"));
            Battle battle = new Battle();

            battle.AddUnit(User.Instance.GetPlayer(), FactionType.Player);

            foreach (var iter in enemyList)
            {
                battle.AddUnit(iter, FactionType.Enemy);
            }

            battle.DoBattle();           

            Console.Clear();

            if (battle.Result() == BattleState.Defeat)
            {
                Console.WriteLine("패배했습니다...");
                Utils.Console.WriteLine("사망", ConsoleColor.Red);
                Console.Clear();
            }
            else
            {
                Utils.Console.WriteLine("Battle! - Result\n", ConsoleColor.DarkYellow);
                Utils.Console.WriteLine("Victory\n", ConsoleColor.Green);
                Console.WriteLine("던전에서 몬스터 {0} 마리를 잡았습니다.", enemyList.Count);
                User.Instance.GetPlayer().DisplayStatus();
                Console.WriteLine("exp 0 → 10\n");
                Utils.Console.WriteLine("[획득 아이템]", ConsoleColor.Yellow);

                Random rand = new Random();
                List<string> randReward = new() { "롱소드", "천갑옷", "빨간포션", "콜라", "사이다" };
                int goldAmount = rand.Next(100, 1000);
                User.Instance.userDate.gold += goldAmount;
                Console.WriteLine("{0} Gold", goldAmount);

                for (int i = 0; i < rand.Next(4, 15); i++)
                {
                    int index = rand.Next(randReward.Count);

                    Item? item = Table<Item>.Get()?.Load(randReward[index]);

                    if (item != null)
                    {
                        User.Instance.GetInventory().AddItem(item);
                    }

                    if (item.ItemType == ItemType.Equipment)
                    {
                        Utils.Console.WriteLine(item.Name, ConsoleColor.Green);
                    }
                    else
                    {
                        Utils.Console.WriteLine(item.Name, ConsoleColor.Magenta);
                    }
                }

                Console.WriteLine();

                var selecter = OptionSelecter.Create();
                selecter.AddOption("0. 다음", "0", () => SceneManager.Instance.LoadScene("로비 씬"));
                selecter.Display();
                selecter.Select("\n>>  ");
            }
        }

        public void End()
        {

        }
    }
}
