using System.Collections.Generic;
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

        public LevelActionsContainer()
        {
            _levelManager = new LevelManager();
            _levelHelper = new LevelHelper();
        }

        public LevelN LoadLevel(string saveName)
        {
            var level = new LevelN();
            var data = _levelManager.Load(saveName);
            level.Number = JsonUtility.FromJson<int>(data[0]);
            level.PlatformsColor = JsonUtility.FromJson<Color>(data[1]);
            level.PlayerPosition = JsonUtility.FromJson<Vector3>(data[2]);
            level.BallPosition = JsonUtility.FromJson<Vector3>(data[3]);
            level.PlatformsPosition = JsonUtility.FromJson<Vector3[]>(data[4]);
            return level;
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

        public LevelN GenerateLevel(LevelN level)
        {
            var sourcePosition = BoundlessLoader.GetLoader().GetGameObject("platform", "Platform").transform
                .localPosition;
            level.Number++;
            level.BallPosition = _levelHelper.GetInitialBallPosition();
            level.PlayerPosition = _levelHelper.GetInitialPlayerPosition();
            level.PlatformsColor = _levelHelper.GetPlatformsColor(level.Number);
            level.PlatformsPosition = _levelHelper.GetPlatformsRelativePosition(level.Number, sourcePosition);
            return level;
        }
    }
}