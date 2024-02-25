using Statistics;

namespace AlbinsUnitTest
{
    public class AlbinsUnitTest
    {
        [Fact]
        public void maximum()
        {
            int expectedNumber = 378;

            int actualNumber = Statistics.Statistics.Maximum();

            Assert.Equal(expectedNumber, actualNumber);
        }

        [Fact]
        public void minimum()
        {
            int expectedNumber = -42;

            int actualNumber = Statistics.Statistics.Minimum();

            Assert.Equal(expectedNumber, actualNumber);
        }

        [Fact]
        public void mean() 
        {
            double expectedNumber = 167.3088;

            double actualNumber = Statistics.Statistics.Mean();
            
            Assert.Equal(expectedNumber, actualNumber);
        }

        [Fact]
        public void median()
        {
            int expectedNumber = 165;

            int actualNumber = (int)Statistics.Statistics.Median();

            Assert.Equal(expectedNumber, actualNumber);
        }

        [Fact]
        public void mode()
        {
            int[] expectedNumber = { 31, 87, 228 };

            int[] actualNumber = Statistics.Statistics.Mode();

            Assert.Equal(expectedNumber, actualNumber);
        }
        [Fact]
        public void range()
        {
            int expectedNumber = 420;
            
            int actualNumber = Statistics.Statistics.Range();

            Assert.Equal(expectedNumber, actualNumber);
        }
        [Fact]
        public void standarddeviation()
        {
            double expectedNumber = 122.3;

            double actualNumber = Statistics.Statistics.StandardDeviation();

            Assert.Equal(expectedNumber, actualNumber);
        }
    }
}