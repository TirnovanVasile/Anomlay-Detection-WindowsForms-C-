using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Proiect_IA_3.Services
{
    public class DataManager
    {

        public List<List<double>> rawInputs = new List<List<double>>();
        public List<List<double>> rawOutputs = new List<List<double>>();


        private List<List<double>> normalizedInputs;
        private List<double> inputMin;
        private List<double> inputMax;

        private List<string> columnHeaders = new List<string>();


        public List<List<double>> TrainInputs { get; private set; }
        public List<List<double>> TrainOutputs { get; private set; }
        public List<List<double>> ValidationInputs { get; private set; }
        public List<List<double>> ValidationOutputs { get; private set; }
        public List<List<double>> TestInputs { get; private set; }
        public List<List<double>> TestOutputs { get; private set; }


        public int TrainCount => TrainInputs?.Count ?? 0;
        public int ValidationCount => ValidationInputs?.Count ?? 0;
        public int TestCount => TestInputs?.Count ?? 0;
        public int InputCount => rawInputs.FirstOrDefault()?.Count ?? 0;
        public int TotalSamples => rawInputs.Count;

        public bool HasData => rawInputs != null && rawInputs.Count > 0;


        public bool IsNormalized { get; private set; } = false;
        public bool IsSplit { get; private set; } = false;


        public void LoadCSV(string filePath, bool append = false)
        {
            if (!append)
            {
                rawInputs.Clear();
                rawOutputs.Clear();
                columnHeaders.Clear();
            }

            using var reader = new StreamReader(filePath);
            string headerLine = reader.ReadLine();
            var headers = headerLine.Split(',').Select(h => h.Trim()).ToList();
            int featureCount = headers.Count - 1;

            if (!append)
                columnHeaders.AddRange(headers.Take(featureCount));

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split(',');

                var inputRow = new List<double>();
                for (int i = 0; i < featureCount; i++)
                    inputRow.Add(double.Parse(parts[i], CultureInfo.InvariantCulture));

                double label = double.Parse(parts[featureCount], CultureInfo.InvariantCulture);

                rawInputs.Add(inputRow);
                rawOutputs.Add(new List<double> { label });
            }
        }


        public void NormalizeData()
        {
            if (!rawInputs.Any()) throw new Exception("Nu exista date!");

            normalizedInputs = new List<List<double>>();
            inputMin = new List<double>();
            inputMax = new List<double>();

            int featureCount = rawInputs[0].Count;

            for (int j = 0; j < featureCount; j++)
            {
                var col = rawInputs.Select(r => r[j]);
                inputMin.Add(col.Min());
                inputMax.Add(col.Max());
            }

            foreach (var row in rawInputs)
            {
                var normRow = new List<double>();
                for (int j = 0; j < featureCount; j++)
                {
                    double range = inputMax[j] - inputMin[j];
                    normRow.Add(range > 0.0001 ? (row[j] - inputMin[j]) / range : 0.5);
                }
                normalizedInputs.Add(normRow);
            }

            IsNormalized = true;
        }


        public void ShuffleAndSplitTrainValidation(double validationRatio = 0.1, int seed = 42)
        {
            if (!IsNormalized) throw new Exception("NormalizeData must be called first.");

            var rand = new Random(seed);
            var indices = Enumerable.Range(0, normalizedInputs.Count).OrderBy(x => rand.Next()).ToList();
            int validCount = (int)(indices.Count * validationRatio);

            TrainInputs = new List<List<double>>();
            TrainOutputs = new List<List<double>>();
            ValidationInputs = new List<List<double>>();
            ValidationOutputs = new List<List<double>>();

            for (int i = 0; i < indices.Count; i++)
            {
                int idx = indices[i];
                if (i < validCount)
                {
                    ValidationInputs.Add(normalizedInputs[idx]);
                    ValidationOutputs.Add(rawOutputs[idx]);
                }
                else
                {
                    TrainInputs.Add(normalizedInputs[idx]);
                    TrainOutputs.Add(rawOutputs[idx]);
                }
            }

            IsSplit = true;
        }

        public void PrepareTestData(List<List<double>> testRawInputs, List<List<double>> testRawOutputs)
        {
            if (!IsNormalized) throw new Exception("NormalizeData must be called first..");

            TestInputs = new List<List<double>>();
            TestOutputs = testRawOutputs;

            int featureCount = testRawInputs[0].Count;

            foreach (var row in testRawInputs)
            {
                var normRow = new List<double>();
                for (int j = 0; j < featureCount; j++)
                {
                    double range = inputMax[j] - inputMin[j];
                    normRow.Add(range > 0.0001 ? (row[j] - inputMin[j]) / range : 0.5);
                }
                TestInputs.Add(normRow);
            }
        }


        public (List<List<double>> X, List<List<double>> Y) CreateSlidingWindows(int windowSize)
        {
            if (!IsNormalized) throw new Exception("NormalizeData must be called first.");
            var X = new List<List<double>>();
            var Y = new List<List<double>>();

            var data = normalizedInputs;
            var labels = rawOutputs;

            for (int i = 0; i <= data.Count - windowSize; i++)
            {
                var window = new List<double>();
                for (int j = 0; j < windowSize; j++)
                    window.AddRange(data[i + j]);

                X.Add(window);
                double maxLabel = labels.Skip(i).Take(windowSize).Max(r => r[0]);
                Y.Add(new List<double> { maxLabel });
            }

            return (X, Y);
        }

        public DataTable GetPreviewDataTable(int count)
        {
            DataTable dt = new DataTable();

            foreach (var col in columnHeaders)
                dt.Columns.Add(col);
            dt.Columns.Add("Faulty");

            var sourceInputs = IsSplit ? TrainInputs : (IsNormalized ? normalizedInputs : rawInputs);
            var sourceOutputs = IsSplit ? TrainOutputs : rawOutputs;

            if (sourceInputs == null || sourceInputs.Count == 0) return dt;

            int limit = Math.Min(count, sourceInputs.Count);
            for (int i = 0; i < limit; i++)
            {
                DataRow row = dt.NewRow();
                for (int j = 0; j < sourceInputs[i].Count; j++)
                {
                    row[j] = IsNormalized ? Math.Round(sourceInputs[i][j], 4) : sourceInputs[i][j];
                }
                row[sourceInputs[i].Count] = sourceOutputs[i][0];
                dt.Rows.Add(row);
            }

            return dt;
        }
    }
}