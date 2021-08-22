using Fillers;
using UnityEngine;

namespace Player.StateMachine
{
    public class SimpleBoostState : State
    {
        [SerializeField] private PlayerStateMachine stateMachine;

        private void OnEnteredCollision(Collision collision)
        {
            var platform = collision.gameObject.GetComponentInParent<Platform.Platform>();
            if (platform)
            {
                platform.SuperExplode(ColorCategory.Boost);
                stateMachine.SetState(PlayerStateType.Default);
                Player.Jump(collision.transform);
                Player.Explode();
            }
        }
        
        public override void Enter()
        {
            Player.Fill(ColorCategory.Boost);
            Player.EnteredCollision += OnEnteredCollision;
        }

        public override void Exit()
        {
            Player.EnteredCollision -= OnEnteredCollision;
        }
    }
}