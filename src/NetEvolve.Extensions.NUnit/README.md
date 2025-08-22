# NetEvolve.Extensions.NUnit

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![NuGet](https://img.shields.io/nuget/v/NetEvolve.Extensions.NUnit.svg)](https://www.nuget.org/packages/NetEvolve.Extensions.NUnit/)

**NetEvolve.Extensions.NUnit** is a .NET library that provides consistent test categorization attributes for NUnit, enabling seamless integration with multi-framework test solutions. This library allows teams to apply standardized test categories across different testing frameworks, making test filtering and execution management uniform and predictable.

## 🎯 Overview

This package is part of the **NetEvolve Extensions Test** ecosystem, designed to provide compatibility between different .NET test frameworks. The main goal is to standardize test categorization across MSTest, NUnit, TUnit, and XUnit frameworks, enabling teams to:

- **Consistent test categorization** across multiple test frameworks
- **Uniform filtering** with commands like `dotnet test --filter TestCategory=IntegrationTest`
- **Cross-framework compatibility** for test organization and execution
- **Standardized test classification** for different types of testing (Unit, Integration, Performance, etc.)

## 🚀 Features

### Test Category Attributes
- **UnitTestAttribute** - Mark tests as unit tests for isolated component testing
- **IntegrationTestAttribute** - Identify integration tests that test component interactions
- **AcceptanceTestAttribute** - Label acceptance tests for user story validation
- **PerformanceTestAttribute** - Designate performance and load testing scenarios
- **EndToEndTestAttribute** - Mark comprehensive workflow testing
- **FunctionalTestAttribute** - Identify functional behavior testing
- **ArchitectureTestAttribute** - Label architectural constraint testing

### Work Item Tracking Attributes
- **BugAttribute** - Associate tests with specific bug fixes
- **IssueAttribute** - Link tests to tracked issues
- **FeatureAttribute** - Connect tests to feature implementations
- **EpicAttribute** - Associate tests with epic-level requirements
- **UserStoryAttribute** - Link tests to specific user stories
- **WorkItemAttribute** - Generic work item association

### Deployment Testing Attributes
- **PreDeploymentTestAttribute** - Mark tests that run before deployment
- **PostDeploymentTestAttribute** - Identify post-deployment validation tests

## 📦 Installation

### .NET CLI

```bash
dotnet add package NetEvolve.Extensions.NUnit
```

### PackageReference

```xml
<PackageReference Include="NetEvolve.Extensions.NUnit" Version="1.0.0" />
```

## 🛠️ Requirements

- **.NET Standard 2.0** (compatible with .NET Framework 4.6.1+, .NET Core 2.0+, .NET 5+)
- **Multi-target support**: .NET 8, .NET 9
- **NUnit framework** compatibility

## 📖 Usage

All attributes are available in the `NetEvolve.Extensions.NUnit` namespace.

```csharp
using NetEvolve.Extensions.NUnit;
```

### Assembly-Level Categorization

Apply categories to all tests in an assembly:

```csharp
using NetEvolve.Extensions.NUnit;

[assembly: UnitTest] // Mark all test methods in this assembly as UnitTest
```

### Class-Level Categorization

Apply categories to all test methods in a test class:

```csharp
[TestFixture]
[IntegrationTest] // Mark all test methods in this class as IntegrationTest
public class DatabaseTests
{
    [Test]
    public void Should_Connect_To_Database()
    {
        // This test is automatically categorized as IntegrationTest
        Assert.That(true, Is.True);
    }
    
    [Test]
    public void Should_Retrieve_User_Data()
    {
        // This test is also categorized as IntegrationTest
        Assert.That("user", Is.Not.Null);
    }
}
```

### Method-Level Categorization

Apply categories to individual test methods:

```csharp
[TestFixture]
public class CalculatorTests
{
    [Test]
    [UnitTest] // Individual test method categorization
    public void Should_Add_Two_Numbers()
    {
        var result = Calculator.Add(2, 3);
        Assert.That(result, Is.EqualTo(5));
    }
    
    [Test]
    [PerformanceTest] // Different category for performance testing
    public void Should_Handle_Large_Numbers_Quickly()
    {
        var stopwatch = Stopwatch.StartNew();
        Calculator.Add(int.MaxValue, 1000000);
        stopwatch.Stop();
        Assert.That(stopwatch.ElapsedMilliseconds, Is.LessThan(100));
    }
}
```

### Multiple Categories

Apply multiple categories to the same test:

```csharp
[TestFixture]
public class UserServiceTests
{
    [Test]
    [IntegrationTest]
    [Bug] // Test was added to fix a specific bug
    [Issue] // Also tracks a specific issue
    public void Should_Handle_Concurrent_User_Updates()
    {
        // Test implementation for bug fix
        Assert.That(true, Is.True);
    }
}
```

### Work Item Association

Link tests to specific work items for traceability:

```csharp
[TestFixture]
public class FeatureTests
{
    [Test]
    [AcceptanceTest]
    [UserStory] // Associates with user story
    [Feature] // Links to feature implementation
    public void Should_Allow_User_Login()
    {
        // Test validates user story completion
        Assert.That(UserService.Login("user", "password"), Is.True);
    }
    
    [Test]
    [EndToEndTest]
    [Epic] // Associates with epic-level requirement
    public void Should_Complete_Order_Workflow()
    {
        // Comprehensive workflow test
        Assert.That(OrderService.ProcessOrder(order), Is.True);
    }
}
```

### Deployment Testing

Organize tests for different deployment phases:

```csharp
[TestFixture]
public class DeploymentTests
{
    [Test]
    [PreDeploymentTest]
    [ArchitectureTest]
    public void Should_Validate_System_Architecture()
    {
        // Validate architectural constraints before deployment
        Assert.That(ArchitectureValidator.IsValid(), Is.True);
    }
    
    [Test]
    [PostDeploymentTest]
    [FunctionalTest]
    public void Should_Verify_System_Health_After_Deployment()
    {
        // Verify system health post-deployment
        Assert.That(HealthCheck.IsSystemHealthy(), Is.True);
    }
}
```

## 🏗️ Real-World Example

```csharp
using NUnit.Framework;
using NetEvolve.Extensions.NUnit;
using System.Diagnostics;

[assembly: IntegrationTest] // Mark all tests as integration tests by default

namespace MyProject.Tests
{
    [TestFixture]
    [AcceptanceTest] // Override assembly-level category for this class
    public class UserManagementTests
    {
        [Test]
        [UserStory]
        [Feature]
        public void Should_Create_New_User_Successfully()
        {
            // Arrange
            var userService = new UserService();
            var newUser = new User { Name = "John Doe", Email = "john@example.com" };
            
            // Act
            var result = userService.CreateUser(newUser);
            
            // Assert
            Assert.That(result.Success, Is.True);
            Assert.That(result.UserId, Is.Not.Null);
        }
        
        [Test]
        [Bug] // This test was added to fix a specific bug
        [Issue] // Also tracks the issue in work item system
        public void Should_Handle_Duplicate_Email_Registration()
        {
            // Arrange
            var userService = new UserService();
            var existingUser = new User { Name = "Jane Doe", Email = "jane@example.com" };
            userService.CreateUser(existingUser);
            
            // Act
            var duplicateUser = new User { Name = "Jane Smith", Email = "jane@example.com" };
            var result = userService.CreateUser(duplicateUser);
            
            // Assert
            Assert.That(result.Success, Is.False);
            Assert.That(result.ErrorMessage, Is.EqualTo("Email already exists"));
        }
    }
    
    [TestFixture]
    public class PerformanceTests
    {
        [Test]
        [PerformanceTest]
        [UnitTest] // Can combine categories as needed
        public void Should_Process_Large_Dataset_Within_Time_Limit()
        {
            // Arrange
            var processor = new DataProcessor();
            var largeDataset = GenerateLargeDataset(10000);
            var stopwatch = Stopwatch.StartNew();
            
            // Act
            processor.ProcessData(largeDataset);
            stopwatch.Stop();
            
            // Assert
            Assert.That(stopwatch.ElapsedMilliseconds, Is.LessThan(5000), 
                "Processing should complete within 5 seconds");
        }
        
        private List<DataItem> GenerateLargeDataset(int count) => 
            Enumerable.Range(1, count).Select(i => new DataItem { Id = i }).ToList();
    }
}
```

## 🔧 Test Filtering

Use the attributes with NUnit's filtering capabilities:

```bash
# Run only unit tests
dotnet test --filter TestCategory=UnitTest

# Run integration and acceptance tests
dotnet test --filter "TestCategory=IntegrationTest|TestCategory=AcceptanceTest"

# Run all tests except performance tests
dotnet test --filter "TestCategory!=PerformanceTest"

# Run tests associated with bugs
dotnet test --filter TestCategory=Bug

# Run pre-deployment tests only
dotnet test --filter TestCategory=PreDeploymentTest
```

## 📚 Available Attributes

| Attribute | Purpose | Common Usage |
|-----------|---------|--------------|
| `UnitTestAttribute` | Individual component testing | Fast, isolated tests |
| `IntegrationTestAttribute` | Component interaction testing | Database, API integration |
| `AcceptanceTestAttribute` | User story validation | Business requirement verification |
| `PerformanceTestAttribute` | Performance validation | Load testing, benchmarks |
| `EndToEndTestAttribute` | Complete workflow testing | Full system scenarios |
| `FunctionalTestAttribute` | Feature behavior testing | Business logic validation |
| `ArchitectureTestAttribute` | Architectural constraint testing | Design rule validation |
| `BugAttribute` | Bug fix validation | Regression testing |
| `IssueAttribute` | Issue tracking association | Work item linkage |
| `FeatureAttribute` | Feature implementation testing | New functionality validation |
| `EpicAttribute` | Epic-level requirement testing | High-level feature validation |
| `UserStoryAttribute` | User story completion testing | Story acceptance criteria |
| `WorkItemAttribute` | Generic work item association | Flexible work tracking |
| `PreDeploymentTestAttribute` | Pre-deployment validation | Deployment readiness |
| `PostDeploymentTestAttribute` | Post-deployment verification | Production validation |

## 🤝 Contributing

Contributions are welcome! Please feel free to submit issues, feature requests, or pull requests to the [extensions.test repository](https://github.com/dailydevops/extensions.test).

## 🔗 Related Packages

This package is part of the **NetEvolve Extensions Test** ecosystem:

- [NetEvolve.Extensions.MSTest](https://www.nuget.org/packages/NetEvolve.Extensions.MSTest) - MSTest compatibility
- [NetEvolve.Extensions.NUnit](https://www.nuget.org/packages/NetEvolve.Extensions.NUnit) (this package)
- [NetEvolve.Extensions.TUnit](https://www.nuget.org/packages/NetEvolve.Extensions.TUnit) - TUnit compatibility  
- [NetEvolve.Extensions.XUnit](https://www.nuget.org/packages/NetEvolve.Extensions.XUnit) - XUnit compatibility
- [NetEvolve.Extensions.XUnit.V3](https://www.nuget.org/packages/NetEvolve.Extensions.XUnit.V3) - XUnit v3 compatibility

Choose the package that matches your testing framework, or use multiple packages for mixed-framework solutions.

---

**Made with ❤️ by the NetEvolve Team**