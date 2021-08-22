using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Player.StateMachine
{
    [RequireComponent(typeof(Player))]
    public class PlayerStateMachine : MonoBehaviour
    {
        [SerializeField] private List<StateDictionaryElement> playerStates;

        private StateDictionaryElement _currentState;
        public PlayerStateType CurrentState => _currentState.StateType;
    
        public void SetState(PlayerStateType stateType, float delay = 0.01f)
        {
            StartCoroutine(ChangeState(stateType, delay));
        }

        private IEnumerator ChangeState(PlayerStateType stateTypeType, float time)
        {
            yield return new WaitForSeconds(time);

            if (_currentState?.State)
            {
                _currentState.State.Exit();
                _currentState.State.enabled = false;
            }

            _currentState = playerStates.FirstOrDefault(x => x.StateType == stateTypeType);
            if (_currentState?.State)
            {
                _currentState.State.Enter();
                _currentState.State.enabled = true;
            }
        }

        
        private void Awake()
        {
            foreach (var stateDictionaryElement in playerStates)
            {
                stateDictionaryElement.State.enabled = false;
            }
        }

        private void Start()
        {
            SetState(PlayerStateType.Default);
        }
        
        private void OnDisable()
        {
            _currentState?.State.Exit();
        }
    }

    [Serializable]
    class StateDictionaryElement
    {
        [SerializeField] private PlayerStateType stateType;
        public PlayerStateType StateType => stateType;
    
        [SerializeField] private State state;
        public State State => state;
    }
}