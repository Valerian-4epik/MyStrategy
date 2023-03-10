using CodeBase.BuildingSystem.HealthSystem;
using UnityEngine;

namespace CodeBase.Enemies.EnemyBehaviors
{
    public class EnemyAttack : MonoBehaviour
    {
        private Enemy _enemy;

        private void Awake()
        {
            _enemy = GetComponent<Enemy>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out HealthSystem building))
            {
                building.TakeDamage(_enemy.EnemyInfo.Damage);
                _enemy.Died?.Invoke(_enemy);
                Destroy(gameObject);
            }
        }
    }
}