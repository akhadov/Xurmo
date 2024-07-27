using System.Reflection;
using NetArchTest.Rules;
using Xurmo.ArchitectureTests.Abstractions;
using Xurmo.Modules.Catalogs.Domain.Products;
using Xurmo.Modules.Catalogs.Infrastructure;
using Xurmo.Modules.Users.Domain.Users;
using Xurmo.Modules.Users.Infrastructure;

namespace Xurmo.ArchitectureTests.Layers;
public class ModuleTests : BaseTest
{
    [Fact]
    public void UsersModule_ShouldNotHaveDependencyOn_AnyOtherModule()
    {
        string[] otherModules = [CatalogsNamespace];
        string[] integrationEventsModules = [
            CatalogsIntegrationEventsNamespace];

        List<Assembly> usersAssemblies =
        [
            typeof(User).Assembly,
            Modules.Users.Application.AssemblyReference.Assembly,
            Modules.Users.Presentation.AssemblyReference.Assembly,
            typeof(UsersModule).Assembly
        ];

        Types.InAssemblies(usersAssemblies)
            .That()
            .DoNotHaveDependencyOnAny(integrationEventsModules)
            .Should()
            .NotHaveDependencyOnAny(otherModules)
            .GetResult()
            .ShouldBeSuccessful();
    }

    [Fact]
    public void CatalogsModule_ShouldNotHaveDependencyOn_AnyOtherModule()
    {
        string[] otherModules = [UsersNamespace];
        string[] integrationEventsModules = [
            UsersIntegrationEventsNamespace];

        List<Assembly> eventsAssemblies =
        [
            typeof(Product).Assembly,
            Modules.Catalogs.Application.AssemblyReference.Assembly,
            Modules.Catalogs.Presentation.AssemblyReference.Assembly,
            typeof(CatalogsModule).Assembly
        ];

        Types.InAssemblies(eventsAssemblies)
            .That()
            .DoNotHaveDependencyOnAny(integrationEventsModules)
            .Should()
            .NotHaveDependencyOnAny(otherModules)
            .GetResult()
            .ShouldBeSuccessful();
    }
}
