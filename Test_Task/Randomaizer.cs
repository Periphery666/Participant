//Visual Studio 2015
// .net 4.5
//Stas ryazanov
//+380501346717

using System;


namespace Test_Task
{
    class Randomaizer
    {
        private static Random rand = new Random();
        private const double VAL_FOR_DIVISION = 10;



        public static double GetDouble(int rangeWith, int rangeTo)
        {
            return Convert.ToDouble((rand.Next(rangeWith, rangeTo * (int)VAL_FOR_DIVISION)) / VAL_FOR_DIVISION);
        }
    }
}
