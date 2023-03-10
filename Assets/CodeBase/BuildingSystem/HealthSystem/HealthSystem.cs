using System;
using CodeBase.Constructions;
using CodeBase.Enemies.EnemyBehaviors;
using UnityEngine;

namespace CodeBase.BuildingSystem.HealthSystem {
    public class HealthSystem : MonoBehaviour {
        [SerializeField] private int _healthAmountMax;

        private int _healthAmount;

        public event Action HealthChanged;
        public event Action<HealthSystem> Destroed;

        private bool IsDead => _healthAmount == 0;

        private void Awake() {
            _healthAmount = _healthAmountMax;
        }

        public void TakeDamage(int damage) {
            _healthAmount -= damage;
            _healthAmount = Mathf.Clamp(_healthAmount, 0, _healthAmountMax);
            HealthChanged?.Invoke();

            if (IsDead)
            {
                print("должно снестись");
                Destroed?.Invoke(this);
                Destroy(gameObject);
            }
        }

        public bool IsFullHealth() =>
            _healthAmount == _healthAmountMax;

        public int GetHealthAmount() =>
            _healthAmount;
        
        public float GetHealthAmountNormalized() =>
            (float)_healthAmount / _healthAmountMax;
    }
}