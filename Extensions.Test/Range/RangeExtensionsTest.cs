using System.Collections.Generic;
using System.Linq;
using Kenstentions.Range;
using Kenstentions.Test.TestUtil;
using NUnit.Framework;

namespace Kenstentions.Test.Range
{
    [TestFixture]
    public class RangeExtensionsTest
    {
        private const int Start = 1;
        private const int Finish = 100;
        private const int Step = 10;
        private const int Except1 = 5;
        private const int Except2 = 10;

        #region Integer ranges

        [Test]
        public void SimpleIntegerRangeWorks()
        {
            var expected = new List<int>();
            for (int i = Start; i <= Finish; i++)
            {
                expected.Add(i);
            }
            expected.AssertIsEquivalent(Start.To(Finish).ToList());
        }

        [Test]
        public void IntegerRangeWithStepWorks()
        {
            var expected = new List<int>();
            for (int i = Start; i <= Finish; i += Step)
            {
                expected.Add(i);
            }
            expected.AssertIsEquivalent(Start.To(Finish).Step(Step).ToList());
        }

        [Test]
        public void IntegerRangeWithExceptWorks()
        {
            var expected = new List<int>();
            for (int i = Start; i <= Finish; i++)
            {
                if (i != Except1 && i != Except2)
                {
                    expected.Add(i);
                }
            }
            expected.AssertIsEquivalent(Start.To(Finish).Except(Except1, Except2).ToList());
        }

        [Test]
        public void IntegerRangeWithNestedExceptWorks()
        {
            var expected = new List<int>();
            for (int i = Start; i <= Finish; i++)
            {
                if (i != Except1 && i != Except2)
                {
                    expected.Add(i);
                }
            }
            expected.AssertIsEquivalent(Start.To(Finish).Except(Except1).Except(Except2).ToList());
        }

        #endregion
    }
}
