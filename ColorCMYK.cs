using VColor.InternalServices;

namespace VColor
{
    public class ColorCMYK : Color
    {

        public int Cyan;

        public int Magenta;

        public int Yellow;

        public int Black;


        public ColorCMYK(ColorRGBA color)
        {
            double r = (double)color.Red / 255;
            double g= (double)color.Green / 255;
            double b= (double)color.Blue / 255;
            Black = (int)(1 - VIntMath.Max(r, g, b));
            Cyan = (int)((1 - r - Black) / (1 - Black));
            Magenta = (int)((1 - g - Black) / (1 - Black));
            Yellow = (int)((1-b-Black) / (1 - Black));
        }

        public ColorCMYK(int cyan, int magenta, int yellow, int black)
        {
            Cyan = cyan;
            Magenta = magenta;
            Yellow = yellow;
            Black = black;
        }

        protected ColorRGBA GetRGBA() => new(255 * (1 - Cyan) * (1 - Black), 255 * (1 - Magenta) * (1 - Black), 255 * (1 - Yellow) * (1 - Black));

        protected ColorHSL GetHSL() => new(GetRGBA());


    }
}
