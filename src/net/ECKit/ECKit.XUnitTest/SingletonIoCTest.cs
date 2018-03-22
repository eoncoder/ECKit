using FluentAssertions;
using ECKit;
using Xunit;
using ECKit.XUnitTest.Model;

namespace ECKit.XUnitTest
{

    public class SingletonIoCTest
    {
        [Fact]
        public void SingletonIoCTest_100_Empty_string_should_be_equal_to_sha1()
        {
            SingletonIoC.Instance.AddSingleton<TestInject>();            

            TestInject v_test = SingletonIoC.Instance.GetService<TestInject>();
            v_test.Value.Should().Be(0);

            v_test.Value = 2;
            TestInject v_testTwo = SingletonIoC.Instance.GetService<TestInject>();
            v_testTwo.Value.Should().Be(2);

        }


    }
}
