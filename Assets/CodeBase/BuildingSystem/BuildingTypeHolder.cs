using CodeBase.Data.BuildingType;
using UnityEngine;

namespace CodeBase.BuildingSystem {
    public class BuildingTypeHolder : MonoBehaviour {
        [SerializeField] private BuildingTypeSo _buildingType;

        public BuildingTypeSo BuildingType => _buildingType;

        private void OnDrawGizmos() {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, _buildingType.MinConstructionRadius);
        }
    }
}