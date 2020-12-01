using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.GameScene;
using Assets.Scripts.GameScene.Performances.Services;
using Assets.Scripts.GameScene.Storage;
using Assets.Scripts.MultiOriented.Models;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Scripts.MultiOriented.StatesManagament.ActionsContainer
{
    public class LevelActionsContainer
    {
        private readonly LevelManager _levelManager;
        private readonly LevelHelper _levelHelper;
        private static readonly GameObject source = BoundlessLoader.GetLoader().GetGameObject("platform", "Platform");

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
            level.Platforms = JsonUtility.FromJson<ConcretePlatform[]>(data[1]);
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

        public void RemovePlatform(LevelN level, Guid guid)
        {
            foreach (var platform in level.Platforms)
            {
                if (platform.guid.Equals(guid))
                {
                    Object.Destroy(platform.gameObject);
                    break;
                }
            }
            /*List<Vector3> positionList = new List<Vector3>(level.Platforms);
            positionList.Remove(removedPosition);
            level.Platforms = positionList.ToArray();*/
        }

        public LevelN GenerateLevel(LevelN level)
        {
            level.Number++;
            level.BallPosition = _levelHelper.GetInitialBallPosition();
            level.PlayerPosition = _levelHelper.GetInitialPlayerPosition();
            
            var relPositions = _levelHelper.GetPlatformsRelativePosition(level.Number, source.transform.localPosition);
            
            var objects = SpawnObjects(source, relPositions);
            
            var color = _levelHelper.GetPlatformsColor(level.Number);
            
            level.Platforms = objects.Select(obj => obj.GetComponent<ConcretePlatform>()).ToArray();
            
            foreach (var platform in level.Platforms)
            {
                platform.guid = Guid.NewGuid();
                platform.color = color;
                ObjectsManagement.GetManagement().AddObjectPrimitiveToList(new ObjectPrimitive(platform.gameObject, platform.guid));
            }
            
            BoundlessLoader.GetLoader().Dispose();
            return level;
        }
        public GameObject[] SpawnObjects(GameObject obj, Vector3[] positions)
        {
            var clones = new List<GameObject>();

            foreach (var clonePosition in positions)
            {
                var clone = Object.Instantiate(obj, clonePosition, Quaternion.identity);
                clone.name = "Platform";
                clones.Add(clone);
            }

            return clones.ToArray();
        }
    }
}