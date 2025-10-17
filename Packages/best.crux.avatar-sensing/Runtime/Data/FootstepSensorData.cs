using System;
using Crux.Core.Runtime.Upgrades;

namespace Crux.AvatarSensing.Runtime.Data
{
    [Serializable]
    [UpgradableLatestVersion(1)]
    public abstract class FootstepSensorData : Upgradable<FootstepSensorData>
    {
        
    }
}