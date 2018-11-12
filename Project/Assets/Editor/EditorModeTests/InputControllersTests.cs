using System;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

using Steamy.Player.Input;

public class InputControllersTests 
{
    //[TestCase(true)]
    //[TestCase(false)]
    //public void ButtonControllerKeyboard(bool keyPressed)
    //{
    //    Func<KeyCode, bool> isButtonClicked = (KeyCode Inputkey) =>
    //    {
    //        return keyPressed;
    //    };
    //    UnityAction response = () => { };  
    //    IButtonInputController inputController =
    //        new ButtonInputController<KeyCode>(KeyCode.A,
    //                                           isButtonClicked,
    //                                           response);
    //    if (inputController.CheckInput())
    //        Assert.Pass();
    //    else
    //        Assert.True(keyPressed == false);
    //}
    //[TestCase(true)]
    //[TestCase(false)]
    //public void ButtonControllerMouse(bool keyPressed)
    //{
    //    var mouseButton = MouseButton.Left;
    //    Func<int, bool> isButtonClicked = (int inputButton) =>
    //    {
    //        return keyPressed;
    //    };
    //    UnityAction response = () => { };
    //    IButtonInputController inputController =
    //        new ButtonInputController<int>(mouseButton,
    //                                           isButtonClicked,
    //                                           response);
    //    if (inputController.CheckInput())
    //        Assert.Pass();
    //    else
    //        Assert.True(keyPressed == false);
    //}
}
