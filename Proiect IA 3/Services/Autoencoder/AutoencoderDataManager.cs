using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Proiect_IA_3.Services.Autoencoder
{
    public class AutoencoderDataManager
    {
        public List<List<double>> TrainInputs { get; private set; }
        public List<List<double>> TrainOutputs { get; private set; }
        public List<List<double>> ValidationInputs { get; private set; }
        public List<List<double>> ValidationOutputs { get; private set; }
        public List<List<double>> TestInputs { get; private set; }
        public List<double> TestLabels { get; private set; } 

        public int TrainCount => TrainInputs.Count;
        public int ValidationCount => ValidationInputs.Count;
        public int TestCount => TestInputs.Count;

        public AutoencoderDataManager()
        {
            TrainInputs = new List<List<double>>();
            TrainOutputs = new List<List<double>>();
            ValidationInputs = new List<List<double>>();
            ValidationOutputs = new List<List<double>>();
            TestInputs = new List<List<double>>();
            TestLabels = new List<double>();
        }

        public void PrepareDataFromMLP(DataManager mlpData)
        {
            TrainInputs.Clear();
            TrainOutputs.Clear();
            ValidationInputs.Clear();
            ValidationOutputs.Clear();
            TestInputs.Clear();
            TestLabels.Clear();


            for (int i = 0; i < mlpData.TrainInputs.Count; i++)
            {
                if (mlpData.TrainOutputs[i][0] < 0.5)
                {
                    TrainInputs.Add(new List<double>(mlpData.TrainInputs[i]));
                    TrainOutputs.Add(new List<double>(mlpData.TrainInputs[i])); 
                }
            }

            for (int i = 0; i < mlpData.ValidationInputs.Count; i++)
            {
                if (mlpData.ValidationOutputs[i][0] < 0.5)
                {
                    ValidationInputs.Add(new List<double>(mlpData.ValidationInputs[i]));
                    ValidationOutputs.Add(new List<double>(mlpData.ValidationInputs[i]));
                }
            }

            if (mlpData.TestInputs != null && mlpData.TestInputs.Count > 0)
            {
                for (int i = 0; i < mlpData.TestInputs.Count; i++)
                {
                    TestInputs.Add(new List<double>(mlpData.TestInputs[i]));
                    TestLabels.Add(mlpData.TestOutputs[i][0]); 
                }
            }
        }

        public void LoadValidationData(string filePath)
        {
            ValidationInputs.Clear();
            ValidationOutputs.Clear();

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var values = line.Split(',').Select(double.Parse).ToList();
                double label = values.Last();
                var features = values.Take(values.Count - 1).ToList();

                if (label == 0)
                {
                    ValidationInputs.Add(new List<double>(features));
                    ValidationOutputs.Add(new List<double>(features));
                }
            }
        }

    }
}