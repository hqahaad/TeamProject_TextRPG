namespace TeamProject_TextRPG.BattleSystem
{
    public class Spawner
    {
        public List<Enemy> Spawn(int min, int max, params Enemy[] enemys)
        {
            return RandomSpawn(min, max, enemys.ToList());
        }

        public List<Enemy> Spawn(int min, int max, List<Enemy> enemys)
        {
            return RandomSpawn(min, max, enemys);
        }

        private List<Enemy> RandomSpawn(int min, int max, List<Enemy> enemys)
        {
            List<Enemy> enemyInstances = new List<Enemy>();

            for (int i = 0; i < new Random().Next(min, max); i++)
            {
                int randIndex = new Random().Next(0, enemys.Count);
                enemyInstances.Add(enemys[randIndex].Clone());
            }

            return enemyInstances;
        }
    }
}

