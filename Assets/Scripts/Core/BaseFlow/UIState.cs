using System;
using System.Collections.Generic;
using Core.UI.UIComponents;

namespace Core.BaseFlow
{
    [Serializable]
    public class UIState : FlowState
    {
        protected List<UIElement> uiElements = new();


        protected void OpenPanels()
        {
            foreach (UIElement uiElement in uiElements)
            {
                uiElement.Show();
            }
        }


        protected void ClosePanels()
        {
            foreach (UIElement uiElement in uiElements)
            {
                uiElement.Hide();
            }
        }
    }
}
