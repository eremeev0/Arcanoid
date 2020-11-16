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
        public (float, int)[] LVL_1 =
        {
            (-.2f, 0), (1.6f, 0), (3.4f, 0), (5.2f, 0), (7f, 0), (8.8f, 0),
            (-.2f, 1), (1.6f, 1), (3.4f, 1), (5.2f, 1), (7f, 1), (8.8f, 1),
            (-.2f, 2), (1.6f, 2), (3.4f, 2), (5.2f, 2), (7f, 2), (8.8f, 2),
            (-.2f, 3), (1.6f, 3), (3.4f, 3), (5.2f, 3), (7f, 3), (8.8f, 3)
        };

        public (int, int)[] LVL_2 =
        {
            /*(), (), (), (),
            (), (), (), (),
            (), (), (), (),
            (), (), (), (),
            (), (), (), (),
            (), (), ()*/
        };


    }
}