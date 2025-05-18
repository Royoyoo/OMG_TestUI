using Core.Configs;
using UnityEngine;
using Utils;

namespace Gameplay
{
    public class LevelSelectModel
    {
        public Observable<Texture> Picture { get; } = new(null);
        public Observable<int> PiecesCount { get; } = new(0);


        public LevelSelectModel(LevelSelectModuleConfig levelSelectModuleConfig)
        {
            Picture.Value = levelSelectModuleConfig.DefaultPicture;
            PiecesCount.Value = levelSelectModuleConfig.DefaultPieceCount;
        }


        public void SetPiecesCount(int piecesCount)
        {
            PiecesCount.Value = piecesCount;
        }
    }
}
