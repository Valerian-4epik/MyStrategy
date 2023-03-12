using System.Collections.Generic;
using CodeBase.ResourceSystems;

namespace CodeBase.Data.TowerStatsInformation
{
    [System.Serializable]
    public class TowerGradationByLevelData
    {
        public float AttackDistance;
        public float Damage;
        public float AttackSpeed;
        public List<ResourceAmount> ResourceAmount;
    }
}