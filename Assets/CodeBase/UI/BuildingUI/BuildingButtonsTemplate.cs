using CodeBase.Data.BuildingType;
using UnityEngine;

namespace CodeBase.UI.BuildingUI {
    public class BuildingButtonsTemplate : MonoBehaviour {
        [SerializeField] private BuildingSystem.BuildingSystem _buildingSystem;

        public void SetBuildingType(BuildingTypeSo buildingType) {
            _buildingSystem.SetBuildingType(buildingType);
        }
    }
}