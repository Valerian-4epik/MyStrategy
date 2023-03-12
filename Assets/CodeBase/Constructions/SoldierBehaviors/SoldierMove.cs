using CodeBase.Enemies.EnemyBehaviors;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Constructions.SoldierBehaviors
{
    [RequireComponent(typeof(Soldier))]
    public class SoldierMove : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;

        private Soldier _soldier;
        private Transform _target;
        private bool _canMove;

        private void Awake()
        {
            _soldier = GetComponent<Soldier>();
        }

        private void OnEnable()
        {
            _agent.speed = _soldier.SoldierInformation.MovementSpeed;
            _soldier.TargetChanged += OnSetupTarget;
        }

        private void OnDisable()
        {
            _soldier.TargetChanged -= OnSetupTarget;
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

        private void OnSetupTarget(Enemy target)
        {
            if (target == null)
            {
                _target = _soldier.StartPosition;
            }
            else
            {
                _target = target.transform;
                target.Died += OnTargetDied;
            }

            _canMove = true;
        }

        private void OnTargetDied()
        {
            _canMove = false;
        }
    }
}