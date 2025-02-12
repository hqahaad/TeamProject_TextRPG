namespace TeamProject_TextRPG.BattleSystem
{
    public interface IUnit
    {
        void DoAction(IBattle battle);
        void GetDamage(Damage damage);
        void DisplayStatus();
        void Update();
        bool IsDead();
    }
       
}
