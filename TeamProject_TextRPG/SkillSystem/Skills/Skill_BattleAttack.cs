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


        public override void SkillAction(Battle battle)
        {
            var enemies = battle.GetUnits(FactionType.Enemy);

            //if (enemies.Count == 0)
            //{
            //    Console.WriteLine("공격할 적이 없습니다!");
            //    return;
            //}
            foreach (var iter in enemies)
            {
                iter.GetDamage(new Damage(order.attackPower));

                
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
