//Visual Studio 2015
// .net 4.5
//Stas ryazanov
//+380501346717

using System;


namespace Test_Task
{
    class Viewer
    {
        private const int SIZE_BEST = 3;

        public static void Print(IContainer cont)
        {

            foreach (Participant itemF in cont)
            {
                Console.WriteLine(itemF);

                foreach (double itemS in itemF)
                {
                    Console.Write(" {0} ||", itemS);
                }
                Console.WriteLine("Delta {0}", itemF.Delta);
            }
            Console.WriteLine();
            System.Threading.Thread.Sleep(5000);
        }


        //todo
        //public static void PritnBest(IContainer cont)
        //{
        //    for (int i = 0; i <((Participant)cont).Count; i++)
        //    {
        //        for (int j = i; j < ((Participant)cont).Count; j++)
        //        {
        //            if ((Participant)cont)[])
        //            {

        //            }
        //        }
        //    }


        //}


    }
}
