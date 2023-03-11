using CodeBase.BuildingSystems.HealthSystem;
using CodeBase.Constructions;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Enemies.EnemyBehaviors
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyMove : MonoBehaviour
    {
        private HealthSystem _target;
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
            TryMove();
        }

        private void TryMove()
        {
            if (_canMove == false)
                return;

            Vector3 position = _target.transform.position;

            _agent.SetDestination(new Vector3(position.x, position.y,
                transform.position.z));
        }

        private void OnSetupTarget(HealthSystem targetTransform)
        {
            _target = targetTransform;
            _target.Destroed += OnTargetDied;
            
            _canMove = true;
        }

        private void OnTargetDied(HealthSystem building)
        {
            _canMove = false;
        }
    }
}