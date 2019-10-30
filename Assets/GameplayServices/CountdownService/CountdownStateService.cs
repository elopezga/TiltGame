using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TiltGame.GameplayServices
{
    public class CountdownStateService : MonoBehaviour
    {
        private StateEventHandler _stateEventHandler;

        // Start is called before the first frame update
        void Start()
        {
            _stateEventHandler = new StateEventHandler(); // Maybe have this as a monobehaviour and serialize variable;
            // So programmer does not have to always to this new stuff

            //_stateEventHandler.OnStateEnter.AddListener(HandleStateEnter);
            _stateEventHandler.OnStateEnter<State_WaitForStart>().AddListener(HandleStateEnterCountdown);
            // _stateEventHandler.OnStateEnter(StateType.WAITFORSTART).AddListener(HandleStateEnterCountdown); <- Viable solution; no dangling class
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        private void HandleStateEnterCountdown()
        {

        }

        private void HandleStateEnter(StateTypes. fda)
        {
            // How do you know its a WAITFORSTART event vs a COUNTDOWN event?
        }
    }
}