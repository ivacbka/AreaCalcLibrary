using System;

namespace AreaCalcLibrary
{
	public static class MathUtils
	{
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
	}
}
