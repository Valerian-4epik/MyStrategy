using System;
using CodeBase.BuildingSystems;
using CodeBase.Constructions;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CodeBase.UpgradeSystems
{
    public class UpgradeBuildingSystem : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private BuildingTypeHolder _nextBuilding;
        [SerializeField] private Image _mainIcon;
        [SerializeField] private GameObject _upgradeButton;
        [SerializeField] private GameObject _resourceSlot;
        [SerializeField] private Image _resourceIcon1;
        [SerializeField] private Image _resourceIcon2;
        [SerializeField] private TMP_Text _textCost1;
        [SerializeField] private TMP_Text _textCost2;

        private void Start()
        {
            if (_nextBuilding != null)
            {
                _resourceIcon1.sprite =
                    _nextBuilding.BuildingType.ConstructionResourceCostArray[0].ResourceTypeSo.Sprite;
                _textCost1.text = _nextBuilding.BuildingType.ConstructionResourceCostArray[0].Amount.ToString();

                if (_nextBuilding.BuildingType.ConstructionResourceCostArray.Count > 1)
                {
                    _resourceSlot.gameObject.SetActive(true);
                    _resourceIcon2.gameObject.SetActive(true);
                    _textCost2.gameObject.SetActive(true);
                    _resourceIcon2.sprite = _nextBuilding.BuildingType.ConstructionResourceCostArray[1].ResourceTypeSo
                        .Sprite;
                    _textCost2.text = _nextBuilding.BuildingType.ConstructionResourceCostArray[1].Amount.ToString();
                }
            }
            else
            {
                _upgradeButton.gameObject.SetActive(false);
            }
        }

        public void CreateBuilding()
        {
            Instantiate(_nextBuilding.gameObject, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        public void DestroyBuilding()
        {
            Destroy(gameObject);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            throw new NotImplementedException();
        }
    }
}