using TMPro;
using UnityEngine;

namespace CodeBase.Data.ResourceType {
    [CreateAssetMenu(fileName = "resourceType", menuName = "data/resourceType")]
    public class ResourceTypeSo : ScriptableObject {
        [SerializeField] private string _name;
        [SerializeField] private Sprite _sprite;

        public string Name => _name;
        public Sprite Sprite => _sprite;
    }
}