using System;
using System.Collections.Generic;

namespace IAD
{
    public class FeatureSpace
    {
        SpaceFiller newFiller = new SpaceFiller();
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
                Console.WriteLine($"ur point is: x: {xAxis} y:{yAxis}");
            }
        }
        

        /// <summary>
        /// Points{i , j}

        /// firstList [i,i+1,i+2,i+3...i+n]
        /// secondList [i,i+1,i+2,i+3...i+n]

        /// Sqrt((firstlist[i]-secondList[i])^2+(firstList[j]-secondList[j])^2) -> ToConsole

        /// </summary>

        public void CreateSpace()
        {
            List<Point> space = new List<Point>();

            Console.WriteLine("How many points in ur space: ");

            long pointsInSpace = Convert.ToInt64(Console.ReadLine());

            newFiller.Fill(ref space, ref pointsInSpace, -9999, 9999);


            /// <summary>
            /// var cause doesn't work with long (try to replace)
            for(int i = 0; i<pointsInSpace; i++)
                space[i].DisplayComponents();


        }


    }

}

