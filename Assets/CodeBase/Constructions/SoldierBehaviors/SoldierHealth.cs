using System;
using System.Threading;
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

        private void Awake()
        {
            _soldier = GetComponent<Soldier>();
            _maxHealthAmount = _soldier.SoldierInformation.Health;
            _healthAmount = _maxHealthAmount;
        }

        public override void PlayDead()
        {
            _soldier.Die(this);
            base.PlayDead();
        }

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