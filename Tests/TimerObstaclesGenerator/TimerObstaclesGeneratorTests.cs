using System.Collections;
using System.Collections.Generic;
using EmptyObstaclesGenerator.Domain;
using MechanicsObstaclesGenerator.Core.Domain;
using MechanicsObstaclesGenerator.Timer.Domain;
using NUnit.Framework;
using ObjectPool.Runtime.Core.Domain;
using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Presenters;
using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.RealtimeEngine;
using Spawners.Runtime.Core.Domain;
using Spawners.Runtime.Core.InterfaceAdapters.Presenters;
using Spawners.Runtime.EmptySpawner.Domain;
using Spawners.Runtime.EmptySpawner.InterfaceAdapters.View;
using Timer.Runtime.Core.Domain;
using Timer.Runtime.Realtime.Domain;
using UnityEngine;
using UnityEngine.TestTools;

namespace ObstacleGenerator.Tests.PlayMode.Timer
{
    public class TimerObstaclesGeneratorTests
    {
        private IRandomGetter<float> _randomGetter;
        private ITimerDurationPicker _timerDurationPicker;
        private ITimer _timer;
        private IObstaclesGenerator _obstaclesGenerator;
        private IObstacleIndexPicker _obstacleIndexPicker;
        private IObstacleSpawner[] _obstacleSpawners;
        private TimerObstaclesGenerator _timerObstaclesGenerator;

        private ISpawner<EmptyData> _spawner;
        private ISpawnerPresenter<EmptyData> _spawnerPresenter;
        private ISpawnedObjectPresenter<EmptyData, IEmptyObjectView> _spawnedObjectPresenter;
        private IObjectPool<IRecyclableObjectView> _objectPool;

        [SetUp]
        public void SetUp()
        {
            _randomGetter = new RandomNumberGetter<float>(2, 2, new FloatUnityRandomNumberPicker());
            _timerDurationPicker = new RandomTimerDurationPicker(_randomGetter);

            IRealtimeTimerExecutor realtimeTimerExecutor = new GameObject("Timer").AddComponent<RealtimeTimerExecutor>();
            
            _timer = new RealtimeTimer(realtimeTimerExecutor);

            List<EmptyData> _emptyDatas = new List<EmptyData>();
            _emptyDatas.Add(new EmptyData());
            _emptyDatas.Add(new EmptyData());
            _emptyDatas.Add(new EmptyData());


            BuildSpawner();
            _obstacleSpawners = new[] { new EmptyObstacleSpawner(_spawner) };
            
            var randomNumberGetter = new RandomNumberGetter<int>(0, _obstacleSpawners.Length - 1, new IntUnityRandomNumberPicker());
            _obstacleIndexPicker = new RandomObstacleIndexPicker(randomNumberGetter);
            _obstaclesGenerator = new ObstaclesGenerator(_obstacleIndexPicker, _obstacleSpawners);

            _timerObstaclesGenerator = new TimerObstaclesGenerator(_timerDurationPicker, _timer, _obstaclesGenerator);
        }

        private void BuildSpawner()
        {
            GameObject parentGameObject = new GameObject("parent");
            GameObject emptyGameObject = new GameObject("prefab");
            emptyGameObject.AddComponent<EmptyObjectView>();

            IGenerator<IRecyclableObjectView> generator =
                new RecyclableObjectGenerator(parentGameObject.transform, emptyGameObject);
            _objectPool = new RecyclableObjectPool(generator, 10);

            _spawnedObjectPresenter = new EmptySpawnedObjectPresenter();

            _spawnerPresenter = new SpawnerPresenter<EmptyData, IEmptyObjectView>(_objectPool, _spawnedObjectPresenter);
            _spawner = new Spawner<EmptyData>(_spawnerPresenter);
        }

        [TearDown]
        public void TearDown()
        {
            _objectPool = null;
        }

        [UnityTest]
        public IEnumerator TurnOnObstacleGenerator_Spawn5Objects()
        {
            yield return null;
            
            //Act
            _timerObstaclesGenerator.TurnOn();

            yield return new WaitForSeconds(10);

            //Assert
            int size = _objectPool.GetPoolSize();
            Assert.AreEqual(5, size);
        }
        
        [UnityTest]
        public IEnumerator TurnOffObstacleGenerator_DoesNotSpawnAnymore()
        {
            yield return null;
            
            //Act
            _timerObstaclesGenerator.TurnOn();

            yield return new WaitForSeconds(5);
            
            _timerObstaclesGenerator.TurnOff();
            
            yield return new WaitForSeconds(5);

            //Assert
            int size = _objectPool.GetPoolSize();
            Assert.AreEqual(3, size);
        }
        
    }
}