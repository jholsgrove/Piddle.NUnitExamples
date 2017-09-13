using System;

namespace Piddle.NUnitExamples
{
    /// <summary>
    /// A class with a method we can write some example tests for.
    /// </summary>
    public class ClassToTest
    {
        /// <summary>
        /// A factory method for <see cref="DateTimeOffset.UtcNow"/>.
        /// </summary>
        private readonly Func<DateTimeOffset> _utcNowFactory;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="utcNowFactory">A factory method for <see cref="DateTimeOffset.UtcNow"/>, so we can test.</param>
        public ClassToTest(Func<DateTimeOffset> utcNowFactory)
        {
            _utcNowFactory = utcNowFactory;
        }

        /// <summary>
        /// Calculates the <see cref="DateTimeOffset"/> of <paramref name="offset"/> from UTC now.
        /// </summary>
        /// <param name="offset">How much to offset.</param>
        /// <returns>The <see cref="DateTimeOffset"/> of <paramref name="offset"/> from UTC now.</returns>
        public DateTimeOffset CalculateOffsetFromUtcNow(TimeSpan offset)
        {
            return _utcNowFactory().Add(offset);
        }
    }
}