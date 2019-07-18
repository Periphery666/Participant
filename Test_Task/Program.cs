//Visual Studio 2015
// .net 4.5
//Stas ryazanov
//+380501346717

using System;


namespace Test_Task
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                GropeAthlete ga = new GropeAthlete();

                UI.ShowMenu();
                UI.GetChoice(ref ga);

            }

            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch
            {
                Console.WriteLine("Somthing Wrong");
            }

        }
    }
}
