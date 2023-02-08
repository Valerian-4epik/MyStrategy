using CodeBase.Data.ResourceType;

namespace CodeBase.ResourceSystem.Abstract {
    [System.Serializable]
    public class ResourceGeneratorData {
        public float TimerMax;
        public ResourceTypeSo ResourceTypeSo;
        public float ResourceDetectionRadius;
        public int MaxResourceAmount;
    }
}