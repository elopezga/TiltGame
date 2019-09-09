using UnityEngine;
using UnityStories;

namespace TiltGame.GameplayServices
{
    [CreateAssetMenu(menuName="TiltGame/GameplayServices/Gameplay Platform Story")]
    public class GameplayPlatformStory : Story
    {
        public Vector3 PlatformNormal;
        public float PlatformTiltMax;

        public override void InitStory()
        {
            PlatformNormal = Vector3.zero;
            PlatformTiltMax = 0f;
        }

        #region Actions & Action Factories
        public class SetPlatformNormal : GenericAction<GameplayPlatformStory, Vector3>
        {
            public override void Action(GameplayPlatformStory story, Vector3 value)
            {
                story.PlatformNormal.x = value.x;
                story.PlatformNormal.y = value.y;
                story.PlatformNormal.z = value.z;
            }
        }
        public static GenericFactory<SetPlatformNormal, GameplayPlatformStory, Vector3> SetPlatformNormalFactory = new GenericFactory<SetPlatformNormal, GameplayPlatformStory, Vector3>();

        public class SetPlatformTiltMax : GenericAction<GameplayPlatformStory, float>
        {
            public override void Action(GameplayPlatformStory story, float value)
            {
                story.PlatformTiltMax = value;
            }
        }
        public static GenericFactory<SetPlatformTiltMax, GameplayPlatformStory, float> SetPlatformTiltMaxFactory = new GenericFactory<SetPlatformTiltMax, GameplayPlatformStory, float>();
        #endregion
    }
}
