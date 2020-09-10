using System;
using System.Linq;

namespace IAD
{
    class Program
    {
        static void Main()
        {
            #region Intializate Components
            FeatureSpace.Point Points = new FeatureSpace.Point();
            FeatureSpace FS = new FeatureSpace();
            Console.WriteLine("Paste first point value:");
            int firstPoint = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Paste second point value:");
            int secondPoint = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Paste List length value:");
            short listLength = Convert.ToInt16(Console.ReadLine());
            if (listLength <= firstPoint || listLength <= secondPoint)
            {
                Console.WriteLine("List length can't be less than point we will use");
                while(listLength <= firstPoint || listLength <= secondPoint){
                    Console.Write("Paste list length again: ");
                    listLength = Convert.ToInt16(Console.ReadLine());
                }
            }
            #endregion

            Points = FS.TakePointFromInput(firstPoint, secondPoint);

            FS.CalculateDistance(listLength, Points);
        }
    }
}
