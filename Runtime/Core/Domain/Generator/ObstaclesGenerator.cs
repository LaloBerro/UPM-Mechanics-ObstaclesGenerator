using System;

namespace MechanicsObstaclesGenerator.Core.Domain
{
    public class ObstaclesGenerator : IObstaclesGenerator
    {
        private readonly IObstacleIndexPicker _obstacleIndexPicker;
        private readonly IObstacleSpawner[] _obstacleSpawners;
        
        private readonly int _totalObstacleSpawners;

        public ObstaclesGenerator(IObstacleIndexPicker obstacleIndexPicker, IObstacleSpawner[] obstacleSpawners)
        {
            _obstacleIndexPicker = obstacleIndexPicker;
            _obstacleSpawners = obstacleSpawners;
            
            _totalObstacleSpawners = obstacleSpawners.Length - 1;

            if (_totalObstacleSpawners < 0)
                throw new Exception("Error initializing ObstacleGenerator because obstacleSpawners[] is empty");
        }

        public void Generate()
        {
            int selectedObstacleIndex = _obstacleIndexPicker.GetObstacleIndex(_totalObstacleSpawners);

            _obstacleSpawners[selectedObstacleIndex].Spawn();
        }
    }
}
