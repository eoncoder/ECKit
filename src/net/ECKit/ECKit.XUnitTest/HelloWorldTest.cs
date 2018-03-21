using FluentAssertions;
using System;
using Xunit;

namespace ECKit.XUnitTest
{
    public class HelloWorldTest
    {
        [Fact]
        public void HelloWorld_100_String_SHOULD_BE_HelloWorld()
        {
            "HelloWorld".Should().Be("HelloWorld");
        }
    }
}
