using Fillers;
using UnityEngine;

namespace Platform
{
    public class Platform : MonoBehaviour, ICategoryFillable
    {
        [SerializeField] private ParticleSystem superExplodeParticles;
        [SerializeField] private CategoryFiller filler;
        private PlatformSegment[] _platformSegments;
        
        public virtual void Explode()
        {
            foreach (var platformSegment in _platformSegments)
            {
                platformSegment.Explode(transform.position);
            }
            Destroy(gameObject);
        }

        public virtual void SuperExplode(ColorCategory fillColorCategory)
        {
            Fill(fillColorCategory);
            filler.Fill(fillColorCategory);
            superExplodeParticles.Play();
            superExplodeParticles.transform.SetParent(null);
            
            Explode();
        }
        
        public void Fill(ColorCategory colorCategory)
        {
            foreach (var platformSegment in _platformSegments)
            {
                platformSegment.Fill(colorCategory);
            }
        }
        
        private void Awake()
        {
            _platformSegments = GetComponentsInChildren<PlatformSegment>();
        }
    }
}