using UnityEngine;

namespace Player.StateMachine
{
    public abstract class State : MonoBehaviour
    {
        [SerializeField] private Player player;
        protected Player Player => player;
        
        public abstract void Enter();
        
        public abstract void Exit();
    }
    public enum PlayerStateType
    {
        Default,
        SimpleBoosted,
        TimeBoosted,
    }
}