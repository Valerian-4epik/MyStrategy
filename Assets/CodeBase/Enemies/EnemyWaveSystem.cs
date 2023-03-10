using System;
using CodeBase.Factory.EnemyFactory;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase.Enemies
{
    [RequireComponent(typeof(EnemySpawner))]
    public class EnemyWaveSystem : MonoBehaviour
    {
        private float _nextWaveSpawnTimer;
        private float _nextEnemySpawnTimer;
        private int _remainingEnemySpawnAmount;
        private EnemySpawner _enemySpawner;

        private void Awake()
        {
            _enemySpawner = GetComponent<EnemySpawner>();
        }

        private void Start()
        {
            
        }

        private void Update()
        {
            _nextWaveSpawnTimer -= Time.deltaTime;

            if (_nextWaveSpawnTimer < 0)
            {
            }


            if (_remainingEnemySpawnAmount > 0)
            {
                _nextEnemySpawnTimer -= Time.deltaTime;

                if (_nextEnemySpawnTimer < 0)
                {
                    _nextEnemySpawnTimer = Random.Range(0f, 0.2f);
                    _enemySpawner.CreateEnemy();
                }
            }
        }
    }
}