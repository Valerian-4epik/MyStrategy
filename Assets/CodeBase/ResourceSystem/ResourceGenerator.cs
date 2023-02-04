using System;
using CodeBase.BuildingSystem;
using CodeBase.Data.BuildingType;
using UnityEngine;

namespace CodeBase.ResourceSystem {
    public class ResourceGenerator : MonoBehaviour {
        private BuildingTypeSo _buildingType;
        private float _timer;
        private float _timerMax;

        private void Awake() {
            _buildingType = GetComponent<BuildingTypeHolder>().BuildingType;
            _timerMax = _buildingType.ResourceGeneratorData.TimerMax;
        }

        private void Update() {
            _timer -= Time.deltaTime;
            if (_timer <= 0f) {
                _timer += _timerMax;
                ResourceSystem.Instance.AddResource(_buildingType.ResourceGeneratorData.ResourceTypeSo, 1);
            }
        }
    }
}