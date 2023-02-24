using System;
using UnityEngine;

namespace CodeBase.BuildingSystem.HealthSystem {
    public class HealthSystem : MonoBehaviour {
        [SerializeField] private int _healthAmountMax;

        private int _healthAmount;

        private void Awake() {
            _healthAmount = _healthAmountMax;
        }

        public void TakeDamage(int damage) {
            
        }
    }
}