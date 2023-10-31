using System;
using MechanicsObstaclesGenerator.Core.Domain;
using Timer.Runtime.Core.Domain;
using UnityEngine;

namespace MechanicsObstaclesGenerator.Timer.Domain
{
    public class TimerObstaclesGenerator : ISwitcher
    {
        private readonly ITimerDurationPicker _timerDurationPicker;
        private readonly ITimer _timer;
        private readonly IObstaclesGenerator _obstaclesGenerator;

        public TimerObstaclesGenerator(ITimerDurationPicker timerDurationPicker, ITimer timer, IObstaclesGenerator obstaclesGenerator)
        {
            _timer = timer;
            _obstaclesGenerator = obstaclesGenerator;
            _timerDurationPicker = timerDurationPicker;
        }

        public void TurnOn()
        {
            _timer.OnTimerFinished += Spawn;
            
            Spawn();
        }

        private void Spawn()
        {
            float timerDuration = _timerDurationPicker.GetTimerDuration();
            _timer.Start(timerDuration);
            
            _obstaclesGenerator.Generate();
        }

        public void TurnOff()
        {
            _timer.OnTimerFinished -= Spawn;
        }
    }
}