using MechanicsObstaclesGenerator.Timer.Domain;
using Zenject;

public class AwakeSwitcherTurnOn : MonoInstaller
{
   [Inject]
   private ISwitcher _switcher;

   public override void InstallBindings()
   {
      _switcher.TurnOn();
   }
}
