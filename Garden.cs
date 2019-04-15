using System;
namespace gardenBox
{
    public class Garden
    {
        public int area;
        public int perimeter;
        public int perSq;
        public string cropInput;
        public string cropName;

        public int CalcArea(int length, int width)
        {
            area = length * width;
            return area;
        }

        public int CalcPerimeter(int length, int width)
        {
            perimeter = (2 * length) + (2 * width);
            return perimeter;
        }

        public double CalcCrop(int perSq, int area)
        {
            
            //not sure about the math here
            double cropMath = (Convert.ToDouble(perSq) / 4) * area;
            double cropMath2 = Math.Floor(cropMath);
            return cropMath2;
        }

    }

   
}
