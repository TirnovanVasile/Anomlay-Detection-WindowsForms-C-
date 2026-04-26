using Microsoft.ML.Data;


namespace Proiect_IA_3.MLNet.Models
{
    public class SensorData
    {
        [VectorType(52)]
        public float[] Features { get; set; }

        [ColumnName("Label")]
        public bool Label { get; set; }
    }

    public class LogRegPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool Prediction { get; set; }

        public float Probability { get; set; }

        public float Score { get; set; }
    }
    public class KMeansPrediction
    {
        [ColumnName("PredictedLabel")]
        public uint ClusterId { get; set; }
    }
}