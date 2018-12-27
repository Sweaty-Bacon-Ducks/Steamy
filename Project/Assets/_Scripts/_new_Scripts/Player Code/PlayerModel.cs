using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

using Steamy.Player.MotionModes;
using Steamy.Utility.Xml;

namespace Steamy.Player
{
	/// <summary>
	/// Holds information about 
	/// </summary>
	public class PlayerModel
	{
		/// <summary>
		/// Players network identifier.
		/// </summary>
		public string NetID;
		/// <summary>
		/// In-game player name.
		/// </summary>
		public string PlayerName;
	}
}

