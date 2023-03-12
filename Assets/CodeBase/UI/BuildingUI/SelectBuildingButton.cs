using System;
using CodeBase.Data.BuildingType;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.BuildingUI
{
    public class SelectBuildingButton : MonoBehaviour
    {
        [SerializeField] private BuildingButtonsTemplate _buttonsTemplate;
        [SerializeField] private BuildingTypeSo _buildingType;
        [SerializeField] private Image _mainIcon;
        [SerializeField] private Image _resourceIcon1;
        [SerializeField] private Image _resourceIcon2;
        [SerializeField] private TMP_Text _textCost1;
        [SerializeField] private TMP_Text _textCost2;
        [SerializeField] private Image _miningResourceIcon;

        private Button _button;

        private void Start()
        {
            _button = GetComponentInChildren<Button>();
            _button.onClick.AddListener(SetBuildingType);
            _mainIcon.sprite = _buildingType.Sprite;
            _resourceIcon1.sprite = _buildingType.ConstructionResourceCostArray[0].ResourceTypeSo.Sprite;
            _textCost1.text = _buildingType.ConstructionResourceCostArray[0].Amount.ToString();

            if (_buildingType.ConstructionResourceCostArray.Count > 1)
            {
                _resourceIcon2.gameObject.SetActive(true);
                _textCost2.gameObject.SetActive(true);
                _resourceIcon2.sprite = _buildingType.ConstructionResourceCostArray[1].ResourceTypeSo.Sprite;
                _textCost2.text = _buildingType.ConstructionResourceCostArray[1].Amount.ToString();
            }

            if (_buildingType.HasResourceGeneratorData)
            {
                _miningResourceIcon.gameObject.SetActive(true);
                _miningResourceIcon.sprite = _buildingType.ResourceGeneratorData.ResourceTypeSo.Sprite;
            }
        }

        private void SetBuildingType()
        {
            _buttonsTemplate.SetBuildingType(_buildingType);
        }
    }
}