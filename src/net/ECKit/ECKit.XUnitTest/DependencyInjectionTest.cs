using System;
using ECKit.XUnitTest.Model;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace ECKit.XUnitTest
{


    public class DependencyInjectionTest
    {
        [Fact]
        public void DependencyInjectionTest_100_Empty_string_should_be_equal_to_sha1()
        {
            IServiceProvider v_Provider = new ServiceCollection()
                .AddSingleton<TestInject>()
                .BuildServiceProvider();

            TestInject v_test = v_Provider.GetService<TestInject>();
            v_test.Value.Should().Be(0);

            v_test.Value = 2;
            TestInject v_testTwo = v_Provider.GetService<TestInject>();
            v_testTwo.Value.Should().Be(2);



        }


    }
}
