//Visual Studio 2015
// .net 4.5
//Stas ryazanov
//+380501346717

using System;
using System.Collections;


namespace Test_Task
{
    class GropeAthlete : IContainer, IEnumerable
    {
        private const int START_SIZE = 3;

        private Participant[] _mParticipant;
        private int _mCapacity = START_SIZE;
        private int _mSize;



        #region Constr


        public GropeAthlete(int size = START_SIZE)
        {
            _mParticipant = new Participant[size];

            for (int i = 0; i < size; i++)
            {
                _mParticipant[i] = new Participant();
            }
            _mCapacity = size;
        }

        #endregion

        #region Methods


        public void SetDelta(double delta, int pos)
        {
            _mParticipant[pos].Delta = delta;
        }

        public void Sort()
        {
            Array.Sort(_mParticipant, new ParticipantNameComparer(_mSize));
        }

        private void Resize()
        {
            _mCapacity += START_SIZE;

            Array.Resize(ref _mParticipant, _mCapacity);
        }

        public void Add(Participant par)
        {
            if (_mSize == _mCapacity)
            {
                Resize();
            }

            _mParticipant[_mSize] = (Participant)par.Clone();
            ++_mSize;


        }

        public void Delete(int index)
        {

            if (_mSize == 0 || index < 0)
            {
                throw new Exception("He is Empty");
            }

            if (index < 0 && index > _mSize)
            {
                throw new IndexOutOfRangeException("Out of Range");
            }
            if (index == _mSize)
            {
                _mParticipant[index - 1] = null;
                --_mSize;
                return;
            }
            _mParticipant[index - 1] = (Participant)_mParticipant[_mSize - 1].Clone();
            _mParticipant[_mSize - 1] = null;
            --_mSize;
        }

        public void Delete()
        {
            Delete(_mSize - 1);
        }

        public object this[int index]
        {
            get
            {
                if (index >= 0 && index < _mSize)
                {
                    return _mParticipant[index].Clone();
                }
                return null;
            }

            set
            {
                if (index >= 0 && index < _mSize)
                {
                    _mParticipant[index] = (Participant)((Participant)value).Clone();
                }
                return;
            }
        }

        public void SetMarks(int pos, double[] newMarks)
        {
            _mParticipant[pos].SetMarks(newMarks);
        }

        public int Count
        {
            get
            {
                return _mSize;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new IteratorParticipant(this);
        }

        #endregion

    }
}
