using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Durwella.DspLinq.Tests
{
    public class DecimateTest
    {
        [Fact]
        public void ThrowsWhenSourceIsNull()
        {
            IEnumerable<int> sequence = null;
            Action act = () => sequence.Decimate();
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void EmptyCase()
        {
            new int[0].Decimate().Should().BeEmpty();
        }

        [Fact]
        public void NineElementsReturnedUnchanged()
        {
            var sequence = new [] { 10, 20, 30, 40, 50, 60, 70, 80, 90 };
            sequence.Decimate().Should().Equal(sequence);
        }

        [Fact]
        public void ReturnsNineFromTen()
        {
            var sequence = Enumerable.Range(100, 10);
            sequence.Decimate().Should().Equal(Enumerable.Range(100, 9));
        }

        [Fact]
        public void SkipsTwentiethAndThirtiethElements()
        {
            var sequence = "AAAAAAAAAABBBBBBBBBBCCCCCCCCCC";
            var actual = new string(sequence.Decimate().ToArray());
            actual.Should().HaveLength(27)
                .And.Be("AAAAAAAAABBBBBBBBBCCCCCCCCC");
        }

        [Fact]
        public void DoesNotConsumeSequence()
        {
            var sequence = new ThrowingEnumerable();
            sequence.Decimate();
        }
    }
}
