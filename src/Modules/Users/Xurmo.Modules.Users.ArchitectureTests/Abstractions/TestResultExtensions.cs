using FluentAssertions;
using NetArchTest.Rules;

namespace Xurmo.Modules.Users.ArchitectureTests.Abstractions;
internal static class TestResultExtensions
{
    internal static void ShouldBeSuccessful(this TestResult testResult)
    {
        testResult.FailingTypes?.Should().BeEmpty();
    }
}
