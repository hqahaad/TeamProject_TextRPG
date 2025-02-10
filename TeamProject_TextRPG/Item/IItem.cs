using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject_TextRPG.Item
{
    public interface IItem
    {
        string GetDescription();
        int GetStat();
    }
}
