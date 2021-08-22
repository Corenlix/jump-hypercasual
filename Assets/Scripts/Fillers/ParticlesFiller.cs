using UnityEngine;

namespace Fillers
{
    public class ParticlesFiller : Filler
    {
        [SerializeField] private ParticleSystem[] particles;
        public override void Fill(Color color)
        {
            foreach (var particle in particles)
            {
                var particleMain = particle.main;
                particleMain.startColor = color;
            }
        }
    }
}
