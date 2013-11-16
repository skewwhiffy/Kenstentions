using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Kenstentions.Test.TestUtil
{
    public static class CollectionTestUtil
    {
        public static void AssertIsEquivalent<T>(
            this List<T> left,
            IList<T> right)
        {
            if (left == null || left.Count == 0)
            {
                Assert.IsTrue(right == null || right.Count == 0);
                return;
            }
            Assert.AreEqual(left.Count, right.Count);
            List<T> smallerLeft = left.ToList();
            List<T> smallerRight = right.ToList();
            Assert.IsTrue(smallerRight.Contains(smallerLeft[0]));
            smallerRight.Remove(smallerLeft[0]);
            smallerLeft.Remove(smallerLeft[0]);
            smallerLeft.AssertIsEquivalent(smallerRight);
        }
    }
}
