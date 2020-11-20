using System.IO;
using UnityEditor;
using UnityEngine;

public class CreateAssetBoundles
{
    [MenuItem("Assets/Build AssetBoundles")]
    static void BuildAllAssetBoundles()
    {
        string assetBoundleDirectory = "Assets/Boundles";
        if (!Directory.Exists(Application.streamingAssetsPath))
        {
            Directory.CreateDirectory(assetBoundleDirectory);
        }

        BuildPipeline.BuildAssetBundles(assetBoundleDirectory, BuildAssetBundleOptions.None,
            BuildTarget.StandaloneWindows64);
    }
}