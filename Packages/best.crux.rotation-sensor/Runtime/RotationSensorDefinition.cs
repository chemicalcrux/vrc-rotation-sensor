using System.Collections;
using System.Collections.Generic;
using Crux.Core.Runtime.Attributes;
using Crux.ProceduralController.Runtime.Models;
using Crux.RotationSensor.Runtime.Data;
using UnityEngine;
using VRC.SDKBase;

namespace Crux.RotationSensor.Runtime
{
    [HideIcon]
    public class RotationSensorDefinition : ComponentModel, IEditorOnly
    {
        [SerializeField, SerializeReference] internal RotationSensorData data = new RotationSensorDataV1();

        private void Reset()
        {
            data = new RotationSensorDataV1();
        }
    }
}
