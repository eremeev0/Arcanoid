using UnityEngine;

namespace Assets.Scripts.MultiOriented
{
    public class ParticleManager: MonoBehaviour
    {
        private ParticleSystem _particle;
        public void SetParticle(ParticleSystem particle)
        {
            _particle = particle;
        }

        public void Play()
        {
            if (_particle == null)
            {
                Debug.LogError("ParticleManager.Play(): particle system is null");
                return;
            }
            _particle.Play();
        }
    }
}