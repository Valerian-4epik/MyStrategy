using System;
using Cinemachine;
using TMPro;
using UnityEngine;

namespace CodeBase.Services {
    public class CameraHandler : MonoBehaviour {
        [SerializeField] private CinemachineVirtualCamera _camera;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _zoomAmount;
        [SerializeField] private float _zoomSpeed;
        [SerializeField] private float _minOrthographicSize;
        [SerializeField] private float _maxOrthographicSize;

        private float _orthographicSize;
        private float _targetOrthographicSize;

        private void Start() {
            _orthographicSize = _camera.m_Lens.OrthographicSize;
        }

        private void Update() {
            HandleMovement();
            HandleZoom();
        }

        private void HandleMovement() {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            Vector3 moveDirection = new Vector3(x, y).normalized;
            transform.position += moveDirection * _moveSpeed * Time.deltaTime;
        }

        private void HandleZoom() {
            _targetOrthographicSize += -Input.mouseScrollDelta.y * _zoomAmount;
            _targetOrthographicSize = Mathf.Clamp(_targetOrthographicSize, _minOrthographicSize, _maxOrthographicSize);
            _orthographicSize = Mathf.Lerp(_orthographicSize, _targetOrthographicSize, Time.deltaTime * _zoomSpeed);
            _camera.m_Lens.OrthographicSize = _orthographicSize;
        }
    }
}