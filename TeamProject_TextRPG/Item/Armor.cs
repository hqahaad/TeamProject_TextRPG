using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject_TextRPG.Item
{
    class Weapon
    {
        public string name { get; set; }
        public int stat { get; set; }
        public int price { get; set; }
        public string description { get; set; }
        public bool isSold { get; set;  }
        public bool isEquip { get; set; }

        public Weapon(string name, int stat, int price, string description)
        {
            this.name = name;
            this.stat = stat;
            this.price = price;
            this.description = description;
            isSold = false;
            isEquip = false;
        }
        public string GetDescription()
        {
            
            str += $"{Name} | Attack: {stat} | {description} | Price: {price}G";
            return str;
        }
        public int GetStat()
        {
            return stat;
        }
    }
}
