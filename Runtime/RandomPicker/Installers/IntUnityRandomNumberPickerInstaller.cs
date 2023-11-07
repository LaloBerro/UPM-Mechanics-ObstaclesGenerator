using MechanicsObstaclesGenerator.Timer.Domain;
using ZenjectExtensions.Zinstallers;

namespace ObstaclesGenerator.Runtime.RandomPicker.Installers
{
    public class IntUnityRandomNumberPickerInstaller : InstanceZinstaller<IRandomNumberPicker<int>>
    {
        protected override IRandomNumberPicker<int> GetInitializedClass()
        {
            return new IntUnityRandomNumberPicker();
        }
    }
}