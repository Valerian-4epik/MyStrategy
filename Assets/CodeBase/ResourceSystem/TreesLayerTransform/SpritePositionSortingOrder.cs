using UnityEngine;

namespace CodeBase.ResourceSystem.TreesLayerTransform {
    public class SpritePositionSortingOrder : MonoBehaviour {
        [SerializeField] private bool _runOnce;
        
        private SpriteRenderer _spriteRenderer;

        private void Awake() {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void LateUpdate() {
            float precisionMultiplier = 5f;
            _spriteRenderer.sortingOrder = (int) (-transform.position.y * precisionMultiplier);
        }
    }
}