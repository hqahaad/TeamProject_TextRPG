namespace TeamProject_TextRPG.BattleSystem
{
    public interface IBattle
    {
        List<IUnit>? GetUnits(FactionType faction);
        bool IsAllDead(FactionType faction);
    }

    public class Battle : IBattle
    {
        private readonly SortedDictionary<FactionType, List<IUnit>> unitDict = new();
        private readonly List<IBattleUpdateHandler> updaters = new();
        private BattleState battleState = BattleState.None;

        public Battle()
        {
            AddUpdateHandler(new VictoryPlayer(() => battleState = BattleState.Victory));
            AddUpdateHandler(new DefeatPlayer(() => battleState = BattleState.Defeat));
        }

        public void AddUpdateHandler(IBattleUpdateHandler handler)
        {
            updaters.Add(handler);
        }

        public void AddUnit(IUnit unit, FactionType factionType)
        {
            if (!unitDict.ContainsKey(factionType))
            {
                unitDict.Add(factionType, new());
            }

            unitDict[factionType].Add(unit);
        }

        public void DoBattle()
        {
            battleState = BattleState.Battle;

            if (unitDict.Count < 2)
            {
                battleState = BattleState.None;
                return;
            }

            while (battleState == BattleState.Battle)
            {
                foreach (var iter in unitDict)
                {
                    foreach (var unit in iter.Value)
                    {
                        updaters.ForEach(c => c.Update(this));

                        if (battleState == BattleState.Battle)
                        {
                            if (!unit.IsDead())
                            {
                                unit.DoAction(this);
                                unit.Update();
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
        }

        public bool IsAllDead(FactionType faction)
        {
            if (!unitDict.ContainsKey(faction))
            {
                return true;
            }
            return unitDict[faction].All(u => u.IsDead());
        }

        public List<IUnit>? GetUnits(FactionType faction)
        {
            return unitDict[faction] ?? null;
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
