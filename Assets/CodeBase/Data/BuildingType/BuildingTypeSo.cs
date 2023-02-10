using CodeBase.ResourceSystem.Abstract;
using UnityEngine;

namespace CodeBase.Data.BuildingType {
    [CreateAssetMenu(fileName = "BuildingType", menuName = "data/buildingType")]
    public class BuildingTypeSo : ScriptableObject {
        [SerializeField] private string _name;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private Transform _transform;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private float _minConstructionRadius;
        [SerializeField] private ResourceGeneratorData _resourceGeneratorData;

        public string Name => _name;
        public Sprite Sprite => _sprite;
        public Transform Transform => _transform;
        public GameObject Prefab => _prefab;
        public float MinConstructionRadius => _minConstructionRadius;
        public ResourceGeneratorData ResourceGeneratorData => _resourceGeneratorData;
    }
}