using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TiltGame.GameplayServices
{
    [RequireComponent(typeof(Animator))]
    public class CountdownAnimationController : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
    }
}

