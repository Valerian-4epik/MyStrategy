using System;
using CodeBase.Enemies;
using CodeBase.Enemies.EnemyBehaviors;
using CodeBase.Services.Abstract;
using UnityEngine;

namespace CodeBase.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        private const float TimeToDie = 1f;

        [SerializeField] private float _moveSpeed;

        protected Vector3 MoveDirection;
        protected Vector3 LastDirection;

        private bool _hasTarget;

        private Enemy _targetEnemy;

        protected void Move()
        {
            if (_hasTarget)
            {
                MoveDirection = (_targetEnemy.transform.position - transform.position).normalized;
                LastDirection = MoveDirection;
            }
            else
            {
                MoveDirection = LastDirection;
                Destroy(gameObject, TimeToDie);
            }

            transform.position += MoveDirection * _moveSpeed * Time.deltaTime;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out EnemyHealth enemy))
            {
                enemy.TakeDamage();
                _targetEnemy.Died -= OnEnemyDied;
                Destroy(gameObject);
            }
        }

        public void SetTarget(Enemy enemy)
        {
            _targetEnemy = enemy;
            _hasTarget = true;
            _targetEnemy.Died += OnEnemyDied;
        }

        private void OnEnemyDied(Enemy enemy)
        {
            _hasTarget = false;
        }
    }
}