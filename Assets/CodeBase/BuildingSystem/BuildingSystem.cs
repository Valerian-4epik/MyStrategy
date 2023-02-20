using System;
using CodeBase.Data.BuildingType;
using CodeBase.Services.Abstract;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.BuildingSystem {
    public class BuildingSystem : MonoBehaviour {
        public static BuildingSystem Instance { get; private set; }

        private BuildingTypeSo _buildingType;

        public event Action<BuildingTypeSo> OnActivateBuildingTypeChanged;

        private void Awake() {
            Instance = this;
        }

        private void Update() {
            if (!Input.GetMouseButtonDown(0) || EventSystem.current.IsPointerOverGameObject()) return;
            if (_buildingType != null && CanSpawnBuilding(_buildingType, Utils.GetMouseWorldPosition())) {
                if (ResourceSystem.ResourceSystem.Instance.CanAfford(_buildingType.ConstructionResourceCostArray)) {
                    ResourceSystem.ResourceSystem.Instance.SpendResources(_buildingType.ConstructionResourceCostArray);
                    Instantiate(_buildingType.Transform, Utils.GetMouseWorldPosition(), Quaternion.identity);
                }
            }
        }

        public void SetBuildingType(BuildingTypeSo buildingType) {
            _buildingType = buildingType;
            OnActivateBuildingTypeChanged?.Invoke(_buildingType);
        }

        public BuildingTypeSo GetActiveBuildingType() {
            return _buildingType;
        }

        public bool CanSpawnBuilding(BuildingTypeSo buildingType, Vector3 position) {
            BoxCollider2D boxCollider2D = buildingType.Prefab.GetComponent<BoxCollider2D>();
            Collider2D[] collider2DArray =
                Physics2D.OverlapBoxAll(position + (Vector3)boxCollider2D.offset, boxCollider2D.size, 0);
            bool isAreaClear = collider2DArray.Length == 0;
            if (!isAreaClear) return false;
            collider2DArray = Physics2D.OverlapCircleAll(position, buildingType.MinConstructionRadius);

            foreach (var collider in collider2DArray) {
                BuildingTypeHolder buildingTypeHolder = collider.GetComponent<BuildingTypeHolder>();
                if (buildingTypeHolder != null) {
                    if (buildingTypeHolder.BuildingType == buildingType) {
                        return false;
                    }
                }
            }

            float maxConstructionRadius = 10;
            collider2DArray = Physics2D.OverlapCircleAll(position, maxConstructionRadius);

            foreach (var collider in collider2DArray) {
                BuildingTypeHolder buildingTypeHolder = collider.GetComponent<BuildingTypeHolder>();
                if (buildingTypeHolder != null) {
                    return true;
                }
            }

            return false;
        }
    }
}