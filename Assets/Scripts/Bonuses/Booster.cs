using Player.StateMachine;
using UnityEngine;

namespace Bonuses
{
    [RequireComponent(typeof(Collider))]
    public class Booster : Bonus
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerStateMachine player))
            {
                player.SetState(PlayerStateType.TimeBoosted);
                Destroy(gameObject);
            }
        }
    }
}
