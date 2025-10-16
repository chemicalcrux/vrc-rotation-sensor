using Crux.ProceduralController.Editor;
using Crux.ProceduralController.Editor.Receivers;
using Crux.RotationSensor.Runtime;
using Crux.RotationSensor.Runtime.Data;
using UnityEngine;
using VRC.SDKBase.Editor.BuildPipeline;

namespace Crux.RotationSensor.Editor
{
    public class RotationSensorProcessorStandalone : IVRCSDKPreprocessAvatarCallback
    {
        public int callbackOrder => -10010;

        public bool OnPreprocessAvatar(GameObject avatarGameObject)
        {
            foreach (var target in avatarGameObject.GetComponentsInChildren<RotationSensorDefinition>())
            {
                if (!Process(avatarGameObject, target))
                    return false;
            }

            return true;
        }

        private bool Process(GameObject root, RotationSensorDefinition definition)
        {
            if (!definition.data.TryUpgradeTo(out RotationSensorDataV1 data))
                return false;

            if (!data.standalone)
                return true;

            var context = new Context
            {
                avatarRoot = root,
                targetObject = definition.gameObject,
                receiver = new FuryFullControllerReceiver(definition.gameObject)
            };

            return RotationSensorProcessor.Process(context, definition);
        }
    }
}