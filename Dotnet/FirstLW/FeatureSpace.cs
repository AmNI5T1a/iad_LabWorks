using System;
using System.Collections.Generic;

namespace IAD
{
    public struct Point
    {
        private int xAxis;
        private int yAxis;

        public void PasteComponents(int x, int y)
        {
            xAxis = x;
            yAxis = y;
        }
        public void DisplayComponents()
        {
            Console.WriteLine($"(x: {xAxis} y: {yAxis})");
        }
    }
    public class FeatureSpace
    {
        private ShowSpace _displaySpace = new ShowSpace();
        private PointsSpaceCreator _spaceCreator = new PointsSpaceCreator();
        public void MainMethod()
        {
            var space = _spaceCreator.CreateSpace(-1000,1000);
            _displaySpace.ShowPointsSpace(ref space , space.Count);
        }
    }

    /// <summary>
    /// y
    /// ^
    /// | .                 .       .
    /// |                   .
    /// |       .
    /// |
    /// |               .
    /// |       .
    /// -----------------------------------------------------------> x 
    /// A certain amount of points in space

    /// </summary>
    class PointsSpaceCreator
    {
        private SpaceFiller newFiller = new SpaceFiller();
        private ShowSpace _displaySpace = new ShowSpace();
        public List<Point> CreateSpace(in int from, in int to)
        {
            List<Point> space = new List<Point>();

            Console.WriteLine("How many points in ur space: ");

            long pointsInSpace = Convert.ToInt64(Console.ReadLine());

            newFiller.Fill(ref space, ref pointsInSpace, from, to);

            _displaySpace.ShowPointsSpace(ref space, pointsInSpace);

            return space;
        }
    }
}

