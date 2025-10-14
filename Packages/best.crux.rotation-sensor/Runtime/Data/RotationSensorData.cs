using System;
using Crux.Core.Runtime.Upgrades;

namespace Crux.RotationSensor.Runtime.Data
{
    [Serializable]
    [UpgradableLatestVersion(1)]
    internal abstract class RotationSensorData : Upgradable<RotationSensorData>
    {
        
    }
}