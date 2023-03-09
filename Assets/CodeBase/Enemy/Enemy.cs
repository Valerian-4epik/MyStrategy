using System;
using CodeBase.Constructions;
using CodeBase.Data.EnemyStatsInformation;
using UnityEngine;

namespace CodeBase.Enemy
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

        private Rigidbody2D _rigidbody2D;
        private Transform _targetTransform;
        private float _lookForTargetTimer;
        private float _lookForTargetTimerMax = 1f;

        public EnemyInformation EnemyInfo => _enemyInfo;

        public Transform TargetTransform
        {
            get => _targetTransform;
            set
            {
                _targetTransform = value;
                TargetChanged?.Invoke(_targetTransform);
            }
        }

        public event Action<Transform> TargetChanged;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
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

            foreach (var collider in colliderArray)
            {
                Building building = collider.GetComponent<Building>();

                if (building != null)
                {
                    if (_targetTransform == null)
                    {
                        TargetTransform = building.transform;
                    }
                    else
                    {
                        if (Vector3.Distance(transform.position, building.transform.position)
                            < Vector3.Distance(transform.position, _targetTransform.position))
                        {
                            TargetTransform = building.transform;
                        };
                    }
                }
            }

            if (_targetTransform == null)
            {
                TargetTransform = BuildingSystem.BuildingSystem.Instance.Castel.transform;
            }
        }
    }
}