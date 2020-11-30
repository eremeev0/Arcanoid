using System.Collections.Generic;
using Assets.Scripts.GameScene;
using Assets.Scripts.GameScene.Performances.Services;
using Assets.Scripts.GameScene.Storage;
using Assets.Scripts.MultiOriented.Models;
using UnityEngine;

namespace Assets.Scripts.MultiOriented.StatesManagament.ActionsContainer
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
            level.Platforms = JsonUtility.FromJson<PlatformService[]>(data[1]);
            level.Player = JsonUtility.FromJson<PlayerService>(data[2]);
            level.Ball = JsonUtility.FromJson<BallService>(data[3]);
            return level;
        }

        public void SaveLevel(LevelN level, string saveName)
        {
            _levelManager.Save(saveName,
                JsonUtility.ToJson(level.Number),
                JsonUtility.ToJson(level.Platforms),
                JsonUtility.ToJson(level.Player),
                JsonUtility.ToJson(level.Ball)
                );
        }

        public void RemovePositionFromList(LevelN level, Vector3 removedPosition)
        {

            /*List<Vector3> positionList = new List<Vector3>(level.Platforms);
            positionList.Remove(removedPosition);
            level.Platforms = positionList.ToArray();*/
        }

        public LevelN GenerateLevel(LevelN level)
        {
            var sourcePosition = BoundlessLoader.GetLoader().GetGameObject("platform", "Platform").transform
                .localPosition;
            level.Number++;
            /*level.BallPosition = _levelHelper.GetInitialBallPosition();
            level.PlayerPosition = _levelHelper.GetInitialPlayerPosition();
            level.PlatformsColor = _levelHelper.GetPlatformsColor(level.Number);
            level.PlatformsPosition = _levelHelper.GetPlatformsRelativePosition(level.Number, sourcePosition);
            */
            return level;
        }
    }
}