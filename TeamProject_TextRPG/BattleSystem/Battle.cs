namespace TeamProject_TextRPG.BattleSystem
{
    public class Faction
    {
        public List<IUnit> UnitList { get; } = new();

        public void AddUnit(IUnit unit)
        {
            if (!UnitList.Contains(unit))
            {
                UnitList.Add(unit);
            }
        }

        public bool IsAllDead()
        {
            return UnitList.All(u => u.IsDead());
        }
    }

    public class Battle
    {
        private SortedDictionary<FactionType, Faction> factionDict = new();
        private BattleState battleState = BattleState.None;
        public int TurnCount { get; } = 0;

        public void AddUnit(IUnit unit, FactionType factionType)
        {
            if (!factionDict.ContainsKey(factionType))
            {
                factionDict.Add(factionType, new());
            }

            factionDict[factionType].AddUnit(unit);
        }

        public void DoBattle()
        {
            if (factionDict.Count < 2)
            {
                battleState = BattleState.None;
                return;
            }

            battleState = BattleState.Battle;

            while (battleState == BattleState.Battle)
            {
                foreach (var iter in factionDict)
                {
                    if (iter.Value.IsAllDead())
                    {
                        //진영이 추가된다면 수정필요
                        battleState = (iter.Key == FactionType.Player) ? BattleState.Defeat : BattleState.Victory;
                        break;
                    }

                    foreach (var unit in iter.Value.UnitList)
                    {
                        //개별 유닛 턴 시작
                        if (!unit.IsDead())
                        {
                            unit.DoAction(this);
                        }
                    }
                }
            }
        }

        public Faction GetFaction(FactionType faction)
        {
            return factionDict[faction];
        }

        public List<IUnit>? GetUnits(FactionType faction)
        {
            return factionDict[faction].UnitList ?? null;
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
