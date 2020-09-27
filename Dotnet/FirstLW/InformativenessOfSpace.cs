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
            Console.WriteLine("FINISHED FILLING ALL CLASSES ");


            for (int i = 1; i < numberOfClasses; i++)
            {
                Console.WriteLine($"Class number: {i}");
                _spaceDisplayer.DisplaySpace(ref listOfClasses[i]);
            }


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
    }
}
