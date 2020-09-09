using System;
using System.Collections.Generic;

namespace IAD
{
    public class FeatureSpace
    {

        public struct Point
        {
            private double xAxis;
            private double yAxis;

            public void PasteComponents(double x, double y)
            {
                this.xAxis = x;
                this.yAxis = y;
            }
            public void DisplayComponents(){
                Console.WriteLine($"x: {xAxis} y:{yAxis}");
            }

        }

        public Point TakePointFromInput(Point tempPoint , double xAxis , double yAxis)
        {
            tempPoint.PasteComponents(xAxis, yAxis);
            return tempPoint;
        }

        public void DisplayPointOnScreen()
        {
            Point testpoint = new Point();
            testpoint = TakePointFromInput(testpoint, 322, 228);
            testpoint.DisplayComponents();
        }
    }
}
