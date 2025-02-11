using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject_TextRPG.ModifierSystem
{
    public interface IStatModifierOrder
    {
        int Apply(IEnumerable<StatModifier> mods, int baseValue);
    }

    public class NormalStatModifierOrder : IStatModifierOrder
    {
        public int Apply(IEnumerable<StatModifier> mods, int baseValue)
        {
            foreach (var mod in mods.Where(mod => mod.Strategy is AddOperation))
            {
                baseValue = mod.Strategy.Culculate(baseValue);
            }

            foreach (var mod in mods.Where(mod => mod.Strategy is MultiplyOperation))
            {
                baseValue = mod.Strategy.Culculate(baseValue);
            }

            return baseValue;
        }
    }
}
