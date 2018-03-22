using FluentAssertions;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using ECKit.Helper;
using ECKit.XUnitTest.Model;

namespace ECKit.XUnitTest
{
    public class ObjectPropertyTest
    {
        [Fact]
        public void ObjectPropertyTest_100_EnumerablePropertiesByAncestorsWithType_2_Levels_Should_be_2_items()
        {
            int v_ResultCount = 2;

            IEnumerable<PropertyInfo> v_Properties = ObjectProperty.EnumerablePropertiesByAncestorsWithType(typeof(HashHelperLevel1Model));
            v_Properties.Should().NotBeEmpty();

            v_Properties.Count().Should().Be(v_ResultCount);

        }

        [Fact]
        public void ObjectPropertyTest_110_EnumerablePropertiesByAncestorsWithType_3_Levels_Should_be_3_items()
        {
            int v_ResultCount = 3;

            IEnumerable<PropertyInfo> v_Properties = ObjectProperty.EnumerablePropertiesByAncestorsWithType(typeof(HashHelperLevel2Model));
            v_Properties.Should().NotBeEmpty();

            v_Properties.Count().Should().Be(v_ResultCount);
            v_Properties.ToArray()[0].Name.Equals("Base");
            v_Properties.ToArray()[1].Name.Equals("Level1");
            v_Properties.ToArray()[2].Name.Equals("Level2");
        }

        [Fact]
        public void ObjectPropertyTest_120_EnumerablePropertiesByAncestorsWithType_3_Levels_2_properties_Should_be_5_items()
        {
            int v_ResultCount = 5;

            IEnumerable<PropertyInfo> v_Properties = ObjectProperty.EnumerablePropertiesByAncestorsWithType(typeof(HashHelperLevel2_1Model));
            v_Properties.Should().NotBeEmpty();

            v_Properties.Count().Should().Be(v_ResultCount);
            v_Properties.ToArray()[0].Name.Should().Be("Base");
            v_Properties.ToArray()[1].Name.Should().Be("Level1_1");
            v_Properties.ToArray()[2].Name.Should().Be("Level1_2");
            v_Properties.ToArray()[3].Name.Should().Be("Level2_1");
            v_Properties.ToArray()[4].Name.Should().Be("Level2_2");
        }

        [Fact]
        public void ObjectPropertyTest_130_EnumerablePropertiesByAncestorsWithType_3_Levels_2_properties_Should_be_5_items()
        {
            int v_ResultCount = 5;

            IEnumerable<PropertyInfo> v_Properties = ObjectProperty.EnumerablePropertiesByAncestorsWithType(typeof(HashHelperLevel2_1aModel));
            v_Properties.Should().NotBeEmpty();

            v_Properties.Count().Should().Be(v_ResultCount);
            v_Properties.ToArray()[0].Name.Should().Be("Base");
            v_Properties.ToArray()[1].Name.Should().Be("Level1_1");
            v_Properties.ToArray()[2].Name.Should().Be("Level1_2");
            v_Properties.ToArray()[3].Name.Should().Be("Level2_1");
            v_Properties.ToArray()[4].Name.Should().Be("Level2_2");
        }

        [Fact]
        public void ObjectPropertyTest_131_EnumerablePropertiesWithType_3_Levels_2_properties_Should_be_5_items()
        {
            int v_ResultCount = 5;

            IEnumerable<PropertyInfo> v_Properties = ObjectProperty.EnumerablePropertiesWithType(typeof(HashHelperLevel2_1aModel));
            v_Properties.Should().NotBeEmpty();

            v_Properties.Count().Should().Be(v_ResultCount);
            v_Properties.ToArray()[0].Name.Should().Be("Base");
            v_Properties.ToArray()[1].Name.Should().Be("Level1_1");
            v_Properties.ToArray()[2].Name.Should().Be("Level1_2");
            v_Properties.ToArray()[3].Name.Should().Be("Level2_1");
            v_Properties.ToArray()[4].Name.Should().Be("Level2_2");
        }


    }
}
