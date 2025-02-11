using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject_TextRPG.BattleSystem;

namespace TeamProject_TextRPG.SkillSystem
{
    //추상 클래스로 바꾸자
    public class Skill : ISkill
    {
        protected string? skillName;
        protected string? skillDescription;
        protected int baseDamage;
        protected int cost;
        protected Player? order;

        public virtual bool CastSkill(Battle battle)
        {
            if (!IsCostSkill())
            {
                return false;
            }

            SkillAction(battle);
            CastEnd();

            return true;
        }

        public virtual void SkillAction(Battle battle) { }

        public void CastEnd()
        {
            UseCost();
        }

        //오버라이드 해서 재정의필요
        public virtual void UseCost()
        {
            order.mp -= cost;
        }

        //오버라이드 해서 재정의필요
        public virtual bool IsCostSkill()
        {
            return order?.mp >= cost;
        }

        public void SetOrder(Player unit) 
        {
            order = unit;
        }

        public string SkillName() => "전투의 함성";

        public string SkillDescription() => skillDescription ?? string.Empty;
    }
}
