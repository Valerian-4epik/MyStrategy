using CodeBase.Data.ResourceType;
using TMPro;
using UnityEngine;

namespace CodeBase.UI {
    public class ResourceUISlot : MonoBehaviour {
        [SerializeField] private ResourceTypeSo _resourceType;
        [SerializeField] private TMP_Text _amountText;

        public ResourceTypeSo ResourceType => _resourceType;
        
        public void SetValue(int value) {
            _amountText.text = value.ToString();
        }
    }
}