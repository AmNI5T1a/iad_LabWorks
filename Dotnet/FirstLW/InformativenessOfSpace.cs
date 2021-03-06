using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace IAD
{
    struct Sector
    {
        public Vector2 from;
        public Vector2 to;

        private static int SectorCounter = 0;
        public Sector(float fromX, float fromY, float toX, float toY)
        {
            this.from.X = fromX;
            this.from.Y = fromY;
            this.to.X = toX;
            this.to.Y = toY;
            SectorCounter++;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"From:({from.X},{from.Y}) to ({to.X},{to.Y})");
        }
    }
    class InformativenessOfSpace
    {
        private SpaceFiller _spaceFiller = new SpaceFiller();
        private IntramultipleDistance _intraDistance = new IntramultipleDistance();
        private SectorCreator _sectorCreator = new SectorCreator();
        private Random _rndGeneration = new Random();
        private SpaceDisplayer _spaceDisplayer = new SpaceDisplayer();
        private BetweenSetsDistance _betweenSetsDis = new BetweenSetsDistance();
        public void MainMethod()
        {
            Console.WriteLine("Input number of classes: ");

            short numberOfClasses = Convert.ToInt16(Console.ReadLine());


            List<Vector2>[] listOfClasses = new List<Vector2>[numberOfClasses];

            for (int i = 0; i < numberOfClasses; i++)
            {
                listOfClasses[i] = new List<Vector2>();
            }


            List<Sector> sectors = new List<Sector>();

            _sectorCreator.GenerateSectors(ref sectors, numberOfClasses);

            foreach (Sector i in sectors)
            {
                Console.WriteLine($"Sector: {i}");
                i.DisplayInfo();
            }

            for (int i = 0; i < numberOfClasses; i++)
            {
                Sector tempSector = sectors[i];
                _spaceFiller.FillSpace(ref listOfClasses[i], _rndGeneration.Next(1, 25), ref tempSector);
                sectors[i] = tempSector;
            }

            Console.WriteLine("_____________________SHOWING U ALL POINTS..._______________________________");
            for (int i = 0; i < numberOfClasses; i++)
            {
                Console.WriteLine($"Iteration number {i + 1}");
                _spaceDisplayer.Print(listOfClasses[i]);
            }
            Console.WriteLine("_______________END OF SHOWING ALL POINTS IN ALL CLASSES____________________");


            for (int i = 0; i < numberOfClasses; i++)
            {
                _intraDistance.CalculateIntramultipleDistance(ref listOfClasses[i]);
            }

            _intraDistance.Print();

            _betweenSetsDis.MainMethod(numberOfClasses, ref listOfClasses);

            //Console.WriteLine($"Between sets distance is: {_betweenSetsDis.CalculateFinalDistance().ToString()}");
            //Console.WriteLine($"Your Intramultiple Distance is : {_intraDistance.ReturnIntraDistance().ToString()}");
            Console.WriteLine($"Your Informativeness of space is : {_betweenSetsDis.CalculateFinalDistance()/_intraDistance.ReturnIntraDistance()}");

            

        }
        class SpaceDisplayer : IDisplayer
        {
            public void Print(in List<Vector2> list)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine($"X: {list[i].X }, Y: {list[i].Y}");
                }
            }
        }
        class SpaceFiller
        {
            Random rndGeneration = new Random();

            /// <summary>
            /// butting - number of points in your class
            /// </summary>

            public void FillSpace(ref List<Vector2> spaceToFill, int butting, ref Sector sector)
            {
                for (int i = 0; i < butting; i++)
                {
                    spaceToFill.Add(new Vector2(rndGeneration.Next((int)sector.from.X, (int)sector.to.X), rndGeneration.Next((int)sector.from.Y, (int)sector.to.Y)));
                }
            }
            /// <summary>
            /// Same as FillSpace but with debug info
            /// </summary>
            public void FillSpaceDebug(ref List<Vector2> spaceToFill, int butting, ref Sector sector)
            {
                Console.WriteLine("__________________MAIN INFO_______________");
                sector.DisplayInfo();
                Console.WriteLine($"(int)sector.from.X : {(int)sector.from.X}");
                Console.WriteLine($"(int)sector.to.Y : {(int)sector.to.Y}");
                Console.WriteLine($"{butting.ToString()}");
                Console.WriteLine("__________________MAIN INFO END_______________");

                for (int i = 0; i < butting; i++)
                {
                    spaceToFill.Add(new Vector2(rndGeneration.Next((int)sector.from.X, (int)sector.to.X), rndGeneration.Next((int)sector.from.Y, (int)sector.to.Y)));
                }

            }
        }
        class SectorCreator
        {
            public void GenerateSectors(ref List<Sector> sectors, short numberOfSectors)
            {
                for (int i = 1; i < numberOfSectors + 1; i++)
                {
                    Console.WriteLine($"Creating {i} sector: ");
                    string[] coordinates = Console.ReadLine().Split(' ');
                    long fromX = long.Parse(coordinates[0]);
                    long fromY = long.Parse(coordinates[1]);
                    long toX = long.Parse(coordinates[2]);
                    long toY = long.Parse(coordinates[3]);

                    sectors.Add(new Sector(fromX, fromY, toX, toY));

                    Console.WriteLine($"Added sector with: ({fromX},{fromY});({toX},{toY})");
                }
            }
        }

        interface IDisplayer
        {
            void Print(in List<Vector2> list);
        }


        class IntramultipleDistance
        {
            public double EuclidDistance(Vector2 firstTemp, Vector2 secondTemp)
            {
                double result = Math.Sqrt(Math.Pow(firstTemp.X - secondTemp.X, 2) + Math.Pow(firstTemp.Y - secondTemp.Y, 2));
                return result;
            }
            List<Double> calculatedDistances = new List<double>();

            int listCounterTEST = 0;

            public double CalculateIntramultipleDistance(ref List<Vector2> space)
            {
                listCounterTEST++;
                List<Double> calculatedDistancesTEST = new List<double>();
                for (int i = 0; i < space.Count; i++)
                {
                    for (int j = 0; j < space.Count; j++)
                    {
                        if (i != j)
                        {
                            calculatedDistances.Add(EuclidDistance(space[i], space[j]));
                            calculatedDistancesTEST.Add(EuclidDistance(space[i], space[j]));
                        }
                    }
                }
                Console.WriteLine("___________________________________________");
                Console.WriteLine($"List number: {listCounterTEST}");
                Console.WriteLine($"Distances in calculatedDistances variable: {calculatedDistancesTEST.Count}");
                Console.WriteLine($"Points in space {space.Count}");
                double _sumOfDistancesTEST = 0;
                for (int i = 0; i < calculatedDistancesTEST.Count; i++)
                    _sumOfDistancesTEST += calculatedDistancesTEST[i];
                Console.WriteLine($"now intramultiple distance is : {_sumOfDistancesTEST / calculatedDistancesTEST.Count}");



                double _sumOfDistances = 0;
                for (int i = 0; i < calculatedDistances.Count; i++)
                {
                    _sumOfDistances += calculatedDistances[i];
                }
                return _sumOfDistances;
            }
            public void Print()
            {
                double foldedDistances = 0;
                for (int i = 0; i < calculatedDistances.Count; i++)
                {
                    foldedDistances += calculatedDistances[i];
                }

                Console.WriteLine($"Your final Intramultiple Distance is: {foldedDistances / calculatedDistances.Count}");
            }
            public double ReturnIntraDistance()
            {
                double foldedDistances = 0;

                for (int i = 0; i < calculatedDistances.Count; i++)
                {
                    foldedDistances += calculatedDistances[i];
                }

                return foldedDistances/calculatedDistances.Count;
            }
        }
        class BetweenSetsDistance
        {
            List<Double> allDistances = new List<double>();
            public void MainMethod(in short numberOfClasses, ref List<Vector2>[] listOfSpaces)
            {
                List<List<Vector2>> _blacklist = new List<List<Vector2>>();

                for (int i = 0; i < numberOfClasses; i++)
                {
                    _blacklist.Add(listOfSpaces[i]);
                    for (int j = 0; j < numberOfClasses; j++)
                    {
                        if (!_blacklist.Contains(listOfSpaces[j]))
                        {
                            CalculateDistance(ref listOfSpaces[i], ref listOfSpaces[j]);
                        }
                    }
                }
                Console.WriteLine($"DISTANCE BETWEEN ALL SETS: {CalculateFinalDistance().ToString()}");
            }

            private void CalculateDistance(ref List<Vector2> blacklistedSpace, ref List<Vector2> anotherSpace)
            {
                IntramultipleDistance _euclidDistance = new IntramultipleDistance();

                for (int i = 0; i < blacklistedSpace.Count; i++)
                {
                    for (int j = 0; j < anotherSpace.Count; j++)
                    {
                        allDistances.Add(_euclidDistance.EuclidDistance(blacklistedSpace[i], anotherSpace[j]));
                    }
                }
            }
            public double CalculateFinalDistance()
            {
                double flattenedDistances = 0;
                for (int i = 0; i < allDistances.Count; i++)
                {
                    flattenedDistances += allDistances[i];
                }
                return (flattenedDistances / allDistances.Count);
            }
        }
    }
}
