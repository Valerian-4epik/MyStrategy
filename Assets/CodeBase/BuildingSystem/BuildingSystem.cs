using System;
using CodeBase.Data.BuildingType;
using CodeBase.Services.Abstract;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.BuildingSystem {
    public class BuildingSystem : MonoBehaviour {
        private BuildingTypeSo _buildingType;

        public event Action<BuildingTypeSo> OnActivateBuildingTypeChanged;

        private void Update() {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
                if (_buildingType != null) {
                    Instantiate(_buildingType.Transform, Utils.GetMouseWorldPosition(), Quaternion.identity);
                }
            }
        }

        public void SetBuildingType(BuildingTypeSo buildingType) {
            _buildingType = buildingType;
            OnActivateBuildingTypeChanged?.Invoke(_buildingType);
        }
    }
}