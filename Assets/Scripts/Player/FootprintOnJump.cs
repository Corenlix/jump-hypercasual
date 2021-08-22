using UnityEngine;

namespace Player
{
    public class FootprintOnJump : FootprintsPool
    {
        [SerializeField] private Player player;

        private void OnPlayerJumped(Transform platform)
        {
            CreateFootprint(player.transform.position, platform);
        }
        
        private void OnEnable()
        {
            player.Jumped += OnPlayerJumped;
        }

        private void OnDisable()
        {
            player.Jumped -= OnPlayerJumped;
        }
    }
}
