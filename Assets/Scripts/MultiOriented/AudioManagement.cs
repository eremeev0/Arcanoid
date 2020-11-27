using UnityEngine;

namespace Assets.Scripts.MultiOriented
{
    public class AudioManagement
    {
        private AudioSource _audioSource;
        private AudioClip _audioClip;
        void SetAudioSource(AudioSource audioSource) { }
        void SetAudioClip(AudioClip audioClip) { }
        void SwitchClip(string clipName) { }
        void UpdateVolume(int volume) { }
        public override string ToString()
        {
            return $"(src: {_audioSource}, clip: {_audioClip})";
        }
    }
}