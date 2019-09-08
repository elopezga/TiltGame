using UnityEngine;
using UnityStories;

namespace TiltGame.ControllerInputServices
{
    public class ControllerUpdateService : MonoBehaviour
    {
        public StoriesHelper storiesHelper;
        private Vector2 JoystickLeftValue = Vector2.zero;
        // Update is called once per frame
        void Update()
        {
            Vector2 joystickLeft = Vector2.zero;
            joystickLeft.x = Input.GetAxis("Horizontal");
            joystickLeft.y = Input.GetAxis("Vertical");
            if (!Vector2.Equals(joystickLeft, JoystickLeftValue))
            {
                // Only update if joystick value has changed
                JoystickLeftValue.x = joystickLeft.x;
                JoystickLeftValue.y = joystickLeft.y;
                storiesHelper.Dispatch(Xbox360ControllerStory.SetJoystickLeftFactory.Get(JoystickLeftValue));
            }
        }
    }
}
