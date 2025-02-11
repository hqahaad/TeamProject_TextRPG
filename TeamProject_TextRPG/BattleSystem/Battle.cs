namespace TeamProject_TextRPG.BattleSystem
{
    public interface IBattle
    {
        List<IUnit>? GetUnits(FactionType faction);
        bool IsAllDead(FactionType faction);
    }

    public class Battle : IBattle
    {
        private readonly SortedDictionary<FactionType, List<IUnit>> factionDict = new();
        private readonly List<IBattleCondition> conditions = new();
        private BattleState battleState = BattleState.None;
        public int TurnCount { get; } = 0;

        public Battle()
        {
            conditions.Add(new VictoryPlayer(() => battleState = BattleState.Victory));
            conditions.Add(new DefeatPlayer(() => battleState = BattleState.Defeat));
        }

        public void AddUnit(IUnit unit, FactionType factionType)
        {
            if (!factionDict.ContainsKey(factionType))
            {
                factionDict.Add(factionType, new());
            }

            factionDict[factionType].Add(unit);
        }

        public void DoBattle()
        {
            if (factionDict.Count < 2)
            {
                battleState = BattleState.None;
                return;
            }

            battleState = BattleState.Battle;

            foreach (var iter in factionDict)
            {
                foreach (var unit in iter.Value)
                {
                    conditions.ForEach(c => c.Update(this));

                    if (battleState == BattleState.Battle)
                    {
                        if (!unit.IsDead())
                        {
                            unit.DoAction(this);
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        public bool IsAllDead(FactionType faction)
        {
            if (!factionDict.ContainsKey(faction))
            {
                return true;
            }
            return factionDict[faction].All(u => u.IsDead());
        }

        public List<IUnit>? GetUnits(FactionType faction)
        {
            return factionDict[faction] ?? null;
        }

        public BattleState Result()
        {
            return battleState;
        }
    }

    public enum BattleState
    {
        None,
        Battle,
        Victory,
        Defeat
    }

    public enum FactionType
    {
        Player,
        Enemy
    }
}
