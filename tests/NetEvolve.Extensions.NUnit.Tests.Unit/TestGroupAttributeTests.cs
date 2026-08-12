namespace NetEvolve.Extensions.NUnit.Tests.Unit;

using System.Diagnostics.CodeAnalysis;
using global::NUnit.Framework;
using global::NUnit.Framework.Interfaces;
using global::NUnit.Framework.Internal;

/// <summary>
/// Unit tests for <see cref="TestGroupAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class TestGroupAttributeTests
{
    /// <summary>
    /// Tests that <see cref="TestGroupAttribute"/> adds the group name as a test property.
    /// </summary>
    [Test]
    public void ApplyToTest_WithId_AddsProperty()
    {
        var attribute = new TestGroupAttribute("MyGroup");
        var test = new TestSuite(nameof(TestGroupAttributeTests));

        attribute.ApplyToTest(test);

        Assert.That(test.Properties[attribute.Category], Does.Contain("MyGroup"));
    }

    /// <summary>
    /// Tests that <see cref="TestGroupAttribute"/> does not add a property, when the id is empty.
    /// </summary>
    [Test]
    public void ApplyToTest_WithEmptyId_DoesNotAddProperty()
    {
        var attribute = new TestGroupAttribute(string.Empty);
        var test = new TestSuite(nameof(TestGroupAttributeTests));

        attribute.ApplyToTest(test);

        Assert.That(test.Properties[attribute.Category], Is.Empty);
    }

    /// <summary>
    /// Tests that <see cref="IApplyToTest.ApplyToTest"/> is a no-op when invoked with a <see langword="null"/> test.
    /// </summary>
    [Test]
    public void ApplyToTest_TestIsNull_DoesNotThrow()
    {
        var attribute = new TestGroupAttribute("MyGroup");

        Assert.DoesNotThrow(() => ((IApplyToTest)attribute).ApplyToTest(null!));
    }
}
