using System;
using System.IO;

using UnityEngine;

using Steamy.Serialization;

namespace Steamy.Player.MotionModes
{
	[Serializable]
	public class MotionMode: IJSONSerializable<MotionMode>
	{
		public string Name;

		protected CharacterViewModel viewModel;

		public MotionMode() {	}
		public MotionMode(CharacterViewModel viewModel)
		{
			this.viewModel = viewModel;
		}

		public virtual void ApplyMotion() {	}

		public override bool Equals(object obj)
		{
			var motionMode = obj as MotionMode;
			return this.Name.Equals(motionMode.Name);
		}
		public override int GetHashCode()
		{
			return Name.GetHashCode();
		}

		public void JSONSerialize(string destination)
		{
			var jsonRepresentation = JsonUtility.ToJson(this);
			var path = Application.streamingAssetsPath + destination;

			using (var writer = new StreamWriter(destination))
			{
				writer.WriteLine(jsonRepresentation);
			}
		}

		public static T JSONDeserialize<T>(string source)
		{
			var path = Application.streamingAssetsPath + source;
			string result = null;
			using (var writer = new StreamReader(path))
			{
				result = writer.ReadToEnd();
			}
			return JsonUtility.FromJson<T>(result);
		}
	}
}
