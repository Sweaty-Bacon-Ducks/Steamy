using UnityEngine;
using UnityEngine.Events;

namespace Steamy.Player.Input
{
    public abstract class ButtonInputController: ScriptableObject
    {
        public abstract bool CheckInput(UnityAction Response);
    }
}