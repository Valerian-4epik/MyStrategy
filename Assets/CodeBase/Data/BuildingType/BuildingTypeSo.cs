using CodeBase.ResourceSystem.Abstract;
using UnityEngine;

namespace CodeBase.Data.BuildingType {
    [CreateAssetMenu(fileName = "BuildingType", menuName = "data/buildingType")]
    public class BuildingTypeSo : ScriptableObject {
        [SerializeField] private string _name;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private Transform _transform;
        [SerializeField] private ResourceGeneratorData _resourceGeneratorData;

        public string Name => _name;
        public Sprite Sprite => _sprite;
        public Transform Transform => _transform;
        public ResourceGeneratorData ResourceGeneratorData => _resourceGeneratorData;
    }
}