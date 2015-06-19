using JetBrains.Application.BuildScript.Application.Zones;
using JetBrains.VsIntegration.Shell.Zones;

namespace Example
{
    [ZoneMarker]
    public class ZoneMarker : IRequire<IVisualStudioZone>
    {
    }
}