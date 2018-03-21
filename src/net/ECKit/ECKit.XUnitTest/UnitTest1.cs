using FluentAssertions;
using System;
using Xunit;

namespace ECKit.XUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            "HelloWorld".Should().Be("HelloWorld");
        }
    }
}
