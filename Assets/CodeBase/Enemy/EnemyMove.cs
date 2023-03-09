using System;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Enemy
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyMove : MonoBehaviour
    {
        private Transform _targetTransform;
        private Enemy _enemy;
        private float _movementSpeed;
        private NavMeshAgent _agent;
        private bool _canMove;

        private void Awake()
        {
            _enemy = GetComponent<Enemy>();
            _agent = GetComponent<NavMeshAgent>();
        }

        private void OnEnable()
        {
            _movementSpeed = _enemy.EnemyInfo.MovementSpeed;
            _agent.speed = _movementSpeed;
            _enemy.TargetChanged += SetTarget;
        }

        private void OnDisable()
        {
            _enemy.TargetChanged -= SetTarget;
        }

        private void Update()
        {
            if (!_canMove)
                return;
            
            var position = _targetTransform.position;
            _agent.SetDestination(new Vector3(position.x, position.y,
                transform.position.z));
        }

        private void SetTarget(Transform targetTransform)
        {
            _targetTransform = targetTransform;
            _canMove = true;
        }
    }
}