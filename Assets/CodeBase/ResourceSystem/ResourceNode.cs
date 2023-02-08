using CodeBase.Data.ResourceType;
using UnityEngine;

namespace CodeBase.ResourceSystem {
    public class ResourceNode : MonoBehaviour {
        [SerializeField] private ResourceTypeSo _resourceType;

        public ResourceTypeSo ResourceType => _resourceType;
    }
}