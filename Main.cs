using System;
using LibraryTest;

namespace LibraryTest
{
	/// <summary>
	/// Main class for library test app
	/// </summary>
	public class MainClass
	{
		public static void Main(string[] args)
		{
			if(LibraryTest.AreaUtilsTest.Test()) 
			{
				Console.WriteLine ("TestPassed");
			} 
			else 
			{
				Console.WriteLine ("TestFailed");
			}
		}
	}
}
