//Visual Studio 2015
// .net 4.5
//Stas ryazanov
//+380501346717

using System.Collections;

namespace Test_Task
{
    class IteratorParticipant : IEnumerator
    {
        private GropeAthlete _mPar;
        private int _mPos;

        public IteratorParticipant(GropeAthlete par)
        {
            _mPar = par;
            _mPos = -1;

        }
        public object Current
        {
            get
            {
               return _mPar[_mPos];
            }
        }

        public bool MoveNext()
        {
            ++_mPos;

           if (_mPos< _mPar.Count)
            {
                return true;
            }

            return false;
        }

        public void Reset()
        {
            _mPos = -1;
        }
    }
}
