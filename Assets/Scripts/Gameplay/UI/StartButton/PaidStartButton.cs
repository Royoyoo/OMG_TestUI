using Core;

namespace Gameplay.UI.StartButton
{
    public class PaidStartButton : BaseStartButton
    {
        protected override void Setup()
        {
            button.interactable = App.PlayerModel.Coins.Value >= App.LevelSelectModuleConfig.CoinsToStartLevel;
        }


        protected override void Click()
        {
            if (App.PlayerModel.Coins.Value < App.LevelSelectModuleConfig.CoinsToStartLevel)
            {
                return;
            }

            App.PlayerModel.ModifyCoins(-App.LevelSelectModuleConfig.CoinsToStartLevel);

            base.Click();
        }
    }
}
