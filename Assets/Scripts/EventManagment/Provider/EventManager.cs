using System;
using Assets.Scripts.Contracts;
using Assets.Scripts.Controllers;
using Assets.Scripts.EventManagment.Events;
using Assets.Scripts.StorageProvider.Service;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.EventManagment.Provider
{
    public class EventManager: MonoBehaviour
    {
        private GameEventManager _gameProvider;
        private UIEventManager _uiProvider;
        private EventManager()
        { }

        
        void Start()
        {
            _gameProvider = new GameEventManager();
            _uiProvider = new UIEventManager();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        public void SendEvent(UIEvents @event)
        {
            _uiProvider.SendEvent(@event);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        public void SendEvent(GameEvents @event)
        {
            _gameProvider.SendEvent(@event);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        /// <param name="value"></param>
        public void SendEvent(GameEvents @event, params string[] value)
        {
            _gameProvider.SendEvent(@event, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        /// <param name="value"></param>
        public void SendEvent(UIEvents @event, params string[] value)
        {
            _uiProvider.SendEvent(@event, value);
        }

    }
}