using System;
using CodeBase.Data.TowerStatsInformation;
using CodeBase.Enemies;
using CodeBase.Enemies.EnemyBehaviors;
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

        private bool _hasTarget;

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

            if (!(_shootTimer < 0f))
                return;

            _shootTimer += _shootTimerMax;
            CreateProjectile();
        }

        private void HandleTargeting()
        {
            _lookForTargetTimer -= Time.deltaTime;

            if ((_lookForTargetTimer < 0f) == false)
                return;

            _lookForTargetTimer += _lookForTargetTimerMax;
            LookForTargets();
        }

        private void LookForTargets()
        {
            Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, _targetMaxRadius);

            foreach (Collider2D target in targets)
            {
                if (target.TryGetComponent(out Enemy enemy) == false)
                    continue;

                if (_hasTarget == false)
                {
                    SetTarget(enemy);
                }
                else
                {
                    Vector3 myPosition = transform.position;
                    float distanceToCurrentTarget = Vector3.Distance(myPosition, _target.transform.position);
                    float distanceToNewTarget = Vector3.Distance(myPosition, enemy.transform.position);

                    if (distanceToCurrentTarget > distanceToNewTarget) 
                        continue;

                    SetTarget(enemy);
                }
            }
        }

        private void SetTarget(Enemy enemy)
        {
            _target = enemy;
            _hasTarget = true;
            enemy.Died += OnTargetDied;
        }

        private void CreateProjectile()
        {
            if (_hasTarget == false)
                return;

            Projectile projectile = Instantiate(_projectile, _projectileSpawnPosition.transform.position,
                Quaternion.identity);
            projectile.SetTarget(_target);
        }

        private void OnTargetDied(Enemy enemy)
        {
            _target = null;
            _hasTarget = false;
        }
    }
}