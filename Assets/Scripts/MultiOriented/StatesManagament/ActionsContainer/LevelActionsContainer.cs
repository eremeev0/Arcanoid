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
            var source = BoundlessLoader.GetLoader().GetGameObject("platform", "Platform");
            
            level.Number++;
            level.BallPosition = _levelHelper.GetInitialBallPosition();
            level.PlayerPosition = _levelHelper.GetInitialPlayerPosition();
            var relPositions = _levelHelper.GetPlatformsRelativePosition(level.Number, source.transform.localPosition);
            var objects = SpawnObjects(source, relPositions);
            var color = _levelHelper.GetPlatformsColor(level.Number);
            foreach (var obj in objects)
            {
                obj.GetComponent<SpriteRenderer>().color = color;
            }
            BoundlessLoader.GetLoader().Dispose();
            return level;
        }
        public GameObject[] SpawnObjects(GameObject obj, Vector3[] positions)
        {
            List<GameObject> clones = new List<GameObject>();
            foreach (var clonePosition in positions)
            {
                var clone = Object.Instantiate(obj, clonePosition, Quaternion.identity);
                clone.name = "Platform";
                clones.Add(clone);
                //clone.transform.parent = copyContainer.transform;
                //clone.AddComponent<GuidComponent>().guid = Guid.NewGuid();

                // _management.AddObjectPrimitiveToList(new ObjectPrimitive(clone, clone.GetComponent<GuidComponent>().guid));
            }

            return clones.ToArray();
        }
    }
}