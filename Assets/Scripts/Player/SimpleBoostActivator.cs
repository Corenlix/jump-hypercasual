using System;
using Player.StateMachine;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class SimpleBoostActivator : MonoBehaviour
    {
        [SerializeField] private int explosivesCountToBoost;
        [SerializeField] private Player player;
        [SerializeField] private PlayerStateMachine playerStateMachine;
    
        private int _explosivesCounter;

        private void OnExploded()
        {
            _explosivesCounter++;
            if (_explosivesCounter >= explosivesCountToBoost && playerStateMachine.CurrentState == PlayerStateType.Default)
                playerStateMachine.SetState(PlayerStateType.SimpleBoosted);
        }

        private void OnJumped(Transform platform)
        {
            _explosivesCounter = 0;
        }
        
        private void OnEnable()
        {
            player.Exploded += OnExploded;
            player.Jumped += OnJumped;
        }

        private void OnDisable()
        {
            player.Exploded -= OnExploded;
            player.Jumped -= OnJumped;
        }
    }
}
