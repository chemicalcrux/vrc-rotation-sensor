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

            public string GetParameter(FootstepSensorDataV1 data, FootstepTarget target)
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

        internal enum FootstepState
        {
            FootDownHold,
            FootUpHold,
        }

        [Serializable]
        internal class FootstepStateEntry
        {
            public FootstepState stateKind;
            public string parameterName;

            public string GetParameter(FootstepSensorDataV1 data, FootstepTarget target)
            {
                string result = data.outputPrefix;

                result += target.identifier;

                if (string.IsNullOrEmpty(parameterName))
                    result += "-" + stateKind;
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

            public string GetParameter(FootstepSensorDataV1 data, FootstepTarget target)
            {
                string result = data.outputPrefix;

                result += target.identifier;

                if (string.IsNullOrEmpty(parameterName))
                    result += "-" + valueKind;
                else
                    result += "-" + parameterName;

                return result;
            }
        }

        public bool standalone;

        public string enableParameter = "Control/Active";
        
        public string outputPrefix = "Shared/Footstep/";
        public string identifier;
        
        public VRCPhysBoneCollider floorCollider;

        public float eventHoldTime;

        public List<FootstepTarget> targets = new();
        public List<FootstepEventEntry> events = new();
        public List<FootstepStateEntry> states = new();
        public List<FootstepValueEntry> values = new();

        public override FootstepSensorData Upgrade()
        {
            return this;
        }
    }
}