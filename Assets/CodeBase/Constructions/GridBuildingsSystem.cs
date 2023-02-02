using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using Resources = UnityEngine.Resources;

namespace CodeBase.Constructions {
    public class GridBuildingsSystem : MonoBehaviour {
        [SerializeField] private GridLayout _gridLayout;
        [SerializeField] private Tilemap _mainTilemap;
        [SerializeField] private Tilemap _tempTilemap;

        public static GridBuildingsSystem current;
        private static Dictionary<TileType, TileBase> tileBases = new Dictionary<TileType, TileBase>();
        
        private Building _tempBuilding;
        private Vector3 _previousPosition;
        private BoundsInt _previousArea;
        private Camera _mainCamera;

        private void Awake() {
            current = this;
            _mainCamera = Camera.main;
        }

        private void Start() {
            tileBases.Add(TileType.Empty, null);
            tileBases.Add(TileType.White, Resources.Load<TileBase>("/Tiles/White"));
            tileBases.Add(TileType.Green, Resources.Load<TileBase>("/Tiles/Green"));
            tileBases.Add(TileType.Red, Resources.Load<TileBase>("/Tiles/Red"));
        }

        private void Update() {
            if (!_tempBuilding)
                return;

            if (Input.GetMouseButtonDown(0)) {
                if (EventSystem.current.IsPointerOverGameObject(0))
                    return;

                if (!_tempBuilding.Placed) {
                    Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector3Int cellPosition = _gridLayout.LocalToCell(touchPosition);

                    if (_previousPosition != cellPosition) {
                        _tempBuilding.transform.localPosition =
                            _gridLayout.CellToLocalInterpolated(cellPosition + new Vector3(0.5f, 0.5f, 0f));
                        _previousPosition = cellPosition;
                        FollowBuilding();
                    }
                }
            }
        }

        //tilemap management

        private static TileBase[] GetTilesBlock(BoundsInt area, Tilemap tilemap) {
            TileBase[] array = new TileBase[area.size.x * area.size.y * area.size.z];
            int counter = 0;

            foreach (var variable in area.allPositionsWithin) {
                Vector3Int position = new Vector3Int(variable.x, variable.y, 0);
                array[counter] = tilemap.GetTile(position);
                counter++;
            }

            return array;
        }

        private static void SetTilesBlock(BoundsInt area, TileType type, Tilemap tilemap) {
            int size = area.size.x * area.size.y * area.size.z;
            TileBase[] tileArray = new TileBase[size];
            FillTiles(tileArray, type);
            tilemap.SetTilesBlock(area, tileArray);
        }

        private static void FillTiles(TileBase[] array, TileType type) {
            for (int i = 0; i < array.Length; i++) {
                array[i] = tileBases[type];
            }
        }

        //building placement
        public void InitializeWithBuilding(GameObject building) {
            _tempBuilding = Instantiate(building, Vector3.zero, Quaternion.identity).GetComponent<Building>();
            FollowBuilding();
        }

        private void ClearArea() {
            TileBase[] toClear = new TileBase[_previousArea.size.x * _previousArea.size.y * _previousArea.size.z];
            FillTiles(toClear, TileType.Empty);
            _tempTilemap.SetTilesBlock(_previousArea, toClear);
        }

        private void FollowBuilding() {
            ClearArea();

            _tempBuilding.area.position = _gridLayout.WorldToCell(_tempBuilding.gameObject.transform.position);
            BoundsInt buildingArea = _tempBuilding.area;

            TileBase[] baseArray = GetTilesBlock(buildingArea, _mainTilemap);
            int size = baseArray.Length;
            TileBase[] tileArray = new TileBase[size];

            for (int i = 0; i < baseArray.Length; i++) {
                if (baseArray[i] == tileBases[TileType.White]) {
                    tileArray[i] = tileBases[TileType.Green];
                }
                else {
                    FillTiles(tileArray, TileType.Red);
                    break;
                }
            }
            
            _tempTilemap.SetTilesBlock(buildingArea, tileArray);
            _previousArea = buildingArea;
        }

        public bool CanTakeArea(BoundsInt area) {
            TileBase[] baseArray = GetTilesBlock(area, _mainTilemap);

            foreach (var tileBase in baseArray) {
                if (tileBase != tileBases[TileType.White]) {
                    Debug.Log("Cannot place here");
                    return false;
                }
            }

            return true;
        }
    }

    public enum TileType {
        Empty,
        White,
        Green,
        Red,
    }
}