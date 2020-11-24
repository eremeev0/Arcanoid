using System.IO;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class BoundlessLoader
    {
        private AssetBundle _localAssetBundle;
        private static BoundlessLoader _loader;
        private BoundlessLoader(){ }
        public static BoundlessLoader GetLoader(){return _loader ??= new BoundlessLoader();}
        public GameObject GetGameObject(string boundleName, string assetName)
        {
            _localAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.dataPath, "Boundles\\" + boundleName));
            if (_localAssetBundle != null) return _localAssetBundle.LoadAsset<GameObject>(assetName);
            Debug.LogError("Failed to load AssetBoundle");
            return null;
        }
    }
}