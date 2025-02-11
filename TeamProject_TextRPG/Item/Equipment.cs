using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject_TextRPG.Item
{
    public interface Equipment
    {
        string GetName();
        string GetDescription();
        int GetStat();
        bool GetBool();
        ItemType GetItemType();
        void SetEquipped(bool v);
    }
    
}
