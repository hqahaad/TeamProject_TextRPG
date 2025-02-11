using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject_TextRPG.GameTables;
using TeamProject_TextRPG.Item;

namespace TeamProject_TextRPG.Scenes
{
    internal class TestScene : IScene
    {
        Inventory inven = new();

        public void Awake()
        {
            new WeaponTable();
            new ArmorTable();
            new PotionTable();
        }

        public void End()
        {

        }

        public void Start()
        {
            inven.AddItem(Table<Weapon>.Get().Load("나무몽둥이"), 1);
            inven.AddItem(Table<Weapon>.Get().Load("나무몽둥이"), 1);
            inven.AddItem(Table<Potion>.Get().Load("콜라"), 1);
            inven.AddItem(Table<Potion>.Get().Load("콜라"), 1);
            inven.AddItem(Table<Potion>.Get().Load("콜라"), 1);
            inven.AddItem(Table<Potion>.Get().Load("사이다"), 1);
            foreach (var item in inven.Inven)
            {
                Console.WriteLine($"{item.Item.GetName()} {item.Count}");
            }
        }
    }
}
