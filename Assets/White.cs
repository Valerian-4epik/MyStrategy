using System;
using UnityEngine;

public class White : MonoBehaviour {
    [SerializeField] private Transform _startPosition;
    
    [SerializeField] private Rigidbody2D _rigidbody; 
    
    [Range(10, 30)] 
    [SerializeField] private int _testNumber;
    
    [SerializeField] private Color32 _testColor32;

    private SpriteRenderer _spriteRenderer;

    private void Start() {
        transform.position = _startPosition.position;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        _spriteRenderer.color = _testColor32;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (!other.gameObject.TryGetComponent(out Red red)) return;
        var joint = red.gameObject.GetComponent<HingeJoint2D>();
        joint.connectedBody = _rigidbody;
    }
}