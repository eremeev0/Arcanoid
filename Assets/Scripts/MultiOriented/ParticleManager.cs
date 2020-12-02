using System;
using System.Collections;
using System.Threading.Tasks;
using Assets.Scripts.MultiOriented.Models;
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
        // change to courutine
        
        /// <summary>
        /// Play particle after delay
        /// </summary>
        /// <param name="delay">milliseconds</param>
        /// <returns><see cref="IEnumerator"/></returns>
        public IEnumerator Play(float delay){
            if (delay < 0) 
            {
                Debug.LogError($"{nameof(delay)} out of range!");
                yield return null;
            }
            if (_particle == null) 
            {
                Debug.LogError($"{nameof(_particle)} is null!");
                yield return null;
            }
            yield return new WaitForSeconds(delay/1000);
            _particle.Play();
        }

        // public void Play(float delay)
        // {
        //     if (delay < 0) throw new ArgumentOutOfRangeException(nameof(delay));
        //     throw new NotImplementedException();
        // }

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