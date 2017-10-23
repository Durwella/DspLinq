using System;
using System.Collections.Generic;

namespace Durwella.DspLinq
{
    /// <summary>
    /// Provides a set of static methods for 
    /// basic signal generation.
    /// Signals are represented as <see cref="IEnumerable{T}" />.
    /// The produced signals are infinite. 
    /// Thus you should not invoke operations that consume the entire enumerable (e.g. .Count() or .Last()).
    /// </summary>
    public static class Generate
    {
        /// <summary>
        /// Produces an inifinte signal of the given amplitude value.
        /// </summary>
        public static IEnumerable<T> Constant<T>(T amplitude)
        {
            while(true)
                yield return amplitude;
        }

        /// <summary>
        /// Produces a square wave that oscillates between amplitude and -amplitude.
        /// </summary>
        /// <param name="amplitude">The value of the starting amplitude</param>
        /// <param name="samplesPerCycle">The number of samples in the complete wave (half of which will be the given amplitude, while rest will be negated amplitude)</param>
        public static IEnumerable<int> Square(int amplitude, int samplesPerCycle) =>
            Square(amplitude, -amplitude, samplesPerCycle);

        /// <summary>
        /// Produces a square wave that oscillates between amplitude and -amplitude.
        /// </summary>
        /// <param name="amplitude">The value of the starting amplitude</param>
        /// <param name="samplesPerCycle">The number of samples in the complete wave (half of which will be the given amplitude, while rest will be negated amplitude)</param>
        public static IEnumerable<float> Square(float amplitude, int samplesPerCycle) =>
            Square(amplitude, -amplitude, samplesPerCycle);

        /// <summary>
        /// Produces a square wave that oscillates between amplitude and -amplitude.
        /// </summary>
        /// <param name="amplitude">The value of the starting amplitude</param>
        /// <param name="samplesPerCycle">The number of samples in the complete wave (half of which will be the given amplitude, while rest will be negated amplitude)</param>
        public static IEnumerable<double> Square(double amplitude, int samplesPerCycle) =>
            Square(amplitude, -amplitude, samplesPerCycle);

        private static IEnumerable<T> Square<T>(T peak, T trough, int samplesPerCycle) where T : struct
        {
            if (samplesPerCycle <= 0)
                throw new ArgumentException("Must be positive", nameof(samplesPerCycle));
            // Ensure arg exceptions are thrown by nesting coroutine
            return _(); IEnumerable<T> _()
            {
                while (true)
                {
                    var i = 0;
                    for(; i != samplesPerCycle / 2; ++i)
                        yield return peak;
                    for(; i != samplesPerCycle; ++i)
                        yield return trough;
                }
            }
        }
    }
}