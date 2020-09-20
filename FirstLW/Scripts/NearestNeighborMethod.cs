using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace IAD
{
    public class MethodOfNearestNeigbor
    {
        /// <summary>
        /// After realising MainMethod - split it
        /// </summary>        
        public void MainMethod()
        {
            Console.WriteLine("Input number of  neighbors: ");
            short numberOfNeighbor = Convert.ToInt16(Console.ReadLine());

            List<Vector2> listOfNeighbors = new List<Vector2>();

            Console.WriteLine("Input number of points in your space: ");
            short pointsInSpace = Convert.ToInt16(Console.ReadLine());

            List<Vector2> space = new List<Vector2>();


            /// <summary>
            /// Filling space with random variables
            /// </summary>
            Random rndGeneration = new Random();
            for (int i = 0; i < pointsInSpace; i++)
            {
                space.Add(new Vector2(rndGeneration.Next(-1000, 1000), rndGeneration.Next(-1000, 1000)));
            }

            /// <summary>
            /// Filling list of Neighbors with random point from space
            /// </summary>
            for (int i = 0; i < numberOfNeighbor; i++)
            {
                listOfNeighbors.Add(space[i]);
            }


            ShowVector2Space(pointsInSpace, space);
            Console.Write("Choose point from your space: ");
            short yourPoint = Convert.ToInt16(Console.ReadLine());

            /// <summary>
            /// Adding your point to black list to avoid him
            /// </summary>
            List<Vector2> blackList = new List<Vector2>();
            blackList.Add(space[yourPoint]);


            /// <summary>
            /// Here we will find our nearest point in space
            /// </summary>
            for (short i = 0; i < pointsInSpace; i++)
            {
                for (short j = 0; j < numberOfNeighbor; j++)
                {
                    if (EuclidDistance(space[yourPoint], space[i]) < EuclidDistance(space[yourPoint], listOfNeighbors[j]) && !blackList.Contains(space[i]))
                    {
                        listOfNeighbors[j] = space[i];
                    }
                    blackList.Add(listOfNeighbors[j]);
                }
            }
            Console.WriteLine("Your nearest neighbors: ");
            ShowVector2Space(numberOfNeighbor, listOfNeighbors);
            Console.WriteLine($"Your point: {space[yourPoint]}");
        }


        /// <summary>
        /// ShowVector2Space - method to output all points to console from your space
        /// pointsInspace - how many points do u have in your space
        /// vector2s - your space
        /// </summary>
        public void ShowVector2Space(in short pointsInSpace, in List<Vector2> vector2s)
        {
            for (int other = 0; other < pointsInSpace; other++)
                Console.WriteLine($"{other.ToString()}: {vector2s[other]}");
        }
        virtual protected double EuclidDistance(Vector2 firstTemp, Vector2 secondTemp)
        {
            double result = Math.Sqrt(Math.Pow(firstTemp.X - secondTemp.X, 2) + Math.Pow(firstTemp.Y - secondTemp.Y, 2));
            return result;
        }
    }
}