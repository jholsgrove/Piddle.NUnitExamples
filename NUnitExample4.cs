using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Piddle.NUnitExamples
{
    [TestFixture]
        public class NUnitExample4
    {
        [Test]
        [Description(@"
            GIVEN I have an instance of ClassToTest
            WHEN I call CalculateOffsetFromUtcNow with a TimeSpan
            THEN it returns the correct DateTimeOffset.
        ")]
        [TestCaseSource(nameof(GetTestCases))]
        public void TestCalculateOffsetFromUtcNow4(DateTimeOffset now, TimeSpan timeSpan, DateTimeOffset expected)
        {
            // GIVEN I have an instance of ClassToTest
            var instance = new ClassToTest(() => now);

            // WHEN I call CalculateOffsetFromUtcNow with a TimeSpan
            var result = instance.CalculateOffsetFromUtcNow(timeSpan);

            // THEN it returns the correct DateTimeOffset.
            Assert.That(result, Is.EqualTo(expected), $"Expected a result of {expected}");
        }

        private static IEnumerable<TestCaseData> GetTestCases()
        {
            //                           ( now                                                       , timeSpan                , expected                                                  );
            yield return new TestCaseData( new DateTimeOffset(2017, 9, 12, 22, 20, 0, TimeSpan.Zero) , TimeSpan.FromSeconds(0) , new DateTimeOffset(2017, 9, 12, 22, 20, 0, TimeSpan.Zero) );
            yield return new TestCaseData( new DateTimeOffset(2017, 9, 12, 22, 20, 0, TimeSpan.Zero) , new TimeSpan(1, 2, 3)   , new DateTimeOffset(2017, 9, 12, 23, 22, 3, TimeSpan.Zero) );
            yield return new TestCaseData( new DateTimeOffset(2017, 9, 12, 23, 20, 0, TimeSpan.Zero) , new TimeSpan(1, 2, 3)   , new DateTimeOffset(2017, 9, 13, 0, 22, 3, TimeSpan.Zero)  );
        }
    }
}
