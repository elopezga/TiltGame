using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TiltGame.GameplayServices
{
    public class StateResponder : StateMachineBehaviour
    {
        public event Action<StateTypes> StateEnterEvent;
        public event Action<StateTypes> StateUpdateEvent;
        public event Action<StateTypes> StateExitEvent;

        public StateTypes StateType {
            get { return _stateType; }
        }

        [SerializeField]
        private StateTypes _stateType;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (StateEnterEvent != null)
            {
                StateEnterEvent.Invoke(_stateType);
            }
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (StateUpdateEvent != null)
            {
                StateUpdateEvent.Invoke(_stateType);
            }
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (StateExitEvent != null)
            {
                StateExitEvent.Invoke(_stateType);
            }
        }
    }
}

