using Core.AssetsSystem;
using Core.Configs;
using Core.UI;
using Gameplay;
using UnityEngine;

namespace Core
{
    public class App : MonoBehaviour
    {
        [SerializeField] private GlobalConfig globalConfig;


        // TODO Move to DI Container
        public static GlobalConfig GlobalConfig;
        public static LevelSelectModuleConfig LevelSelectModuleConfig;
        public static AssetsManager AssetsManager;
        public static UIManager UIManager;
        public static LevelSelectModel LevelSelectModel;
        public static PlayerModel PlayerModel;


        private readonly AppFlow.AppFlow appFlow = new();


        private void Awake()
        {
            DontDestroyOnLoad(this);
            GlobalConfig = globalConfig;
            LevelSelectModuleConfig = globalConfig.GetConfigOfType<LevelSelectModuleConfig>();

            appFlow.Run();
        }
    }
}
