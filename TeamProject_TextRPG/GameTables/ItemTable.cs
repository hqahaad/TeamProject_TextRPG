using TeamProject_TextRPG.InventorySystem;

namespace TeamProject_TextRPG.GameTables
{
    public class WeaponTable
    {
        public WeaponTable()
        {
            Table<Item>.Get()?.Add("나무몽둥이", new Weapon("나무몽둥이", 10, 1, "주위에 굴러다니는 나무 막대기"));
            Table<Item>.Get()?.Add("단검", new Weapon("단검", 3, 10, "모험자에게 주어지는 가장 기본 무기"));
            Table<Item>.Get()?.Add("철퇴", new Weapon("철퇴", 5, 20, "모든 것을 평등하게 만드는 만물의 대화수단"));
            Table<Item>.Get()?.Add("롱소드", new Weapon("롱소드", 6, 25, "적당한 길이의 롱소드 "));
            Table<Item>.Get()?.Add("츠바이핸더", new Weapon("츠바이핸더", 10, 40, "근거리, 중거리 모두 완벽한 무기"));
            Table<Item>.Get()?.Add("서리한", new Weapon("서리한", 30, 80, "서리한이 굶주렸다"));
            Table<Item>.Get()?.Add("대화수단", new Weapon("대화수단", 60, 200, "디스 이스 건"));
        }
    }
        public class ArmorTable
        {
            public ArmorTable()
            {
                Table<Item>.Get()?.Add("소울류 갑옷", new Armor("소울류 갑옷", 1, 1, "고인물들이 입고다닌다는 전설의 갑옷"));
                Table<Item>.Get()?.Add("티셔츠", new Armor("티셔츠", 2, 10, "색상이 다양하다"));
                Table<Item>.Get()?.Add("천갑옷", new Armor("천갑옷", 4, 20, "천을 겹겹이 쌓아서 만든 갑옷"));
                Table<Item>.Get()?.Add("롱패딩", new Armor("롱패딩", 6, 30, "따뜻한 롱패딩. 이상하게도 천갑옷보다 보호를 더 잘한다."));
                Table<Item>.Get()?.Add("가죽갑옷", new Armor("가죽갑옷", 8, 40, "악어가죽으로 만든 Fashionable~"));
                Table<Item>.Get()?.Add("플레이트메일", new Armor("플레이트메일", 10, 50, "철로 만들어진 갑옷"));
                Table<Item>.Get()?.Add("산데비스탄", new Armor("산데비스탄", 20, 100, "I really wanna stay at your house~"));
            }
        }

        public class PotionTable
        {
            public PotionTable()
            {
                Table<Item>.Get()?.Add("콜라", new Potion("콜라", 1, 1, "제로를 마시면 죄책감이 덜든다"));
                Table<Item>.Get()?.Add("사이다", new Potion("사이다", 1, 1, "이것도 제로다"));
                Table<Item>.Get()?.Add("아메리카노", new Potion("아메리카노", 1, 1, "얼.죽.아."));
                Table<Item>.Get()?.Add("카페라떼", new Potion("카페라떼", 2, 2, "우유가 들어가서 회복률이 좀 더 효과가 있다."));
                Table<Item>.Get()?.Add("레드불", new Potion("레드불", 3, 3, "카페인 파워!"));
                Table<Item>.Get()?.Add("빨간포션", new Potion("빨간포션", 10, 10, "여기서 부터는 진짜 회복약이다"));
                Table<Item>.Get()?.Add("보약", new Potion("보약", 20, 20, "무협 게임에서 나올거 같은 보약. 수정과 맛"));
                Table<Item>.Get()?.Add("엘릭시어", new Potion("엘릭시어", 50, 50, "최상급 포션"));
            }
        }
}
