using System;
using Crux.Core.Runtime.Upgrades;

namespace Crux.RotationSensor.Runtime.Data
{
    [Serializable]
    [UpgradableVersion(1)]
    internal class RotationSensorDataV1 : RotationSensorData
    {
        public string parameterName;
        
        public override RotationSensorData Upgrade()
        {
            return this;
        }
    }
}