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
                    Console.Clear();
                    FeatureSpace _featureSpace = new FeatureSpace();
                    _featureSpace.MainMethod();
                    break;
                case (2):
                    Console.Clear();
                    InformativenessOfSpace informativeness = new InformativenessOfSpace();
                    informativeness.MainMethod();
                    break;
                case (3):
                    Console.Clear();
                    MethodOfNearestNeigbor kNN = new MethodOfNearestNeigbor();
                    kNN.MainMethod();
                    Console.ReadKey();
                    break;
            }
        }
    }
}
