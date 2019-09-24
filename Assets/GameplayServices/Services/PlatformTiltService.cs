﻿using System.Collections;
using UnityEngine;
using UnityStories;
using TiltGame.ControllerInputServices;

namespace TiltGame.GameplayServices
{
    public class PlatformTiltService : MonoBehaviour
    {
        public StoriesHelper _controllerStoriesHelper;
        public StoriesHelper _gameplayStoriesHelper;
        public float TiltAngleMax = 15f;
        public float TiltSlerpDuration = 0.2f;

        private Vector2 _joystickLeft = Vector2.zero;
        private Vector3 _cameraForward = Vector3.zero;
        private Vector3 _cameraRight = Vector3.zero;

        // State
        private Quaternion _targetRotation = Quaternion.identity;
        private IEnumerator _tiltSlerpCoroutine = null;

        void Start()
        {
            _controllerStoriesHelper.Setup(gameObject, OnControllerStateChange);
            _gameplayStoriesHelper.Setup(gameObject, OnGameplayStateChange);
        }

        private void OnControllerStateChange(Story story)
        {
            _joystickLeft = story.Get<Xbox360ControllerStory>().JoystickLeft;
            UpdateTilt();
        }

        private void OnGameplayStateChange(Story story)
        {
            _cameraForward = story.Get<GameplayCameraStory>().CameraForward;
            _cameraRight = story.Get<GameplayCameraStory>().CameraRight;
            UpdateTilt();
        }

        private void UpdateTilt()
        {
            Vector3 projectedForward = Vector3.Cross(_cameraRight, Vector3.up); // Project on plane does not work for some reason
            Vector3 projectedRight = Vector3.ProjectOnPlane(_cameraRight, Vector3.up);

            // Do Slerp for smoother movement
            /* transform.rotation = Quaternion.AngleAxis(Joystick2RotationAngle(_joystickLeft.x), -1f * projectedForward)
                * Quaternion.AngleAxis(Joystick2RotationAngle(_joystickLeft.y), projectedRight); */

            _targetRotation = Quaternion.AngleAxis(Joystick2RotationAngle(_joystickLeft.x), -1f * projectedForward)
                * Quaternion.AngleAxis(Joystick2RotationAngle(_joystickLeft.y), projectedRight);

            // Only have one tilt slerp coroutine. Any input updates within the running coroutine will be processed within the same tilt slerp.
            // Treat this as batch slerping inputs.
            // Not a good solution because last minute input change withing already running coroutine will cause it to snap in that direction.
            if (_tiltSlerpCoroutine == null)
            {
                _tiltSlerpCoroutine = TiltSlerp();
                StartCoroutine(_tiltSlerpCoroutine);
            }            

            //transform.rotation = Quaternion.Slerp(sourceRotation, targetRotation, )
        }

        private IEnumerator TiltSlerp()
        {
            float elapsedTime = 0f;
            Quaternion sourceRotation = transform.rotation;

            while (elapsedTime < TiltSlerpDuration)
            {
                elapsedTime += Time.deltaTime;
                transform.rotation = Quaternion.Slerp(sourceRotation, _targetRotation, Mathf.InverseLerp(0f, TiltSlerpDuration, elapsedTime));

                yield return 0f;
            }

            _tiltSlerpCoroutine = null;
        }

        private float Joystick2RotationAngle(float joystickAxisValue)
        {
            float normal = Mathf.InverseLerp(-1f, 1f, joystickAxisValue);
            float lerped = Mathf.Lerp(-1f * TiltAngleMax, TiltAngleMax, normal);

            return lerped;
        }
    }
}
