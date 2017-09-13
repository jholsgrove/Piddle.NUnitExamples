using NUnit.Framework;
using System;

namespace Piddle.NUnitExamples
{
    [TestFixture]
    public class NUnitExample3
    {
        [Test]
        [Description(@"
            GIVEN I have an instance of ClassToTest
            WHEN I call CalculateOffsetFromUtcNow with a TimeSpan
            THEN it returns the correct DateTimeOffset.
        ")]
        public void TestCalculateOffsetFromUtcNow3()
        {
            // GIVEN I have an instance of ClassToTest

            const int hours = 1;
            const int minutes = 2;
            const int seconds = 3;
            var now = new DateTimeOffset(2017, 9, 12, 22, 20, 0, TimeSpan.Zero);
            var instance = new ClassToTest(() => now);

            // WHEN I call CalculateOffsetFromUtcNow with a TimeSpan

            var result = instance.CalculateOffsetFromUtcNow(new TimeSpan(hours, minutes, seconds));

            // THEN it returns the correct DateTimeOffset.

            var expected = now.UtcTicks
                + (TimeSpan.TicksPerHour * hours)
                + (TimeSpan.TicksPerMinute * minutes)
                + (TimeSpan.TicksPerSecond * seconds);
            Assert.That(result.UtcTicks, Is.EqualTo(expected));
        }
    }
}
