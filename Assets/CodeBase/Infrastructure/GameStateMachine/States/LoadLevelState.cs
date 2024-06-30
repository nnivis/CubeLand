using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    internal class LoadLevelState : IPayloadedState<string>
    {
        private const string HeroPath = "Hero/hero";
        private const string InitialPointTag = "InitialPoint";
        private const string HudPath = "Hud/Hud";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain)
        {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
        }

        public void Enter(string sceneName)
        {
            _loadingCurtain.Show();
            _sceneLoader.Load(sceneName, onLoaded);
        }

        public void Exit() =>
          _loadingCurtain.Hide();

        private void onLoaded()
        {
            //var initialPoint = GameObject.FindWithTag(InitialPointTag);
            //GameObject hero = Instantiate(path: HeroPath, at: initialPoint.transform.position);
            //Instantiate(HudPath);

            _stateMachine.Enter<GameLoopState>();
        }

        private static GameObject Instantiate(string path)
        {
            var heroPrefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(heroPrefab);
        }

        private static GameObject Instantiate(string path, Vector3 at)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, at, Quaternion.identity);
        }

    }
}
