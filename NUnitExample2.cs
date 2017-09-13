using NUnit.Framework;
using System;

namespace Piddle.NUnitExamples
{
    [TestFixture]
    public class NUnitExample2
    {
        [Test]
        public void TestCalculateOffsetFromUtcNow2()
        {
            // Arrange.

            const int hours = 1;
            const int minutes = 2;
            const int seconds = 3;
            var now = new DateTimeOffset(2017, 9, 12, 22, 20, 0, TimeSpan.Zero);
            var instance = new ClassToTest(() => now);

            // Act.

            var result = instance.CalculateOffsetFromUtcNow(new TimeSpan(hours, minutes, seconds));

            // Assert.

            var expected = now.UtcTicks
                + (TimeSpan.TicksPerHour * hours)
                + (TimeSpan.TicksPerMinute * minutes)
                + (TimeSpan.TicksPerSecond * seconds);
            Assert.That(result.UtcTicks, Is.EqualTo(expected));
        }
    }
}
