using Spawners.Runtime.Core.Domain;

namespace MechanicsObstaclesGenerator.Core.Domain
{
    public abstract class ObstacleSpawner<TEntityData> : IObstacleSpawner
    {
        private readonly ISpawner<TEntityData> _spawner;

        protected ObstacleSpawner(ISpawner<TEntityData> spawner)
        {
            _spawner = spawner;
        }

        public void Spawn()
        {
            TEntityData entityData = GetData();
            
            _spawner.Spawn(entityData);
        }

        protected abstract TEntityData GetData();
    }
}