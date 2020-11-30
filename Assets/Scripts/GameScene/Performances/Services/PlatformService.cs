using System;
using Assets.Scripts.MultiOriented;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.GameScene.Performances.Services
{
    [Serializable]
    public class PlatformService: MonoBehaviour
    {
        public Guid PlatformGuid;// { get; private set;}
        public Vector3 PlatformPosition;// { get; private set; }
        public Color PlatformColor;// { get; private set; }
        public int HitsToDeath;// { get; private set; }

        private static PlatformService _platformService;
        private UnityAction<Guid> _getPlatformPosition;
        private UnityAction _isAllPlatformsDestroyed;
        private readonly ObjectsManagement _objectsManagement;
        private ParticleManager _particles;

        private PlatformService()
        {
            _objectsManagement = ObjectsManagement.GetManagement();
            _particles = gameObject.AddComponent<ParticleManager>();
        }

        public static PlatformService GetPlatformService()
        {
            return _platformService ?? (_platformService = new PlatformService());
        }

        public void OnAllPlatformDestroyed(UnityAction action)
        {
            _isAllPlatformsDestroyed = action;
        }

        public void Destroy(GameObject obj)
        {
            _particles.Play();
            if (obj.transform.parent.childCount == 1)
            {
                _isAllPlatformsDestroyed.Invoke();
                //_isAllDestroyed = true;
            }
            // use guid
            // class.Remove(id)
            var guid = obj.GetComponent<GuidComponent>().guid;
            _objectsManagement.RemoveObjectById(guid);
            _getPlatformPosition.Invoke(guid);
        }

        public void OnPlatformDestroyed(UnityAction<Guid> action)
        {
            _getPlatformPosition = action;
        }
    }
}