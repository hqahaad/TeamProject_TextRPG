﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject_TextRPG.Item
{
    class Weapon : IItem
    {
        public string Name { get; set; }
        public int Stat { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public bool IsSold { get; set; }
        public bool IsEquip { get; set; }

        public Weapon(string name, int stat, int price, string description)
        {
            this.Name = name;
            this.Stat = stat;
            this.Price = price;
            this.Description = description;
            IsSold = false;
            IsEquip = false;
        }
        public string GetDescription()
        {
            string str = IsEquip ? "[E]" : "";
            str += $"{Name} | Attack: {Stat} | {Description} | Price: {Price}G";
            return str;
        }
        public int GetStat()
        {
            return Stat;
        }


    }
}
