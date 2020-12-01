using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.MultiOriented
{
    public class ParticleManager: MonoBehaviour
    {
        private ParticleSystem _particle;

        void Start()
        {
            _particle = GetComponentInChildren<ParticleSystem>();
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
        // change to 
        
        public void Play(float delay)
        {
            if (delay < 0) throw new ArgumentOutOfRangeException(nameof(delay));
            throw new NotImplementedException();
        }

        public void SetParticleStartColor(Color color)
        {
            var particleMain = _particle.main;
            particleMain.startColor = new ParticleSystem.MinMaxGradient(color);
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