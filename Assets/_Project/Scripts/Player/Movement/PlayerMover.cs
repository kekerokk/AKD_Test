using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerMover : MonoBehaviour {
    [SerializeField] Rigidbody _rb;
    [SerializeField] Transform _camera;

    [SerializeField] float _moveSpeed = 5f, _horizontalRotationSpeed = 120f, _verticalRotationSpeed = 30f;
    [SerializeField] float _maxVerticalCameraAngle = 45f;
    
    // [Inject]
    IMovementInput _input;

    float _cameraAngle;

    [Inject]
    void Init(IMovementInput movementInput) {
        _input = movementInput;
    }

    void FixedUpdate() {
        _rb.velocity = transform.forward * (_input.move.y * _moveSpeed) + transform.right * (_input.move.x * _moveSpeed);
    }

    void Update() {
        transform.rotation *= Quaternion.AngleAxis(_input.look.x * _horizontalRotationSpeed * Time.deltaTime, Vector3.up);

        _cameraAngle += -_input.look.y * _verticalRotationSpeed * Time.deltaTime;
        _cameraAngle = Mathf.Clamp(_cameraAngle, -_maxVerticalCameraAngle, _maxVerticalCameraAngle);
        _camera.localRotation = Quaternion.Euler(_cameraAngle, _camera.rotation.y, _camera.rotation.z);
    }
}
