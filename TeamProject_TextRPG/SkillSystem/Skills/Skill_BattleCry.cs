using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject_TextRPG.BattleSystem;

namespace TeamProject_TextRPG.SkillSystem.Skills
{
    public class Skill_BattleCry : Skill
    {
        public Skill_BattleCry()
        {
            skillName = "전투의 함성";
            skillDescription = "모든 적을 공격합니다";
        }

        public override void SkillAction(Battle battle)
        {
            var enemys = battle.GetUnits(FactionType.Enemy);

            foreach (var iter in enemys)
            {
                iter.GetDamage(new Damage(order.attackPower));
            }
        }

        public override bool IsCostSkill()
        {
            return order.mp < 100;
        }

        public override void UseCost()
        {
            order.mp -= 100;
        }
    }
}
