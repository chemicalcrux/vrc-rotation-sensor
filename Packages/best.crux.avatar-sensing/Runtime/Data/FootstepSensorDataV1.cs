using System;
using System.Collections.Generic;
using Crux.Core.Runtime.Upgrades;
using UnityEngine;
using VRC.SDK3.Dynamics.PhysBone.Components;

namespace Crux.AvatarSensing.Runtime.Data
{
    [Serializable]
    [UpgradableVersion(1)]
    internal class FootstepSensorDataV1 : FootstepSensorData
    {
        [Serializable]
        internal class FootstepTarget
        {
            public Transform transform;
            public string identifier;

            public string GetPhysboneParameter(FootstepSensorDataV1 data)
            {
                string result = "Input/Physbone/";

                result += identifier;

                return result;
            }

            public string GetInputParameter(FootstepSensorDataV1 data)
            {
                return GetPhysboneParameter(data) + "_Angle";
            }
        }
        
        internal enum FootstepEvent
        {
            FootDown,
            FootUp
        }

        [Serializable]
        internal class FootstepEventEntry
        {
            public FootstepEvent eventKind;
            public string parameterName;

            public string GetParameter(FootstepSensorDataV1 data, FootstepSensorDataV1.FootstepTarget target)
            {
                string result = data.outputPrefix;

                result += target.identifier;

                if (string.IsNullOrEmpty(parameterName))
                    result += "-" + eventKind;
                else
                    result += "-" + parameterName;

                return result;
            }
        }

        internal enum FootstepValue
        {
            GroundProximity
        }

        [Serializable]
        internal class FootstepValueEntry
        {
            public FootstepValue valueKind;
            public string parameterName;
            public Vector2 inputRange = new Vector2(0, 1);
            public Vector2 outputRange = new Vector2(0, 1);
        }

        public bool standalone;

        public string enableParameter = "Control/Active";
        
        public string outputPrefix = "Shared/Footstep/";
        public string identifier;
        
        public VRCPhysBoneCollider floorCollider;

        public float eventHoldTime = 0f;

        public List<FootstepTarget> targets;
        public List<FootstepEventEntry> events;
        public List<FootstepValueEntry> values;

        public override FootstepSensorData Upgrade()
        {
            return this;
        }
    }
}