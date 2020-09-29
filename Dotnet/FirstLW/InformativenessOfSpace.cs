using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace IAD
{

    class InformativenessOfSpace
    {

        private SpaceFiller _spaceFiller = new SpaceFiller();
        private SpaceDisplayer _spaceDisplayer = new SpaceDisplayer();
        private IntramultipleDistance _intraDistance = new IntramultipleDistance();
        private Random rndGeneration = new Random();
        public void MainMethod()
        {
            Console.WriteLine("Input number of classes: ");

            short numberOfClasses = Convert.ToInt16(Console.ReadLine());

            //var listOfClasses = new ArrayList();
            List<Vector2>[] listOfClasses = new List<Vector2>[numberOfClasses];

            for (int i = 0; i < numberOfClasses; i++)
            {
                //_spaceFiller.FillSpace(ref listOfClasses[i], rndGeneration.Next(5,25),-1000,1000);
                listOfClasses[i] = new List<Vector2>();

                _spaceFiller.FillSpace(ref listOfClasses[i], rndGeneration.Next(5, 25), -1000, 1000);

            }
            #region Show All Classes(commented)
            /*
            for (int i = 0; i < numberOfClasses; i++)
            {
                Console.WriteLine($"Class number: {i}");
                _spaceDisplayer.DisplaySpace(ref listOfClasses[i]);
            }
            */
            #endregion

            for (int i = 0; i < numberOfClasses; i++)
                _intraDistance.CalculateIntramultipleDistance(ref listOfClasses[i]);

            _intraDistance.Print();



        }
        class SpaceFiller
        {
            Random rndGeneration = new Random();
            public void FillSpace(ref List<Vector2> spaceToFill, int butting, short from, short to)
            {
                for (int i = 0; i < butting; i++)
                {
                    spaceToFill.Add(new Vector2(rndGeneration.Next(-1000, 1000), rndGeneration.Next(-1000, 1000)));
                }

            }
        }
        class SpaceDisplayer
        {
            public void DisplaySpace(ref List<Vector2> spaceToShow)
            {
                for (int i = 0; i < spaceToShow.Count; i++)
                {
                    Console.WriteLine(spaceToShow[i].ToString());
                }
            }
        }

        interface IDisplayer
        {
            void Print();
        }

        class IntramultipleDistance : IDisplayer
        {
            MethodOfNearestNeigbor kNN = new MethodOfNearestNeigbor();
            List<Double> calculatedDistances = new List<double>();

            int listCounterTEST = 0;

            public void CalculateIntramultipleDistance(ref List<Vector2> space)
            {
                listCounterTEST++;
                List<Double> calculatedDistancesTEST = new List<double>();
                for (int i = 0; i < space.Count; i++)
                {
                    for (int j = 0; j < space.Count; j++)
                    {
                        if (i != j)
                        {
                            calculatedDistances.Add(kNN.EuclidDistance(space[i], space[j]));
                            calculatedDistancesTEST.Add(kNN.EuclidDistance(space[i], space[j]));
                        }
                    }
                }
                Console.WriteLine("___________________________________________");
                Console.WriteLine($"List number: {listCounterTEST}");
                Console.WriteLine($"Distances in calculatedDistances variable: {calculatedDistancesTEST.Count}");
                Console.WriteLine($"Points in space {space.Count}");
                double _sumOfDistancesTEST = 0;
                for(int i =0; i< calculatedDistancesTEST.Count; i++)
                    _sumOfDistancesTEST +=calculatedDistancesTEST[i];
                Console.WriteLine($"now intramultiple distance is : {_sumOfDistancesTEST/calculatedDistancesTEST.Count}");
            }
            public void Print()
            {
                double _sumOfDistances = 0;
                for (int i = 0; i < calculatedDistances.Count; i++)
                {
                    _sumOfDistances += calculatedDistances[i];
                }
                Console.WriteLine($"Your intramultiple distance: {_sumOfDistances / calculatedDistances.Count}");
            }
        }
    }
}
