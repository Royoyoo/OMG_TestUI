using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI.UIComponents
{
    public class BasePopup : UIElement
    {
        [SerializeField] private Button closeButton;
        [SerializeField] protected TMP_Text popupText;

        private Action closeCallback;


        public virtual void Initialize(string text, Action callback)
        {
            closeCallback = callback;

            if (!string.IsNullOrEmpty(text))
            {
                popupText.text = text;
            }

            closeButton.onClick.AddListener(ProcessClick);
        }


        public virtual void Deinitialize()
        {
            closeButton.onClick.RemoveListener(ProcessClick);
            Hide();
        }


        protected virtual void ProcessClick()
        {
            Deinitialize();
            closeCallback?.Invoke();
        }
    }
}
