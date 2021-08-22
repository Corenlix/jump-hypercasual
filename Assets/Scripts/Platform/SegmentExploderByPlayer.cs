using UnityEngine;

namespace Platform
{
    [RequireComponent(typeof(Collider))]
    public class SegmentExploderByPlayer : MonoBehaviour
    {
        [SerializeField] private Platform explodingPlatform;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player.Player player) && explodingPlatform)
            {
                explodingPlatform.Explode();
                player.Explode();
            }
        }
    }
}
