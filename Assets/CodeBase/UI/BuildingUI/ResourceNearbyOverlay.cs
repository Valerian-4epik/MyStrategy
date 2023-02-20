using System;
using CodeBase.ResourceSystem;
using CodeBase.ResourceSystem.Abstract;
using TMPro;
using UnityEngine;

namespace CodeBase.UI.BuildingUI {
    public class ResourceNearbyOverlay : MonoBehaviour {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private ResourceGeneratorData _resourceGeneratorData;

        private void Start() {
            Hide();
        }

        private void Update() {
            int nearbyResourceAmount =
                ResourceGenerator.GetNearbyResourceAmount(_resourceGeneratorData, transform.position);
            float percent =
                Mathf.RoundToInt((float)nearbyResourceAmount / _resourceGeneratorData.MaxResourceAmount * 100f);
            _text.text = $"{percent}%".ToString();
        }

        public void Show(ResourceGeneratorData resourceGeneratorData) {
            _resourceGeneratorData = resourceGeneratorData;
            gameObject.SetActive(true);
            _spriteRenderer.sprite = _resourceGeneratorData.ResourceTypeSo.Sprite;
        }

        public void Hide() {
            gameObject.SetActive(false);
        }
    }
}