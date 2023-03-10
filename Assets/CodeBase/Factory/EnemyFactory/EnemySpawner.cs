using System;
using System.Collections;
using System.Collections.Generic;
using CodeBase.Enemies;
using CodeBase.Enemies.EnemyBehaviors;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase.Factory.EnemyFactory
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<Transform> _spawnPoint;
        [SerializeField] private Enemy _enemy;
        [SerializeField] private Transform _mainTarget;

        public void CreateEnemy(int value)
        {
            var spawnPointTransform = _spawnPoint[GetRandomIndex()];

            for (int i = 0; i < value; i++)
            {
                var enemy = Instantiate(_enemy, spawnPointTransform.position, Quaternion.identity);
                enemy.TargetTransform = _mainTarget;
            }
        }

        private Transform GetRandomSpawnPoint()
        {
            
        }
        
        private int GetRandomIndex()
        {
            return Random.Range(0, _spawnPoint.Count);
        }
    }
}