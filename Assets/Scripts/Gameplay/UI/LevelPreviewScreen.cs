using System;
using Core.Configs;
using Core.UI.UIComponents;
using UnityEngine;

namespace Gameplay.UI
{
    public class LevelPreviewScreen : UIElement
    {
        public event Action OnStartClicked;


        [SerializeField] private PicturePreview picturePreview;
        [SerializeField] private PieceCountSelector pieceCountSelector;
        [SerializeField] private StartButtonsGroup startButtonsGroup;


        private LevelSelectModuleConfig config;
        private LevelSelectModel levelSelectModel;


        public void SetDependencies(LevelSelectModel levelSelectModel, LevelSelectModuleConfig levelSelectModuleConfig)
        {
            this.levelSelectModel = levelSelectModel;
            config = levelSelectModuleConfig;
        }


        public override void Show()
        {
            base.Show();

            picturePreview.Initialize(levelSelectModel.Picture.Value);
            pieceCountSelector.Initialize(levelSelectModel, config);
            startButtonsGroup.Initialize();

            startButtonsGroup.OnStartClicked += StartGame;
        }


        public override void Hide()
        {
            base.Hide();

            pieceCountSelector.Deinitialize();
            startButtonsGroup.Deinitialize();

            startButtonsGroup.OnStartClicked -= StartGame;
        }


        private void StartGame()
        {
            OnStartClicked?.Invoke();
        }
    }
}
