using System;
using LibraryTest;

namespace LibraryTest
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.ReadLine();
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
