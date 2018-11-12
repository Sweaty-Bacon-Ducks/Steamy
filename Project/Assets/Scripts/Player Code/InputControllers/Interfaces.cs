using System;

using UnityEngine;
using UnityEngine.Events;

namespace Steamy.Player.Input
{

    public interface IPointableInputController<T> 
    {
        /// <summary>
        /// Gets input from a pointable device (like mouse or touchpad).
        /// </summary>
        /// <returns>Input as type given in parameter</returns>
        T GetInput();
    }

}