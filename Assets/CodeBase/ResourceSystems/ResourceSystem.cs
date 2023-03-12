using System;
using System.Collections.Generic;
using CodeBase.Data.ResourceType;
using UnityEngine;

namespace CodeBase.ResourceSystems {
    public class ResourceSystem : MonoBehaviour {
        public static ResourceSystem Instance { get; private set; }

        [SerializeField] private ResourceTypeListSo _resourceTypeList;

        private Dictionary<ResourceTypeSo, int> _resourceAmountDictionary;

        public event Action<ResourceTypeSo, int> ResourceAmountChanged;

        private void Awake() {
            Instance = this;

            _resourceAmountDictionary = new Dictionary<ResourceTypeSo, int>();

            foreach (var resourceType in _resourceTypeList.ResourceTypeList) {
                _resourceAmountDictionary[resourceType] = 0;
            }
        }

        public void AddResource(ResourceTypeSo resourceType, int amount) {
            _resourceAmountDictionary[resourceType] += amount;
            ResourceAmountChanged?.Invoke(resourceType, _resourceAmountDictionary[resourceType]);
        }

        public bool CanAfford(List<ResourceAmount> resourceAmounts) {
            foreach (var amount in resourceAmounts) {
                if (_resourceAmountDictionary[amount.ResourceTypeSo] >= amount.Amount) {
                }
                else {
                    return false;
                }
            }

            return true;
        }

        public void SpendResources(List<ResourceAmount> resourceAmounts) {
            foreach (var amount in resourceAmounts) {
                _resourceAmountDictionary[amount.ResourceTypeSo] -= amount.Amount;
            }
        }
    }
}