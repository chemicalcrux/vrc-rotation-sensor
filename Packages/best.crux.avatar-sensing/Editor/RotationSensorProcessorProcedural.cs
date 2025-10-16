using Crux.ProceduralController.Editor;
using Crux.ProceduralController.Editor.Processors;
using Crux.RotationSensor.Runtime;
using Crux.RotationSensor.Runtime.Data;
using JetBrains.Annotations;

namespace Crux.RotationSensor.Editor
{
    [UsedImplicitly]
    public class RotationSensorProcessorProcedural : Processor<RotationSensorDefinition>
    {
        public override void Process(Context context)
        {
            if (!model.data.TryUpgradeTo(out RotationSensorDataV1 data))
                return;

            if (data.standalone)
                return;

            RotationSensorProcessor.Process(context, model);
        }
    }
}