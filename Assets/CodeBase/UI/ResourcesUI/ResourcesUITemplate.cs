using System.Collections.Generic;
using System.Linq;
using CodeBase.Data.ResourceType;
using UnityEngine;

namespace CodeBase.UI {
    public class ResourcesUITemplate : MonoBehaviour {
        [SerializeField] private List<ResourceUISlot> _slots;

        private void Start() {
            ResourceSystem.ResourceSystem.Instance.ResourceAmountChanged += TransmitInformationToSlot;
        }

        private void TransmitInformationToSlot(ResourceTypeSo type, int value) {
            var slot = GetSlot(type);
            slot.SetValue(value);
        }

        private ResourceUISlot GetSlot(ResourceTypeSo type) =>
            _slots.FirstOrDefault(slot => slot.ResourceType.Name == type.Name);
    }
}