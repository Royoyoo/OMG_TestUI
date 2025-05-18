using System;
using System.Collections.Generic;
using Core.AssetsSystem;
using Core.UI.UIComponents;
using UnityEngine;
using BasePopup = Core.UI.UIComponents.BasePopup;

namespace Core.UI
{
    public class UIManager
    {
        private const string uiLayerTopCanvasPath = "/App/UI/Canvas/";


        private readonly AssetsManager assetsManager;

        private Transform uiElementsRoot;
        private RectTransform uiCanvasRectTransform;
        private Dictionary<string, UIElement> elements = new();


        public UIManager(AssetsManager assetsManager)
        {
            this.assetsManager = assetsManager;

            uiElementsRoot = GameObject.Find(uiLayerTopCanvasPath).transform;
            uiCanvasRectTransform = uiElementsRoot.GetComponent<RectTransform>();
        }


        public T GetUiElement<T>(string id, Transform root = null) where T : UIElement
        {
            if (elements.ContainsKey(id) == false)
            {
                T uiElement = assetsManager.CreateObject<T>(id, root ? root : uiElementsRoot);
                SortElementsBySortOrder(uiElement);
                elements.Add(id, uiElement);
            }

            return (T) elements[id];
        }


        public BasePopup RequestPopup(string id, string popupText = null, Action callback = null)
        {
            BasePopup popup = GetUiElement<BasePopup>(id);

            popup.Initialize(popupText, callback);
            popup.Show();

            return popup;
        }


        private void SortElementsBySortOrder(UIElement uiElement)
        {
            for (int i = uiCanvasRectTransform.childCount - 2; i >= 0; i--)
            {
                UIElement childUiElement = uiCanvasRectTransform.GetChild(i).GetComponent<UIElement>();

                if (childUiElement != null && uiElement.SortOrder >= childUiElement.SortOrder)
                {
                    uiElement.transform.SetSiblingIndex(i + 1);

                    return;
                }
            }

            uiElement.transform.SetAsFirstSibling();
        }
    }
}
