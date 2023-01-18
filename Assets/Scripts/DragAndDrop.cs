using UnityEngine;

public class DragAndDrop : MonoBehaviour {
    private Camera _camera;

    private void Start() {
        _camera = Camera.main;
    }

    private void OnMouseDrag() {
        float distanceToScreen = _camera.WorldToScreenPoint(gameObject.transform.position).y;
        transform.position =
            _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, -distanceToScreen, Input.mousePosition.z));
    }

    private void OnMouseUpAsButton() {
    }
}