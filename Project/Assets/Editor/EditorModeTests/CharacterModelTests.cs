using System.IO;
using System.Collections.Generic;

using NUnit.Framework;

using Steamy.Player;
using Steamy.Player.MotionModes;
using System;

public class CharacterModelTests
{
	[Test(Author = "Jakub Kowalik")]
	public void SaveCharacterModelToXml()
	{
		var resultFilePath = ".\\Assets\\Editor\\EditorModeTests\\character.xml";

		File.Delete(resultFilePath);

		var characterModel = new CharacterModel();
		var characterData = new CharacterData
		{
			MaxHitPoints = 100,
			Name = "Gracjan"
		};

		characterModel.Data = characterData;
		characterModel.MotionModes = new HashSet<MotionMode> { new RunningMode(), new JumpMode(), new JumpMode() };
		CharacterModel.SaveToXml(resultFilePath, characterModel);
		Assert.Pass();
	}

	[Test(Author = "Jakub Kowalik")]
	public void ReadCharacterModelFromXml()
	{
		var resultFilePath = ".\\Assets\\Editor\\EditorModeTests\\character.xml";

		var extraTypes = new Type[] { typeof(MotionMode) };
		var characterModel = CharacterModel.ReadFromXml(resultFilePath, extraTypes);
		Assert.True(characterModel.Data.Name == "Gracjan" && 
			characterModel.Data.MaxHitPoints == 100f &&
			characterModel.MotionModes.Contains(new RunningMode()) &&
			characterModel.MotionModes.Contains(new JumpMode()));
	}
}
