using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UI
{
    public class PieceCountOption : MonoBehaviour
    {
        public event Action<int> OnClicked;

        [SerializeField] private TMP_Text text;
        [SerializeField] private Button button;


        private int thisPieceCount;
        private LevelSelectModel levelSelectModel;


        public void Initialize(int piecesCount, LevelSelectModel levelSelectModel)
        {
            thisPieceCount = piecesCount;
            this.levelSelectModel = levelSelectModel;

            levelSelectModel.PiecesCount.OnValueChanged += UpdateState;

            text.text = piecesCount.ToString();
            button.interactable = thisPieceCount != levelSelectModel.PiecesCount.Value;
            
            button.onClick.AddListener(Click);
        }


        public void Deinitialize()
        {
            levelSelectModel.PiecesCount.OnValueChanged -= UpdateState;
            button.onClick.RemoveListener(Click);
        }


        private void Click()
        {
            OnClicked?.Invoke(thisPieceCount);
        }


        private void UpdateState(int currentPieceCount)
        {
            button.interactable = currentPieceCount != thisPieceCount;
        }
    }
}
