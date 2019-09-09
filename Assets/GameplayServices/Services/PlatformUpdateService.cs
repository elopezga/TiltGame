using UnityEngine;
using UnityStories;

namespace TiltGame.GameplayServices
{
    [RequireComponent(typeof(PlatformTiltService))]
    public class PlatformUpdateService : MonoBehaviour
    {
        [SerializeField]
        private StoriesHelper _platformStoriesHelper;

        private PlatformTiltService _tiltService;

        private Vector3 _platformNormal = Vector3.zero;
        private float _platformMaxTilt = 0f;

        void Start()
        {
            _tiltService = GetComponent<PlatformTiltService>();
        }

        // Update is called once per frame
        void Update()
        {
           if (!Vector3.Equals(transform.up, _platformNormal))
           {
               _platformNormal = transform.up;
               _platformStoriesHelper.Dispatch(GameplayPlatformStory.SetPlatformNormalFactory.Get(_platformNormal));
           }

           if (_platformMaxTilt != _tiltService.TiltAngleMax)
           {
               _platformMaxTilt = _tiltService.TiltAngleMax;
               _platformStoriesHelper.Dispatch(GameplayPlatformStory.SetPlatformTiltMaxFactory.Get(_platformMaxTilt));
           }

           Debug.DrawRay(transform.position, _platformNormal);
        }
    }
}

