namespace VColor.InternalServices
{
    internal static class VIntMath
    {

        public static double Max(params double[] values)
        {
            double res = 0;
            foreach (var sel in values)
                res = Math.Max(res, sel);
            return res;
        }
        public static double Min(params double[] values)
        {
            double res = values.FirstOrDefault();
            foreach (var sel in values)
                res = Math.Min(res, sel);
            return res;
        }

    }
}
