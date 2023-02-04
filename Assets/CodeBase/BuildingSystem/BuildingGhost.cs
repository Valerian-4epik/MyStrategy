using System;
using CodeBase.Services.Abstract;
using UnityEngine;

namespace CodeBase.BuildingSystem {
    public class BuildingGhost : MonoBehaviour {
        private GameObject _spriteObject;

        private void Awake() {
            Hide();
        }

        private void Start() {
            
        }

        private void Update() {
            transform.position = Utils.GetMouseWorldPosition();
        }

        private void Show(Sprite sprite) {
            _spriteObject.SetActive(true);
            _spriteObject.GetComponent<SpriteRenderer>().sprite = sprite;
        }

        private void Hide() {
            _spriteObject.SetActive(false);
        }
    }
}