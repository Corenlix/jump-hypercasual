using Fillers;
using UnityEngine;

namespace Platform
{
        public class FinalPlatform : Platform
        {
                public override void Explode()
                {
                }

                public override void SuperExplode(ColorCategory fillColorCategory)
                {
                        
                }
                
                private void OnTriggerEnter(Collider other)
                {
                        if (other.gameObject.TryGetComponent(out Player.Player player))
                        {
                                GameState.Instance.Pass();
                        }
                }
        }
}