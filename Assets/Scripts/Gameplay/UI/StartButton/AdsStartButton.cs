using System.Threading.Tasks;
using Core;
using Core.UI.UIComponents;

namespace Gameplay.UI.StartButton
{
    public class AdsStartButton : BaseStartButton
    {
        protected override void Setup()
        {
            button.interactable = true;
        }


        protected override async void Click()
        {
            button.interactable = false;
            BasePopup ad = App.UIManager.RequestPopup("AdsPopup", "Watching Ad");

            await Task.Delay(1000);

            ad.Deinitialize();
            button.interactable = true;

            base.Click();
        }
    }
}
