using System;
using Fillers;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class Player : MonoBehaviour, ICategoryFillable
    {
        public event Action<Transform> Jumped;
        public event Action Exploded;
        public event Action KillingTried;
        public event Action<Collision> EnteredCollision;
        
        [SerializeField] private float jumpVelocity;
        [SerializeField] private CategoryFiller playerFiller;
        [SerializeField] private FootprintsPool footprintsPool;
        
        private Rigidbody _rigidbody;
            
        public void Jump(Transform fromPlatform)
        {
            _rigidbody.velocity = Vector2.up * jumpVelocity;
            Jumped?.Invoke(fromPlatform);
        }
        
        public void TryKill()
        {
            KillingTried?.Invoke();
        }

        public void Explode()
        {
            Exploded?.Invoke();
        }
        
        private void OnCollisionEnter(Collision other)
        {
            EnteredCollision?.Invoke(other);
        }
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Fill(ColorCategory colorCategory)
        {
            playerFiller.Fill(colorCategory);
            footprintsPool.Fill(colorCategory);
        }
    }
}