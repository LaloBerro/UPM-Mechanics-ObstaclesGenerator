namespace MechanicsObstaclesGenerator.Timer.Domain
{
    public interface IRandomNumberPicker<NumberType>
    {
        NumberType GetRandomBetween(NumberType min, NumberType max);
    }
}