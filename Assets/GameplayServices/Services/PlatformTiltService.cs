using System.Collections;
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

            // Cancel current slerp and restart with current source position
            if (_tiltSlerpCoroutine != null)
            {
                StopCoroutine(_tiltSlerpCoroutine);
            }
            _tiltSlerpCoroutine = TiltSlerp(projectedForward, projectedRight);
            StartCoroutine(_tiltSlerpCoroutine);

        }

        private IEnumerator TiltSlerp(Vector3 projectedForward, Vector3 projectedRight)
        {
            float elapsedTime = 0f;
            Quaternion sourceRotation = transform.rotation;
            Quaternion targetRotation = Quaternion.AngleAxis(Joystick2RotationAngle(_joystickLeft.x), -1f * projectedForward)
                * Quaternion.AngleAxis(Joystick2RotationAngle(_joystickLeft.y), projectedRight);

            while (elapsedTime < TiltSlerpDuration)
            {
                elapsedTime += Time.fixedDeltaTime;
                transform.rotation = Quaternion.Slerp(sourceRotation, targetRotation, Mathf.InverseLerp(0f, TiltSlerpDuration, elapsedTime));

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
