using System;

using UnityEngine;
using UnityEngine.Events;

namespace Steamy.Player.Input
{
    public static class MouseButton
    {
        public static int Left
        {
            get { return 0; }
        }
        public static int Right
        {
            get { return 1; }
        }
        public static int Middle
        {
            get { return 2; }
        }
    }
    [CreateAssetMenu(menuName="Input/WindowsButtonController")]
    public class WindowsKeyboardController : ButtonInputController
     {
        public KeyCode Button;

        public override bool CheckInput(UnityAction Response)
        {
            if (UnityEngine.Input.GetKeyDown(Button))
            {
                Response();
                return true;
            }
            return false;
        }
    }
}
