using System;
using System.Collections.Generic;

namespace IAD
{
    public class FeatureSpace
    {
        public struct Point
        {
            public double xAxis;
            public double yAxis;

            public void PasteComponents(double x, double y)
            {
                xAxis = x;
                yAxis = y;
            }
            public void DisplayComponents()
            {
                Console.WriteLine($"x: {xAxis} y:{yAxis}");
            }
        }

        public Point TakePointFromInput(double xAxis, double yAxis)
        {
            Point tempPoint = new Point();
            tempPoint.PasteComponents(xAxis, yAxis);
            return tempPoint;
        }

        /// <summary>
        /// Points{i , j}

        /// firstList [i,i+1,i+2,i+3...i+n]
        /// secondList [i,i+1,i+2,i+3...i+n]

        /// Sqrt((firstlist[i]-secondList[i])^2+(firstList[j]-secondList[j])^2) -> ToConsole
        
        /// </summary>
        public void CalculateDistance(Int16 other, Point tempFirstPoint)
        {
            List<double> firstList = new List<double>();
            List<double> secondList = new List<double>();
            Random rnd = new Random();

            for (int i = 0; i < other; i++)
            {
                firstList.Add(rnd.Next(0, 99999999));
                secondList.Add(rnd.Next(0, 99999999));
            }
            Console.WriteLine("Your answer is: " + Math.Sqrt(Math.Pow((firstList[(int)tempFirstPoint.xAxis] - secondList[(int)tempFirstPoint.xAxis]), 2)
                                                                + (Math.Pow((firstList[(int)tempFirstPoint.yAxis] - secondList[(int)tempFirstPoint.yAxis]), 2))));
            Console.WriteLine("-----Options for Debugging-----");
            Console.WriteLine($"Sqrt(({(firstList[(int)tempFirstPoint.xAxis]).ToString()} - {(secondList[(int)tempFirstPoint.xAxis]).ToString()})^2"
                                        + $"({(firstList[(int)tempFirstPoint.yAxis]).ToString()} - {(secondList[(int)tempFirstPoint.yAxis]).ToString()})^2)");

            Console.WriteLine($"First point: {tempFirstPoint.xAxis.ToString()}\nSecond point: {tempFirstPoint.yAxis.ToString()}");
        }
    }
}
