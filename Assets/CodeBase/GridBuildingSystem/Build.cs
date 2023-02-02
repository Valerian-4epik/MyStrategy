using UnityEngine;

namespace CodeBase.GridBuildingSystem {
    public class Build : MonoBehaviour {
        public Vector2Int Size = Vector2Int.one;

        private void OnDrawGizmosSelected() {
            for (int x = 0; x < Size.x; x++) {
                for (int y = 0; y < Size.y; y++) {
                    Gizmos.color = new Color(0.88f, 0f, 1f, 0.3f);

                    Gizmos.DrawCube(transform.position + new Vector3(x, y, 0), new Vector3(1, 1, 0));
                }
            }
        }
    }
}