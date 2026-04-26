using Proiect_IA_3.Models;
using System.Diagnostics;

namespace Proiect_IA_3.Services
{
    public class TrainingEngine
    {
        private NeuralNetwork network;
        private DataManager dataManager;
        private CancellationTokenSource cancellationToken;

        public double LearningRate { get; set; }
        public int MaxEpochs { get; set; }
        public double TargetError { get; set; }
        public bool UseValidation { get; set; }

        public bool IsTraining { get; private set; }

        public event EventHandler<EpochCompletedEventArgs> EpochCompleted;
        public event EventHandler<TrainingCompletedEventArgs> TrainingCompleted;

        public TrainingEngine(NeuralNetwork network, DataManager dataManager)
        {
            this.network = network;
            this.dataManager = dataManager;

            LearningRate = 0.01;
            MaxEpochs = 1000;
            TargetError = 0.001;
            UseValidation = true;
        }

        public async void StartTrainingAsync()
        {
            IsTraining = true;
            cancellationToken = new CancellationTokenSource();

            await Task.Run(() => Train(cancellationToken.Token));
        }

        public void StopTraining()
        {
            if (cancellationToken != null)
                cancellationToken.Cancel();
        }

        private void Train(CancellationToken token)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            double finalLoss = 0;
            int epochsCompleted = 0;

            try
            {
                for (int epoch = 1; epoch <= MaxEpochs; epoch++)
                {
                    if (token.IsCancellationRequested)
                        break;

                    double trainLoss = TrainEpoch();

                    double validLoss = 0;
                    if (UseValidation && dataManager.ValidationCount > 0)
                    {
                        validLoss = ValidateEpoch();
                    }

                    epochsCompleted = epoch;
                    finalLoss = trainLoss;

                    OnEpochCompleted(new EpochCompletedEventArgs
                    {
                        Epoch = epoch,
                        TrainingLoss = trainLoss,
                        ValidationLoss = validLoss
                    });

                    if (trainLoss <= TargetError)
                    {
                        break;
                    }

                    Thread.Sleep(1);
                }
            }
            finally
            {
                stopwatch.Stop();
                IsTraining = false;

                OnTrainingCompleted(new TrainingCompletedEventArgs
                {
                    TotalEpochs = epochsCompleted,
                    FinalLoss = finalLoss,
                    TrainingTime = stopwatch.Elapsed
                });
            }
        }

        private double TrainEpoch()
        {
            double totalError = 0;
            int sampleCount = dataManager.TrainCount;

            var indices = Enumerable.Range(0, sampleCount).ToList();

            foreach (int i in indices)
            {
                var inputs = dataManager.TrainInputs[i];
                var targets = dataManager.TrainOutputs[i];

                network.InputValues = new List<double>(inputs);
                var outputs = ForwardPropagation();

                double sampleError = CalculateError(outputs, targets);
                totalError += sampleError;

                BackPropagation(targets);
                UpdateWeights();
            }

            return totalError / sampleCount;
        }

        private double ValidateEpoch()
        {
            double totalError = 0;
            int sampleCount = dataManager.ValidationCount;

            for (int i = 0; i < sampleCount; i++)
            {
                var inputs = dataManager.ValidationInputs[i];
                var targets = dataManager.ValidationOutputs[i];

                network.InputValues = new List<double>(inputs);
                var outputs = ForwardPropagation();

                double sampleError = CalculateError(outputs, targets);
                totalError += sampleError;
            }

            return totalError / sampleCount;
        }

        private List<double> ForwardPropagation()
        {
            List<double> currentOutput = new List<double>(network.InputValues);

            foreach (var layer in network.HiddenLayers)
            {
                currentOutput = layer.Process(currentOutput);
            }

            if (network.OutputLayer != null)
            {
                currentOutput = network.OutputLayer.Process(currentOutput);
            }

            return currentOutput;
        }

        private void BackPropagation(List<double> targets)
        {
            var outputLayer = network.OutputLayer;

            for (int i = 0; i < outputLayer.neurons.Count; i++)
            {
                var neuron = outputLayer.neurons[i];
                double output = neuron.output;
                double target = targets[i];

                double error = target - output;
                double derivative = CalculateActivationDerivative(output, outputLayer.activationType, outputLayer.g);

                neuron.delta = error * derivative;
            }

            for (int l = network.HiddenLayers.Count - 1; l >= 0; l--)
            {
                var currentLayer = network.HiddenLayers[l];
                Layer nextLayer;

                if (l == network.HiddenLayers.Count - 1)
                    nextLayer = outputLayer;
                else
                    nextLayer = network.HiddenLayers[l + 1];

                for (int i = 0; i < currentLayer.neurons.Count; i++)
                {
                    var neuron = currentLayer.neurons[i];

                    double errorSum = 0;
                    foreach (var nextNeuron in nextLayer.neurons)
                    {
                        errorSum += nextNeuron.delta * nextNeuron.weights[i];
                    }

                    double derivative = CalculateActivationDerivative(neuron.output, currentLayer.activationType, currentLayer.g);
                    neuron.delta = errorSum * derivative;
                }
            }
        }

        private void UpdateWeights()
        {
            for (int l = 0; l < network.HiddenLayers.Count; l++)
            {
                var layer = network.HiddenLayers[l];
                List<double> inputs;

                if (l == 0)
                    inputs = network.InputValues;
                else
                    inputs = network.HiddenLayers[l - 1].neurons.Select(n => n.output).ToList();

                foreach (var neuron in layer.neurons)
                {
                    for (int w = 0; w < neuron.weights.Count; w++)
                    {
                        neuron.weights[w] += LearningRate * neuron.delta * inputs[w];
                    }
                    neuron.theta -= LearningRate * neuron.delta;
                }
            }

            var outputLayer = network.OutputLayer;
            List<double> outputInputs;

            if (network.HiddenLayers.Count > 0)
                outputInputs = network.HiddenLayers[network.HiddenLayers.Count - 1].neurons.Select(n => n.output).ToList();
            else
                outputInputs = network.InputValues;

            foreach (var neuron in outputLayer.neurons)
            {
                for (int w = 0; w < neuron.weights.Count; w++)
                {
                    neuron.weights[w] += LearningRate * neuron.delta * outputInputs[w];
                }
                neuron.theta -= LearningRate * neuron.delta;
            }
        }

        private double CalculateActivationDerivative(double activation, ActivationType type, double g)
        {
            if (type == ActivationType.Sigmoid)
                return activation * (1 - activation) * g;
            else if (type == ActivationType.Tanh)
                return (1 - activation * activation) * g;
            else if (type == ActivationType.ReLU)
                return activation > 0 ? 1.0 : 0.0;
            return 1.0;
        }

        private double CalculateError(List<double> outputs, List<double> targets)
        {
            double sum = 0;
            for (int i = 0; i < outputs.Count; i++)
            {
                double diff = targets[i] - outputs[i];
                sum += diff * diff;
            }
            return sum / outputs.Count;
        }

        protected virtual void OnEpochCompleted(EpochCompletedEventArgs e)
        {
            if (EpochCompleted != null)
                EpochCompleted(this, e);
        }

        protected virtual void OnTrainingCompleted(TrainingCompletedEventArgs e)
        {
            if (TrainingCompleted != null)
                TrainingCompleted(this, e);
        }
    }

    public class EpochCompletedEventArgs : EventArgs
    {
        public int Epoch { get; set; }
        public double TrainingLoss { get; set; }
        public double ValidationLoss { get; set; }
    }

    public class TrainingCompletedEventArgs : EventArgs
    {
        public int TotalEpochs { get; set; }
        public double FinalLoss { get; set; }
        public TimeSpan TrainingTime { get; set; }
    }
}
