using UnityEngine;

namespace Fillers
{
    public class CameraFiller : Filler
    {
        [SerializeField] private Camera camera;
        public override void Fill(Color color)
        {
            camera.backgroundColor = color;
        }
    }
}