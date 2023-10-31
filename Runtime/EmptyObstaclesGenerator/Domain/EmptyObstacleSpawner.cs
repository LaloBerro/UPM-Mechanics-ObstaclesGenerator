using MechanicsObstaclesGenerator.Core.Domain;
using Spawners.Runtime.Core.Domain;
using Spawners.Runtime.EmptySpawner.Domain;

namespace EmptyObstaclesGenerator.Domain
{
    public class EmptyObstacleSpawner : ObstacleSpawner<EmptyData>
    {
        public EmptyObstacleSpawner(ISpawner<EmptyData> spawner) : base(spawner)
        {
        }

        protected override EmptyData GetData()
        {
            return new EmptyData();
        }
    }
}