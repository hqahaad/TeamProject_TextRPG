using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
            skillDescription = "모든 아군이 공격력 10을 얻습니다";
        }

        public override void SkillAction(Battle battle)
        {
            foreach (var unit in battle.GetUnits(FactionType.Player))
            {


                   ((Player)unit).attackPower += 10;
                    Console.WriteLine($"{((Player)unit).name}의 공격력이 10 증가했습니다!");
                
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
