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

        public void CountdownStart()
        {
            _countdownText.enabled = true;
        }

        public void CountdownStep()
        {
            --_currentCountdownValue;
            _animator.SetInteger("CurrentNumber", _currentCountdownValue);

            if (_currentCountdownValue == 0)
            {
                _countdownText.text = string.Empty;
                _countdownText.enabled = false;
                _animator.SetBool("CountdownFinished", true);
            }
            else
            {
                _countdownText.text = _currentCountdownValue.ToString();
            }

        }

        public void CountdownMessageStart()
        {
            _countdownText.enabled = true;
            _countdownText.text = _countdownMessage;
        }

        public void CountdownFinish()
        {
            _countdownText.enabled = false;
            _animator.enabled = false;
        }

        private void Awake()
        {
            _countdownText = GetComponent<Text>();
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            _currentCountdownValue = _countdownDuration;
            _animator.SetInteger("CurrentNumber", _countdownDuration);
            _countdownText.text = _currentCountdownValue.ToString(); // Todo make a model that will automatically update the view when its modified.
        }
    }
}

