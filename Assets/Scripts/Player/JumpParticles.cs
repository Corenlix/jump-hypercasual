using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(ParticleSystem))]
    public class JumpParticles : MonoBehaviour
    {
        [SerializeField] private Player player;
    
        private ParticleSystem _particleSystem;

        public void Fill(Color color)
        {
            var particleSystemMain = _particleSystem.main;
            particleSystemMain.startColor = color;
        }
        
        private void OnPlayerJumped(Transform platform)
        {
            _particleSystem.Play();
        }

        private void Awake()
        {
            _particleSystem = GetComponent<ParticleSystem>();
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
