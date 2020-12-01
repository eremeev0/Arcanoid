using System;
using Assets.Scripts.MultiOriented;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.GameScene.Performances.Services
{
    public class PlatformService: MonoBehaviour
    {
        /*public Guid PlatformGuid;// { get; private set;}
        public Vector3 PlatformPosition;// { get; private set; }
        public Color PlatformColor;// { get; private set; }
        public int HitsToDeath;// { get; private set; }
        */
        //private static PlatformService _platformService;
       
        private UnityAction<Guid> _getPlatformPosition;
        private UnityAction _isAllPlatformsDestroyed;
        private ObjectsManagement _objectsManagement;
        private ParticleManager _particles;

        //Unity Start Message
        private void Start()
        {
            _objectsManagement = ObjectsManagement.GetManagement();
            _particles = gameObject.AddComponent<ParticleManager>();
        }

        public void OnAllPlatformDestroyed(UnityAction action)
        {
            _isAllPlatformsDestroyed = action;
        }

        public void Destroy(GameObject obj)
        {
            var platform = obj.GetComponent<ConcretePlatform>();
            _particles.Play();
            if (transform.childCount == 1)
            {
                _isAllPlatformsDestroyed.Invoke();
            }

            _objectsManagement.RemoveObjectById(platform.GetGuid()); //need to remove this class?
            _getPlatformPosition.Invoke(platform.GetGuid());
        }

        public void OnPlatformDestroyed(UnityAction<Guid> action)
        {
            _getPlatformPosition = action;
        }
    }
}