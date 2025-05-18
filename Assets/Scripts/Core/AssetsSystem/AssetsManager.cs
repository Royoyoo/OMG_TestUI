using System;
using System.Collections.Generic;
using Core.Configs;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Object = UnityEngine.Object;

namespace Core.AssetsSystem
{
    public class AssetsManager
    {
        private readonly Dictionary<string, AssetReference> availableAssets = new();

        private GlobalConfig globalConfig;


        public AssetsManager(GlobalConfig globalConfig)
        {
            this.globalConfig = globalConfig;

            LoadAssetsInfo();
        }


        public T GetAsset<T>(string id) where T : UnityEngine.Object
        {
            AssetReference assetReference = availableAssets.GetValueOrDefault(id);

            if (assetReference != null)
            {
                return GetAssetFromReference<T>(assetReference, id);
            }

            throw new Exception($"Asset with id '{id}' doesn't found");
        }


        public T GetAssetFromReference<T>(AssetReference assetReference, string id = "") where T : UnityEngine.Object
        {
            if (typeof(T).IsSubclassOf(typeof(Behaviour)))
            {
                GameObject assetGameObject = assetReference.Asset == null ?
                    assetReference.LoadAssetAsync<GameObject>().WaitForCompletion() :
                    (GameObject) assetReference.Asset;

                T component = assetGameObject.GetComponent<T>();

                if (component == null)
                {
                    throw new Exception($"Asset with id '{id}' exists, but component of type '{nameof(T)}' is missing.");
                }

                return component;
            }
            else
            {
                return assetReference.Asset == null ?
                    assetReference.LoadAssetAsync<T>().WaitForCompletion() :
                    (T) assetReference.Asset;
            }
        }


        public T CreateObject<T>(string id, Transform parent = null) where T : UnityEngine.Component
        {
            T assetPrefab = GetAsset<T>(id);

            return Object.Instantiate(assetPrefab, parent);
        }


        private void LoadAssetsInfo()
        {
            foreach (ModuleConfig moduleConfig in globalConfig.ModuleConfigs)
            {
                if (moduleConfig.AssetsReferences != null)
                {
                    foreach (AssetReferenceById referenceById in moduleConfig.AssetsReferences)
                    {
                        availableAssets.Add(referenceById.Id, referenceById.AssetReference);
                    }
                }
            }
        }
    }
}
