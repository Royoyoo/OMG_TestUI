using System;
using System.Collections.Generic;
using Gameplay.UI.StartButton;
using UnityEngine;

namespace Gameplay.UI
{
    class StartButtonsGroup : MonoBehaviour
    {
        public event Action OnStartClicked;

        [SerializeField] private List<BaseStartButton> buttons;


        public void Initialize()
        {
            foreach (BaseStartButton button in buttons)
            {
                button.Initialize();
                button.OnClicked += OnButtonClicked;
            }
        }


        public void Deinitialize()
        {
            foreach (BaseStartButton button in buttons)
            {
                button.OnClicked -= OnButtonClicked;
                button.Deinitialize();
            }
        }


        private void OnButtonClicked()
        {
            OnStartClicked?.Invoke();
        }
    }
}
