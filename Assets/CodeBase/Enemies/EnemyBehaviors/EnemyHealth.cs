using UnityEngine;

namespace CodeBase.Enemies.EnemyBehaviors
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyHealth : MonoBehaviour
    {
        private Enemy _enemy;
        private int _maxHealth;
        private int _currentHealth;

        private void Awake()
        {
            _enemy = GetComponent<Enemy>();
        }

        private void Start()
        {
            _maxHealth = _enemy.EnemyInfo.Health;
        }

        public void TakeDamage()
        {
            _enemy.Die();
            Destroy(gameObject);
        }
    }
}