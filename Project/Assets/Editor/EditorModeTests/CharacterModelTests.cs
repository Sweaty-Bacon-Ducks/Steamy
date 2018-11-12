using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

using NUnit.Framework;

using Steamy.Player;
using Steamy.Player.MotionModes;
using Steamy.Player.Input;
using Steamy.Utility.Xml;

public class CharacterModelTests
{
	//[Test(Author = "Jakub Kowalik")]
	//public void SaveCharacterModelToXml()
	//{
	//	var resultFilePath = ".\\Assets\\Editor\\EditorModeTests\\XmlTestCharacter.xml";

	//	File.Delete(resultFilePath);

	//	var characterModel = new CharacterModel();
	//	var characterData = new CharacterData
	//	{
	//		MaxHitPoints = 100,
	//		Name = "Gracjan"
	//	};
	//	characterModel.Data = characterData;
 //       UnityAction Response = () => { };
 //       IButtonInputController horizontalRunController1 = new ButtonInputController<KeyCode>(KeyCode.A,
 //                                                                                           Input.GetKey,
 //                                                                                           Response);
 //       MotionMode motionMode1 = new HorizontalRunMode("Running",
 //                                                      horizontalRunController1,
 //                                                      HorizontalDirection.Left, 
 //                                                      RunningSpeed:  1.0f,
 //                                                      SpeedThreshold:  20f);
 //       IButtonInputController horizontalRunController2 = new ButtonInputController<KeyCode>(KeyCode.B,
 //                                                                                           Input.GetKey,
 //                                                                                           Response);
 //       MotionMode motionMode2 = new HorizontalRunMode("Slower Running",
 //                                                      horizontalRunController2,
 //                                                      HorizontalDirection.Left,
 //                                                      RunningSpeed: .5f,
 //                                                      SpeedThreshold: 20f);
 //       characterModel.MotionModes = new HashSet<MotionMode> { motionMode1, motionMode2 };

 //       ObjectSerializer<CharacterModel>.SaveToXml(resultFilePath, characterModel, Assembly
 //                                                                                  .GetExecutingAssembly()
 //                                                                                  .GetExportedTypes());
	//	Assert.Pass();
	//}

	//[Test(Author = "Jakub Kowalik")]
	//public void ReadCharacterModelFromXml()
	//{
	//	//var resultFilePath = ".\\Assets\\Editor\\EditorModeTests\\character.xml";

	//	//var extraTypes = new Type[] { typeof(MotionMode) };
	//	//var characterModel = CharacterModel.ReadFromXml(resultFilePath, extraTypes);
	//	//Assert.True(characterModel.Data.Name == "Gracjan" && 
	//		//characterModel.Data.MaxHitPoints == 100f &&
	//		//characterModel.MotionModes.Contains(new HorizontalRunMode()) &&
	//		//characterModel.MotionModes.Contains(new JumpMode()));
	//}
}
