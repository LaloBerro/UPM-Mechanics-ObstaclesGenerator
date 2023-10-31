using MechanicsObstaclesGenerator.Core.Domain;
using Zenject;
using ZenjectExtensions.Zinstallers;

namespace MechanicsObstaclesGenerator.Core.Installers
{
    public class ObstaclesGeneratorInstaller : InstanceZinstaller<IObstaclesGenerator>
    {
        [Inject]
        private IObstacleIndexPicker _obstacleIndexPicker;
        
        [Inject]
        private IObstacleSpawner[] _obstacleSpawners;
        
        protected override IObstaclesGenerator GetInitializedClass()
        {
            return new ObstaclesGenerator(_obstacleIndexPicker, _obstacleSpawners);
        }
    }
}