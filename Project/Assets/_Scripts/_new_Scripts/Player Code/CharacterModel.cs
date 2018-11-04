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
	}

	/// <summary>
	/// An in-game character model. 
	/// </summary>
	[Serializable]
	public class CharacterModel
	{
		#region Fields
		/// <summary>
		/// View model attached to the character model.
		/// </summary>
		[XmlIgnore]
		[NonSerialized]
		public CharacterViewModel ViewModel;

		/// <summary>
		/// Holds information about the character such as maximum ammount of hitpoints or jumping force
		/// </summary>
		[XmlElement(ElementName = "Data")]
		public CharacterData Data;

		[XmlArray(ElementName = "MotionModes")]
		public HashSet<MotionMode> MotionModes;
		#endregion

		#region Interface
		/// <summary>
		/// Calls all available movement modes.
		/// </summary>
		public void DoMotion()
		{
			MotionModes.Select((MotionMode mode) => mode.Do(ViewModel));
		}
		#endregion

		#region Serialization
		/// <summary>
		/// TODO: I think that this method can be generalized to any type
		/// </summary>
		/// <param name="xmlPath"></param>
		/// <param name="characterModel"></param>
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
		/// <summary>
		/// TODO: I think that this method can be generalized to any type
		/// </summary>
		/// <param name="xmlPath"></param>
		/// <param name="extraSuperClasses"></param>
		/// <returns></returns>
		public static CharacterModel ReadFromXml(string xmlPath, Type[] extraSuperClasses)
		{
			var exportedTypes = Assembly.GetExecutingAssembly()
				.GetExportedTypes();

			// Get all types subclassing the types in the parameter
			var extraTypes = extraSuperClasses.Select((Type superClass) =>
			{
				return exportedTypes
				.Where((Type type) => type.IsSubclassOf(superClass))
				.ToArray();
			})
			.SelectMany(x => x)
			.Distinct()
			.ToArray();

			var serializer = new XmlSerializer(typeof(CharacterModel), extraTypes: extraTypes);

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
		#endregion
	}
}

