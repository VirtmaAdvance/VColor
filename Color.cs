using VColor.InternalServices;

namespace VColor
{
    public class Color
	{

        private int _red;
        private int _green;
        private int _blue;
        private byte _alpha;
        /// <summary>
        /// The red intensity of the color.
        /// </summary>
        public int Red
        {
            get => _red;
            set => _red = PreserveColorValues ? value : GetColorInput(value);
        }
        /// <summary>
        /// The green intensity of the color.
        /// </summary>
        public int Green
        {
            get => _green;
            set => _green = PreserveColorValues ? value : GetColorInput(value);
        }
        /// <summary>
        /// The blue intensity of the color.
        /// </summary>
        public int Blue
        {
            get => _blue;
            set => _blue = PreserveColorValues ? value : GetColorInput(value);
        }
        /// <summary>
        /// The alpha value of the color.
        /// </summary>
        public double Alpha
        {
            get => (double)_alpha / 255;
            set => _alpha = GetColorInput(value);
        }
        /// <summary>
        /// The light-based color format.
        /// </summary>
        public ColorRGBA RGBA => new(_red, _green, _blue, _alpha);
        /// <summary>
        /// The paint-based color value.
        /// </summary>
        public ColorCMYK CMYK => new(new ColorRGBA(_red, _green, _blue, _alpha));
        /// <summary>
        /// The HSL color format.
        /// </summary>
        public ColorHSL HSL => new(new ColorRGBA(Red, Green, Blue));
        /// <summary>
        /// Gets the hexadecimal value of the color.
        /// </summary>
        public string Hexadecimal => "#" + _red.ToString("x2") + _green.ToString("x2") + _blue.ToString("x2") + (_alpha < 255 ? _alpha.ToString("x2") : "");

        public bool PreserveColorValues = true;

        /// <summary>
        /// Creates a new <see cref="Color"/> object.
        /// </summary>
        public Color() { }

        /// <summary>
        /// Scales all colors by the specified <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value to scale up or down by.</param>
        public void Scale(int value)
        {
            Red += value;
            Green += value;
            Blue += value;
        }
        /// <summary>
        /// Gets the <see cref="System.Drawing.Color"/> representation of this color object.
        /// </summary>
        /// <returns></returns>
        public System.Drawing.Color ToDrawingColor() => System.Drawing.Color.FromArgb(_alpha, _red, _green, _blue);

        protected static byte GetColorInput(int value) => (byte)(value.InRange(0, 255) ? value : value.GetClosest(0, 255));
        protected static byte GetColorInput(double value) => (byte)((value.InRange(0, 1) ? value : value.GetClosest(0, 1)) * 255);

        public static Color GetColorByName(string name)
        {
            return name.Trim().ToLower() switch
            {
                "black" => Gen(0, 0, 0),
                "grey" => Gen(127, 127, 127),
                "darkgrey" => Gen(30, 30, 30),
                "white" => Gen(255, 255, 255),
                "blue" => Gen(0, 0, 255),
                "skyblue" => Gen(0, 200, 255),
                "lightblue" => Gen(100, 100, 255),
                "darkblue" => Gen(0, 0, 100),
                "red" => Gen(255, 0, 0),
                "lightred" => Gen(255, 150, 150),
                "darkred" => Gen(100, 0, 0),
                "pink" => Gen(255, 0, 255),
                "lovepink" => Gen(255, 0, 150),
                "darkpink" => Gen(150, 0, 100),
                "green" => Gen(0, 255, 0),
                "darkgreen" => Gen(0, 150, 0),
                "lime" => Gen(200, 255, 150),
                "yellow" => Gen(255, 255, 0),
                "lemon" => Gen(255, 255, 100),
                "purple" => Gen(100, 0, 200),
                "lightpurple" => Gen(150, 0, 255),
                "orange" => Gen(255, 150, 0),
                "brown" => Gen(200, 150, 0),
                _ => Gen(0, 0, 0),
            };
        }

        private static ColorRGBA Gen(int r, int g, int b, int a = 1) => new(r, g, b, a);

    }
}
