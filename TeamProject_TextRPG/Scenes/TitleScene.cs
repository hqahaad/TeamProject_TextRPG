using TeamProject_TextRPG.GameTables;
using TeamProject_TextRPG.Item;
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
            Console.WriteLine("이름을 입력해주세요\n");
            Console.Write(">>  ");
            string inputName = Console.ReadLine() ?? string.Empty;

            Console.Clear();
            Console.WriteLine("직업을 선택해주세요\n");
            var selecter = OptionSelecter.Create();
            selecter.AddOption("1. 전사", "1");
            selecter.AddOption("2. 궁수", "2");
            selecter.AddOption("3. 도적", "3");
            selecter.AddOption("4. 성직자", "4");

            selecter.SetExceptionMessage("잘못된 입력입니다.");

            selecter.Display();
            selecter.Select("\n원하시는 직업을 선택해주세요.\n>>  ");

            Player player = new Player();
            Inventory inven = new Inventory();
            player.name = inputName;
            player.level = 1;
            player.attackPower = 10;
            player.defensivePower = 50;
            player.hp = 150;

            //
            player.AddSkill(new Skill_BattleAttack());
            player.AddSkill(new Skill_BattleCry());
            //

            PlayerManager.Instance.player = player;
            PlayerManager.Instance.inventory = inven;
            SceneManager.Instance.LoadScene("로비 씬");
        }

        public void End()
        {
        }
    }
}
