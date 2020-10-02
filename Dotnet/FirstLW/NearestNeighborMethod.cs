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
        private SpaceFiller _filler = new SpaceFiller();
        private ShowSpace _displaySpace = new ShowSpace();
        public void MainMethod()
        {
            Console.WriteLine("Input  number of  neighbors: ");
            short numberOfNeighbor = Convert.ToInt16(Console.ReadLine());

            List<Vector2> listOfNeighbors = new List<Vector2>();

            Console.WriteLine("Input number of points in your space: ");
            short pointsInSpace = Convert.ToInt16(Console.ReadLine());

            List<Vector2> space = new List<Vector2>();


            /// <summary>
            /// Filling space with random variables
            /// </summary>
            _filler.Fill(ref space, ref pointsInSpace, -1000, 1000);

            /// <summary>
            /// Filling list of Neighbors with random point from space
            /// </summary>
            _filler.Fill(ref listOfNeighbors, ref numberOfNeighbor, ref space);


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
            _displaySpace.ShowVector2Space(numberOfNeighbor, listOfNeighbors);
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

        /// <summary>
        /// Formule : √((x1-x2)^2+(y1-y2)^2)
        /// Can be modified to change to Vector3,Vector4 and so on
        /// </summary>
        virtual public double EuclidDistance(Vector2 firstTemp, Vector2 secondTemp)
        {
            double result = Math.Sqrt(Math.Pow(firstTemp.X - secondTemp.X, 2) + Math.Pow(firstTemp.Y - secondTemp.Y, 2));
            return result;
        }
    }
    class SpaceFiller
    {
        private Random rndGeneration = new Random();

        /// <summary>
        /// Method to fill list with random variables
        /// </summary>
        public void Fill(ref List<Vector2> list, ref short butting, short from, short to)
        {
            for (short i = 0; i < butting; i++)
                list.Add(new Vector2(rndGeneration.Next(from, to), rndGeneration.Next(from, to)));
        }
        /// <summary>
        /// Method to fill a list from another existing list
        /// <summary>
        public void Fill(ref List<Vector2> listToFill, ref short butting, ref List<Vector2> mainList)
        {
            for (short i = 0; i < butting; i++)
                listToFill.Add(mainList[i]);
        }
        /// <summary>
        /// Method for filling space in first task 
        /// </summary>
        public void Fill(ref List<Point> space, ref long pointsInSpace, int from, int to)
        {
            Point point = new Point();
            for (long i = 0; i <= pointsInSpace; i++)
            {
                point.PasteComponents(rndGeneration.Next(from, to), rndGeneration.Next(from, to));

                space.Add(point);
            }
        }
    }
    class ShowSpace
    {
        public void ShowVector2Space(in short pointsInSpace, in List<Vector2> vector2s)
        {
            for (int other = 0; other < pointsInSpace; other++)
                Console.WriteLine($"{other.ToString()}: {vector2s[other]}");
        }
        public void ShowPointsSpace(ref List<Point> space, in long pointsInSpace)
        {
            for (int i = 1; i < pointsInSpace; i++)
            {
                Console.Write($"{i} point is: ");
                space[i].DisplayComponents();
            }
        }
    }
}