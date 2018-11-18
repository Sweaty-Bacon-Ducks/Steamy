using System;
using System.IO;

using UnityEngine;

using NUnit.Framework;

using Steamy.Player.MotionModes;

public class CharacterModelTests
{
	[Test]
	public void MotionModeSerializationTest()
	{
		var motionMode = new HorizontalRunMode
		{
			Name = "Running",
			AxisName = "Horizontal",
			RunningForce = 2f,
			SpeedThreshold = 10f,
		};
		var jsonRepresentation = JsonUtility.ToJson(motionMode);
		var path = Application.streamingAssetsPath + "\\defs\\movement\\HorizontalRunMode.json";

		using (var writer = new StreamWriter(path))
		{
			writer.WriteLine(jsonRepresentation);
		}

		Assert.Pass();
	}
}
