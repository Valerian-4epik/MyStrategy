using System;
using CodeBase.Constructions;
using CodeBase.Data.EnemyStatsInformation;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyInformation _enemyInfo;
        
        private Building _target;
        private Rigidbody2D _rigidbody2D;

        public EnemyInformation EnemyInfo => _enemyInfo;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _target = BuildingSystem.BuildingSystem.Instance.Castel;
        }

        private void Update()
        {
            
        }
    }
}
