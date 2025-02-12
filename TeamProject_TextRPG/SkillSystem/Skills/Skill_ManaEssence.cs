using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject_TextRPG.BattleSystem;
using TeamProject_TextRPG.GameObject;

namespace TeamProject_TextRPG.SkillSystem.Skills
{
    public class Skill_ManaEssence : Skill
    {
        public Skill_ManaEssence()
        {
            skillName = "마나 회복";
            skillDescription = "모든 아군이 마나 30을 얻습니다";
        }

        public override void SkillAction(IBattle battle)
        {
            foreach (var unit in battle.GetUnits(FactionType.Player))
            {
                ((Player)unit).Mp += 30;
                Console.WriteLine($"{((Player)unit).Name}의 마나가 30 증가했습니다!");
            }
        }
        public override bool IsCostSkill()
        {
            return order.Mp > 20;
        }

        public override void UseCost()
        {
            order.Mp -= 20;
        }
    }
}
