using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TiltGame.GameplayServices
{
    public class StateResponder : StateMachineBehaviour
    {
        public event Action<StateTypes> StateEnter;
        public event Action<StateTypes> StateUpdate;
        public event Action<StateTypes> StateExit;

        [SerializeField]
        private StateTypes _stateType;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (StateEnter != null)
            {
                
            }
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }
    }
}

