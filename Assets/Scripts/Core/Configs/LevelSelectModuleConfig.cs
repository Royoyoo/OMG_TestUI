using System.Collections.Generic;
using UnityEngine;

namespace Core.Configs
{
    [CreateAssetMenu(fileName = "LevelSelect_Module_Config", menuName = "Configs/LevelSelect Module Config")]
    public class LevelSelectModuleConfig : ModuleConfig
    {
        [SerializeField] private Texture defaultPicture;
        [SerializeField] private List<int> piecesCounts;
        [SerializeField] private int defaultPieceCount;
        [SerializeField] private int startCoins;
        [SerializeField] private int coinsToStartLevel;


        public Texture DefaultPicture => defaultPicture;
        public List<int> PiecesCounts => piecesCounts;
        public int DefaultPieceCount => defaultPieceCount;
        public int StartCoins => startCoins;
        public int CoinsToStartLevel => coinsToStartLevel;
    }
}
