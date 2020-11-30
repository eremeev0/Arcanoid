using UnityEngine;

namespace Assets.Scripts.MultiOriented
{
    public class AudioManager: MonoBehaviour
    {
        private AudioSource _audioSource;
        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            if (_audioSource == null)
            {
                Debug.LogError("Component Audio Source not found!");
                return;
            }
        }

        public void SetClipSource(AudioClip sourceClip)
        {
            if (sourceClip == null)
            {
                Debug.LogError("Audio clip not found!");

            }
            _audioSource.clip = sourceClip;
        }

        public void Play()
        {
            if (_audioSource == null)
            {
                Debug.LogError("Can't Play: Audio source is null!");
                return;
            }

            if (_audioSource.clip == null)
            {
                Debug.LogError("Can't Play: Audio clip is null!");
                return;
            }
            _audioSource.Play();
        }

        public void Stop()
        {

            if (_audioSource == null)
            {
                Debug.LogError("Can't Stop: Audio source is null!");
                return;
            }

            if (_audioSource.clip == null)
            {
                Debug.LogError("Can't Stop: Audio clip is null!");
                return;
            }

            if (!_audioSource.isPlaying)
            {
                Debug.LogWarning("Clip is already stopped!");
                return;
            }
            _audioSource.Stop();
        }

        public void IsLoop(bool isLoop)
        {
            _audioSource.loop = isLoop;
        }

        public void SetVolume(ushort volume)
        {
            _audioSource.volume = volume;
        }

        public override string ToString()
        {
            return $"(src: {_audioSource}, clip: {_audioSource.clip})";
        }
    }
}