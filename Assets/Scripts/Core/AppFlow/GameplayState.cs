using Core.BaseFlow;
using Gameplay.UI;

namespace Core.AppFlow
{
    class GameplayState : FlowState
    {
        private const string GameplayScreenId = "GameplayScreen";


        private GameplayScreen gameplayScreen;


        public override void OnEnter()
        {
            base.OnEnter();

            gameplayScreen = App.UIManager.GetUiElement<GameplayScreen>(GameplayScreenId);
            gameplayScreen.Show();

            gameplayScreen.OnExit += ToLevelSelect;
        }


        public override void OnExit()
        {
            gameplayScreen.Hide();

            gameplayScreen.OnExit -= ToLevelSelect;

            base.OnExit();
        }


        private void ToLevelSelect()
        {
            RequestTransition(AppFlow.ToLevelSelectTransitionKey);
        }
    }
}
