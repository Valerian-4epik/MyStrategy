using System;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Enemy
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyMove : MonoBehaviour
    {
        [SerializeField] private Transform _targetTransform;

        private Enemy _enemy;
        private float _movementSpeed;
        private NavMeshAgent _agent;

        private void Awake()
        {
            _enemy = GetComponent<Enemy>();
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            _movementSpeed = _enemy.EnemyInfo.MovementSpeed;
            _agent.speed = _movementSpeed;
        }

        private void Update()
        {
            var position = _targetTransform.position;
            _agent.SetDestination(new Vector3(position.x, position.y,
                transform.position.z));
        }
    }
}