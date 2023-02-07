using UnityEngine;

namespace CodeBase.Services.Abstract {
    public static class Utils {
        private static Camera _mainCamera;

        public static void SetupCamera() {
            if (_mainCamera == null) _mainCamera = Camera.main;
        }
        
        public static Vector3 GetMouseWorldPosition() {
            Vector3 mouseWorldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPosition.z = 0f;
            return mouseWorldPosition;
        }
    }
}