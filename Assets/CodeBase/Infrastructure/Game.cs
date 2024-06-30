using CodeBase.Logic;

namespace CodeBase.Infrastructure
{
    public class Game
    {
        public GameStateMachine GameStateMachine;
        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain curtain)
        {
            GameStateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), curtain);
        }
    }
}
