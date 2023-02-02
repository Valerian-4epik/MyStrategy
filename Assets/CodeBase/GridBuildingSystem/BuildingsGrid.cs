using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.GridBuildingSystem {
    public class BuildingsGrid : MonoBehaviour {
        [SerializeField] private Camera mainCamera;
        public Vector2Int GridSize = new Vector2Int(10, 10);

        private Build[,] grid;
        private Build _flyingBuild;

        private void Awake() {
            grid = new Build[GridSize.x, GridSize.y];

            mainCamera = Camera.main;
        }

        public void StartPlacingBuilding(Build buildPrefab) {
            if (_flyingBuild != null) {
                Destroy(_flyingBuild.gameObject);
            }

            _flyingBuild = Instantiate(buildPrefab);
        }

        private void Update() {
            Debug.Log(mainCamera.ScreenToWorldPoint(Input.mousePosition));
            Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);


            if (_flyingBuild != null) {
                int x = Mathf.RoundToInt(mouseWorldPosition.x);
                int y = Mathf.RoundToInt(mouseWorldPosition.y);

                _flyingBuild.transform.position = new Vector2(x, y);

                if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject() == false)
                    _flyingBuild = null;

                if (Input.GetMouseButtonDown(1))
                    Destroy(_flyingBuild.gameObject);
            }
        }
    }
}