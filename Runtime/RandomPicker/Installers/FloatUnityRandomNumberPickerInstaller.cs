using MechanicsObstaclesGenerator.Timer.Domain;
using ZenjectExtensions.Zinstallers;

namespace ObstaclesGenerator.Runtime.RandomPicker.Installers
{
    public class FloatUnityRandomNumberPickerInstaller : InstanceZinstaller<IRandomNumberPicker<float>>
    {
        protected override IRandomNumberPicker<float> GetInitializedClass()
        {
            return new FloatUnityRandomNumberPicker();
        }
    }
}