using System;

namespace CodeBase.Infrastructure
{
    internal class BootStrapState : IState
    {
        private const string Initial = "Initial";
        private GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;

        public BootStrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            RegisterServices();
            _sceneLoader.Load(Initial, onLoaded: EnterLoadLevel);
        }

        public void Exit()
        {
        }
        private void EnterLoadLevel() => 
        _gameStateMachine.Enter<LoadLevelState, string>("Main");

        private void RegisterServices()
        {

        }


    }
}