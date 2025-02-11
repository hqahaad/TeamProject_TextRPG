using TeamProject_TextRPG.BattleSystem;
using TeamProject_TextRPG.GameTables;

namespace TeamProject_TextRPG.Scenes
{
    public class BattleScene : IScene
    {
        public void Awake()
        {
            new EnemyTable();
        }

        public void Start()
        {
            
           
            

            Spawner spawner = new Spawner();
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
                //패배! 게임 종료 로직
            }
            else
            {
                Console.WriteLine("승리했습니다!");
                //승리! 보상 획득 로직
            }
        }

        public void End()
        {

        }
    }

    public class Test : Player
    { }

}
