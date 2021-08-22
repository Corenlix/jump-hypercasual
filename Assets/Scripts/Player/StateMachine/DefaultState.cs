using Fillers;
using UnityEngine;

namespace Player.StateMachine
{
    public class DefaultState : State
    {
        public override void Enter()
        {
            Player.Fill(ColorCategory.Player);
            Player.KillingTried += OnKillingTried;
            Player.EnteredCollision += OnEnteredCollision;
        }

        public override void Exit()
        {
            Player.KillingTried -= OnKillingTried;
            Player.EnteredCollision -= OnEnteredCollision;
        }

        private void OnKillingTried()
        {
            GameState.Instance.Lose();
        }

        private void OnEnteredCollision(Collision collision)
        {
            Player.Jump(collision.transform);
        }
    }
}