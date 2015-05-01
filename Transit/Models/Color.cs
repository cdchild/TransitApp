using System;

namespace Transit.Models
{
    public class Color
    {
        public Color()
        {
            A = 255;
            R = 0;
            G = 0;
            B = 0;
        }
        public Color(byte r, byte g, byte b, byte a = 255)
        {
            A = a;
            R = r;
            G = g;
            B = b;
        }
		public Color(int intColor, byte a = 255)
		{
			A = a;
			R = Convert.ToByte((intColor & 0x00000FF) >> (8 * 0));
			G = Convert.ToByte((intColor & 0x0000FF00) >> (8 * 1));
			B = Convert.ToByte((intColor & 0x00FF0000) >> (8 * 2));
		}
		public Color(string hexColor, byte a = 255)
		{
			hexColor = hexColor.Replace("#", "");
			A = a;
			R = Convert.ToByte(hexColor.Substring(0, 2), 16);
			G = Convert.ToByte(hexColor.Substring(2, 2), 16);
			B = Convert.ToByte(hexColor.Substring(4, 2), 16);
		}
        public  byte A { get; set; }
        public  byte R { get; set; }
        public  byte G { get; set; }
        public  byte B { get; set; }
        public  double Alpha(int digits = 2)
        {
            return Math.Round(
                ((double)A / 255),
                digits
            );
        }
        public virtual System.Drawing.Color color
        {
            get
            {
                return System.Drawing.Color.FromArgb(A, R, G, B);
            }
        }
        public virtual bool IsLightColor
        {
            get
            {
                return (color.GetBrightness() >= 0.5);
            }
        }
        public virtual bool IsAlmostWhiteColor
        {
            get
            {
                return (color.GetBrightness() >= 0.95);
            }
        }
        public new string ToString
        {
            get
            {
                if (A < 255)
                    return R.ToString() + ", " + G.ToString() + ", " + B.ToString() + ", " + Alpha().ToString();
                else
                    return R.ToString() + ", " + G.ToString() + ", " + B.ToString();
            }
        }
    }
}