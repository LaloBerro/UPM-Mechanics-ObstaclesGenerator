using UnityEngine;

namespace MechanicsObstaclesGenerator.Timer.Domain
{
    public class IntUnityRandomNumberPicker : IRandomNumberPicker<int>
    {
        public int GetRandomBetween(int min, int max)
        {
            return Random.Range(min, max);
        }
    }
}