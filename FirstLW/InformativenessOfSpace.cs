using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace IAD
{

    /// <summary>
    /// Task completed without using solutions from previous tasks
    /// </summary>
    public class InformativenessOfSpace
    {
        private short numberOfSpaces;
        private CreateSpace _spaceCreator = new CreateSpace();
        public void MainMethod()
        {
            Console.WriteLine("Input number of classes(spaces): ");
            numberOfSpaces = Convert.ToInt16(Console.ReadLine());

            _spaceCreator.Create(numberOfSpaces);

        }

    }

    class CreateSpace
    {
        public void Create(in short classesInSpace)
        {
            List<Vector2>[] mainSpace = new List<Vector2>[classesInSpace];

            //for (int i = 0; i < classesInSpace; i++)
                //mainSpace[i].Add(new Vector2(1, 1));

            for(int i = 0; i < classesInSpace; i++)
                Console.WriteLine($"{mainSpace[i]}");
        }
        
    }
}