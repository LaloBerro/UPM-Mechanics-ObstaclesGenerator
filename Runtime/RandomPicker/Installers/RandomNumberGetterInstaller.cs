using MechanicsObstaclesGenerator.Timer.Domain;
using UnityEngine;
using Zenject;
using ZenjectExtensions.Zinstallers;

namespace ObstaclesGenerator.Runtime.RandomPicker.Installers
{
    public abstract class RandomNumberGetterInstaller<TNumber> : InstanceZinstaller<IRandomGetter<TNumber>>
    {
        [Header("Config")] 
        [SerializeField] private TNumber _minDuration;
        [SerializeField] private TNumber _maxDuration;
        
        [Inject]
        private IRandomNumberPicker<TNumber> _randomNumberPicker;
        
        protected override IRandomGetter<TNumber> GetInitializedClass()
        {
            return new RandomNumberGetter<TNumber>(_minDuration, _maxDuration, _randomNumberPicker);
        }
    }
}