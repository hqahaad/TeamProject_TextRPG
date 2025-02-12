using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TeamProject_TextRPG.ModifierSystem
{
    public class StatMediator
    {
        private readonly List<StatModifier> modifierList = new();
        private readonly Dictionary<StatType, IEnumerable<StatModifier>> modifiersCache = new();
        private readonly IStatModifierOrder order = new NormalStatModifierOrder();

        public void PerformQuery(object sender, Query query)
        {
            if (!modifiersCache.ContainsKey(query.StatType))
            {
                modifiersCache[query.StatType] = modifierList.Where(mod => mod.Type == query.StatType).ToList();
            }
            query.Value = order.Apply(modifiersCache[query.StatType], query.Value);
        }

        private void InvalidateCache(StatType statType)
        {
            modifiersCache.Remove(statType);
        }

        public void AddModifier(StatModifier modifier)
        {
            modifierList.Add(modifier);
            modifiersCache.Remove(modifier.Type);
            modifier.MarkedForRemoval = false;

            modifier.OnDispose += _ => InvalidateCache(modifier.Type);
            modifier.OnDispose += _ => modifierList.Remove(modifier);
        }

        public void Update()
        {
            modifierList.ForEach(m => m.Update());

            foreach (var mod in modifierList.Where(mod => mod.MarkedForRemoval).ToList())
            {
                mod.Dispose();
            }
        }
    }

    public class Query
    {
        public readonly StatType StatType;
        public int Value;

        public Query(StatType statType, int value)
        {
            StatType = statType;
            Value = value;
        }
    }
}
