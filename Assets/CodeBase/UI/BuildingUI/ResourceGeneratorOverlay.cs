using System;
using CodeBase.ResourceSystem;
using CodeBase.ResourceSystem.Abstract;
using TMPro;
using UnityEngine;

namespace CodeBase.UI.ResourcesUI {
    public class ResourceGeneratorOverlay : MonoBehaviour {
        [SerializeField] private SpriteRenderer _icon;
        [SerializeField] private GameObject _bar;
        [SerializeField] private TMP_Text _amountText;

        private ResourceGenerator _resourceGenerator;
        private ResourceGeneratorData _resourceGeneratorData;

        private void Awake() {
            _resourceGenerator = GetComponentInParent<ResourceGenerator>();
            _resourceGeneratorData = _resourceGenerator.ResourceGeneratorData;
        }

        private void Start() {
            _icon.sprite = _resourceGeneratorData.ResourceTypeSo.Sprite;
            _amountText.text = _resourceGenerator.GetAmountGeneratedPerSecond().ToString();
        }

        private void Update() {
            _bar.transform.localScale = new Vector3(-_resourceGenerator.GetTimerNormalized(), 1, 1);
        }
    }
}