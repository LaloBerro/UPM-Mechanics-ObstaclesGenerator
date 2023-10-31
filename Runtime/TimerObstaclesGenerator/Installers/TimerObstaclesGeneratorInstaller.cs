using MechanicsObstaclesGenerator.Core.Domain;
using MechanicsObstaclesGenerator.Timer.Domain;
using Timer.Runtime.Core.Domain;
using Zenject;
using ZenjectExtensions.Zinstallers;

namespace MechanicsObstaclesGenerator.Timer.Installers
{
    public class TimerObstaclesGeneratorInstaller : InstanceZinstaller<ISwitcher>
    {
        [Inject]
        private ITimerDurationPicker _timerDurationPicker;
        [Inject]
        private ITimer _timer;
        [Inject]
        private IObstaclesGenerator _obstaclesGenerator;
    
        protected override ISwitcher GetInitializedClass()
        {
            return new TimerObstaclesGenerator(_timerDurationPicker, _timer, _obstaclesGenerator);
        }
    }
}