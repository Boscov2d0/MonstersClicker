using System;
using System.Collections;

using Object = UnityEngine.Object;

namespace MonstersGame
{
    public class TestInteractiveObjectsList<T> : IEnumerable, IEnumerator
    {
        private T[] _objects;

        private int _index = -1;
        //private int _leght;
        public object Current => _objects[_index];
        public int Length { get => _objects.Length; }


        public bool MoveNext()
        {
            if (_index == Length - 1)
            {
                Reset();
                return false;
            }

            _index++;
            return true;
        }

        public void Reset()
        {
            _index = -1;
        }
        public IEnumerator GetEnumerator()
        {
            return this;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
