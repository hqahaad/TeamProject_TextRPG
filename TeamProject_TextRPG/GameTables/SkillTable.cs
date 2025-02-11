using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject_TextRPG.SkillSystem;

namespace TeamProject_TextRPG.GameTables
{
    #region 전사 스킬

    //전체 데미지 스킬, 마나를 사용합니다.
    public class Skill_BattleCry : Skill
    { 
        public string Name { get; set; }
        public string Description { get; set; }
    }


    #endregion
}
