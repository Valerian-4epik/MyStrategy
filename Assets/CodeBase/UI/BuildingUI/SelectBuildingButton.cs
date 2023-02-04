using System;
using CodeBase.Data.BuildingType;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.BuildingUI {
    public class SelectBuildingButton : MonoBehaviour {
        [SerializeField] private BuildingButtonsTemplate _buttonsTemplate;
        [SerializeField] private BuildingTypeSo _buildingType;

        private Button _button;

        private void Start() {
            _button = GetComponentInChildren<Button>();
            _button.onClick.AddListener(SetBuildingType);
        }

        private void SetBuildingType() {
            _buttonsTemplate.SetBuildingType(_buildingType);
        }
    }
}