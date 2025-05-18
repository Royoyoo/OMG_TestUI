namespace Core.AppFlow
{
    public class AppFlow : BaseFlow.BaseFlow
    {
        // Constants
        public const string ToLevelSelectTransitionKey = "ToLevelSelect";
        public const string ToGameplayTransitionKey = "ToGameplay";



        #region Object lifecycle

        public AppFlow()
        {
            Build();
        }

        #endregion



        #region Private Methods

        private void Build()
        {
            AppInitState appInitState = CreateState<AppInitState>();
            LevelSelectState levelSelectState = CreateState<LevelSelectState>();
            GameplayState gameplayState = CreateState<GameplayState>();

            appInitState.AddTransition(ToLevelSelectTransitionKey, levelSelectState);
            levelSelectState.AddTransition(ToGameplayTransitionKey, gameplayState);
            gameplayState.AddTransition(ToLevelSelectTransitionKey, levelSelectState);

            SetEntryState(appInitState);
        }

        #endregion
    }
}
