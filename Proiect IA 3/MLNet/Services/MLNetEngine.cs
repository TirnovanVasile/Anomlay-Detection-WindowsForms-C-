using Microsoft.ML;
using Proiect_IA_3.MLNet.Models; 
using Proiect_IA_3.Services;    
using System.Collections.Generic;
using System.Linq;

namespace Proiect_IA_3.MLNet.Services
{
    public class MLNetEngine
    {
        private readonly MLContext mlContext;
        private ITransformer trainedModel;

        public bool IsTrained { get; private set; } = false;

        public MLNetEngine()
        {
            mlContext = new MLContext(seed: 42);
        }

        private IEnumerable<SensorData> ConvertData(List<List<double>> inputs, List<List<double>> outputs)
        {
            var dataList = new List<SensorData>();
            for (int i = 0; i < inputs.Count; i++)
            {
                dataList.Add(new SensorData
                {
                    Features = inputs[i].Select(x => (float)x).ToArray(),
                    Label = outputs != null && outputs[i][0] >= 0.5
                });
            }
            return dataList;
        }

        public void TrainLogisticRegression(DataManager dataManager)
        {
            var trainingData = ConvertData(dataManager.TrainInputs, dataManager.TrainOutputs);
            IDataView dataView = mlContext.Data.LoadFromEnumerable(trainingData);


            var pipeline = mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "Label", featureColumnName: "Features");

            trainedModel = pipeline.Fit(dataView);
            IsTrained = true;
        }

        public void TrainKMeans(DataManager dataManager)
        {
            var trainingData = ConvertData(dataManager.TrainInputs, dataManager.TrainOutputs);
            IDataView dataView = mlContext.Data.LoadFromEnumerable(trainingData);

            var pipeline = mlContext.Clustering.Trainers.KMeans(featureColumnName: "Features", numberOfClusters: 2);

            trainedModel = pipeline.Fit(dataView);
            IsTrained = true;
        }

        public List<int> PredictAll(List<List<double>> testInputs, bool isKMeans)
        {
            var testData = ConvertData(testInputs, null);
            IDataView testDataView = mlContext.Data.LoadFromEnumerable(testData);

            IDataView predictions = trainedModel.Transform(testDataView);

            if (isKMeans)
            {
                var predictedResults = mlContext.Data.CreateEnumerable<KMeansPrediction>(predictions, reuseRowObject: false).ToList();

                return predictedResults.Select(p => p.ClusterId == 2 ? 1 : 0).ToList();
            }
            else
            {
                var predictedResults = mlContext.Data.CreateEnumerable<LogRegPrediction>(predictions, reuseRowObject: false).ToList();

                return predictedResults.Select(p => p.Prediction ? 1 : 0).ToList();
            }
        }
    }
}