using System.Collections;
using Fillers;
using UnityEngine;

namespace Platform
{
        [RequireComponent(typeof(Rigidbody))]
        [RequireComponent(typeof(Renderer))]
        [RequireComponent(typeof(Collider))]
        public class PlatformSegment : MonoBehaviour, ICategoryFillable
        {
                [SerializeField] private bool isKiller;
                [SerializeField] private CategoryFiller categoryFiller;
                
                private const float ExplosionForce = 10f;
                private const float ExplosionRadius = 10f;
                private const float DestroyTime = 2f;
        
                private Rigidbody _rigidbody;

                public void Explode(Vector3 explosionPosition)
                {
                        _rigidbody.isKinematic = false;
                        _rigidbody.AddExplosionForce(ExplosionForce, explosionPosition, ExplosionRadius, -1, ForceMode.VelocityChange);
                        transform.SetParent(null);
                        GetComponent<Collider>().enabled = false;
                        StartCoroutine(Deactivate(DestroyTime));
                }

                public void Fill(ColorCategory colorCategory)
                {
                        categoryFiller.Fill(colorCategory);
                }

                private IEnumerator Deactivate(float time)
                {
                        yield return new WaitForSeconds(time);
                        gameObject.SetActive(false);
                }
                
                private void OnCollisionEnter(Collision other)
                {
                        if (isKiller && other.gameObject.TryGetComponent(out Player.Player player))
                        {
                                player.TryKill();
                        }
                }
                
                private void Awake()
                {
                        _rigidbody = GetComponent<Rigidbody>();
                        if(isKiller)
                                categoryFiller.SetDefaultFillCategory(ColorCategory.Killer);
                }
                
                private void OnDrawGizmos()
                {
                        if (isKiller)
                        {
                                Gizmos.color = Color.red;
                                var renderer = GetComponent<Renderer>();
                                Gizmos.DrawCube(renderer.bounds.center, Vector3.one);
                        }
                }
        }
}