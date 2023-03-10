using UnityEngine;

namespace CodeBase.Data.TowerStatsInformation
{
    [CreateAssetMenu(fileName = "towerInfo", menuName = "data/towerInfo")]
    public class TowerInformation : ScriptableObject
    {
        [SerializeField] private TowerGradationByLevelData _level1;
        [SerializeField] private TowerGradationByLevelData _level2;
        [SerializeField] private TowerGradationByLevelData _level3;

        public TowerGradationByLevelData Level1Info => _level1;
        public TowerGradationByLevelData Level2Info => _level2;
        public TowerGradationByLevelData Level3Info => _level3;
    }
}