namespace TeamProject_TextRPG.GameTables
{
    public class EnemyTable
    {
        public EnemyTable()
        {
            Table<Enemy>.Get()?.Add("미니언", new Enemy("미니언", 2, 15, 5, 0));
            Table<Enemy>.Get()?.Add("공허충", new Enemy("공허충", 3, 10, 9, 0));
            Table<Enemy>.Get()?.Add("대포미니언", new Enemy("대포미니언", 5, 25, 8, 0));
            Table<Enemy>.Get()?.Add("슬라임", new Enemy("슬라임", 7, 30, 9, 0));
            Table<Enemy>.Get()?.Add("걷는 버섯", new Enemy("걷는 버섯", 9, 35, 11, 0));
            Table<Enemy>.Get()?.Add("도적", new Enemy("도적", 10, 35, 17, 0));
            Table<Enemy>.Get()?.Add("땅거미", new Enemy("땅거미", 12, 40, 20, 0));
            Table<Enemy>.Get()?.Add("거대전갈", new Enemy("거대전갈", 30, 50, 40, 0));
            Table<Enemy>.Get()?.Add("바하무트", new Enemy("바하무트", 50, 80, 60, 0));
            Table<Enemy>.Get()?.Add("지나가던 개발자", new Enemy("지나가던 개발자", 90, 100, 80, 5));
        }
    }
}
