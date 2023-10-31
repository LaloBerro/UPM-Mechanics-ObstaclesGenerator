using MechanicsObstaclesGenerator.Timer.Domain;
using Zenject;
using ZenjectExtensions.Zinstallers;

namespace MechanicsObstaclesGenerator.Timer.Installers
{
    public class RandomTimerDurationPickerInstaller : InstanceZinstaller<ITimerDurationPicker>
    {
        [Inject]
        private IRandomGetter<float> _randomGetter;
        
        protected override ITimerDurationPicker GetInitializedClass()
        {
            return new RandomTimerDurationPicker(_randomGetter);
        }
    }
}