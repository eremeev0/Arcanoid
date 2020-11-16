using System.Collections.Generic;

namespace Assets.Scripts.Contracts
{
    public class SpawnerDto
    {
        private SpawnerDto()
        { }

        private static SpawnerDto _spawner;

        public static SpawnerDto GetSpawner()
        {
            if (_spawner == null)
                _spawner = new SpawnerDto();
            return _spawner;
        }
        public (int, int)[] LVL_1 =
        {

        };

        public (int, int)[] LVL_2 =
        {

        };


    }
}