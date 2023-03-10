using System;
using System.Collections;
using System.Collections.Generic;
using CodeBase.Enemies;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase.Factory.EnemyFactory
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<Transform> _spawnPoint;
        [SerializeField] private Enemy _enemy;
        [SerializeField] private Transform _mainTarget;

        private void Start()
        {
            StartCoroutine(CreateEnemy(5));
        }

        private IEnumerator CreateEnemy(int value)
        {
            for (int i = 0; i < value; i++)
            {
                var enemy= Instantiate(_enemy, _spawnPoint[GetRandomTransform()].position, Quaternion.identity);
                enemy.TargetTransform = _mainTarget;

                yield return new WaitForSeconds(5f);
            }
        }

        private int GetRandomTransform()
        {
            return Random.Range(0, _spawnPoint.Count);
        }
    }
}
