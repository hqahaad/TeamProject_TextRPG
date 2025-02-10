namespace TeamProject_TextRPG
{
    public class Singleton<T> where T : class, new()
    {
        private static T? instance = null;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new T();
                    return instance;
                }

                return instance;
            }
        }

        protected Singleton() { }
    }
}
