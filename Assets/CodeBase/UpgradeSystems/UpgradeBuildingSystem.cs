using System;
using CodeBase.Constructions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.UpgradeSystems
{
    public class UpgradeBuildingSystem : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Building _nextBuilding;

        public void CreateBuilding()
        {
            if (_nextBuilding != null)
            {
                Instantiate(_nextBuilding.gameObject, _transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }

        public void DestroyBuilding()
        {
            Destroy(gameObject);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            print("нажал");
        }
    }
}