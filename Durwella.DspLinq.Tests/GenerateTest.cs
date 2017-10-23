using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Durwella.DspLinq.Tests
{
    public class GenerateTest
    {
        [Fact]
        public void GeneratesConstantSignal()
        {
            var amplitude = 123;

            var signal = Generate.Constant(amplitude);

            signal.First().Should().Be(amplitude);
            signal.ElementAt(20).Should().Be(amplitude);
        }

        [Fact]
        public void GeneratesIntSquareWave()
        {
            var signal = Generate.Square(amplitude: 7, samplesPerCycle: 4);
            signal.Take(8).Should().Equal(7, 7, -7, -7, 7, 7, -7, -7);
        }

        [Fact]
        public void GeneratesFloatSquareWave()
        {
            var signal = Generate.Square(amplitude: 1.1f, samplesPerCycle: 5);
            signal.Take(10).Should().Equal(1.1f, 1.1f, -1.1f, -1.1f, -1.1f, 1.1f, 1.1f, -1.1f, -1.1f, -1.1f);
        }

        [Fact]
        public void GeneratesDoubleSquareWave()
        {
            var signal = Generate.Square(amplitude: 1.3, samplesPerCycle: 2);
            signal.Take(4).Should().Equal(1.3, -1.3, 1.3, -1.3);
        }

        [Fact]
        public void SquareWaveThrowsForNegativeSampleCount()
        {
            Assert.Throws<ArgumentException>(
                () => Generate.Square(1, -1));
        }
    }
}