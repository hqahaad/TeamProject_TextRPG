using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject_TextRPG.BattleSystem;

namespace TeamProject_TextRPG.SkillSystem
{
    //추상 클래스로 바꾸자
    public abstract class Skill
    {
        protected string skillName = string.Empty;
        protected string skillDescription = string.Empty;
        protected Player? order;

        public bool CastSkill(Battle battle)
        {
            if (!IsCostSkill())
            {
                return false;
            }

            SkillAction(battle);
            UseCost();
            CastEnd();

            return true;
        }

        public void SetOrder(Player unit)
        {
            order = unit;
        }

        public abstract void SkillAction(Battle battle);

        public virtual void CastEnd() { }

        public abstract void UseCost();

        public abstract bool IsCostSkill();

        public string SkillName() => skillName;

        public string SkillDescription() => skillDescription;
    }
}
