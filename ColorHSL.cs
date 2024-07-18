using VColor.InternalServices;

namespace VColor
{
	public class ColorHSL : Color
	{

		private int _hue;

		private int _saturation;

		private int _lightness;

		public int Hue
		{
			get => _hue;
			set => _hue = value.InRange(0, 360) ? value : value.GetClosest(0, 360);
		}

		public int Saturation
		{
			get => _saturation;
			set => _saturation = value.InRange(0, 100) ? value : value.GetClosest(0, 100);
		}

		public int Lightness
		{
			get => _lightness;
			set => _lightness = value.InRange(0, 100) ? value : value.GetClosest(0, 100);
		}

		public ColorHSL(ColorRGBA color)
		{
			double r = (double)color.Red / 255;
			double g = (double)color.Green / 255;
			double b = (double)color.Blue / 255;
			var cmax = VIntMath.Max(r, g, b);
			var cmin = VIntMath.Min(r, g, b);
			var cDelta = cmax - cmin;
			Lightness = (int)((cmax + cmin) / 2);
			Saturation = (int)(cDelta == 0 ? 0 : cDelta / (1 - Math.Abs(2 * Lightness - 1)));
			Hue = (int)(cDelta == 0 ? 0 : cmax == r ? (60 * (((g - b) / cDelta) % 6)) : cmax == g ? (60 * (((b - r) / cDelta) + 2)) : (60 * (((r - g) / cDelta) + 4)));
		}

		public ColorHSL(int hue, int saturation, int lightness)
		{
			Hue = hue;
			Saturation = saturation;
			Lightness = lightness;
			var tmp = GetRGBA();
			Red = tmp.Red;
			Green = tmp.Green;
			Blue = tmp.Blue;
			Alpha = tmp.Alpha;
		}

		public ColorRGBA GetRGBA()
		{
            var c = (1 - Math.Abs(2 * Lightness - 1) * Saturation);
            var x = c * (1 - (Math.Abs(Hue / 60) % 2) - 1);
            var m = Lightness - (c / 2);
            BasicRGB tmp;
            if (0 <= Hue && Hue < 60)
                tmp = new(c, x, 0);
            else if (60 <= Hue && Hue < 120)
                tmp = new(x, c, 0);
            else if (120 <= Hue && Hue < 180)
                tmp = new(0, c, x);
            else if (180 <= Hue && Hue < 240)
                tmp = new(0, x, c);
            else if (240 <= Hue && Hue < 300)
                tmp = new(x, 0, c);
            else
                tmp = new(c, 0, x);
            return new((tmp.r + m) * 255, (tmp.g + m) * 255, (tmp.b + m) * 255);
        }

		public ColorCMYK GetCMYK() => new(GetRGBA());


	}
}
