using Fillers;
using UnityEngine;

namespace Player
{
    public class FootprintsPool : MonoBehaviour, ICategoryFillable
    {
        [SerializeField] private Footprint footprintTemplate;
        [SerializeField] private int footprintsMaxCount;

        private Footprint[] _footprints;
        private int _currentFootprintIndex;
        
        protected void CreateFootprint(Vector3 position, Transform trailParent)
        {
            var trail = _footprints[_currentFootprintIndex];
            _currentFootprintIndex = (_currentFootprintIndex + 1) % _footprints.Length;

            trail.transform.position = position;
            trail.transform.rotation = Quaternion.identity;
            trail.transform.SetParent(trailParent);
            trail.gameObject.SetActive(true);
        }
        
        private void Awake()
        {
            InitPool();
        }
    
        private void InitPool()
        {
            _footprints = new Footprint[footprintsMaxCount];
            for (int i = 0; i < footprintsMaxCount; i++)
            {
                var spawnedFootprint = Instantiate(footprintTemplate, transform);
                spawnedFootprint.gameObject.SetActive(false);
                _footprints[i] = spawnedFootprint;
            }
        }

        public void Fill(ColorCategory colorCategory)
        {
            foreach (var footprint in _footprints)
            {
                footprint.Fill(colorCategory);
            }
        }
    }
}
