using UnityEngine;
using UnityEngine.SceneManagement;
using Project.Infrastructure.GameStates;
using Project.Infrastructure.Services.SceneLoading;

namespace Project.Infrastructure.Root
{
    public class EntryPoint
    {
        private const string COROUTINES_OBJECT_NAME = "COROUTINES";
        private const string UIROOT_PREFAB_PATH = "UIRoot";

        private static EntryPoint _instance;

        private CoroutineRunner _coroutineRunner;
        private UIRoot _uIRoot;
        private Game _game;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Start()
        {
#if UNITY_EDITOR
            string activeSceneName = SceneManager.GetActiveScene().name;

            if (activeSceneName != Scenes.BOOT)
                SceneManager.LoadScene(Scenes.BOOT);
#endif

            _instance = new EntryPoint();
        }

        private EntryPoint()
        {
            Debug.Log("Entry point process...");

            InitializeCoroutineRunner();
            InitializeUIRoot();
            InitializeGame();
        }

        private void InitializeUIRoot()
        {
            UIRoot uiRootPrefab = Resources.Load<UIRoot>(UIROOT_PREFAB_PATH);
            _uIRoot = Object.Instantiate(uiRootPrefab);
            Object.DontDestroyOnLoad(_uIRoot.gameObject);
        }

        private void InitializeCoroutineRunner()
        {
            _coroutineRunner = new GameObject(COROUTINES_OBJECT_NAME).AddComponent<CoroutineRunner>();
            Object.DontDestroyOnLoad(_coroutineRunner.gameObject);
        }

        private void InitializeGame()
        {
            _game = new Game(_coroutineRunner, _uIRoot);
        }
    }
}