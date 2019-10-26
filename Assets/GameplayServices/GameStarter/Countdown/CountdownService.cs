using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TiltGame.GameplayServices
{
    [RequireComponent(typeof(Animator), typeof(Text))]
    public class CountdownService : MonoBehaviour
    {
        [SerializeField]
        private int _countdownDuration = 3;
        [SerializeField]
        private string _countdownMessage = "START!";

        private Animator _animator;
        private AnimationClip _animationClip;
        private Text _countdownText;

        private int _currentCountdownValue = 0;

        public void CountdownStep()
        {
            --_currentCountdownValue;
            Debug.LogError(_currentCountdownValue);
            _animator.SetInteger("CurrentNumber", _currentCountdownValue);

            _countdownText.text = _currentCountdownValue.ToString();
        }

        private void Awake()
        {
            _countdownText = GetComponent<Text>();

            _animator = GetComponent<Animator>();
            AnimatorClipInfo clipInfo = _animator.GetCurrentAnimatorClipInfo(0)[0];
            _animationClip = clipInfo.clip;

            if (_animationClip == null)
            {
                Debug.LogError("No animation clip found :/");
                return;
            }

            AnimationEvent[] events = _animationClip.events;
            AnimationEvent endEvent = events[0];

            if (endEvent == null)
            {
                Debug.LogError("No animation event found :/");
                return;
            }

            Debug.LogError(endEvent.functionName);
            endEvent.intParameter = _countdownDuration;

        }

        private void Start()
        {
            _currentCountdownValue = _countdownDuration;
            _animator.SetInteger("CurrentNumber", _countdownDuration);
            _countdownText.text = _currentCountdownValue.ToString(); // Todo make a model that will automatically update the view when its modified.
        }
    }
}

