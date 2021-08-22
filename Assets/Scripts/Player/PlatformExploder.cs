using Fillers;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Collider))]
    public class PlatformExploder : MonoBehaviour
    {
        [SerializeField] private Player player;
        private ColorCategory _fillColorCategory;
        
        public void Activate(ColorCategory fillColorCategory)
        {
            _fillColorCategory = fillColorCategory;
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            var platform = other.GetComponentInParent<Platform.Platform>();
            if (platform)
            {
                platform.SuperExplode(_fillColorCategory);
                player.Explode();
            }
        }
    }
}
