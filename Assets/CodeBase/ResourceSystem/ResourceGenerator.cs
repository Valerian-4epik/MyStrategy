using System.Linq;
using CodeBase.BuildingSystem;
using CodeBase.ResourceSystem.Abstract;
using UnityEngine;

namespace CodeBase.ResourceSystem
{
    public class ResourceGenerator : MonoBehaviour
    {
        private ResourceGeneratorData _resourceGeneratorData;
        private float _timer;
        private float _timerMax;

        public ResourceGeneratorData ResourceGeneratorData => _resourceGeneratorData;
        public float TimerNormalized => _timer / _timerMax;
        public float AmountGeneratedPerSecond => 1 / _timerMax;

        private void Awake()
        {
            _resourceGeneratorData = GetComponent<BuildingTypeHolder>().BuildingType.ResourceGeneratorData;
            _timerMax = _resourceGeneratorData.TimerMax;
        }

        private void Start()
        {
            int nearbyResourceAmount = GetNearbyResourceAmount(_resourceGeneratorData, transform.position);

            if (nearbyResourceAmount == 0)
            {
                enabled = false;
            }
            else
            {
                _timerMax = (_resourceGeneratorData.TimerMax / 2f) + _resourceGeneratorData.TimerMax *
                    (1 - (float)nearbyResourceAmount / _resourceGeneratorData.MaxResourceAmount);
            }
        }

        private void Update()
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0f == false)
                return;

            _timer += _timerMax;
            ResourceSystem.Instance.AddResource(_resourceGeneratorData.ResourceTypeSo, 1);
        }

        public static int GetNearbyResourceAmount(ResourceGeneratorData resourceGeneratorData, Vector3 position)
        {
            Collider2D[] colliders =
                Physics2D.OverlapCircleAll(position, resourceGeneratorData.ResourceDetectionRadius);
            
            int nearbyResourceAmount = 0;

            foreach (Collider2D collider in colliders)
            {
                if (!collider.TryGetComponent(out ResourceNode resourceNode))
                    continue;

                if (resourceNode.ResourceType == resourceGeneratorData.ResourceTypeSo)
                {
                    nearbyResourceAmount++;
                }
            }

            return Mathf.Clamp(nearbyResourceAmount, 0, resourceGeneratorData.MaxResourceAmount);
        }
    }
}