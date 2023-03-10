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

        private Enemy _targetEnemy;

        protected virtual void Update()
        {
            if (_targetEnemy != null)
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
                Destroy(gameObject);
            }
        }

        public void SetTarget(Enemy enemy)
        {
            _targetEnemy = enemy;
        }
    }
}