using System.Collections;
using System.Collections.Generic;
using Crux.ProceduralController.Runtime.Models;
using Crux.RotationSensor.Runtime.Data;
using UnityEngine;
using VRC.SDKBase;

namespace Crux.RotationSensor.Runtime
{
    public class RotationSensorDefinition : ComponentModel, IEditorOnly
    {
        [SerializeField, SerializeReference] internal RotationSensorData data = new RotationSensorDataV1();

        private void Reset()
        {
            data = new RotationSensorDataV1();
        }
    }
}
