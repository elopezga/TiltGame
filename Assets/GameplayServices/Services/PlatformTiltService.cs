using UnityEngine;
using UnityStories;
using TiltGame.ControllerInputServices;

namespace TiltGame.GameplayServices
{
    public class PlatformTiltService : MonoBehaviour
    {
        public StoriesHelper _controllerStoriesHelper;
        public StoriesHelper _gameplayStoriesHelper;

        [SerializeField]
        private float TiltAngleMax = 15f;

        private Vector2 _joystickLeft = Vector2.zero;
        private Vector3 _cameraForward = Vector3.zero;
        private Vector3 _cameraRight = Vector3.zero;

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

            transform.rotation = Quaternion.AngleAxis(Joystick2RotationAngle(_joystickLeft.x), -1f * projectedForward)
                * Quaternion.AngleAxis(Joystick2RotationAngle(_joystickLeft.y), projectedRight);
        }

        private float Joystick2RotationAngle(float joystickAxisValue)
        {
            float normal = Mathf.InverseLerp(-1f, 1f, joystickAxisValue);
            float lerped = Mathf.Lerp(-1f * TiltAngleMax, TiltAngleMax, normal);

            return lerped;
        }
    }
}
