using System.Collections.Generic;
using CodeBase.ResourceSystems;

namespace CodeBase.Data.TowerStatsInformation
{
    [System.Serializable]
    public class BarrackGradationByLevelData
    {
        public float SpawnCooldown;
        public int SoldierAmount;
        public List<ResourceAmount> ResourceAmount;
    }
}