namespace TeamProject_TextRPG.Scenes
{
    public sealed class SceneManager : Singleton<SceneManager>
    {
        private Dictionary<string, IScene> scenes = new Dictionary<string, IScene>();
        private IScene? currentScene = null;

        public void AddScene(string sceneName, IScene scene)
        {
            if (!scenes.TryGetValue(sceneName, out var value))
            {
                scenes.Add(sceneName, scene);
            }
        }

        public bool LoadScene(string sceneName)
        {
            if (currentScene == null)
            {
                if (scenes.TryGetValue(sceneName, out var value))
                {
                    currentScene = value;
                    currentScene.Awake();
                    currentScene.Start();

                    return true;
                }
            }
            else
            {
                if (scenes.TryGetValue(sceneName, out var value))
                {
                    currentScene.End();
                    currentScene = value;
                    currentScene.Awake();
                    currentScene.Start();

                    return true;
                }
            }

            return false;
        }
    }
}
