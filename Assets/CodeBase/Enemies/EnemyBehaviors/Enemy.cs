using System;
using CodeBase.BuildingSystem.HealthSystem;
using CodeBase.Constructions;
using CodeBase.Data.EnemyStatsInformation;
using UnityEngine;

namespace CodeBase.Enemies.EnemyBehaviors
{
    public class Enemy : MonoBehaviour
    {
        public static Enemy Create(Vector3 position)
        {
            Transform enemyModel = Resources.Load<Transform>("Prefabs/Enemies/Enemy");
            Transform enemyTransform = Instantiate(enemyModel, position, Quaternion.identity);

            Enemy enemy = enemyModel.GetComponent<Enemy>();
            return enemy;
        }

        [SerializeField] private EnemyInformation _enemyInfo;

        private HealthSystem _target;
        private float _lookForTargetTimer;
        private float _lookForTargetTimerMax = 1f;
        private bool _hasTarget;

        public event Action<Enemy> Died;
        public event Action<HealthSystem> TargetChanged;

        public EnemyInformation EnemyInfo => _enemyInfo;

        public HealthSystem Target
        {
            get => _target;
            set
            {
                _target = value;
                _hasTarget = true;
                TargetChanged?.Invoke(_target);
            }
        }

        public void Die()
        {
            Died?.Invoke(this);
        }
        
        private void Update()
        {
            HandleTargeting();
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
            float targetMaxRadius = 10f;
            Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, targetMaxRadius);

            foreach (Collider2D buildingCollider in colliderArray)
            {
                if (buildingCollider.TryGetComponent(out HealthSystem building) == false)
                    continue;

                if (_hasTarget == false)
                {
                    SetTarget(building);
                    _hasTarget = true;
                }
                else
                {
                    Vector3 position = transform.position;
                    float distanceToNewBuilding = Vector3.Distance(position, building.transform.position);
                    float distanceToCurrentTarget = Vector3.Distance(position, _target.transform.position);

                    if (distanceToNewBuilding < distanceToCurrentTarget)
                    {
                        SetTarget(building);
                    }
                }
            }

            if (_hasTarget)
                return;

            Building instanceCastle = BuildingSystem.BuildingSystem.Instance.Castle;

            if (instanceCastle.TryGetComponent(out HealthSystem healthSystem))
                SetTarget(healthSystem);
        }

        private void SetTarget(HealthSystem building)
        {
            Target = building;
            building.Destroed += OnBuildingDestroed;
        }

        private void OnBuildingDestroed(HealthSystem building)
        {
            SetTarget(BuildingSystem.BuildingSystem.Instance.Castle.GetComponent<HealthSystem>());
        }
    }
}