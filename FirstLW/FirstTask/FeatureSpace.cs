using System;
using System.Collections.Generic;

namespace IAD
{
    public class FeatureSpace
    {
        double[,] Display = new double[1920, 1080];
        public struct Point
        {
            private double xAxis;
            private double yAxis;

            public void PasteComponents(double x, double y)
            {
                this.xAxis = x;
                this.yAxis = y;
            }
            public void DisplayComponents()
            {
                Console.WriteLine($"x: {xAxis} y:{yAxis}");
            }
        }

        public Point TakePointFromInput(Point tempPoint, double xAxis, double yAxis)
        {
            tempPoint.PasteComponents(xAxis, yAxis);
            return tempPoint;
        }

        public void CreateDisplay()
        {
            double counter = 0;

            for (int i = 0; i < 1920; i++)
                for (int j = 0; j < 1080; j++)
                {
                    Display[i, j] = counter;
                    counter++;
                }
        }
        /*<summary>Calculate distance between 2 points on screen using Euclidean algorithm</summary>*/
        public void CalculateDistance(Point tempFirstPoint , Point tempSecondPoint)
        {
            Console.Write($"Distance: ");
        }
    }
}
