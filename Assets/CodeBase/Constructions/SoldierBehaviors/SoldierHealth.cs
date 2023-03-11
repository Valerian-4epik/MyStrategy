using System;
using CodeBase.BuildingSystems.HealthSystem;
using UnityEngine;

namespace CodeBase.Constructions.SoldierBehaviors
{
    public class SoldierHealth : HealthSystem
    {
        private Soldier _soldier;
        private int _maxHealthAmount;
        private int _healthAmount;
        
        private bool IsDead => _healthAmount == 0;

        public event Action Died
        {
            add
            {
                _soldier.Died += value;
            }
            remove
            {
                _soldier.Died -= value;
            }
        }

        private void Awake()
        {
            _soldier = GetComponent<Soldier>();
            _maxHealthAmount = _soldier.SoldierInformation.Health;
            _healthAmount = _maxHealthAmount;
        }

//         public void TakeDamage(int damage)
//         {
//             _healthAmount -= damage;
//             _healthAmount = Mathf.Clamp(_healthAmount, 0, _maxHealthAmount);
//             HealthChanged?.Invoke()
//
//             if (IsDead)
//             {
//                 Destroed?.Invoke(this);
//                 Destroy(gameObject);
//             }
//         }
//
//         public bool IsFullHealth() =>
//             _healthAmount == _healthAmountMax;
//
//         public int GetHealthAmount() =>
//             _healthAmount;
//
//         public float GetHealthAmountNormalized() =>
//             (float)_healthAmount / _healthAmountMax;
    }
}