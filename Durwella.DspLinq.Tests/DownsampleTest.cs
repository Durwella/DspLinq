using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Durwella.DspLinq.Tests
{
    public class DownsampleTest
    {
        [Fact]
        public void ThrowsWhenNIsZero()
        {
            var sequence = Enumerable.Range(1, 5);
            Action act = () => sequence.Downsample(0);
            act.ShouldThrowExactly<ArgumentException>();
        }

        [Fact]
        public void ThrowsWhenNIsNegative()
        {
            var sequence = Enumerable.Range(1, 5);
            Action act = () => sequence.Downsample(-1);
            act.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void EmptyCase()
        {
            new int[0].Downsample(1).Should().BeEmpty();
        }

        [Fact]
        public void DownsamplingWithNOfOneIncludesEveryElement()
        {
            var sequence = new [] { 10, 20, 30, 40, 50, 60, 70, 80, 90 };
            sequence.Downsample(1).Should().Equal(sequence);
        }

        [Fact]
        public void ReturnsEvenElements()
        {
            var sequence = Enumerable.Range(10, 10);
            sequence.Downsample(2).Should().Equal(10, 12, 14, 16, 18);
        }

        [Fact]
        public void ReturnsThirdElements()
        {
            var sequence = Enumerable.Range(1, 10);
            sequence.Downsample(3).Should().Equal(1, 4, 7, 10);
        }

        [Fact]
        public void ReturnsOneElementWhenNGreaterThanCount()
        {
            new int[10].Downsample(100).Should().HaveCount(1);
        }

        [Fact]
        public void DoesNotConsumeSequence()
        {
            var sequence = new ThrowingEnumerable();
            sequence.Downsample(1);
        }
    }
}
