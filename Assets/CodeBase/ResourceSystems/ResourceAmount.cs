using CodeBase.Data.ResourceType;
using UnityEngine;

namespace CodeBase.ResourceSystems {
    [System.Serializable]
    public class ResourceAmount {
        [SerializeField] private ResourceTypeSo _resourceTypeSo;
        [SerializeField] private int _amount;

        public ResourceTypeSo ResourceTypeSo => _resourceTypeSo;
        public int Amount => _amount;
    }
}