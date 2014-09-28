using System;

namespace AreaCalcLibrary
{
	/// <summary>
	/// Area calculations library
	/// </summary>
	public static class AreaUtils
	{
		#region public data

		/// <summary>
		/// The float epsilon used for calculations within library
		/// </summary>
		public static volatile float AbsoluteEpsilon = 0.0001f;
		public static volatile float RelativeEpsilon = 0.0001f;

		/// <summary>
		/// Exception type thrown by this library
		/// </summary>
		public class InvalidInputException: ApplicationException
		{
			public InvalidInputException(string message): base(message)
			{
			}
		}

		#endregion

		////////////////////////////////////////////////////////////////////////////////
		////////////////////////////////////////////////////////////////////////////////

		#region public functions

		/// <summary>
		/// Calculations of right triangle area
		/// </summary>
		/// <param name="a">first triangle side length</param>
		/// <param name="b">second triangle side length</param>
		/// <param name="c">third triangle side length</param>
		/// <exception cref="InvalidInputException">Thrown when input data describes not the right triangle</exception>
		public static float RightTriangleArea(float a, float b, float c)
		{
			if((a <= 0) || (b <= 0) || (c <= 0))
				throw new InvalidInputException("Sides should be greater than zero");
			
			if((a + b < c) || (a + c < b) || (b + c < a))
				throw new InvalidInputException("Sides should describe triangle");
			
			float [] sides = new float[3]{a, b, c};
			Array.Sort(sides);
			float hypSqrCalculated = sides[0] * sides[0] + sides[1] * sides[1];

			if(!MathUtils.AreAlmostEqual(hypSqrCalculated, sides[2] * sides[2], RelativeEpsilon, AbsoluteEpsilon))
				throw new InvalidInputException("Sides should describe right triangle");
			
			return sides[0] * 0.5f * sides[1];
		}

		#endregion
	}
}
