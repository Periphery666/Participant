//Visual Studio 2015
// .net 4.5
//Stas ryazanov
//+380501346717

using System;
using System.Collections;


namespace Test_Task
{
    class ParticipantNameComparer : IComparer
    {
        private int _mrealSize;
        public int Compare(object x, object y)
        {
            if (_mrealSize==0)
            {
                return 0;
            }
            _mrealSize--;

            Participant p1 = x as Participant;
            Participant p2 = y as Participant;

            if (p1 ==null || p2 == null)
            {
                throw new InvalidCastException("Invalid Cast");
            }

            return p1.FirstName.CompareTo(p2.FirstName);

        }
        public ParticipantNameComparer(int realSize)
        {
            _mrealSize = realSize;
        }
    }
}
