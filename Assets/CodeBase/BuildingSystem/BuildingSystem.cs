using System;
using CodeBase.Constructions;
using CodeBase.Data.BuildingType;
using CodeBase.Services.Abstract;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.BuildingSystem
{
    public class BuildingSystem : MonoBehaviour
    {
        [SerializeField] private Building _castle;

        private BuildingTypeSo _buildingType;
        private bool _buildingSelected;
        
        public event Action<BuildingTypeSo> OnActivateBuildingTypeChanged;

        public static BuildingSystem Instance { get; private set; }
        public Building Castle => _castle;

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            TryBuild();
        }

        private void TryBuild()
        {
            if (Input.GetMouseButtonDown(0) == false || EventSystem.current.IsPointerOverGameObject())
                return;

            if (_buildingSelected == false || CanSpawnBuilding(_buildingType, Utils.GetMouseWorldPosition()) == false)
                return;

            if (ResourceSystem.ResourceSystem.Instance.CanAfford(_buildingType.ConstructionResourceCostArray) == false)
                return;

            ResourceSystem.ResourceSystem.Instance.SpendResources(_buildingType.ConstructionResourceCostArray);
            Instantiate(_buildingType.Transform, Utils.GetMouseWorldPosition(), Quaternion.identity);
        }

        public void SetBuildingType(BuildingTypeSo buildingType)
        {
            _buildingType = buildingType;
            OnActivateBuildingTypeChanged?.Invoke(_buildingType);
            _buildingSelected = true;
        }

        public BuildingTypeSo GetActiveBuildingType()
        {
            return _buildingType;
        }

        public bool CanSpawnBuilding(BuildingTypeSo buildingType, Vector3 position)
        {
            if (buildingType.Prefab.TryGetComponent(out BoxCollider2D boxCollider2D) == false)
                return false;

            Collider2D[] collider2DArray = Physics2D.OverlapBoxAll(position + (Vector3)boxCollider2D.offset, boxCollider2D.size, 0);

            bool isAreaClear = collider2DArray.Length == 0;
            
            if (isAreaClear == false)
                return false;

            collider2DArray = Physics2D.OverlapCircleAll(position, buildingType.MinConstructionRadius);

            foreach (Collider2D collider in collider2DArray)
            {
                if (collider.TryGetComponent(out BuildingTypeHolder buildingTypeHolder) == false)
                    continue;

                if (buildingTypeHolder.BuildingType == buildingType)
                {
                    return false;
                }
            }

            float maxConstructionRadius = 10;
            collider2DArray = Physics2D.OverlapCircleAll(position, maxConstructionRadius);

            foreach (Collider2D collider in collider2DArray)
            {
                if (collider.TryGetComponent(out BuildingTypeHolder buildingTypeHolder))
                {
                    return true;
                }
            }

            return false;
        }
    }
}