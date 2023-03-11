using UnityEngine;

namespace CodeBase.Data.TowerStatsInformation
{
    [CreateAssetMenu(fileName = "barrackInfo", menuName = "data/barrackInfo")]
    public class BarrackInformation : ScriptableObject
    {
        [SerializeField] private BarrackGradationByLevelData _level1;
        [SerializeField] private BarrackGradationByLevelData _level2;
        [SerializeField] private BarrackGradationByLevelData _level3;

        public BarrackGradationByLevelData Level1Info => _level1;
        public BarrackGradationByLevelData Level2Info => _level2;
        public BarrackGradationByLevelData Level3Info => _level3;
    }
}