using System.Collections.Generic;
using Proiect_IA_3.Models;

namespace Proiect_IA_3.Services.Autoencoder
{
    public class AutoencoderEvaluator
    {
        public class AutoencoderResults
        {
            public double Accuracy { get; set; }
            public double Precision { get; set; }
            public double Recall { get; set; }
            public double F1Score { get; set; }
            public int TruePositives { get; set; }
            public int FalsePositives { get; set; }
            public int TrueNegatives { get; set; }
            public int FalseNegatives { get; set; }
        }

        public AutoencoderResults Evaluate(NeuralNetwork network, AutoencoderDataManager dataManager, double anomalyThreshold)
        {
            var results = new AutoencoderResults();
            int totalSamples = dataManager.TestCount;

            for (int i = 0; i < totalSamples; i++)
            {
                network.InputValues = new List<double>(dataManager.TestInputs[i]);
                var reconstructedOutput = network.ForwardPropagate();

                double mse = 0;
                for (int j = 0; j < reconstructedOutput.Count; j++)
                {
                    double error = dataManager.TestInputs[i][j] - reconstructedOutput[j];
                    mse += error * error;
                }
                mse /= reconstructedOutput.Count;

                int predictedClass = mse >= anomalyThreshold ? 1 : 0;
                int actualClass = dataManager.TestLabels[i] >= 0.5 ? 1 : 0;

                if (predictedClass == 1 && actualClass == 1) results.TruePositives++;
                else if (predictedClass == 1 && actualClass == 0) results.FalsePositives++;
                else if (predictedClass == 0 && actualClass == 0) results.TrueNegatives++;
                else if (predictedClass == 0 && actualClass == 1) results.FalseNegatives++;
            }

            int correctPredictions = results.TruePositives + results.TrueNegatives;
            results.Accuracy = (double)correctPredictions / totalSamples * 100.0;

            double precisionDenom = results.TruePositives + results.FalsePositives;
            results.Precision = precisionDenom > 0 ? (double)results.TruePositives / precisionDenom : 0;

            double recallDenom = results.TruePositives + results.FalseNegatives;
            results.Recall = recallDenom > 0 ? (double)results.TruePositives / recallDenom : 0;

            double f1Denom = results.Precision + results.Recall;
            results.F1Score = f1Denom > 0 ? 2 * (results.Precision * results.Recall) / f1Denom : 0;

            return results;
        }
    }
}