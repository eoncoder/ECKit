using FluentAssertions;
using Xunit;
using ECKit.Helper;

namespace ECKit.XUnitTest
{
    public class HashHelperTest
    {
        [Fact]
        public void HashHelperTest_100_Empty_string_should_be_equal_to_sha1()
        {
            string v_result = "da39a3ee5e6b4b0d3255bfef95601890afd80709";

            HashHelper.Sha1With(string.Empty).Should().Be(v_result);
        }

        [Fact]
        public void HashHelperTest_200_Empty_string_should_be_equal_to_md5()
        {
            uint v_result = 3649838548;

            HashHelper.Md5With(string.Empty).Should().Be(v_result);
        }
    }
}
