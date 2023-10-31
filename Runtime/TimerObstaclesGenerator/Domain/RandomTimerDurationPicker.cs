namespace MechanicsObstaclesGenerator.Timer.Domain
{
    public class RandomTimerDurationPicker : ITimerDurationPicker
    {
        private readonly IRandomGetter<float> _randomGetter;

        public RandomTimerDurationPicker(IRandomGetter<float> randomGetter)
        {
            _randomGetter = randomGetter;
        }

        public float GetTimerDuration()
        {
            return _randomGetter.GetRandomNumber();
        }
    }
}