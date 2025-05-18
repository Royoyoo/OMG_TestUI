using System;
using Core.UI.UIComponents;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UI
{
    class GameplayScreen : UIElement
    {
        public event Action OnExit;


        [SerializeField] private Button button;


        public override void Show()
        {
            base.Show();

            button.onClick.AddListener(OnClick);
        }


        public override void Hide()
        {
            button.onClick.RemoveListener(OnClick);

            base.Hide();
        }


        private void OnClick()
        {
            OnExit?.Invoke();
        }
    }
}
