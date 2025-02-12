using TeamProject_TextRPG.BattleSystem;
using TeamProject_TextRPG.GameObject;
using TeamProject_TextRPG.ModifierSystem;

namespace TeamProject_TextRPG.SkillSystem.Skills
{
    public class Skill_BattleCry : Skill
    {
        public Skill_BattleCry()
        {
            skillName = "전투의 함성";
            skillDescription = "모든 아군이 공격력 10을 얻습니다";
        }

        public override void SkillAction(IBattle battle)
        {
            foreach (var unit in battle.GetUnits(FactionType.Player))
            {
                var player = unit as Player;
                player.mediator.AddModifier(new StatModifier(StatType.Attack, new AddOperation(10),2));
                Console.WriteLine($"{player.name}의 공격력이 10 증가했습니다!");

            }
        }

        public override bool IsCostSkill()
        {
            return order.mp > 10;
        }

        public override void UseCost()
        {
            order.mp -= 10;
        }
    }
}
