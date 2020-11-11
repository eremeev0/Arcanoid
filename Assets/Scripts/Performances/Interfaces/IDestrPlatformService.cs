namespace Assets.Scripts.Performances.Interfaces
{
    public interface IDestrPlatformService
    {
        void IncrementDestroyed();
        bool IsAllDestroyed();
    }
}