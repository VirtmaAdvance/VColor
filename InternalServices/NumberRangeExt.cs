namespace VColor.InternalServices
{
	internal static class NumberRangeExt
	{
		/// <summary>
		/// Determines if the <paramref name="value"/> is within the range.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <returns></returns>
		public static bool InRange(this int value, int min, int max) => value>=min && value<=max;
		/// <inheritdoc cref="InRange(int, int, int)"/>
		public static bool InRange(this float value, float min, float max) => value >= min && value <= max;
		/// <inheritdoc cref="InRange(int, int, int)"/>
		public static bool InRange(this double value, double min, double max) => value >= min && value <= max;
		/// <summary>
		/// Gets the closest value the number is to.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <returns></returns>
		public static int GetClosest(this int value, int min, int max) => (Math.Max(value, min) - Math.Min(value, min)) <= (Math.Max(value, max) - Math.Min(value, min)) ? min : max;
		/// <inheritdoc cref="GetClosest(int, int, int)"/>
        public static float GetClosest(this float value, float min, float max) => (Math.Max(value, min) - Math.Min(value, min)) <= (Math.Max(value, max) - Math.Min(value, min)) ? min : max;
        /// <inheritdoc cref="GetClosest(int, int, int)"/>
        public static double GetClosest(this double value, double min, double max) => (Math.Max(value, min) - Math.Min(value, min)) <= (Math.Max(value, max) - Math.Min(value, min)) ? min : max;

    }
}
