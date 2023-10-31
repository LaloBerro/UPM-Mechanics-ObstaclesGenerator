using MechanicsObstaclesGenerator.Core.Domain;
using MechanicsObstaclesGenerator.Timer.Domain;
using Zenject;

namespace MechanicsObstaclesGenerator.Core.Installers
{
    public class RandomObstacleIndexPickerZinstaller : ObstacleIndexPickerZInstaller
    {
        [Inject]
        private IRandomGetter<int> _randomGetter;
        
        protected override IObstacleIndexPicker GetInitializedClass()
        {
            return new RandomObstacleIndexPicker(_randomGetter);
        }
    }
}