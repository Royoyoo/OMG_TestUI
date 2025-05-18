using System.Collections.Generic;
using Core;
using Core.Configs;
using UnityEngine;

namespace Gameplay.UI
{
    public class PieceCountSelector : MonoBehaviour
    {
        private const string PieceCountOptionPrefabKey = "PieceCountOption";


        [SerializeField] private Transform buttonsRoot;


        private readonly List<PieceCountOption> optionButtons = new();
        private LevelSelectModel levelSelectModel;


        public void Initialize(LevelSelectModel levelSelectModel, LevelSelectModuleConfig levelSelectModuleConfig)
        {
            this.levelSelectModel = levelSelectModel;

            foreach (int piecesCountOption in levelSelectModuleConfig.PiecesCounts)
            {
                PieceCountOption optionButton = App.AssetsManager.CreateObject<PieceCountOption>(PieceCountOptionPrefabKey, buttonsRoot);
                optionButton.Initialize(piecesCountOption, levelSelectModel);
                optionButton.OnClicked += SelectOption;

                optionButtons.Add(optionButton);
            }

            SelectOption(levelSelectModuleConfig.DefaultPieceCount);
        }


        public void Deinitialize()
        {
            foreach (PieceCountOption optionButton in optionButtons)
            {
                optionButton.Deinitialize();
                Destroy(optionButton.gameObject);
            }

            optionButtons.Clear();
        }


        public void SelectOption(int pieceCount)
        {
            levelSelectModel.SetPiecesCount(pieceCount);
        }
    }
}
