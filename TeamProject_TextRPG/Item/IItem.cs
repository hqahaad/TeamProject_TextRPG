namespace TeamProject_TextRPG.Item
{
    public interface IItem
    {
        string GetName();
        
        string GetDescription();
        int GetStat();

        bool GetBool();
    }
}
