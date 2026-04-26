using Proiect_IA_3.Models;
using System.Data;

namespace Proiect_IA_3.Services
{
    public class ModelEvaluator
    {
        public EvaluationResults Evaluate(NeuralNetwork network, List<List<double>> inputs, List<List<double>> targets)
        {
            var results = new EvaluationResults
            {
                TotalSamples = inputs.Count,
                Predictions = new List<List<double>>(),
                ActualValues = new List<List<double>>()
            };

            double mse = 0;
            double mae = 0;
            int correctPredictions = 0;

            for (int i = 0; i < inputs.Count; i++)
            {
                network.InputValues = new List<double>(inputs[i]);
                var output = network.ForwardPropagate();

                results.Predictions.Add(output);
                results.ActualValues.Add(targets[i]);

                for (int j = 0; j < output.Count; j++)
                {
                    double error = targets[i][j] - output[j];
                    mse += error * error;
                    mae += Math.Abs(error);
                }

                int predictedClass = output[0] >= 0.5 ? 1 : 0;
                int actualClass = targets[i][0] >= 0.5 ? 1 : 0;

                if (predictedClass == actualClass)
                {
                    correctPredictions++;
                }
            }

            results.MSE = mse / (inputs.Count * targets[0].Count);
            results.RMSE = Math.Sqrt(results.MSE);
            results.MAE = mae / (inputs.Count * targets[0].Count);
            results.Accuracy = (correctPredictions * 100.0) / inputs.Count;

            return results;
        }
    }

    public class EvaluationResults
    {
        public int TotalSamples { get; set; }
        public double MSE { get; set; }
        public double RMSE { get; set; }
        public double MAE { get; set; }
        public double Accuracy { get; set; }

        public List<List<double>> Predictions { get; set; }
        public List<List<double>> ActualValues { get; set; }
    }
}
