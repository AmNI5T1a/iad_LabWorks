using System;
using System.Linq;
using System.Numerics;

namespace IAD
{
    public class MethodOfNearestNeigbor
    {
        public Int16 InputNumberOfNeighbor(Int16 tempVariable)
        {
            tempVariable = Convert.ToInt16(Console.ReadLine());
            return tempVariable;
        }
        public Vector2 CreateVector2Space(Int16 points)
        {
            Random tempRandomVariable = new Random();
            Vector2[] space = new Vector2[points];
            for (int i = 0; i < space.Length; i++)
            {
                space[i] = new Vector2(tempRandomVariable.Next(-100, 100), tempRandomVariable.Next(-100, 100));
            }
            Console.WriteLine("Finished fillling space..");

            return space;
        }
        public void MainMethod()
        {
            Console.WriteLine("Print number of neighbor: ");
            int16 numberOfNeighbor = InputNumberOfNeighbor(Console.ReadLine());

            List<shortint> listOfNeighbor = new List<shortint>();
            Console.WriteLine("Input number of points in your space: ");
            Vector2 space = (Vector2)CreateVector2Space(Convert.ToInt16(Console.ReadLine()));
            Console.WriteLine("Choose ur point: ");
            shortint yourChosenPoint = Convert.ToInt16(Console.ReadLine());


            /// <summary>
            // if this point closer than any of this point switch this point
            /// </summary>
            for (int i = 0; i < space.Length; i++)
            {

            }


        }

    }
}