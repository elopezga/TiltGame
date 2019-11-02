using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace TiltGame.GameplayServices
{
    public static class AnimatorExtensions
    {
        public static StateResponder GetStateResponder(this Animator animator, StateTypes stateType)
        {
            return animator.GetBehaviours<StateResponder>().ToList().First(behavior => behavior.StateType.Equals(stateType));
        }
    }
}