namespace MechanicsObstaclesGenerator.Timer.Domain
{
    public class RandomNumberGetter<TNumber> : IRandomGetter<TNumber>
    {
        private readonly TNumber _minDuration;
        private readonly TNumber _maxDuration;
        private readonly IRandomNumberPicker<TNumber> _randomNumberPicker;

        public RandomNumberGetter(TNumber minDuration, TNumber maxDuration, IRandomNumberPicker<TNumber> randomNumberPicker)
        {
            _minDuration = minDuration;
            _maxDuration = maxDuration;
            _randomNumberPicker = randomNumberPicker;
        }

        public TNumber GetRandomNumber()
        {
            return _randomNumberPicker.GetRandomBetween(_minDuration, _maxDuration);
        }
    }
}