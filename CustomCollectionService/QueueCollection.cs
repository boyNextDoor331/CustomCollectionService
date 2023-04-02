using CustomCollectionService.Exceptions;
using System.Collections;

namespace CustomCollectionService
{
    public class QueueCollection<T> : IQueueCollection<T>
    {
        private T[] _values;

        public QueueCollection()
        {
            _values = new T[0];
        }

        public int Capacity => _values.Length;

        public T[] Messages => _values;


        public void Enqueue(T value)
        {
            if (value != null)
            {
                var termArray = new T[_values.Length + 1];
                termArray[0] = value;
                for (int i = 0; i < _values.Length; i++)
                {
                    termArray[i + 1] = _values[i];
                }
                _values = termArray;
            }
            else 
            {
                throw new NullArgumentEcxeption("Input must not be null");
            }
        }

        public T Dequeue()
        {
            var result = _values[_values.Length - 1];
            var tempArray = new T[_values.Length - 1];
            for(int i = 0; i < _values.Length - 1; i++)
            {
                tempArray[i] = _values[i];
            }
            _values = tempArray;
            return result;
        }


        public void Clean()
        {
            _values = new T[0];
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
