using System;
using CodeBase.Enemies;
using CodeBase.Services.Abstract;
using UnityEngine;

namespace CodeBase.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;

        protected Vector3 MoveDirection;
        
        private Enemy _targetEnemy;

        protected virtual void Update()
        {
            if (_targetEnemy != null)
            {
                MoveDirection = (_targetEnemy.transform.position - transform.position).normalized;
                transform.eulerAngles = new Vector3(0, 0, Utils.GetAngleFromVector(MoveDirection));
                transform.position += MoveDirection * _moveSpeed * Time.deltaTime;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Enemy enemy))
            {
                Destroy(enemy.gameObject);
            }
        }

        public void SetTarget(Enemy enemy)
        {
            _targetEnemy = enemy;
        }
    }
}