namespace VColor
{
    public class ColorRGBA : Color
	{

        /// <summary>
        /// Creates a new <see cref="Color"/> object.
        /// </summary>
        /// <param name="red">The amount of red.</param>
        /// <param name="green">The amount of green.</param>
        /// <param name="blue">The amount of blue.</param>
        /// <param name="alpha">The alpha influence.</param>
        public ColorRGBA(int red, int green, int blue, double alpha)
        {
            Red = red;
            Green = green;
            Blue = blue;
            Alpha = alpha;
        }
        /// <inheritdoc cref="Color(int, int ,int ,double)"/>
        public ColorRGBA(int red, int green, int blue) : this(red, green, blue, 1) { }

        public ColorHSL GetHSL() => new(this);

        public ColorCMYK GetCMYK() => new(this);

    }
}
