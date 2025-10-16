using System;
using Crux.Core.Runtime.Upgrades;

namespace Crux.AvatarSensing.Runtime.Data
{
    [Serializable]
    [UpgradableLatestVersion(1)]
    internal abstract class RotationSensorData : Upgradable<RotationSensorData>
    {
        
    }
}