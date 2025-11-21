# NetEvolve.Extensions.Test

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![.NET](https://img.shields.io/badge/.NET-10-blue.svg)](https://dotnet.microsoft.com/)
[![Build Status](https://github.com/dailydevops/extensions.test/actions/workflows/ci.yml/badge.svg)](https://github.com/dailydevops/extensions.test/actions)

A comprehensive compatibility library providing **standardized test categorization attributes** across multiple .NET test frameworks. This library enables teams to maintain consistent test organization, filtering, and execution management regardless of their chosen testing framework.

## 🎯 Overview

**NetEvolve.Extensions.Test** bridges the gap between different .NET testing frameworks by providing a unified set of test categorization attributes. Whether you're using MSTest, NUnit, TUnit, or XUnit, you can apply the same categorization strategy across your entire solution.

### Key Benefits

- ✅ **Framework Agnostic**: Use the same attributes across MSTest, NUnit, TUnit, XUnit, and XUnit v3
- ✅ **Consistent Filtering**: Execute tests uniformly with `dotnet test --filter TestCategory=IntegrationTest`
- ✅ **Standardized Organization**: Organize tests by type (Unit, Integration, Performance, etc.)
- ✅ **Work Item Tracking**: Link tests to bugs, features, user stories, and epics
- ✅ **Deployment Testing**: Separate pre-deployment and post-deployment validation
- ✅ **.NET 10 Support**: Built for modern .NET with full C# 13 compatibility

## 📦 Supported Test Frameworks

| Framework | Package | NuGet |
|-----------|---------|-------|
| **MSTest** | [NetEvolve.Extensions.MSTest](src/NetEvolve.Extensions.MSTest/) | [![NuGet](https://img.shields.io/nuget/v/NetEvolve.Extensions.MSTest.svg)](https://www.nuget.org/packages/NetEvolve.Extensions.MSTest) |
| **NUnit** | [NetEvolve.Extensions.NUnit](src/NetEvolve.Extensions.NUnit/) | [![NuGet](https://img.shields.io/nuget/v/NetEvolve.Extensions.NUnit.svg)](https://www.nuget.org/packages/NetEvolve.Extensions.NUnit) |
| **TUnit** | [NetEvolve.Extensions.TUnit](src/NetEvolve.Extensions.TUnit/) | [![NuGet](https://img.shields.io/nuget/v/NetEvolve.Extensions.TUnit.svg)](https://www.nuget.org/packages/NetEvolve.Extensions.TUnit) |
| **XUnit** | [NetEvolve.Extensions.XUnit](src/NetEvolve.Extensions.XUnit/) | [![NuGet](https://img.shields.io/nuget/v/NetEvolve.Extensions.XUnit.svg)](https://www.nuget.org/packages/NetEvolve.Extensions.XUnit) |
| **XUnit v3** | [NetEvolve.Extensions.XUnit.V3](src/NetEvolve.Extensions.XUnit.V3/) | [![NuGet](https://img.shields.io/nuget/v/NetEvolve.Extensions.XUnit.V3.svg)](https://www.nuget.org/packages/NetEvolve.Extensions.XUnit.V3) |

## 🚀 Quick Start

### Installation

Choose the package matching your test framework:

```bash
# MSTest
dotnet add package NetEvolve.Extensions.MSTest

# NUnit
dotnet add package NetEvolve.Extensions.NUnit

# TUnit
dotnet add package NetEvolve.Extensions.TUnit

# XUnit
dotnet add package NetEvolve.Extensions.XUnit

# XUnit v3
dotnet add package NetEvolve.Extensions.XUnit.V3
```

### Basic Usage

```csharp
using NetEvolve.Extensions.MSTest; // Or NUnit, TUnit, XUnit, etc.

[TestClass]
[IntegrationTest] // Categorize all tests in this class
public class DatabaseTests
{
    [TestMethod]
    [Bug] // Mark as bug fix test
    public void Should_Handle_Concurrent_Updates()
    {
        // Your test implementation
    }
}
```

### Filter Tests

```bash
# Run only integration tests
dotnet test --filter TestCategory=IntegrationTest

# Run unit and acceptance tests
dotnet test --filter "TestCategory=UnitTest|TestCategory=AcceptanceTest"

# Exclude performance tests
dotnet test --filter "TestCategory!=PerformanceTest"
```

## 📚 Available Attributes

### Test Categories
- `UnitTestAttribute` - Isolated component tests
- `IntegrationTestAttribute` - Component interaction tests
- `AcceptanceTestAttribute` - User story validation
- `PerformanceTestAttribute` - Performance and load testing
- `EndToEndTestAttribute` - Complete workflow tests
- `FunctionalTestAttribute` - Feature behavior tests
- `ArchitectureTestAttribute` - Design constraint validation
- `CodedUITestAttribute` - UI automation tests (MSTest)

### Work Item Tracking
- `BugAttribute` - Bug fix validation
- `IssueAttribute` - Issue tracking
- `FeatureAttribute` - Feature implementation
- `EpicAttribute` - Epic-level requirements
- `UserStoryAttribute` - User story completion
- `WorkItemAttribute` - Generic work item association

### Deployment Testing
- `PreDeploymentTestAttribute` - Pre-deployment validation
- `PostDeploymentTestAttribute` - Post-deployment verification

## 🛠️ Requirements

- **.NET 10** or later
- Compatible with **.NET Standard 2.0** projects (.NET Framework 4.6.1+, .NET Core 2.0+)
- **C# 13** support

## 📖 Documentation

Each package includes comprehensive documentation:

- [MSTest Documentation](src/NetEvolve.Extensions.MSTest/README.md)
- [NUnit Documentation](src/NetEvolve.Extensions.NUnit/README.md)
- [TUnit Documentation](src/NetEvolve.Extensions.TUnit/README.md)
- [XUnit Documentation](src/NetEvolve.Extensions.XUnit/README.md)
- [XUnit v3 Documentation](src/NetEvolve.Extensions.XUnit.V3/README.md)

## 🤝 Contributing

Contributions are welcome! Please feel free to:

- Report issues or bugs
- Suggest new features or improvements
- Submit pull requests

Visit our [GitHub repository](https://github.com/dailydevops/extensions.test) to get started.

## 📄 License

This project is licensed under the **MIT License** - see the [LICENSE](LICENSE) file for details.

---

**Made with ❤️ by the NetEvolve Team**