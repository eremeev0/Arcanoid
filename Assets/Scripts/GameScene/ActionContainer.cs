using System;
using Assets.Scripts.GameScene.Controllers.Sub;
using Assets.Scripts.MultiOriented;
using Assets.Scripts.MultiOriented.Models;
using Assets.Scripts.MultiOriented.StatesManagament.ActionsContainer;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Scripts.GameScene
{
    public class ActionContainer
    {
        private readonly LevelActionsContainer _levelActions;
        private readonly ObjectsManagement _management;
        public ActionContainer()
        {
            _levelActions = new LevelActionsContainer();
            _management = ObjectsManagement.GetManagement();
        }

        public void SpawnObjects(GameObject obj, Vector3[] positions, GameObject copyContainer)
        {
            foreach (var clonePosition in positions)
            {
                var clone = Object.Instantiate(copyContainer, clonePosition, Quaternion.identity);
                clone.name = "Platform";
                clone.transform.parent = copyContainer.transform;
                //clone.AddComponent<GuidComponent>().guid = Guid.NewGuid();
                
               // _management.AddObjectPrimitiveToList(new ObjectPrimitive(clone, clone.GetComponent<GuidComponent>().guid));
            }
        }

        // add is freeze component, add interface
        public void FreezeObject(GameObject obj)
        {
            switch (obj.name)
            {
                case "Player":
                    obj.GetComponent<PlayerController>().enabled = false;
                    break;
                case "Ball":
                    obj.GetComponent<BallController>().enabled = false;
                    break;
                default:
                    break;
            }
        }

        public void UnFreezeObject(GameObject obj)
        {
            switch (obj.name)
            {
                case "Player":
                    obj.GetComponent<PlayerController>().enabled = true;
                    break;
                case "Ball":
                    obj.GetComponent<BallController>().enabled = true;
                    break;
                default:
                    break;
            }
        }

        public LevelN GenerateLevel(LevelN level)
        {
            return _levelActions.GenerateLevel(level);
        }

        public LevelN LevelInit(LevelN level)
        {
            return _levelActions.GenerateLevel(level);
        }

        public void UpdatePlatformsList(LevelN level, Vector3 platformPosition)
        {
            _levelActions.RemovePositionFromList(level, platformPosition);
        }

        public LevelN LoadLevel(string saveName)
        {
            return _levelActions.LoadLevel(saveName);
        }
    }
}