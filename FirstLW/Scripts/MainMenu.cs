using System;
using System.Linq;

namespace IAD
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Choose ur task: \n1.Working with featured space\n2.Informativeness of the feature space \n3.Method of nearest neighbors");
            Int16 chooser = Convert.ToInt16(Console.ReadLine());
            switch (chooser)
            {
                case (1):
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
                        while (listLength <= firstPoint || listLength <= secondPoint)
                        {
                            Console.Write("Paste list length again: ");
                            listLength = Convert.ToInt16(Console.ReadLine());
                        }
                    }
                    #endregion

                    Points = FS.TakePointFromInput(firstPoint, secondPoint);

                    FS.CalculateDistance(listLength, Points);
                    break;
                case (2):
                    
                    break;
                case (3):
                    Console.Clear();
                    MethodOfNearestNeigbor kNN = new MethodOfNearestNeigbor();
                    kNN.MainMethod();
                    Console.WriteLine("Ready!");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
