using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject_TextRPG.GameTables
{
    public class DungeonTable
    {
        public DungeonTable()
        {
            var dive = new DungeonDate();
            dive.AddEnemy("미니언", "공허충", "대포미니언");
            Table<DungeonDate>.Get()?.Add("1층", dive);
            dive.amount = 3;

            dive = new DungeonDate();
            dive.AddEnemy("미니언", "공허충", "대포미니언");
            dive.AddReward("단검", "소울류 갑옷");
            dive.amount = 4;
            Table<DungeonDate>.Get()?.Add("2층", dive);

            dive = new DungeonDate();
            dive.AddEnemy("슬라임", "걷는 버섯", "대포미니언");
            dive.AddReward("카페라떼");
            dive.amount = 4;
            Table<DungeonDate>.Get()?.Add("3층", dive);

            dive = new DungeonDate();
            dive.AddEnemy("걷는 버섯", "도적", "슬라임");
            dive.amount = 5;
            dive.AddReward("철퇴", "티셔츠");
            Table<DungeonDate>.Get()?.Add("4층", dive);

            dive = new DungeonDate();
            dive.AddEnemy("걷는 버섯", "도적", "땅거미");
            dive.AddReward("롱소드", "레드불");
            dive.amount = 5;
            Table<DungeonDate>.Get()?.Add("5층", dive);
        }
    }
}
