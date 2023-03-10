using System;
using CodeBase.Factory.EnemyFactory;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase.Enemies
{
    [RequireComponent(typeof(EnemySpawner))]
    public class EnemyWaveSystem : MonoBehaviour
    {
        private State _state;
        private int _waveNumber;
        private float _nextWaveSpawnTimer;
        private float _nextEnemySpawnTimer;
        private int _remainingEnemySpawnAmount;
        private EnemySpawner _enemySpawner;
        private Transform _currentSpawnPointTransform;

        private void Awake()
        {
            _enemySpawner = GetComponent<EnemySpawner>();
        }

        private void Start()
        {
            _state = State.WaitingToSpawnNextWave;
            _nextWaveSpawnTimer = 5f;
        }

        private void Update()
        {
            switch (_state)
            {
                case State.WaitingToSpawnNextWave:
                    StartSpawnWaveTimer();
                    break;
                case State.SpawningWave:
                    StartSpawnEnemyTimer();
                    break;
            }
        }

        private void StartSpawnEnemyTimer()
        {
            if (_remainingEnemySpawnAmount > 0)
            {
                _nextEnemySpawnTimer -= Time.deltaTime;

                if (_nextEnemySpawnTimer < 0)
                {
                    _nextEnemySpawnTimer = Random.Range(0f, 0.2f);
                    _enemySpawner.CreateEnemy(_currentSpawnPointTransform);
                    _remainingEnemySpawnAmount--;
                }

                if (_remainingEnemySpawnAmount <= 0)
                {
                    _state = State.WaitingToSpawnNextWave;
                }
            }
        }

        private void StartSpawnWaveTimer()
        {
            _nextWaveSpawnTimer -= Time.deltaTime;

            if (_nextWaveSpawnTimer < 0)
            {
                SpawnWave();
            }
        }

        private void SpawnWave()
        {
            _currentSpawnPointTransform = _enemySpawner.GetRandomSpawnPoint();
            _nextWaveSpawnTimer = 10f;
            _remainingEnemySpawnAmount = 5 + 3 * _waveNumber;//это типа прогрессия
            _state = State.SpawningWave;
            _waveNumber++;
        }
    }

    public enum State
    {
        WaitingToSpawnNextWave,
        SpawningWave,
    }
}