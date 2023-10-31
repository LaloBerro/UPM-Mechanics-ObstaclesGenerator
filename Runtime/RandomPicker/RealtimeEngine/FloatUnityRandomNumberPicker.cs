using UnityEngine;

namespace MechanicsObstaclesGenerator.Timer.Domain
{
    public class FloatUnityRandomNumberPicker : IRandomNumberPicker<float>
    {
        public float GetRandomBetween(float min, float max)
        {
            return Random.Range(min, max);
        }
    }
}