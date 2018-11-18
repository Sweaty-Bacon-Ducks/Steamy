using System;
using System.IO;

using UnityEngine;

namespace Steamy.Player.MotionModes
{
	public interface IJSONSerializable<T>
	{
		void JSONSerialize(string destination);
		T JSONDeserialize(string source);
	}
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

		public MotionMode JSONDeserialize(string source)
		{
			throw new NotImplementedException();
		}
	}
}
