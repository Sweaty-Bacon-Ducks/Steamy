using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Reflection;

using Steamy.Utility.Xml;
using Steamy.Utility.Reflection;
using Steamy.Player.MotionModes;

namespace Steamy.Player
{
	public class CharacterData
	{
		/// <summary>
		/// Name of the character.
		/// </summary>
		public string Name;
		/// <summary>
		/// Max ammount of hit points.
		/// </summary>
		public float MaxHitPoints;
		/// <summary>
		/// Current ammount of hit points.
		/// </summary>
		[XmlIgnore]
		public float HitPoints;

		public CharacterData() { }

		public CharacterData(string Name, float MaxHitPoints)
		{
			this.Name = Name;
			this.MaxHitPoints = MaxHitPoints;
			this.HitPoints = this.MaxHitPoints;
		}
	}

	/// <summary>
	/// An in-game character model. 
	/// </summary>
	public class CharacterModel
	{
		/// <summary>
		/// View model attached to the character model.
		/// </summary>
		[XmlIgnore]
		public CharacterViewModel ViewModel;

		/// <summary>
		/// Holds information about the character such as maximum ammount of hitpoints or jumping force
		/// </summary>
		[XmlElement(ElementName = "Data")]
		public CharacterData Data;

		[XmlArray(ElementName = "MotionModes")]
		public HashSet<MotionMode> MotionModes;

		public static void SaveToXml(string xmlPath, CharacterModel characterModel)
		{
			// Get all types for the serializer
			var MotionModeTypes = characterModel.MotionModes.Select((MotionMode mode) => mode.GetType()).ToArray();

			// Create a new serializer
			var serializer = new XmlSerializer(characterModel.GetType(), extraTypes: MotionModeTypes);

			// Open the file
			using (var filestream = new FileStream(path: xmlPath,
				  mode: FileMode.CreateNew))
			{
				serializer.Serialize(stream: filestream, o: characterModel);
			}
		}
		public static CharacterModel ReadFromXml(string xmlPath)
		{
			var serializer = new XmlSerializer(typeof(CharacterModel));

			// Handle the unknown nodes and attributes
			serializer.UnknownNode += new XmlNodeEventHandler(serializer.UnknownNodeCallback);
			serializer.UnknownAttribute += new XmlAttributeEventHandler(serializer.UnknownAttributeCallback);

			// Open the file
			using (var filestream = new FileStream(path: xmlPath,
				  mode: FileMode.Open))
			{
				// TODO: copy constructor
				var deserializationResult = serializer.Deserialize(stream: filestream) as CharacterModel;
				return deserializationResult;
			}
		}
		/// <summary>
		/// Calls all available movement modes.
		/// </summary>
		public void DoMotion()
		{
			MotionModes.Select((MotionMode mode) => mode.Do(ViewModel));
		}
	}
}

