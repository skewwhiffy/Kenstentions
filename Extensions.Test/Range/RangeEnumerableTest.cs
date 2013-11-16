using System;
using System.Collections.Generic;
using System.Linq;
using Kenstentions.Range;
using Kenstentions.Test.TestUtil;
using NUnit.Framework;

namespace Kenstentions.Test.Range
{
    [TestFixture]
    public class RangeEnumerableTest
    {
        private const int Start = 1;
        private const int Finish = 100;
        private const int Step = 10;
        private List<int> _except;
        private List<int> _exceptSecond;

        [SetUp]
        public void BeforeEach()
        {
            _except = new List<int> { 3, 58 };
            _exceptSecond = new List<int> { 39, 8 };
        }

        [Test]
        public void SimpleRangeWorks()
        {
            var enumerable = new RangeEnumerable(Start, Finish);
            var expected = new List<int>();
            for (int i = Start; i <= Finish; i++)
            {
                expected.Add(i);
            }
            expected.AssertIsEquivalent(enumerable.ToList());
        }

        [Test]
        public void StepWorks()
        {
            var enumerable = new RangeEnumerable(Start, Finish)
                {
                    Step = Step
                };
            var expected = new List<int>();
            for (int i = Start; i <= Finish; i+=Step)
            {
                expected.Add(i);
            }
            expected.AssertIsEquivalent(enumerable.ToList());
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SettingStepAfterGettingEnumeratorThrows()
        {
            var enumerable = new RangeEnumerable(Start, Finish);
            int first = enumerable.FirstOrDefault();
            enumerable.Step = Step;
            Assert.Fail("{0}", first);
        }

        [Test]
        public void ExceptWorks()
        {
            var enumerable = new RangeEnumerable(Start, Finish)
                {
                    Except = _except
                };
            var expected = new List<int>();
            for (int i = Start; i <= Finish; i++)
            {
                if (!_except.Contains(i))
                {
                    expected.Add(i);
                }
            }
            expected.AssertIsEquivalent(enumerable.ToList());
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SettingExceptAfterGettingEnumeratorThrows()
        {
            var enumerable = new RangeEnumerable(Start, Finish);
            int first = enumerable.FirstOrDefault();
            enumerable.Except = _except;
            Assert.Fail("{0}", first);
        }

        [Test]
        public void ChangingExceptAfterSettingDoesNotAffectExceptValues()
        {
            var enumerable = new RangeEnumerable(Start, Finish)
                {
                    Except = _except
                };
            var expected = new List<int>();
            for (int i = Start; i <= Finish; i++)
            {
                if (!_except.Contains(i))
                {
                    expected.Add(i);
                }
            }
            _except.Add(23);
            expected.AssertIsEquivalent(enumerable.ToList());
        }

        [Test]
        public void SettingExceptTwiceExceptsBothSets()
        {
            var enumerable = new RangeEnumerable(Start, Finish)
                {
                    Except = _except
                };
            var expected = new List<int>();
            for (int i = Start; i <= Finish; i++)
            {
                if (!_except.Contains(i) && !_exceptSecond.Contains(i))
                {
                    expected.Add(i);
                }
            }
            enumerable.Except = _exceptSecond;
            expected.AssertIsEquivalent(enumerable.ToList());
            _except.AddRange(_exceptSecond);
            _except.AssertIsEquivalent(enumerable.Except);
        }
    }
}
