using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steamy.Serialization
{
	public interface IJSONSerializable<T>
	{
		void JSONSerialize(string destination);
	}
}
