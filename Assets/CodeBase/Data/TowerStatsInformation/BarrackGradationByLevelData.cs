using System.Collections.Generic;
using CodeBase.ResourceSystem;

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