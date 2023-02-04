using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Data.ResourceType {
    [CreateAssetMenu(fileName = "resourceTypeList", menuName = "data/resourceTypeList")]
    public class ResourceTypeListSo : ScriptableObject {
        [SerializeField] private List<ResourceTypeSo> _resourceTypeList;

        public List<ResourceTypeSo> ResourceTypeList => _resourceTypeList;
    }
}