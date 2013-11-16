using System.Linq;

namespace Kenstentions.Range
{
    public static class RangeExtensions
    {
        public static RangeEnumerable To(this int start, int finish)
        {
            return new RangeEnumerable(start, finish);
        }

        public static RangeEnumerable Step(this RangeEnumerable range, int step)
        {
            range.Step = step;
            return range;
        }

        public static RangeEnumerable Except(this RangeEnumerable range, params int[] excepts)
        {
            range.Except = excepts.ToList();
            return range;
        }
    }
}
