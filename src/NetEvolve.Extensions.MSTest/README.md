# NetEvolve.Extensions.MSTest

Compatibility library for solutions using multiple .NET test frameworks.
The following test frameworks are supported -
[MSTest](https://www.nuget.org/packages/NetEvolve.Extensions.MSTest),
[NUnit](https://www.nuget.org/packages/NetEvolve.Extensions.NUnit) &
[XUnit](https://www.nuget.org/packages/NetEvolve.Extensions.XUnit).

## Basic functionality

For consistent usage and addressing of use cases like `dotnet test -c Release --filter TestCategory=IntegrationTest`, the following attributes are provided in this library in the namespace `NetEvolve.Extensions.MSTest`.

-  `AcceptanceTestAttribute`
-  `BugAttribute`
-  `EndToEndTestAttribute`
-  `EpicAttribute`
-  `FeatureAttribute`
-  `FunctionalTestAttribute`
-  `IntegrationTestAttribute`
-  `IssueAttribute`
-  `PerformanceTestAttribute`
-  `PostDeploymentTestAttribute`
-  `PreDeploymentTestAttribute`
-  `UnitTestAttribute`
-  `UserStoryAttribute`
-  `WorkItemAttribute`

### Applying

These can be applied to all class and method definitions as follows.

```cs
[TestClass]
[AcceptanceTest] // Mark all test methods as AcceptanceTest
public partial class FantasticTest
{
    [TestMethod]
    [AcceptanceTest] // Alternatively, only one method can be selected.
    public void I_am_Ironman()
    {
        Assert.Fail();
    }
}
```