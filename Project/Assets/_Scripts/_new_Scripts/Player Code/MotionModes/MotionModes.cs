using System;
using System.Xml.Serialization;

namespace Steamy.Player.MotionModes
{
	public class MotionMode
	{
		public override bool Equals(object obj)
		{
			var thisType = GetType();
			var objType = obj.GetType();
			return thisType.ToString() == objType.ToString();
		}
		public override int GetHashCode()
		{
			return GetType().ToString().GetHashCode();
		}

		public virtual CharacterModel Do(CharacterViewModel playerViewModel)
		{
			throw new System.NotImplementedException("You can't use this method on this object!");
		}
	}

	public class RunningMode : MotionMode
	{
		public override CharacterModel Do(CharacterViewModel playerViewModel)
		{
			return null;
		}
	}

	public class JumpMode : MotionMode
	{
		public override CharacterModel Do(CharacterViewModel playerViewModel)
		{
			return null;
		}
	}
}
