﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject_TextRPG.Item;

namespace TeamProject_TextRPG
{
    public class PlayerManager: Singleton<PlayerManager>
    {
        public Player? player;
        public Inventory? inventory;
    }
}
