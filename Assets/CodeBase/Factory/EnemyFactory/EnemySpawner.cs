using System;
using System.Collections;
using System.Collections.Generic;
using CodeBase.BuildingSystem.HealthSystem;
using CodeBase.Constructions;
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
        [SerializeField] private HealthSystem _mainTarget;

        public void CreateEnemy(Transform transform)
        {
            var enemy = Instantiate(_enemy, transform.position, Quaternion.identity);
            enemy.Target = _mainTarget;
        }

        public Transform GetRandomSpawnPoint() =>
            _spawnPoint[GetRandomIndex()];

        private int GetRandomIndex()
        {
            return Random.Range(0, _spawnPoint.Count);
        }
    }
}