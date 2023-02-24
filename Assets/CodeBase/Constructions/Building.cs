using System;
using CodeBase.BuildingSystem.HealthSystem;
using UnityEngine;

namespace CodeBase.Constructions {
    public class Building : MonoBehaviour {
        public bool Placed { get; private set; }
        public BoundsInt area;

        private void Start() {
            var healthSystem = GetComponent<HealthSystem>();
        }
    }
}