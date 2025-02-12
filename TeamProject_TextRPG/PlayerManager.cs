using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject_TextRPG.GameObject;
using TeamProject_TextRPG.InventorySystem;

namespace TeamProject_TextRPG
{
    public class PlayerManager : Singleton<PlayerManager>
    {
        public Player? player = null;
        public Inventory? inventory = null;
        public int dungeonFloor = 1;
    }
}
