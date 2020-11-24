using Assets.Scripts.Cross.Models;
using Assets.Scripts.Cross.StatesManagament.ActionsContainer;
using Assets.Scripts.Game.Controllers.Sub;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class ActionContainer
    {
        private LevelActionsContainer _levelActions;

        public ActionContainer()
        {
            _levelActions = new LevelActionsContainer();
        }

        public void SpawnObjects(GameObject obj, Vector3[] positions, GameObject copyContainer)
        {
            GameObject clone;
            foreach (var clonePosition in positions)
            {
                clone = Object.Instantiate(copyContainer, clonePosition, Quaternion.identity);
                clone.name = "Platform";
                clone.transform.parent = copyContainer.transform;
            }
        }

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
                    obj.GetComponent<PlayerController>().enabled = false;
                    break;
                case "Ball":
                    obj.GetComponent<BallController>().enabled = false;
                    break;
                default:
                    break;
            }
        }

        public LevelN GenerateLevel(LevelN level)
        {
            return _levelActions.GenerateLevel(level);
        }

        public LevelN LevelInit()
        {
            return _levelActions.GenerateLevel(new LevelN());
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