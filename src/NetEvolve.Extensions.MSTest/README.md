# NetEvolve.Extensions.MSTest

Compatibility library for solutions using multiple .NET test frameworks.
The following test frameworks are supported
- [MSTest](https://www.nuget.org/packages/NetEvolve.Extensions.MSTest)
- [NUnit](https://www.nuget.org/packages/NetEvolve.Extensions.NUnit)    
- [TUnit](https://www.nuget.org/packages/NetEvolve.Extensions.TUnit)
- [XUnit](https://www.nuget.org/packages/NetEvolve.Extensions.XUnit)
- [XUnit.V3](https://www.nuget.org/packages/NetEvolve.Extensions.XUnit.V3)

## Basic functionality

For consistent usage and addressing of use cases like `dotnet test -c Release --filter TestCategory=IntegrationTest`, the following attributes are provided in this library in the namespace `NetEvolve.Extensions.MSTest`.

- `AcceptanceTestAttribute`
- `ArchitectureTestAttribute`
- `BugAttribute`
- `EndToEndTestAttribute`
- `EpicAttribute`
- `FeatureAttribute`
- `FunctionalTestAttribute`
- `IntegrationTestAttribute`
- `IssueAttribute`
- `PerformanceTestAttribute`
- `PostDeploymentTestAttribute`
- `PreDeploymentTestAttribute`
- `UnitTestAttribute`
- `UserStoryAttribute`
- `WorkItemAttribute`

### Applying
These can be applied on assembly, class or method definitions as follows.

```cs
[assembly: AcceptanceTest] // Mark all test methods of this assembly as AcceptanceTest

[TestClass]
[AcceptanceTest] // Mark all test methods of this class as AcceptanceTest
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