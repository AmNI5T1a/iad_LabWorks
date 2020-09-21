class SpaceFiller
    {
        Random rndGeneration = new Random();

        /// <summary>
        /// Fill list with random variables
        /// </summary>
        public void Fill(ref List<Vector2> list, ref short butting, short from, short to)
        {
            for (short i = 0; i < butting; i++)
                list.Add(new Vector2(rndGeneration.Next(from,to),rndGeneration.Next(from,to)));
        }
        /// <summary>
        /// Fill a list from another existing list
        /// <summary>
        public void Fill(ref List<Vector2> listToFill, ref short butting , ref List<Vector2> mainList)
        {
            for(short i=0;i< butting;i++)
                listToFill.Add(mainList[i]);
        }
    }