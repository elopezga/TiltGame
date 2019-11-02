using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TiltGame.GameplayServices
{
    public class CountdownStateService : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;

        private StateResponder _stateResponderWaitForStart;
        private StateResponder _stateResponderCountdownState; // Is there a cleaner way of doing this?

        // Start is called before the first frame update
        void Awake()
        {
            _stateResponderWaitForStart = _animator.GetStateResponder(StateTypes.WAITFORSTART);
            _stateResponderCountdownState = _animator.GetStateResponder(StateTypes.COUNTDOWN);
        }

        private void OnEnable()
        {
            _stateResponderWaitForStart.StateEnterEvent += HandleStateEnterWaitForStart;
            _stateResponderCountdownState.StateEnterEvent += HandleStateEnterCountdown;
        }

        private void OnDisable()
        {
            _stateResponderWaitForStart.StateEnterEvent -= HandleStateEnterWaitForStart;
            _stateResponderCountdownState.StateEnterEvent -= HandleStateEnterCountdown;
        }

        private void HandleStateEnterWaitForStart(StateTypes stateType)
        {
            Debug.LogError("You did it!");
        }

        private void HandleStateEnterCountdown(StateTypes stateTypes)
        {
            Debug.LogError("You did it again!");
        }
    }
}