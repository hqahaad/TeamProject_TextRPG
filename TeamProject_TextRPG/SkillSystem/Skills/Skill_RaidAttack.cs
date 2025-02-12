using TeamProject_TextRPG.BattleSystem;

namespace TeamProject_TextRPG.SkillSystem.Skills
{
    internal class Skill_RaidAttack : Skill
    {
        public Skill_RaidAttack()
        {
            skillName = "급습";
            skillDescription = "뒤에서 급습합니다";
        }

        public override void SkillAction(IBattle battle)
        {
            order.CastTarget(battle, FactionType.Enemy, (u) => Skill_Attack(u));
        }

        private void Skill_Attack(IUnit unit)
        {
            Console.Clear();
            unit.GetDamage(new Damage(order.Attack * 2));
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
