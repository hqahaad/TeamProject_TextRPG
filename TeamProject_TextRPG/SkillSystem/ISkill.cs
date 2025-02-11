using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject_TextRPG.BattleSystem;

namespace TeamProject_TextRPG.SkillSystem
{
    public interface ISkill
    {
        string SkillName();
        string SkillDescription();
        bool CastSkill(Battle battle);
        void CastEnd();
        void SetOrder(Player unit);
    }
}
