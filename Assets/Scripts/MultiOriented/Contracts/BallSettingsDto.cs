namespace Assets.Scripts.MultiOriented.Contracts
{
    public class BallSettingsDto
    {
        private BallSettingsDto(){}
        private static BallSettingsDto _ballSettings;

        public static BallSettingsDto GetBallSettings()
        {
            return _ballSettings ?? (_ballSettings = new BallSettingsDto());
        }
        public float BallSpeed { get; set; } = 1f;
        public float BallMaxSpeed { get; set; } = 14f;
        public float BallSpeedMultiplier { get; set; } = .1f;
    }
}