using System;
using System.Collections;
using System.Collections.Generic;

namespace Kenstentions.Range
{
    public class RangeEnumerable : IEnumerable<int>
    {
        private readonly int _finish;
        private readonly int _start;
        private bool _enumeratorInitialized;

        public RangeEnumerable(int start, int finish)
        {
            _finish = finish;
            _start = start;
            Step = 1;
        }

        public IEnumerator<int> GetEnumerator()
        {
            _enumeratorInitialized = true;
            for (int i = _start; i <= _finish; i += Step)
            {
                if (!Except.Contains(i))
                {
                    yield return i;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private int _step;

        public int Step
        {
            get { return _step; }
            set
            {
                if (_enumeratorInitialized)
                {
                    throw new InvalidOperationException("Cannot set step on range after looping has started");
                }
                _step = value;
            }
        }

        private readonly List<int> _except = new List<int>();

        public IList<int> Except
        {
            get { return _except.AsReadOnly(); }
            set
            {
                if (_enumeratorInitialized)
                {
                    throw new InvalidOperationException("Cannot set except values on range after looping has started");
                }
                _except.AddRange(value);
            }
        }
    }
}
