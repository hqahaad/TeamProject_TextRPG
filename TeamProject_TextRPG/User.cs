using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject_TextRPG.GameObject;
using TeamProject_TextRPG.InventorySystem;

namespace TeamProject_TextRPG
{
    public class User : Singleton<User>
    {
        private UserDate userDate = new();
        private List<Player> playerList = new();
        private Inventory inventory;

        public Player GetPlayer() => playerList[0];
        public void SetPlayer(Player player)
        {
            playerList.Add(player);
        }

        public void SetInventory(Inventory inventory)
        {
            this.inventory = inventory;
        }

        public Inventory GetInventory()=>inventory;
        
    }
}
