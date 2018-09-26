using Xunit;
using FluentAssertions;

namespace VeiviserTest
{
    public class UnitTest1
    {
        [Fact]
        public void TestMethod1()
        {
            var noko = "yes";
            noko.Should().NotBeNullOrEmpty();

        }
    }
}
