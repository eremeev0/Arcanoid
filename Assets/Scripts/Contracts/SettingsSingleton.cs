using UnityEngine;

namespace Assets.Scripts.Contracts
{
    public class SettingsSingleton
    {
        private SettingsSingleton(){}
        private static SettingsSingleton _settings;

        public static SettingsSingleton GetSettings()
        {
            return _settings ?? (_settings = new SettingsSingleton());
        }

        public float PlayerSpeed { get; set; } = DefaultSettingsDto.PlayerSpeed;
        public Color PlayerColor { get; set; } = DefaultSettingsDto.PlayerColor;
        public Vector2 GameResolution { get; set; } = DefaultSettingsDto.GameResolution;
        public int PlayerScore { get; set; } = DefaultSettingsDto.PlayerScore;

        public bool IsGameStopped { get; set; } = false;
        public bool IsLevelComplete { get; set; } = false;
        public bool IsLevelFailed { get; set; } = false;
        public bool IsScoreUpdate { get; set; } = true;
        public float BallSpeed { get; set; } = 1f;
        public float BallMaxSpeed { get; set; } = 14f;
        public float BallSpeedMultiplier { get; set; } = .1f;
    }
}