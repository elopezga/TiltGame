using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TiltGame.GameplayServices
{
    /* [CreateAssetMenu(fileName = "State Types", menuName = "TiltGame/GameplayServices/StateType")]
    public class StateTypes : ScriptableObject
    {
        public enum States
        {
            WAITFORSTART,
            COUNTDOWN
        }

        [SerializeField]
        private List<States> _statesList = new List<States>();
    } */

    public enum StateTypes
    {
        WAITFORSTART,
        COUNTDOWN
    }

    public class State_WaitForStart {}
}