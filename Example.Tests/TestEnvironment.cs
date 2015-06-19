using JetBrains.Application.BuildScript.Application.Zones;
using JetBrains.ReSharper.TestFramework;
using JetBrains.ReSharper.UnitTestFramework;
using JetBrains.TestFramework;
using JetBrains.TestFramework.Application.Zones;
using NUnit.Framework;

[ZoneDefinition]
public interface IExampleTestZone : ITestsZone, IRequire<IUnitTestingZone>
{
}

[SetUpFixture]
public class TestEnvironmentAssembly : ExtensionTestEnvironmentAssembly<IExampleTestZone>
{
    public override void SetUp()
    {
        base.SetUp();
    }
}