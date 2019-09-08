using UnityEngine;
using UnityStories;

namespace TiltGame.GameplayServices
{
    [CreateAssetMenu(menuName="TiltGame/GameplayServices/Gameplay Camera Story")]
    public class GameplayCameraStory : Story
    {
        public Vector3 CameraForward = Vector3.zero;
        public Vector3 CameraRight = Vector3.zero;

        public override void InitStory()
        {
            CameraForward = Vector3.zero;
            CameraRight = Vector3.zero;
        }

        #region Actions & Action Factories
        public class SetCameraForward : GenericAction<GameplayCameraStory, Vector3>
        {
            public override void Action(GameplayCameraStory story, Vector3 value)
            {
                story.CameraForward.x = value.x;
                story.CameraForward.y = value.y;
                story.CameraForward.y = value.z;
            }
        }
        public static GenericFactory<SetCameraForward, GameplayCameraStory, Vector3> SetCameraForwardFactory = new GenericFactory<SetCameraForward, GameplayCameraStory, Vector3>();

        public class SetCameraRight : GenericAction<GameplayCameraStory, Vector3>
        {
            public override void Action(GameplayCameraStory story, Vector3 value)
            {
                story.CameraRight.x = value.x;
                story.CameraRight.y = value.y;
                story.CameraRight.z = value.z;
            }
        }
        public static GenericFactory<SetCameraRight, GameplayCameraStory, Vector3> SetCameraRightFactory = new GenericFactory<SetCameraRight, GameplayCameraStory, Vector3>();
        #endregion
    }
}