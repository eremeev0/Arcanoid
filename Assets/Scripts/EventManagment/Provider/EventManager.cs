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
        private GameEventManager _gameManager;
        private UIEventManager _uiManager;

        void Start()
        {
            _gameManager = new GameEventManager();
            _uiManager = new UIEventManager();
        }

        void Update()
        {

        }

        /// <summary>
        /// Call function by selected Global event
        /// </summary>
        /// <param name="event">Global event</param>
        public void Call(GlobalEvents @event)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        public void SendEvent(UIEvents @event)
        {
            _uiManager.SendEvent(@event);
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        [Obsolete("Procedure SendEvent(GameEvents) is deprecated. Use Call(GlobalEvents) instead.")]
        public void SendEvent(GameEvents @event)
        {
            _gameManager.SendEvent(@event);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        /// <param name="value"></param>
        [Obsolete("Procedure SendEvent(GameEvents, string) is deprecated. Alternative want be done.")]
        public void SendEvent(GameEvents @event, string value)
        {
            _gameManager.SendEvent(@event, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        /// <param name="object"></param>
        [Obsolete("Procedure SendEvent(GameEvents, GameObject, (float, int)[]) is deprecated. Alternative want be done.")]
        public void SendEvent(GameEvents @event, GameObject @object, (float, int)[]pos)
        {
            if (_gameManager == null)
                _gameManager = new GameEventManager();
            _gameManager.SendEvent(@event, @object, pos);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        /// <param name="value"></param>
        public void SendEvent(UIEvents @event, params string[] value)
        {
            _uiManager.SendEvent(@event, value);
        }
    }
}