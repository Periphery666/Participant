//Visual Studio 2015
// .net 4.5
//Stas ryazanov
//+380501346717


namespace Test_Task
{
    class Mark
    {

        private const int NEW_SIZE_DELTA_MIN_MAX = 2;


        #region Methods

        public static void SetMarksDelta(GropeAthlete ga)
        {
            for (int i = 0; i < ga.Count; i++)
            {
                ga.SetMarks(i, FindMaxMinMarks((Participant)ga[i]));
                ga.SetDelta(DeltaMark((Participant)ga[i]), i);

            }
        }



         private static double [] FindMaxMinMarks(Participant par)
        {
            int minPos = 0;
            int maxPos = 0;
            double min = par[0];
            double max = par[0];

            for (int i = 1; i < par.Count; i++)
            {
                if (min > par[i])
                {
                    min = par[i];
                    minPos = i;
                    continue;
                }
                if (max < par[i])
                {
                    max = par[i];
                    maxPos = i;
                }
            }

           return  RemoveMaxMinMarks(par, minPos, maxPos);

        }

        private static double [] RemoveMaxMinMarks(Participant par, int minPos, int maxPos)
        {

            double[] sourse = new double[par.Count - NEW_SIZE_DELTA_MIN_MAX];

            int iterator = 0;
            for (int i = 0; i < par.Count; i++)
            {
                if (minPos==i || maxPos==i)
                {
                    continue;
                }
                sourse[iterator] = par[i];
                ++iterator;
            }

            return sourse;


        }


        public static double DeltaMark(Participant par)
        {
            double sum = 0;

            for (int i = 0; i < par.Count; i++)
            {
                sum += (double)par[i];
            }

            return sum / par.Count;

        }

        #endregion

    }
}
