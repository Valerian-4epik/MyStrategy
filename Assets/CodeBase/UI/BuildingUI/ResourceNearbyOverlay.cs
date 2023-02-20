using CodeBase.ResourceSystem;
using CodeBase.ResourceSystem.Abstract;
using TMPro;
using UnityEngine;

namespace CodeBase.UI.BuildingUI {
    public class ResourceNearbyOverlay : MonoBehaviour {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private ResourceGeneratorData _resourceGeneratorData;

        public void Show(ResourceGeneratorData resourceGeneratorData) {
            _resourceGeneratorData = resourceGeneratorData;
            gameObject.SetActive(true);
            _spriteRenderer.sprite = _resourceGeneratorData.ResourceTypeSo.Sprite;
            int nearbyResourceAmount =
                ResourceGenerator.GetNearbyResourceAmount(_resourceGeneratorData, transform.position);
            float percent = nearbyResourceAmount / resourceGeneratorData.MaxResourceAmount;
            
            
        }

        public void Hide() {
            gameObject.SetActive(false);
        }
    }
}