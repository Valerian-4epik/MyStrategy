using CodeBase.Data.ResourceType;

namespace CodeBase.ResourceSystems.Abstract {
    [System.Serializable]
    public class ResourceGeneratorData {
        public float TimerMax;
        public ResourceTypeSo ResourceTypeSo;
        public float ResourceDetectionRadius;
        public int MaxResourceAmount;
    }
}