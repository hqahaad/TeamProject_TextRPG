﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject_TextRPG.BattleSystem;
using TeamProject_TextRPG.GameObject;
using TeamProject_TextRPG.ModifierSystem;

namespace TeamProject_TextRPG.SkillSystem.Skills
{
    public class Skill_QuickMovements : Skill
    {
        public Skill_QuickMovements()
        {
            skillName = "날쌘 몸놀림";
            skillDescription = "모든 아군이 회피율 10% 증가합니다";
        }

        public override void SkillAction(IBattle battle)
        {
            foreach (var units in battle.GetUnits(FactionType.Player))
            {
                var player = units as Player;
                Console.WriteLine(player.Avoid);
                player.mediator.AddModifier(new StatModifier(StatType.Avoid, new MultiplyOperation(1.1f), 2));
                Console.WriteLine(player.Avoid);
                Console.ReadLine();
                Console.WriteLine($"{player.Name}의 회피율 10% 증가했습니다!");

            }
        }

        public override bool IsCostSkill()
        {
            return order.Mp > 10;
        }
        public override void UseCost()
        {
            order.Mp -= 10;
        }
    }
}
