using MechanicsObstaclesGenerator.Core.Domain;
using MechanicsObstaclesGenerator.Core.Installers;
using Spawners.Runtime.Core.Domain;
using Spawners.Runtime.EmptySpawner.Domain;

namespace EmptyObstaclesGenerator.Domain
{
    public class EmptyObstacleSpawnerInstaller : ObstacleSpawnerZinstaller<EmptyData>
    {
        protected override IObstacleSpawner GetObstacleSpawner(ISpawner<EmptyData> spawner)
        {
            return new EmptyObstacleSpawner(spawner);
        }
    }
}