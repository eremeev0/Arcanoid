using UnityEngine;

namespace Assets.Scripts.MultiOriented
{
    public class ParticleManager: MonoBehaviour
    {
        private ParticleSystem _particle;

        void Start()
        {
            _particle = GetComponent<ParticleSystem>();
        }

        public void SetParticle(ParticleSystem particle)
        {
            _particle = particle;
        }

        public void Play()
        {
            if (_particle == null)
            {
                Debug.LogError("particle system is null");
                return;
            }
            _particle.Play();
        }

        public void Stop()
        {
            if (_particle == null)
            {
                Debug.LogError("particle system is null");
                return;
            }
            _particle.Stop();
        }
    }
}