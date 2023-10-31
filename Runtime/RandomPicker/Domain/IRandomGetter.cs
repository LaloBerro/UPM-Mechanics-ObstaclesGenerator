namespace MechanicsObstaclesGenerator.Timer.Domain
{
    public interface IRandomGetter<TNumber>
    {
        public TNumber GetRandomNumber();
    }
}