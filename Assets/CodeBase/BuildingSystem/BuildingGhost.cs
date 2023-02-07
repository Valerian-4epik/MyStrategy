using System;
using CodeBase.Data.BuildingType;
using CodeBase.Services.Abstract;
using UnityEngine;

namespace CodeBase.BuildingSystem {
    public class BuildingGhost : MonoBehaviour {
        [SerializeField] private GameObject _spriteObject;
        
        private void Awake() {
            Utils.SetupCamera(); //перенести в loadlevelState.
            Hide();
        }

        private void Start() {
            BuildingSystem.Instance.OnActivateBuildingTypeChanged += BuildingSystem_OnActiveBuildingType;
        }

        private void Update() {
            transform.position = Utils.GetMouseWorldPosition();
        }

        private void BuildingSystem_OnActiveBuildingType(BuildingTypeSo buildingType) {
            var type = BuildingSystem.Instance.GetActiveBuildingType();
            Show(type.Sprite);
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