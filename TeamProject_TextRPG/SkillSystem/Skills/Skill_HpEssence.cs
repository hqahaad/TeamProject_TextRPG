using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject_TextRPG.BattleSystem;
using TeamProject_TextRPG.GameObject;

namespace TeamProject_TextRPG.SkillSystem.Skills
{
    public class Skill_HpEssence : Skill
    {
        public Skill_HpEssence()
        {
            skillName = "체력증가";
            skillDescription = "모든 아군이 체력 30을 얻습니다";
        }

        public override void SkillAction(IBattle battle)
        {
            foreach (var unit in battle.GetUnits(FactionType.Player))
            {
                ((Player)unit).Hp += 30;
                Console.WriteLine($"{((Player)unit).Name}의 체력 30을 얻었습니다!");
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
