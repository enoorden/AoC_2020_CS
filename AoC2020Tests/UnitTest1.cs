using Day09;
using Xunit;

namespace AoC2020Tests
{
    public class day09tests
    {
        long[] Range = new long[] { 1, 2, 3, 4, 5 };

        [Fact]
        public void RangeContainsSum1()
        {
            var result = day09.RangeContainsSum(Range, 9);
            Assert.True(result, "should be true");
        }
        [Fact]
        public void RangeContainsSum2()
        {
            var result = day09.RangeContainsSum(Range, 10);
            Assert.False(result, "should be false");
        }
        [Fact]
        public void RangeContainsSum3()
        {
            var result = day09.RangeContainsSum(Range, 6);
            Assert.True(result, "should be true");
        }
        [Fact]
        public void RangeContainsSum4()
        {
            var result = day09.RangeContainsSum(Range, 2);
            Assert.False(result, "should be false");
        }
    }

    public class day11tests
    {

    }
}
