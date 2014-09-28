using System;
using System.Collections.Generic;

namespace LibraryTest
{
	using AreaCalcLibrary;
	
	public static class AreaUtilsTest
	{
		private struct TestDataSet
		{
			public float A;
			public float B;
			public float C;
			public TestResult Result;
			public float Area;
		}
		
		private enum TestResult
		{
			Failed,
			Succeded
		}
		
		private static bool IsTestPassed(TestDataSet dataSet)
		{
			try
			{
				bool resultIsRight = MathUtils.AreAlmostEqual(AreaUtils.RightTriangleArea( dataSet.A, dataSet.B, dataSet.C), dataSet.Area, _relError, _absError);
				Console.WriteLine("ResultIsRight");
				return (resultIsRight && dataSet.Result == TestResult.Succeded);
			}
			catch(AreaUtils.InvalidInputException)
			{
				Console.WriteLine("GotException");
				return (dataSet.Result == TestResult.Failed);
			}
		}
		
		public static bool Test()
		{
			bool passed = true;
			for(int i = 0; i < _sets.Count; i++)
			{
				if(!IsTestPassed(_sets[i]))
				{
					passed = false;
					Console.WriteLine("Test failed on dataset[" + i + "]:" + " side A:" + _sets[i].A + " side B:" + _sets[i].B + " side C:" + _sets[i].C);
				}
			}
			
			if(passed)
			{
				Console.WriteLine("ManualTestsPassed");
			}
			else
			{
				Console.WriteLine("ManualTestsFailed");
			}	
			return passed;
		}

		private static float _relError = 0.0001f;
		private static float _absError = 0.0001f;
		private static List<TestDataSet> _sets = new List<TestDataSet>()
		{
			new TestDataSet{ A = 0, 								B=3, C=4, Result=TestResult.Failed, 	Area=0},
			new TestDataSet{ A = -3, 								B=4, C=5, Result=TestResult.Failed, 	Area=0},
			new TestDataSet{ A = 2, 								B=4, C=5, Result=TestResult.Failed, 	Area=0},
			new TestDataSet{ A = 3 + _absError - Single.Epsilon, 	B=4, C=5, Result=TestResult.Succeded, 	Area=6.0f},
			new TestDataSet{ A = 3, 								B=4, C=5, Result=TestResult.Succeded, 	Area=6.0f},
			new TestDataSet{ A = Single.NaN, 						B=4, C=5, Result=TestResult.Failed, 	Area=0},
			new TestDataSet{ A = Single.NegativeInfinity, 			B=4, C=5, Result=TestResult.Failed, 	Area=0},
			new TestDataSet{ A = Single.PositiveInfinity, 			B=4, C=5, Result=TestResult.Failed, 	Area=0},
			new TestDataSet{ A = Single.MaxValue, 					B=4, C=5, Result=TestResult.Failed, 	Area=0},
			new TestDataSet{ A = 30000 + 30000 * _relError * 0.99f, B=40000, C=50000, Result=TestResult.Succeded, 	Area=600000000.0f},
		};
	}
}
