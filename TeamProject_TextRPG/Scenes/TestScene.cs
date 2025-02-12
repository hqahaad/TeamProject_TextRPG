using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject_TextRPG.GameTables;
using TeamProject_TextRPG.Item;
using TeamProject_TextRPG.ModifierSystem;

namespace TeamProject_TextRPG.Scenes
{
    public class TestScene : IScene
    {
        public void Awake()
        {

        }

        public void End()
        {

        }

        public void Start()
        {
            Stats stat = new Stats();

            var mod = new StatModifier(StatType.Att, new MultiplyOperation(2));

            stat.mediator.AddModifier(new StatModifier(StatType.Att, new AddOperation(12)));
            stat.mediator.AddModifier(new StatModifier(StatType.Att, new AddOperation(12)));
            stat.mediator.AddModifier(new StatModifier(StatType.Att, new AddOperation(12)));
            stat.mediator.AddModifier(mod);
            stat.mediator.AddModifier(new StatModifier(StatType.Att, new AddOperation(12)));
            stat.mediator.AddModifier(new StatModifier(StatType.Att, new AddOperation(12)));

            Console.WriteLine(stat.Attack);

            mod.Dispose();

            Console.WriteLine(stat.Attack);
        }
    }
}
