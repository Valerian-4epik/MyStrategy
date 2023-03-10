using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Enemies
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
            _enemy.TargetChanged += OnSetupTarget;
        }

        private void OnDisable()
        {
            _enemy.TargetChanged -= OnSetupTarget;
        }

        private void Update()
        {
            if (!_canMove)
                return;
            
            var position = _targetTransform.position;
            _agent.SetDestination(new Vector3(position.x, position.y,
                transform.position.z));
        }

        private void OnSetupTarget(Transform targetTransform)
        {
            _targetTransform = targetTransform;
            _canMove = true;
        }
    }
}