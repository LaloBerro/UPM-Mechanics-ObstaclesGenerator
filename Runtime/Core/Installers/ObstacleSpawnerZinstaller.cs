using MechanicsObstaclesGenerator.Core.Domain;
using Spawners.Runtime.Core.Domain;
using Zenject;
using ZenjectExtensions.Zinstallers;

namespace MechanicsObstaclesGenerator.Core.Installers
{
    public abstract class ObstacleSpawnerZinstaller<TEntityData> : InstanceZinstaller<IObstacleSpawner>
    {
        [Inject]
        private ISpawner<TEntityData> _spawner;
        
        protected override IObstacleSpawner GetInitializedClass()
        {
            return GetObstacleSpawner(_spawner);
        }

        protected abstract IObstacleSpawner GetObstacleSpawner(ISpawner<TEntityData> spawner);
    }
}