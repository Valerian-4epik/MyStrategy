using System.Linq;
using CodeBase.BuildingSystem;
using CodeBase.ResourceSystem.Abstract;
using UnityEngine;

namespace CodeBase.ResourceSystem {
    public class ResourceGenerator : MonoBehaviour {
        public static int GetNearbyResourceAmount(ResourceGeneratorData resourceGeneratorData, Vector3 position) {
            Collider2D[] colliders =
                Physics2D.OverlapCircleAll(position, resourceGeneratorData.ResourceDetectionRadius);
            int nearbyResourceAmount = colliders.Select(collider => collider.GetComponent<ResourceNode>())
                .Where(resourceNode => resourceNode != null).Count(resourceNode =>
                    resourceNode.ResourceType == resourceGeneratorData.ResourceTypeSo);

            return nearbyResourceAmount = Mathf.Clamp(nearbyResourceAmount, 0, resourceGeneratorData.MaxResourceAmount);
        }

        private ResourceGeneratorData _resourceGeneratorData;
        private float _timer;
        private float _timerMax;

        public ResourceGeneratorData ResourceGeneratorData => _resourceGeneratorData;

        private void Awake() {
            _resourceGeneratorData = GetComponent<BuildingTypeHolder>().BuildingType.ResourceGeneratorData;
            _timerMax = _resourceGeneratorData.TimerMax;
        }

        private void Start() {
            int nearbyResourceAmount = GetNearbyResourceAmount(_resourceGeneratorData, transform.position);
            
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

            if (!(_timer <= 0f)) return;
            _timer += _timerMax;
            ResourceSystem.Instance.AddResource(_resourceGeneratorData.ResourceTypeSo, 1);
        }

        public float GetTimerNormalized() => _timer / _timerMax;
        public float GetAmountGeneratedPerSecond() => 1 / _timerMax;
    }
}