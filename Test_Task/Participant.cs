//Visual Studio 2015
// .net 4.5
//Stas ryazanov
//+380501346717

using System;
using System.Collections;


namespace Test_Task
{
    class Participant :  IEnumerable, ICloneable
    {

        #region Fields

        private string _mFirstName;
        private string _mLastName;
        private uint _mAge;
        private double _mDelte;

        private double[] _mMarks;

        private Discipline _mDisc;



        #endregion


        #region Properties

        public double Delta
        {
            get
            {
                return _mDelte;
            }

            set
            {
                _mDelte = (double)value;
            }
        }

        public string FirstName
        {
            get
            {
                return _mFirstName;
            }
            
        }
        public string LastName
        {
            get
            {
                return _mLastName;
            }

        }

        public int Count
        {
            get
            {
               return _mMarks.Length;
            }
        }


        public double this[int index]
        {
            get
            {
                if (index>=0 && index < _mMarks.Length)
                {
                    return _mMarks[index];
                }

                return -1;
            }

            set
            {
                if (index > 0 && index < _mMarks.Length)
                {
                     _mMarks[index] = value;
                }
            }
        }



        #endregion


        #region Constructs

        public Participant()
        {

        }

        public Participant(Participant part): this(part._mFirstName, part._mLastName, part._mAge, part._mDisc, part._mMarks, part._mDelte)
        {

        }


        public Participant(string firstName, string lastName, uint age, Discipline disc,  double[] marks, double delta = 0 )
        {
            _mFirstName = firstName;
            _mLastName = lastName;
            _mAge = age;
            _mDisc = disc;
            _mDelte = delta;
            _mMarks = (double [])marks.Clone();

        }



        #endregion


        #region Methods


        public void SetMarks(double [] newMarks)
        {
            _mMarks = (double[])newMarks.Clone();
        }

        public IEnumerator GetEnumerator()
        {
            return _mMarks.GetEnumerator();
        }

        public override string ToString()
        {
            return string.Format(" First Name  {0} \n Last Name {1} \n Discipline {2} ", _mFirstName, _mLastName , _mDisc);
        }

        public object Clone()
        {
            return new Participant(this);
        }

        #endregion



    }
}
