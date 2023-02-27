using System;
using CodeBase.BuildingSystem.HealthSystem;
using UnityEngine;

namespace CodeBase.Constructions {
    public class Building : MonoBehaviour {
        public bool Placed { get; private set; }
        public BoundsInt area;

        private HealthSystem _healthSystem;

        private void Start() {
            _healthSystem = GetComponent<HealthSystem>();
            _healthSystem.Died += OnDied;
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Space)) {
                _healthSystem.TakeDamage(9);
            }
        }

        private void OnDied() {
            Destroy(gameObject);
        }
    }
}