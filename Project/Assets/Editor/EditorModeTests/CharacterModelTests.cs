using System.IO;
using System.Collections.Generic;

using NUnit.Framework;

using Steamy.Player;
using Steamy.Player.MotionModes;

public class CharacterModelTests
{
	[Test(Author = "Jakub Kowalik")]
	public void SaveCharacterModelToXml()
	{
		var resultFilePath = ".\\Assets\\Editor\\EditorModeTests\\character.xml";

		File.Delete(resultFilePath);
		
		var characterModel = new CharacterModel();
		var characterData = new CharacterData(Name: "Gracjan", MaxHitPoints: 100);

		characterModel.Data = characterData;
		characterModel.MotionModes = new HashSet<MotionMode> { new RunningMode(), new JumpMode(), new JumpMode() };
		CharacterModel.SaveToXml(resultFilePath, characterModel);
		Assert.Pass();
	}

	[Test(Author = "Jakub Kowalik")]
	public void ReadCharacterModelToXml()
	{
		var resultFilePath = ".\\Assets\\Editor\\EditorModeTests\\character.xml";

		var characterModel = CharacterModel.ReadFromXml(resultFilePath);
		Assert.True(characterModel.Data.Name == "Gracjan");
	}
}
