namespace MechanicsObstaclesGenerator.Core.Domain
{
    public interface IObstacleIndexPicker
    {
        int GetObstacleIndex(int totalObstacles);
    }
}