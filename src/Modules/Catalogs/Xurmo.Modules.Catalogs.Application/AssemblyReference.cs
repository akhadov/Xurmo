using System.Reflection;

namespace Xurmo.Modules.Catalogs.Application;
public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
