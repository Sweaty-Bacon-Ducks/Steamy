using System.Xml.Serialization;

namespace Steamy.Utility.Xml
{
	public static class EXmlSerializer
	{
		public static void UnknownNodeCallback(this XmlSerializer serializer,
												 object sender,
												 XmlNodeEventArgs e)
		{

		}

		public static void UnknownAttributeCallback(this XmlSerializer serializer,
												object sender,
												XmlAttributeEventArgs e)
		{

		}
	}
}
