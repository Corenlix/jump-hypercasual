using Fillers;
using UnityEngine;

namespace Player.StateMachine
{
    public class TimeBoostedState : State
    {
        [SerializeField] private float boostDuration;
        [SerializeField] private PlatformExploder platformExploder;
        [SerializeField] private PlayerStateMachine stateMachine;
        
        private float _boostRemainTime;

        private void Update()
        {
            _boostRemainTime -= Time.deltaTime;
            if(_boostRemainTime <= 0f)
                stateMachine.SetState(PlayerStateType.SimpleBoosted);
        }
        
        public override void Enter()
        {
            platformExploder.Activate(ColorCategory.Boost);
            _boostRemainTime = boostDuration;

            Player.Fill(ColorCategory.Boost);
        }

        public override void Exit()
        {
            platformExploder.Deactivate();
        }
        
    }
}