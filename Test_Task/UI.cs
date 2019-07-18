//Visual Studio 2015
// .net 4.5
//Stas ryazanov
//+380501346717

using System;


namespace Test_Task
{
    class UI
    {

        private const int OFFSET = 36;
        private const int MAX_CHOISE = 0x07;
        private static FuncStart _mfs;

        public static void ShowMenu()
        {
            Console.WriteLine("==========Select action ===========");
            Console.WriteLine();
            Console.WriteLine("1 Add Participant==================>");
            Console.WriteLine("2 Delete Participant===============>");
            Console.WriteLine("3 Show Participant=================>");
            Console.WriteLine("4 Sort Participant=================>");
            Console.WriteLine("5 Participant is starting show=====>");
            Console.WriteLine("6 Remove Min Max ==================>");
            Console.WriteLine("7 Exit");

        }


        public static void GetChoice(ref GropeAthlete ga)
        {
            int choise = 0;
            Console.SetCursorPosition(OFFSET, choise+1);

            ConsoleKeyInfo cci = new ConsoleKeyInfo();
            do
            {
                try
                {
                    cci = Console.ReadKey();
                    bool startFunc = Move(cci.Key, ref choise);
                    if (startFunc)
                    {
                        Console.Clear();
                        StartUserChoise(ref ga);
                        Console.Clear();
                        ShowMenu();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    System.Threading.Thread.Sleep(3000);
                    Console.Clear();
                    ShowMenu();
                }
            } while (choise != MAX_CHOISE || cci.Key != ConsoleKey.Enter);

        }


        private static void StartUserChoise(ref GropeAthlete ga)
        {
            try
            {
                switch (_mfs)
                {

                    case FuncStart.Add:
                        ga.Add(GetNewParticipant());
                        break;
                    case FuncStart.Delete:
                        ga.Delete(GetIndexDeleter(ga));
                        break;
                    case FuncStart.RemoveMinMax:
                        Mark.SetMarksDelta(ga);
                        break;
                    case FuncStart.Show:
                        Viewer.Print(ga);
                        break;
                    case FuncStart.Sort:
                        ga.Sort();
                        break;
                    case FuncStart.StartParticipant:
                        ParticipantShow(ref ga);
                        break;

                    default:
                        break;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void ParticipantShow(ref GropeAthlete ga)
        {
            if (ga.Count == 0)
            {
                throw new EmptyException("Grope is empty");
            }

            Console.WriteLine("Show is end");
            Console.WriteLine("Judge is going to set marks");
            for (int i = 0; i < ga.Count; i++)
            {
                ga.SetMarks(i,Judge.GetMarks());
            }

        }

        private static int GetIndexDeleter(GropeAthlete ga)
        {
            int index = 0;
            bool exit = false;
            if (ga.Count == 0)
            {
                return -1;
            }
            do
            {
                try
                {

                    Console.WriteLine("Set index to delete = > ");
                    index = int.Parse(Console.ReadKey().KeyChar.ToString());

                    if (index < 0 || index > ga.Count)
                    {
                        throw new Exception("Index Out Of Range");
                    }

                }
                catch (Exception ex)
                {
                    exit = true;
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Try agan");
                }

            } while (exit);

            return index;

        }

        private static Participant GetNewParticipant()
        {

            Console.WriteLine("Enter First Name => ");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name => ");
            string lastName = Console.ReadLine();

            bool goodParse = false;
            string strAge = string.Empty;
            int age = 0;
            Discipline disc = Discipline.NoDirection;

            do
            {
                try
                {
                    Console.WriteLine("Enter Age => ");
                    strAge = Console.ReadLine();
                    age = int.Parse(strAge);

                    Console.WriteLine("1 - Box, 2 -Gymnastics, 3-Swim, 4 -Wrestling ");
                    disc = (Discipline)int.Parse(Console.ReadKey().KeyChar.ToString());

                    goodParse = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Try agan");
                    goodParse = true;
                }
            } while (goodParse);

            return new Participant(firstName, lastName, (uint)age, disc, new double[] { 0.0d });
        }


        private static bool Move(ConsoleKey ck, ref int choise)
        {
            switch (ck)
            {
                case ConsoleKey.UpArrow:
                    if (choise != 0)
                    {
                        --choise;
                        --_mfs;
                        Console.SetCursorPosition(50, choise+1);
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (choise != MAX_CHOISE)
                    {
                        ++choise;
                        ++_mfs;
                        Console.SetCursorPosition(50, choise+1);
                    }
                    break;
                case ConsoleKey.Enter:
                    if (choise != MAX_CHOISE)
                    {
                        return true;
                    }
                    break;
            }
            return false;
        }

    }

}
