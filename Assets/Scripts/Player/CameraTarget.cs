using System;
using UnityEngine;

namespace Player
{
    public class CameraTarget : MonoBehaviour
    {
        [SerializeField] private Vector3 offset;
        private Transform _cameraTransform;
    
        private void UpdatePosition()
        {
            _cameraTransform.position = transform.position + offset;
        }
        
        private void Update()
        {
            if (_cameraTransform.position.y > transform.position.y + offset.y)
                UpdatePosition();
        }

        private void Awake()
        {
            _cameraTransform = Camera.main.transform;
        }

        private void Start()
        {
            UpdatePosition();
        }
    }
}
