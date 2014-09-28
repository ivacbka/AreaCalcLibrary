using System;

namespace AreaCalcLibrary
{
	/// <summary>
	/// Math utils class
	/// </summary>
	public static class MathUtils
	{
		#region public functions

		/// <summary>
		/// Is equal for floats
		/// </summary>
		/// <returns><c>true</c>, if almost equal was ared, <c>false</c> otherwise.</returns>
		/// <param name="a">compared value1</param>
		/// <param name="b">compared value2</param>
		/// <param name="relError">Relative comparison error</param>
		/// <param name="absError">Absolute comparison error</param>
		public static bool AreAlmostEqual(float a, float b, float relError, float absError)
		{
			if (Math.Abs(a - b) < absError)
				return true;
			
			float relativeError;
			
			if (Math.Abs(a) < Math.Abs(b)) 
			{
				relativeError = Math.Abs((a - b) / b);
			}
			else 
			{
				relativeError = Math.Abs((a - b) / a);
			}
			
			if (relativeError <= relError)
				return true;
			
			return false;
		}

		#endregion
	}
}
