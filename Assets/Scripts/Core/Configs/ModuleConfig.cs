using System.Collections.Generic;
using Core.AssetsSystem;
using UnityEngine;

namespace Core.Configs
{
    [CreateAssetMenu(fileName = "Module_Config", menuName = "Configs/Module Config")]
    public class ModuleConfig : ScriptableObject
    {
        // Serializable fields
        [SerializeField] private List<AssetReferenceById> assetsReferencesById = new();

        //Public properties
        public IReadOnlyList<AssetReferenceById> AssetsReferences => assetsReferencesById;
    }
}
