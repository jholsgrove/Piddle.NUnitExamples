using NUnit.Framework;
using System;

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
        //       ( now                         , seconds        , expected                    )]
        [TestCase( "2017-09-12T23:20:00+00:00" , 0              , "2017-09-12T23:20:00+00:00" )]
        [TestCase( "2017-09-12T22:20:00+00:00" , 3600 + 120 + 3 , "2017-09-12T23:22:03+00:00" )]
        [TestCase( "2017-09-12T23:20:00+00:00" , 3600 + 120 + 3 , "2017-09-13T00:22:03+00:00" )]
        public void TestCalculateOffsetFromUtcNow4(string now, int seconds, string expected)
        {
            // GIVEN I have an instance of ClassToTest
            var instance = new ClassToTest(() => DateTimeOffset.Parse(now));

            // WHEN I call CalculateOffsetFromUtcNow with a TimeSpan
            var result = instance.CalculateOffsetFromUtcNow(TimeSpan.FromSeconds(seconds));

            // THEN it returns the correct DateTimeOffset.
            Assert.That(result, Is.EqualTo(DateTimeOffset.Parse(expected)), $"Expected a result of {expected}");
        }
    }
}
