using System;
using CodeBase.BuildingSystems.HealthSystem;
using CodeBase.Data.TowerStatsInformation;
using CodeBase.Enemies.EnemyBehaviors;
using UnityEngine;

namespace CodeBase.Constructions.SoldierBehaviors
{
    public class Soldier : MonoBehaviour
    {
        [SerializeField] private SoldierInformation _soldierInformation;

        public SoldierInformation SoldierInformation => _soldierInformation;

        private Transform _target;
        private Transform _startPosition;
        private float _lookForTargetTimer;
        private float _lookForTargetTimerMax = 1f;
        private bool _hasTarget;

        public Transform StartPosition
        {
            get => _startPosition;
            set => _startPosition = value;
        }

        public event Action<HealthSystem> Died;
        public event Action<Enemy> TargetChanged;

        private void Update()
        {
            HandleTargeting();
        }

        public void Die(HealthSystem healthSystem) => Died?.Invoke(healthSystem);

        private void HandleTargeting()
        {
            _lookForTargetTimer -= Time.deltaTime;

            if (_lookForTargetTimer < 0f)
            {
                _lookForTargetTimer += _lookForTargetTimerMax;
                LookForTargets();
            }
        }

        private void LookForTargets()
        {
            float targetMaxRadius = 10f; //взять из даты 
            Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, targetMaxRadius);

            foreach (Collider2D buildingCollider in colliderArray)
            {
                if (buildingCollider.TryGetComponent(out Enemy enemy) == false)
                    continue;

                if (_hasTarget == false)
                {
                    SetTarget(enemy);
                    _hasTarget = true;
                }
                else
                {
                    Vector3 position = transform.position;
                    float distanceToNewEnemy = Vector3.Distance(position, enemy.transform.position);
                    float distanceToCurrentTarget = Vector3.Distance(position, _target.transform.position);

                    if (distanceToNewEnemy < distanceToCurrentTarget)
                    {
                        SetTarget(enemy);
                    }
                }
            }

            if (_hasTarget)
                return;

            _target = _startPosition;
            TargetChanged?.Invoke(null);
        }

        private void SetTarget(Enemy enemy)
        {
            _target = enemy.transform;
            TargetChanged?.Invoke(enemy);
            enemy.Died += RemoveTarget;
        }

        private void RemoveTarget()
        {
            _target = _startPosition;
            _hasTarget = false;
        }
    }
}