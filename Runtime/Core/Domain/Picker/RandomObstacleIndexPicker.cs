using MechanicsObstaclesGenerator.Timer.Domain;

namespace MechanicsObstaclesGenerator.Core.Domain
{
    public class RandomObstacleIndexPicker : IObstacleIndexPicker
    {
        private readonly IRandomGetter<int> _randomGetter;

        public RandomObstacleIndexPicker(IRandomGetter<int> randomGetter)
        {
            _randomGetter = randomGetter;
        }

        public int GetObstacleIndex(int totalObstacles)
        {
            return _randomGetter.GetRandomNumber();
        }
    }
}