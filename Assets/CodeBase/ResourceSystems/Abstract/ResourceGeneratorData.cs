using CodeBase.Data.ResourceType;
using UnityEngine;

namespace CodeBase.ResourceSystems.Abstract {
    [System.Serializable]
    public class ResourceGeneratorData {
        public float TimerMax;
        public ResourceTypeSo ResourceTypeSo;
        public float ResourceDetectionRadius;
        public int MaxResourceAmount;
        public LayerMask _ignoreLayerMask;
    }
}