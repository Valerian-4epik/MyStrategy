using System.Collections.Generic;
using CodeBase.ResourceSystem;
using CodeBase.ResourceSystem.Abstract;
using UnityEngine;

namespace CodeBase.Data.BuildingType
{
    [CreateAssetMenu(fileName = "BuildingType", menuName = "data/buildingType")]
    public class BuildingTypeSo : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private Transform _transform;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private bool _hasResourceGeneratorData;
        [SerializeField] private ResourceGeneratorData _resourceGeneratorData;
        [SerializeField] private float _minConstructionRadius;
        [SerializeField] private List<ResourceAmount> _constructionResourceCostArray;
        [SerializeField] private int _healthAmount;

        public string Name => _name;
        public Sprite Sprite => _sprite;
        public Transform Transform => _transform;
        public GameObject Prefab => _prefab;
        public bool HasResourceGeneratorData => _hasResourceGeneratorData;
        public ResourceGeneratorData ResourceGeneratorData => _resourceGeneratorData;
        public float MinConstructionRadius => _minConstructionRadius;
        public List<ResourceAmount> ConstructionResourceCostArray => _constructionResourceCostArray;
        public int HealthAmount => _healthAmount;
    }
}