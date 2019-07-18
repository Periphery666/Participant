//Visual Studio 2015
// .net 4.5
//Stas ryazanov
//+380501346717


namespace Test_Task
{
    class Judge
    {
        private const int MIN_MARK = 0x00;
        private const int MAX_MARK = 0x06;
        private const int COUNT_MARKS = 0x06;

        public static double[] GetMarks()
        {
            double[] source = new double[COUNT_MARKS];
            for (int i = 0; i < COUNT_MARKS; i++)
            {
                source[i] = Randomaizer.GetDouble(MIN_MARK, MAX_MARK);
            }

            return source;
        }

    }
}
