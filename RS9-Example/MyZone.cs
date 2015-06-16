using System.IO;
using JetBrains.Application.BuildScript.Application.Zones;
using JetBrains.Application.Environment;

namespace RS9_Example
{
    [ZoneDefinition]
    public interface IMyZone : IZone
    {
    }

    [ZoneMarker]
    public class ZoneMarker : IMyZone
    {
    }

    [ZoneActivator]
    public class MyZoneActivator : IActivate<IMyZone>
    {
        public bool ActivatorEnabled()
        {
            // trying to figure out, when/if this is loaded
            File.WriteAllText(@"C:\Users\seb\activatorEnabled.txt", "it works");
            return true;
        }
    }
}