using System;
using System.Collections.Generic;

namespace IAD
{
    public struct Point
    {
        private int xAxis;
        private int yAxis;

        public Point(int x, int y)
        {
            this.xAxis = x;
            this.yAxis = y;
        }
        public void DisplayComponents()
        {
            Console.WriteLine($"(x: {xAxis} y: {yAxis})");
        }
    }
    public class FeatureSpace
    {
        public void MainMethod()
        {
            List<Point> space = new List<Point>();

            Console.WriteLine("Enter number of points in your space");
            long pointsInSpace = Convert.ToInt64(Console.ReadLine());

            Filler spaceFiller = new Filler();
            spaceFiller.FillSpaceWithPoints(ref space, ref pointsInSpace, -1000,1000);
            

            ShowSpace _displaySpace = new ShowSpace();
            _displaySpace.ShowPointsSpace(ref space, space.Count);
        }
    }
    interface PointsSpaceFiller
    {
        void FillSpaceWithPoints(ref List<Point> space,ref long pointInSpace, int from, int to);
    }

    class Filler : PointsSpaceFiller
    {
        public void FillSpaceWithPoints(ref List<Point> space,ref long pointInSpace, int from, int to)
        {
            Random rndGeneration = new Random();

            for (long j = 0; j < pointInSpace; j++)
                space.Add(new Point(rndGeneration.Next(from, to), rndGeneration.Next(from, to)));
        }
    }

}

