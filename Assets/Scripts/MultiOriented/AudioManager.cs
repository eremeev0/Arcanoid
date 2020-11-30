using UnityEngine;

namespace Assets.Scripts.MultiOriented
{
    public class AudioManager: MonoBehaviour
    {
        private AudioSource _audioSource;
        private AudioClip _audioClip;

        public override string ToString()
        {
            return $"(src: {_audioSource}, clip: {_audioClip})";
        }
    }
}