using UnityEngine;
using UnityStories;


namespace TiltGame.GameplayServices
{
    [RequireComponent(typeof(Camera))]
    public class GameplayCameraUpdateService : MonoBehaviour
    {
        public StoriesHelper storiesHelper;

        private Vector3 CameraForward = Vector3.zero;
        private Vector3 CameraRight= Vector3.zero;

        // Update is called once per frame
        void Update()
        {
            Vector3 forward = transform.forward;
            Vector3 right = transform.right;

            if (!Vector3.Equals(forward, CameraForward))
            {
                CameraForward.x = forward.x;
                CameraForward.y = forward.y;
                CameraForward.z = forward.z;
                storiesHelper.Dispatch(GameplayCameraStory.SetCameraForwardFactory.Get(CameraForward));
            }

            if (!Vector3.Equals(right, CameraRight))
            {
                CameraRight.x = right.x;
                CameraRight.y = right.y;
                CameraRight.z = right.z;
                storiesHelper.Dispatch(GameplayCameraStory.SetCameraRightFactory.Get(CameraRight));
            }

            Debug.DrawRay(transform.position, CameraForward);
            Debug.DrawRay(transform.position, CameraRight);


        }
    }
}
