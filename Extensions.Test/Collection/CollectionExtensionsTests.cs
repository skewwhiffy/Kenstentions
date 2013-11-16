using System.Collections.Generic;
using System.Linq;
using Kenstentions.Collection;
using Kenstentions.Test.TestUtil;
using NUnit.Framework;

namespace Kenstentions.Test.Collection
{
  [TestFixture]
  public class CollectionExtensionsTests
  {
      #region Distinct

      [Test]
      public void DistinctWorksWithDistinctCollection()
      {
          var distinct = new List<int> {1, 2, 3};
          List<int> actual = distinct.Distinct(i => 2 * i).ToList();
          distinct.AssertIsEquivalent(actual);
      }

      [Test]
      public void DistinctWorksWithNonDistinctCollection()
      {
          var nonDistinct = new List<int> {1, 2, 2, 3};
          List<int> actual = nonDistinct.Distinct(i => 2*i).ToList();
          var expected = new List<int> {1, 2, 3};
          expected.AssertIsEquivalent(actual);
      }

      [Test]
      public void DistinctWorksWithDistinctCollectionWithNonDistinctKeys()
      {
          const string fiveLetterWord = "hello";
          const string anotherFiveLetterWord = "fails";
          var distinctWithNonDistinctKeys = new List<string> {"hello", "goodbye", "aardvark", "fails"};
          List<string> actual = distinctWithNonDistinctKeys.Distinct(s => s.Length).ToList();
          Assert.IsTrue(actual.All(distinctWithNonDistinctKeys.Contains));
          actual.ForEach(a => distinctWithNonDistinctKeys.Remove(a));
          Assert.AreEqual(1, distinctWithNonDistinctKeys.Count);
          string remaining = distinctWithNonDistinctKeys[0];
          Assert.IsTrue(remaining == fiveLetterWord || remaining == anotherFiveLetterWord);
      }

      #endregion

      #region ListWith

      [Test]
      public void ListWithWorksWithSingleton()
      {
          const string singleton = "hello";
          List<string> singletonList = singleton.ListWith();
          Assert.AreEqual(singleton, singletonList.SingleOrDefault());
      }

      [Test]
      public void ListWithWorksWithMultipleObjects()
      {
          const string first = "first";
          const string second = "second";
          const string third = "third";
          var expected = new List<string> {first, second, third};
          List<string> actual = first.ListWith(second, third);
          expected.AssertIsEquivalent(actual);
      }

      #endregion
  }
}
