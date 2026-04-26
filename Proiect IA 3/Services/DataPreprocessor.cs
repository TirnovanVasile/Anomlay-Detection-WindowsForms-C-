using System;
using System.IO;
using System.Linq;
using System.Globalization;

namespace Proiect_IA_3.Services
{
    public class DataPreprocessor
    {
        public void ProcessAllTEP(string sourceDir, string destDir, Action<string> onProgress)
        {
            if (!Directory.Exists(destDir)) Directory.CreateDirectory(destDir);

            ProcessFile(Path.Combine(sourceDir, "TEP_FaultFree_Training.csv"), Path.Combine(destDir, "train_normal.csv"), 1, 30, 0, onProgress);
            ProcessFile(Path.Combine(sourceDir, "TEP_Faulty_Training.csv"), Path.Combine(destDir, "train_faulty.csv"), 1, 30, 1, onProgress);
            ProcessFile(Path.Combine(sourceDir, "TEP_FaultFree_Testing.csv"), Path.Combine(destDir, "test_normal.csv"), 31, 50, 0, onProgress);
            ProcessFile(Path.Combine(sourceDir, "TEP_Faulty_Testing.csv"), Path.Combine(destDir, "test_faulty.csv"), 31, 50, 1, onProgress);

            onProgress?.Invoke("Preprocessing completed successfully!");
        }

        private void ProcessFile(string inputPath, string outputPath, int startRun, int endRun, int label, Action<string> onProgress)
        {
            if (!File.Exists(inputPath)) return;
            onProgress?.Invoke($"Procesez {Path.GetFileName(inputPath)}...");

            using (var reader = new StreamReader(inputPath))
            using (var writer = new StreamWriter(outputPath))
            {
                string header = reader.ReadLine();
                var cols = header.Split(',').Select(c => c.Trim().ToLower()).ToList();

                int runIdx = cols.IndexOf("simulationrun");
                int sampleIdx = cols.IndexOf("sample");
                int faultIdx = cols.IndexOf("faultnumber");

                var featureIndices = cols
                    .Select((name, index) => new { name, index })
                    .Where(x => x.name.StartsWith("xmeas_") || x.name.StartsWith("xmv_"))
                    .Select(x => x.index).ToList();

                writer.WriteLine(string.Join(",", featureIndices.Select(i => cols[i])) + ",Faulty");

                Random rnd = new Random(42);

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] parts = line.Split(',');
                    int run = (int)float.Parse(parts[runIdx], CultureInfo.InvariantCulture);
                    int sample = (int)float.Parse(parts[sampleIdx], CultureInfo.InvariantCulture);

                    if (run >= startRun && run <= endRun && sample > 100 && sample % 1 == 0)
                    {
                        var features = featureIndices.Select(i => parts[i]);

                        int currentLabel = (label == 1 && (int)float.Parse(parts[faultIdx], CultureInfo.InvariantCulture) > 0) ? 1 : 0;

                        if (currentLabel == 1)
                        {
                            if (rnd.NextDouble() < 0.05)
                            {
                                writer.WriteLine(string.Join(",", features) + ",1");
                            }
                        }
                        else
                        {
                            writer.WriteLine(string.Join(",", features) + ",0");
                        }
                    }
                }
            }
        }
    }
}