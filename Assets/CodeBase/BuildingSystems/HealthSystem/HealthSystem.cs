using System;
using CodeBase.Constructions.SoldierBehaviors;
using UnityEngine;

namespace CodeBase.BuildingSystems.HealthSystem
{
    public class HealthSystem : MonoBehaviour
    {
        [SerializeField] private int _healthAmountMax;
        
        private int _healthAmount;

        public event Action HealthChanged;
        public event Action<HealthSystem> Destroed;

        private bool IsDead => _healthAmount == 0;

        private void Awake()
        {
            _healthAmount = _healthAmountMax;
        }

        public virtual void PlayDead()
        {
            Destroy(gameObject);
        }

        public virtual void TakeDamage(int damage)
        {
            _healthAmount -= damage;
            _healthAmount = Mathf.Clamp(_healthAmount, 0, _healthAmountMax);
            HealthChanged?.Invoke();

            if (IsDead)
            {
                Destroed?.Invoke(this);
                PlayDead();
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