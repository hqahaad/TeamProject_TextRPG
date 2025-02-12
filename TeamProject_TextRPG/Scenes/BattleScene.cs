using TeamProject_TextRPG.BattleSystem;
using TeamProject_TextRPG.GameObject;
using TeamProject_TextRPG.GameTables;

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
            List<Enemy> enemyList = spawner.Spawn(5, 10, Table<Enemy>.Get().Load("미니언"), Table<Enemy>.Get().Load("공허충"), Table<Enemy>.Get().Load("대포미니언"));
            Battle battle = new Battle();

            battle.AddUnit(PlayerManager.Instance.player, FactionType.Player);

            foreach (var iter in enemyList)
            {
                battle.AddUnit(iter, FactionType.Enemy);               
            }

            battle.DoBattle();

            if (battle.Result() == BattleState.Defeat)
            {
                Console.WriteLine("패배했습니다...");
            }
            else
            {
                Console.WriteLine("승리했습니다!");

                //PlayerManager.Instance.inventory.AddItem()

                SceneManager.Instance.LoadScene("로비 씬");
            }
        }

        public void End()
        {

        }
    }
}
