using System.Collections.Generic;
using System.IO;
using Assets.Scripts.Cross.Models;
using Assets.Scripts.Game;
using Assets.Scripts.Game.Storage;
using UnityEngine;

namespace Assets.Scripts.Cross.StatesManagament.ActionsContainer
{
    public class LevelActionsContainer
    {
        private readonly LevelManager _levelManager;
        private readonly LevelHelper _levelHelper;

        private const string _boundleName = "Boundles\\platform";
        private const string _assetName = "Platform";

        private AssetBundle _localAssetBundle;
        
        public LevelActionsContainer()
        {
            _levelManager = new LevelManager();
            _levelHelper = new LevelHelper();
        }

        public void LoadLevel(LevelN level, string saveName)
        {
            GenerateLevel(level);
            var data = _levelManager.Load(saveName);
            level.Number = JsonUtility.FromJson<int>(data[0]);
            level.PlatformsColor = JsonUtility.FromJson<Color>(data[1]);
            level.PlayerPosition = JsonUtility.FromJson<Vector3>(data[2]);
            level.BallPosition = JsonUtility.FromJson<Vector3>(data[3]);
            level.PlatformsPosition = JsonUtility.FromJson<Vector3[]>(data[4]);
        }

        public void SaveLevel(LevelN level, string saveName)
        {
            _levelManager.Save(saveName,
                JsonUtility.ToJson(level.Number),
                JsonUtility.ToJson(level.PlatformsColor),
                JsonUtility.ToJson(level.PlayerPosition),
                JsonUtility.ToJson(level.BallPosition),
                JsonUtility.ToJson(level.PlatformsPosition)
                );
        }

        public void RemovePositionFromList(LevelN level, Vector3 removedPosition)
        {
            List<Vector3> positionList = new List<Vector3>(level.PlatformsPosition);
            positionList.Remove(removedPosition);
            level.PlatformsPosition = positionList.ToArray();
        }

        public void GenerateLevel(LevelN level)
        {
            _localAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.dataPath, _boundleName));
            if (_localAssetBundle == null)
            {
                Debug.LogError("Failed to load AssetBoundle");
                return;
            }
            level.Number++;
            var Platform = _localAssetBundle.LoadAsset<GameObject>(_assetName);
            level.BallPosition = _levelHelper.GetInitialBallPosition();
            level.PlayerPosition = _levelHelper.GetInitialPlayerPosition();
            level.PlatformsColor = _levelHelper.GetPlatformsColor(level.Number);
            level.PlatformsPosition = _levelHelper.GetPlatformsRelativePosition(level.Number, Platform.transform.localPosition);
        }
    }
}