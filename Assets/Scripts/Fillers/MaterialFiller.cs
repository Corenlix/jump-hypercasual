using UnityEngine;

namespace Fillers
{
    public class MaterialFiller : Filler
    {
        [SerializeField] private Renderer[] renderers;

        public override void Fill(Color color)
        {
            foreach (var renderer in renderers)
            {
                renderer.material.color = color;
            }
        }
    }
}
