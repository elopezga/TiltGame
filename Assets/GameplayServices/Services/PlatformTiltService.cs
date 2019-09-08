using UnityEngine;
using UnityStories;
using TiltGame.ControllerInputServices;

namespace TiltGame.GameplayServices
{
    public class PlatformTiltService : MonoBehaviour
    {
        public StoriesHelper _storiesHelper;

        [SerializeField]
        private float TiltAngleMax = 15f;

        void Start()
        {
            _storiesHelper.Setup(gameObject, OnStoryChange);
        }

        private void OnStoryChange(Story story)
        {            
            Vector2 _joystickLeft = story.Get<Xbox360ControllerStory>().JoystickLeft;
            Vector3 _cameraForward = story.Get<GameplayCameraStory>().CameraForward;
            Vector3 _cameraRight = story.Get<GameplayCameraStory>().CameraRight;
            

            Vector3 projectedForward = Vector3.ProjectOnPlane(_cameraForward, Vector3.up);
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
