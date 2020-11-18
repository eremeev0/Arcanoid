using System;

namespace Assets.Scripts.EventManagment.Events
{
    [Obsolete("Enum GameEvents is deprecated. Use GlobalEvents instead.")]
    public enum GameEvents
    {
        GAME_PAUSED,
        GAME_RESUMED,
        START_GAME,
        CLOSE_GAME,
        LEVEL_FAILED,
        LEVEL_COMPLETED,
        SPAWN_OBJECTS
    }
}