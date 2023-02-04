using System;
using System.Collections.Generic;
using System.Resources;
using CodeBase.Data.ResourceType;
using UnityEngine;

namespace CodeBase.ResourceSystem {
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
    }
}