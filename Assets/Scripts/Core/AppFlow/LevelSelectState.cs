using Core.BaseFlow;
using Gameplay;
using Gameplay.UI;

namespace Core.AppFlow
{
    public class LevelSelectState : FlowState
    {
        private const string LevelPreviewScreenId = "LevelPreviewScreen";


        private LevelPreviewScreen levelPreviewScreen;


        public override void OnEnter()
        {
            base.OnEnter();

            App.LevelSelectModel = new LevelSelectModel(App.LevelSelectModuleConfig);

            levelPreviewScreen = App.UIManager.GetUiElement<LevelPreviewScreen>(LevelPreviewScreenId);
            levelPreviewScreen.SetDependencies(App.LevelSelectModel, App.LevelSelectModuleConfig);
            levelPreviewScreen.Show();

            levelPreviewScreen.OnStartClicked += ToGameplay;
        }


        public override void OnExit()
        {
            levelPreviewScreen.Hide();

            levelPreviewScreen.OnStartClicked -= ToGameplay;

            base.OnExit();
        }


        private void ToGameplay()
        {
            RequestTransition(AppFlow.ToGameplayTransitionKey);
        }
    }
}
