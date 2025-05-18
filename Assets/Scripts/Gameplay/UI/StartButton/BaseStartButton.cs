using System;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UI.StartButton
{
    public abstract class BaseStartButton : MonoBehaviour
    {
        public event Action OnClicked;

        [SerializeField] protected Button button;


        public void Initialize()
        {
            Setup();
            button.onClick.AddListener(Click);
        }


        public void Deinitialize()
        {
            button.onClick.RemoveListener(Click);
        }


        protected abstract void Setup();


        protected virtual void Click()
        {
            InvokeClick();
        }


        private void InvokeClick()
        {
            OnClicked?.Invoke();
        }
    }
}
