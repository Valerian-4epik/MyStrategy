using System;
using CodeBase.BuildingSystem;
using CodeBase.Data.BuildingType;
using CodeBase.ResourceSystem.Abstract;
using UnityEngine;

namespace CodeBase.ResourceSystem {
    public class ResourceGenerator : MonoBehaviour {
        private ResourceGeneratorData _resourceGeneratorData;
        private float _timer;
        private float _timerMax;

        private void Awake() {
            _resourceGeneratorData = GetComponent<BuildingTypeHolder>().BuildingType.ResourceGeneratorData;
            _timerMax = _resourceGeneratorData.TimerMax;
        }

        private void Start() {
            Collider2D[] colliders =
                Physics2D.OverlapCircleAll(transform.position, _resourceGeneratorData.ResourceDetectionRadius);
            int nearbyResourceAmount = 0;

            foreach (var collider in colliders) {
                ResourceNode resourceNode = collider.GetComponent<ResourceNode>();
                if (resourceNode != null) {
                    if (resourceNode.ResourceType == _resourceGeneratorData.ResourceTypeSo) {
                        nearbyResourceAmount++;
                    }
                }
            }

            nearbyResourceAmount = Mathf.Clamp(nearbyResourceAmount, 0, _resourceGeneratorData.MaxResourceAmount);

            if (nearbyResourceAmount == 0) {
                enabled = false;
            }
            else {
                _timerMax = (_resourceGeneratorData.TimerMax / 2f) + _resourceGeneratorData.TimerMax *
                    (1 - (float)nearbyResourceAmount / _resourceGeneratorData.MaxResourceAmount);
            }

            print("nearbyResourceAmount" + nearbyResourceAmount + ";" + _timerMax);
        }


        private void Update() {
            _timer -= Time.deltaTime;
            if (_timer <= 0f) {
                _timer += _timerMax;
                ResourceSystem.Instance.AddResource(_resourceGeneratorData.ResourceTypeSo, 1);
            }
        }
    }
}