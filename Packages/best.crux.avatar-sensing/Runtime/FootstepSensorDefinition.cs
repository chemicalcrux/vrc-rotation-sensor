using System;
using Crux.AvatarSensing.Runtime.Data;
using Crux.Core.Runtime.Upgrades;
using Crux.ProceduralController.Runtime.Models;
using UnityEngine;
using VRC.SDKBase;

namespace Crux.AvatarSensing.Runtime
{
    [UpgradableLatestVersion(1)]
    public class FootstepSensorDefinition : ComponentModel, IEditorOnly
    {
        [SerializeField, SerializeReference] internal FootstepSensorData data = new FootstepSensorDataV1();

        private void Reset()
        {
            data = new FootstepSensorDataV1();
        }

        private void OnDrawGizmosSelected()
        {
            if (!data.TryUpgradeTo(out FootstepSensorDataV1 latest))
                return;

            foreach (var target in latest.targets)
            {
                Gizmos.DrawLine(target.transform.position, target.transform.position + Vector3.down * 0.3f);
            }
        }
    }
}