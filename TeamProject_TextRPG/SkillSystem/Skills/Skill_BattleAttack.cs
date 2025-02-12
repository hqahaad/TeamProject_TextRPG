using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject_TextRPG.BattleSystem;

namespace TeamProject_TextRPG.SkillSystem.Skills
{
    public class Skill_BattleAttack : Skill
    {
        public Skill_BattleAttack()
        {
            skillName = "배틀어택";
            skillDescription = "적 모두에게 피해를 입힌다";
        }


        public override void SkillAction(IBattle battle)
        {
            var enemies = battle.GetUnits(FactionType.Enemy);

            
            foreach (var iter in enemies)
            {
                if (iter.IsDead()) 
                {
                    continue;
                }
                iter.GetDamage(new Damage(order.Attack));

                
            }
            
        }
        public override bool IsCostSkill()
        {
            return order.mp > 20;
        }

        public override void UseCost()
        {
            order.mp -= 20;
        }
    }
}
