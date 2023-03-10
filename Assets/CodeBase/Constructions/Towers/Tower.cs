using System;
using CodeBase.Data.TowerStatsInformation;
using CodeBase.Enemies;
using CodeBase.Projectiles;
using UnityEngine;

namespace CodeBase.Constructions.Towers
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private TowerInformation _towerInformation;
        [SerializeField] private Projectile _projectile;

        private ProjectileSpawnPosition _projectileSpawnPosition;
        private float _targetMaxRadius;
        private float _shootTimerMax;
        private float _shootTimer;
        private Enemy _target;
        private float _lookForTargetTimer;
        private float _lookForTargetTimerMax = 1f;

        private void Awake()
        {
            _projectileSpawnPosition = GetComponentInChildren<ProjectileSpawnPosition>();
        }

        private void Start()
        {
            _targetMaxRadius = _towerInformation.Level1Info.AttackDistance;
            _shootTimerMax = _towerInformation.Level1Info.AttackSpeed;
        }

        private void Update()
        {
            HandleTargeting();
            HandleShooting();
        }

        private void HandleShooting()
        {
            _shootTimer -= Time.deltaTime;

            if (_shootTimer < 0f)
            {
                _shootTimer += _shootTimerMax;
                CreateProjectile();
            }
        }

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
            Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, _targetMaxRadius);

            foreach (var collider in colliderArray)
            {
                if (collider.TryGetComponent(out Enemy enemy))
                {
                    if (_target == null)
                    {
                        _target = enemy;
                    }
                    else
                    {
                        if (Vector3.Distance(transform.position, enemy.transform.position)
                            < Vector3.Distance(transform.position, _target.transform.position))
                        {
                            _target = enemy;
                        }
                    }
                }
            }
        }

        private void CreateProjectile()
        {
            if (_target != null)
            {
                Projectile projectile = Instantiate(_projectile, _projectileSpawnPosition.transform.position,
                    Quaternion.identity);
                projectile.SetTarget(_target);
            }
        }
    }
}