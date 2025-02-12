using TeamProject_TextRPG.GameObject;
using TeamProject_TextRPG.InventorySystem;
using TeamProject_TextRPG.SkillSystem.Skills;

namespace TeamProject_TextRPG.Scenes
{
    public class TitleScene : IScene
    {
        public void Awake()
        {
        }

        public void Start()
        {
            Player? player = null;

            Console.WriteLine("이름을 입력해주세요\n");
            Console.Write(">>  ");
            string inputName = Console.ReadLine() ?? string.Empty;

            Console.Clear();
            Console.WriteLine("직업을 선택해주세요\n");
            var selecter = OptionSelecter.Create();

            selecter.AddOption("[1] 전사", "1", () => player = CreateCharacter(1, inputName));
            selecter.AddOption("[2] 도적", "2", () => player = CreateCharacter(2, inputName));
            selecter.AddOption("[3] 힐러", "3", () => player = CreateCharacter(3, inputName));

            selecter.SetExceptionMessage("잘못된 입력입니다.");

            selecter.Display();
            selecter.Select("\n원하시는 직업을 선택해주세요.\n>>  ");

            PlayerManager.Instance.player = player;

            Inventory inven = new Inventory();
            PlayerManager.Instance.inventory = inven;
            SceneManager.Instance.LoadScene("로비 씬");
        }

        public void End()
        {
        }

        private Player? CreateCharacter(int id, string inputName)
        {
            Player? newPlayer = null;

            switch (id)
            {
                case 1:
                    newPlayer = new Player(inputName, "전사", 10, 5, 100, 100,
                        new Skill_BattleCry(), new Skill_BattleAttack());
                    break;
                case 2:
                    newPlayer = new Player(inputName, "도적", 12, 3, 80, 100,
                        new Skill_RaidAttack(), new Skill_QuickMovements());
                    break;
                case 3:
                    newPlayer = new Player(inputName, "힐러", 6, 5, 70, 130,
                        new Skill_ManaEssence(), new Skill_HpEssence());
                    break;
                default: break;
            }

            return newPlayer;
        }
    }
}
