using UnityEngine;
using UnityStories;

namespace TiltGame.ControllerInputServices
{
   [CreateAssetMenu(menuName="TiltGame/ControllerInputServices/Xbox 360 Controller Story")]
    public class Xbox360ControllerStory : Story
    {
        public Vector2 JoystickLeft = Vector2.zero;
        public Vector2 JoystickRight = Vector2.zero;

        public override void InitStory()
        {
            JoystickLeft = Vector2.zero;
            JoystickRight = Vector2.zero;
        }

        // Actions / Factories
        #region Actions & Action Factories
        public class SetJoystickLeft : GenericAction<Xbox360ControllerStory, Vector2>
        {
            public override void Action(Xbox360ControllerStory story, Vector2 value)
            {
                // Avoids using new Vector3 to not produce garbage
                story.JoystickLeft.x = value.x;
                story.JoystickLeft.y = value.y;
            }
        }
        public static GenericFactory<SetJoystickLeft, Xbox360ControllerStory, Vector2> SetJoystickLeftFactory = new GenericFactory<SetJoystickLeft, Xbox360ControllerStory, Vector2>();

        public class SetJoystickRight : GenericAction<Xbox360ControllerStory, Vector2>
        {
            public override void Action(Xbox360ControllerStory story, Vector2 value)
            {
                // Avoids using new Vector3 to not produce garbage
                story.JoystickRight.x = value.x;
                story.JoystickRight.y = value.y;
            }
        }
        // Missing SetJoystickRight factory
        #endregion

    } 
}