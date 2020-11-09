using System;
using System.ComponentModel;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts
{
    public class EventManager: MonoBehaviour
    {
        [SerializeField] private readonly UIController _uiController;
        [SerializeField] private readonly BallController _ballController;

        public EventManager([NotNull] BallController ballController, [NotNull] UIController uiController)
        {
            _ballController = ballController ?? throw new ArgumentNullException(nameof(ballController));
            _uiController = uiController ?? throw new ArgumentNullException(nameof(uiController));
        }

        public void SetEvent(GameEvents @event)
        {
            if (!Enum.IsDefined(typeof(GameEvents), @event))
                throw new InvalidEnumArgumentException(nameof(@event), (int) @event, typeof(GameEvents));
            
            switch (@event)
            {
                case GameEvents.GAME_STARTED:

                    break;
                case GameEvents.GAME_EXITED:

                    break;
                case GameEvents.GAME_RESTARTED:

                    break;
                case GameEvents.LEVEL_FAILED:
                    
                    break;
                case GameEvents.GAME_BACK_TO_MENU:
                    _uiController.ShowMenu();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(@event), @event, null);
            }
        }

        public void SetEvent(GameEvents @event, float value)
        {
            if (!Enum.IsDefined(typeof(GameEvents), @event))
                throw new InvalidEnumArgumentException(nameof(@event), (int) @event, typeof(GameEvents));
            
            switch (@event)
            {
                case GameEvents.POINTS_UPDATED:
                    _uiController.SetPoints(value);
                    break;
                case GameEvents.SPEED_UPDATED:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(@event), @event, null);
            }
        }


        void Start()
        {

        }

        void Update()
        {

        }
    }
}