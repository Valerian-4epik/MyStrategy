using System;
using CodeBase.Data.BuildingType;
using CodeBase.ResourceSystem.Abstract;
using CodeBase.Services.Abstract;
using CodeBase.UI.BuildingUI;
using Unity.VisualScripting;
using UnityEngine;

namespace CodeBase.BuildingSystem {
    public class BuildingGhost : MonoBehaviour {
        [SerializeField] private GameObject _spriteObject;
        [SerializeField] private BuildingSystem _buildingSystem;
        [SerializeField] private Color32 _acceptColor;
        [SerializeField] private Color32 _refuseColor;

        private bool _isSearchBuildingState;
        private BuildingTypeSo _buildingType;
        private SpriteRenderer _spriteRenderer;
        private ResourceNearbyOverlay _resourceNearbyOverlay;
        
        private void Awake() {
            _resourceNearbyOverlay = GetComponentInChildren<ResourceNearbyOverlay>();
            Utils.SetupCamera(); //перенести в loadlevelState.
            Hide();
            _isSearchBuildingState = false;
            _spriteRenderer = _spriteObject.GetComponent<SpriteRenderer>();
        }

        private void Start() {
            BuildingSystem.Instance.OnActivateBuildingTypeChanged += BuildingSystem_OnActiveBuildingType;
        }

        private void LateUpdate() {
            if (_isSearchBuildingState) {
                if (_buildingSystem.CanSpawnBuilding(_buildingType, Utils.GetMouseWorldPosition())) {
                    _spriteRenderer.color = _acceptColor;
                }
                else {
                    _spriteRenderer.color = _refuseColor;
                }
            }
        }

        private void Update() {
            transform.position = Utils.GetMouseWorldPosition();
        }

        private void BuildingSystem_OnActiveBuildingType(BuildingTypeSo buildingType) {
            _buildingType = buildingType;
            var type = BuildingSystem.Instance.GetActiveBuildingType();
            Show(type.Sprite);
            _resourceNearbyOverlay.Show(type.ResourceGeneratorData);
            _isSearchBuildingState = true;
        }
        
        private void Show(Sprite sprite) {
            _spriteObject.SetActive(true);
            _spriteObject.GetComponent<SpriteRenderer>().sprite = sprite;
        }

        private void Hide() {
            _spriteObject.SetActive(false);
        }
    }
}