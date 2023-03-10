using CodeBase.Data.BuildingType;
using CodeBase.Services.Abstract;
using CodeBase.UI.BuildingUI;
using UnityEngine;

namespace CodeBase.BuildingSystems
{
    public class BuildingGhost : MonoBehaviour
    {
        [SerializeField] private GameObject _spriteObject;
        [SerializeField] private BuildingSystem _buildingSystem;
        [SerializeField] private Color32 _acceptColor;
        [SerializeField] private Color32 _refuseColor;

        private bool _isSearchBuildingState;
        private BuildingTypeSo _buildingType;
        private SpriteRenderer _spriteRenderer;
        private ResourceNearbyOverlay _resourceNearbyOverlay;

        private void Awake()
        {
            _resourceNearbyOverlay = GetComponentInChildren<ResourceNearbyOverlay>();
            Utils.SetupCamera(); //перенести в loadlevelState.
            Hide();
            _isSearchBuildingState = false;
            _spriteRenderer = _spriteObject.GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            var buildingSystem = BuildingSystem.Instance;
            buildingSystem.ActivateBuildingTypeChanged += ActiveBuildingType;
            buildingSystem.DeactivateBuildingGhost += RestartBuildingType;
        }

        private void LateUpdate()
        {
            if (!_isSearchBuildingState)
                return;

            _spriteRenderer.color = _buildingSystem.CanSpawnBuilding(_buildingType, Utils.GetMouseWorldPosition()) 
                ? _acceptColor 
                : _refuseColor;
        }

        private void Update()
        {
            transform.position = Utils.GetMouseWorldPosition();
        }

        private void ActiveBuildingType(BuildingTypeSo buildingType)
        {
            _buildingType = buildingType;
            var type = BuildingSystem.Instance.GetActiveBuildingType();
            Show(type.Sprite);

            if (type.HasResourceGeneratorData)
            {
                _resourceNearbyOverlay.Show(type.ResourceGeneratorData);
                _isSearchBuildingState = true;
            }
            else
            {
                _resourceNearbyOverlay.Hide();
            }
        }

        private void Show(Sprite sprite)
        {
            _spriteObject.SetActive(true);
            _spriteObject.GetComponent<SpriteRenderer>().sprite = sprite;
        }

        private void Hide()
        {
            _spriteObject.SetActive(false);
        }

        private void RestartBuildingType()
        {
            Hide();
            _resourceNearbyOverlay.Hide();
        }
    }
}