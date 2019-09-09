using UnityEngine;
using UnityStories;
using TiltGame.ControllerInputServices;

namespace TiltGame.GameplayServices
{
    [RequireComponent(typeof(Rigidbody))]
    public class MovementBoostService : MonoBehaviour
    {
        [SerializeField]
        private StoriesHelper _controllerStoriesHelper;
        [SerializeField]
        private StoriesHelper _gameplayPlatformStoriesHelper;

        [SerializeField]
        private float _forceMagnitude;
        [SerializeField]
        private float _maxSpeed;

        private Rigidbody _rigidBody;
        private Vector3 _joystick3D = Vector3.zero;
        private Vector3 _platformNormal = Vector3.zero;
        private float _platformMaxTilt = 0f;

        // Start is called before the first frame update
        void Start()
        {
            _rigidBody = GetComponent<Rigidbody>();

            _controllerStoriesHelper.Setup(gameObject, OnControllerStateChange);
            _gameplayPlatformStoriesHelper.Setup(gameObject, OnPlatformStateChange);
        }

        private void OnControllerStateChange(Story story)
        {
            Vector2 joystick = story.Get<Xbox360ControllerStory>().JoystickLeft;
            _joystick3D = new Vector3(joystick.x, 0f, joystick.y);

            // Do this on velocity update
            //UpdateVelocity();
        }

        private void OnPlatformStateChange(Story story)
        {
            _platformNormal = story.Get<GameplayPlatformStory>().PlatformNormal;
            _platformMaxTilt = story.Get<GameplayPlatformStory>().PlatformTiltMax;

            // Do this on velocity update
            //UpdateVelocity();
        }

        private void FixedUpdate()
        {
            UpdateVelocity();
        }

        /* private void UpdateVelocity()
        {
            Vector3 direction = Vector3.ProjectOnPlane(_joystick3D, _platformNormal);
            float tiltVelocityQuantifier = Vector3.Cross(Vector3.up, _platformNormal).magnitude;
            float tiltVelocityNormalized = Mathf.InverseLerp(0f, 15f, tiltVelocityQuantifier); // Use max angle allowed
            float velocityMagnitude = Mathf.Lerp(0f, _maxSpeed, tiltVelocityNormalized);
            _rigidBody.velocity = direction * velocityMagnitude;

            Debug.DrawRay(transform.position, _rigidBody.velocity);
        } */

        private void UpdateVelocity()
        {
            Vector3 force = Vector3.ProjectOnPlane(_joystick3D, _platformNormal);
            float forceMagnitudeBasedOnTilt = Vector3.Cross(Vector3.up, _platformNormal).magnitude;
            float forceMagnitudeNormalized = Mathf.InverseLerp(0f, 1f, forceMagnitudeBasedOnTilt);
            float forceMagnitudeToApply = Mathf.Lerp(0f, _platformMaxTilt, forceMagnitudeNormalized);
            float ass1 = Mathf.InverseLerp(0f, 1f, forceMagnitudeToApply);
            float ass2 = Mathf.Lerp(0, _maxSpeed, ass1);
            //float forceMagnitudeNormalized = Mathf.InverseLerp(0f, 0.2f, forceMagnitudeBasedOnTilt); // <-- Need to be max angle allowed to tilt
            //float forceMagnitudeToApply = Mathf.Lerp(0f, _maxSpeed, forceMagnitudeNormalized);
            _rigidBody.AddForce(force * ass2);

            // Don't exceed max speed
            //_rigidBody.velocity = Vector3.ClampMagnitude(_rigidBody.velocity, _maxSpeed);

            Debug.DrawRay(transform.position, force * ass2);
        }
    }
}