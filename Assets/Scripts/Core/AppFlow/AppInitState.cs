using Core.AssetsSystem;
using Core.BaseFlow;
using Core.UI;
using Gameplay;

namespace Core.AppFlow
{
    public class AppInitState : FlowState
    {
        public override void OnEnter()
        {
            base.OnEnter();

            Setup();
        }


        private void Setup()
        {
            App.AssetsManager = new AssetsManager(App.GlobalConfig);
            App.UIManager = new UIManager(App.AssetsManager);
            
            App.PlayerModel = new PlayerModel(App.LevelSelectModuleConfig);

            RequestTransition(AppFlow.ToLevelSelectTransitionKey);
        }
    }
}
