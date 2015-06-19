using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using Example.Completion;
using Example.Tests;
using JetBrains.Application;
using JetBrains.Application.BuildScript.Application.Zones;
using JetBrains.Application.Environment;
using JetBrains.ReSharper.Resources.Shell;
using JetBrains.ReSharper.UnitTestFramework;
using JetBrains.TestFramework;
using JetBrains.TestFramework.Application.Zones;
using JetBrains.Threading;
using NUnit.Framework;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.

[assembly: AssemblyTitle("RS9-Example-Test")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("RS9-Example-Test")]
[assembly: AssemblyCopyright("Copyright ©  2015")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.

[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM

[assembly: Guid("40263732-71cb-45fc-b47e-4224c314f9cc")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]

[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

/// <summary>
///     Test environment. Must be in the global namespace.
/// </summary>
[SetUpFixture]
// ReSharper disable once CheckNamespace
public class AssemblyInfo : TestEnvironmentAssembly<ExampleTestsZone>
{
    /// <summary>
    ///     Gets the assemblies to load into test environment.
    ///     Should include all assemblies which contain components.
    /// </summary>
    private static IEnumerable<Assembly> GetAssembliesToLoad()
    {
        // Test assembly
        yield return Assembly.GetExecutingAssembly();

        yield return typeof (ContextAnalysis).Assembly;
    }

    public override void SetUp()
    {
        base.SetUp();
        ReentrancyGuard.Current.Execute(
            "LoadAssemblies",
            () => Shell.Instance.GetComponent<AssemblyManager>().LoadAssemblies(
                GetType().Name,
                GetAssembliesToLoad()));
    }

    public override void TearDown()
    {
        ReentrancyGuard.Current.Execute(
            "UnloadAssemblies",
            () => Shell.Instance.GetComponent<AssemblyManager>().UnloadAssemblies(
                GetType().Name,
                GetAssembliesToLoad()));
        base.TearDown();
    }
}

namespace Example.Tests
{
    [ZoneDefinition]
    public class ExampleTestsZone : ITestsZone
    {
    }

    [ZoneMarker]
    public class ZoneMarker : IRequire<IUnitTestingZone>
    {
    }

    [ZoneActivator]
    public class ExampleTestsZoneActivator : IActivate<ExampleTestsZone>
    {
        public bool ActivatorEnabled()
        {
            return true;
        }
    }
}