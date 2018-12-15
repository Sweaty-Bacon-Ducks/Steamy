using System.Reflection;

namespace Steamy.Utility.Reflection
{
	public static class EReflection
	{
		/// <summary>
		/// Creates an instance of type given as the parameter.
		/// </summary>
		/// <typeparam name="T">Type to cast after instantiation. Must be the same as the parameter "typeName"</typeparam>
		/// <param name="assembly">This assembly</param>
		/// <param name="typeName">Name of the class to instantiate. The parameter can be given as Namespace.AnotherNamespace.TargetClass.</param>
		/// <returns>Instance of this type.</returns>
		public static T CreateInstanceOf<T>(this Assembly assembly, string typeName) where T: class
		{
			var executingAssembly = Assembly.GetExecutingAssembly();
			return executingAssembly.CreateInstance(typeName: typeName) as T;
		}
	}
}
