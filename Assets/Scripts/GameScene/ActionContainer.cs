using Assets.Scripts.GameScene.Controllers.Sub;
using Assets.Scripts.MultiOriented;
using Assets.Scripts.MultiOriented.Models;
using Assets.Scripts.MultiOriented.StatesManagament.ActionsContainer;
using UnityEngine;

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

        public void SetParent(LevelN level, GameObject parent)
        {
            foreach (var platform in level.Platforms)
            {
                platform.transform.parent = parent.transform;
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