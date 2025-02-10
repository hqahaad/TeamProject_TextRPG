namespace TeamProject_TextRPG.GameTables
{
    public static class Table<T> where T : class
    {
        public class TableContainer
        {
            public Dictionary<string, T> Table { get; set; } = new();

            public void Add(string key, T value)
            {
                if (Table.ContainsKey(key))
                {
                    Table.Add(key, value);
                }
            }

            public T? Load(string key)
            {
                return Table[key] ?? null;
            }
        }

        public static Dictionary<Type, TableContainer> tableDict = new();

        public static TableContainer? Get()
        {
            if (!tableDict.TryGetValue(typeof(T), out var value))
            {
                tableDict.Add(typeof(T), new TableContainer());
                return tableDict[typeof(T)];
            }
            else
            {
                return value;
            }
        }
    }
}
