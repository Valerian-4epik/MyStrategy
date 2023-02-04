using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Data.BuildingType {
    [CreateAssetMenu(fileName = "buildingTypeList", menuName = "data/buildingTypeList")]
    public class BuildingTypeListSo : ScriptableObject {
        [SerializeField] private List<BuildingTypeSo> _buildingTypeList;

        public List<BuildingTypeSo> BuildingTypeSos => _buildingTypeList;
    }
}