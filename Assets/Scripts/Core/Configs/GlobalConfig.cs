using System.Collections.Generic;
using UnityEngine;

namespace Core.Configs
{
    [CreateAssetMenu(fileName = "Global_Config", menuName = "Configs/Global Config")]
    public class GlobalConfig : ScriptableObject
    {
        [SerializeField] private List<ModuleConfig> moduleConfigs;
        public List<ModuleConfig> ModuleConfigs => moduleConfigs;


        public T GetConfigOfType<T>() where T : ModuleConfig
        {
            return moduleConfigs.Find(config => config is T) as T;
        }
    }
}
