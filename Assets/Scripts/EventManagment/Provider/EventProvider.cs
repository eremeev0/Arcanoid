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
    public class EventProvider: MonoBehaviour
    {
        private GameEventProvider _gameProvider;
        private UIEventProvider _uiProvider;
        private EventProvider()
        { }

        
        void Start()
        {
            _gameProvider = new GameEventProvider();
            _uiProvider = new UIEventProvider();
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