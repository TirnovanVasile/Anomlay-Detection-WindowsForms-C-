using Proiect_IA_3.Models;
using System.Text.Json;


namespace Proiect_IA_3.Services
{
    public static class ModelSerializer
    {
        [Serializable]
        public class SerializableModel
        {
            public List<double> InputValues { get; set; }
            public List<SerializableLayer> HiddenLayers { get; set; }
            public SerializableLayer OutputLayer { get; set; }
            public bool IsTrained { get; set; }
        }

        [Serializable]
        public class SerializableLayer
        {
            public List<SerializableNeuron> Neurons { get; set; }
            public GinType GinType { get; set; }
            public ActivationType ActivationType { get; set; }
            public OutputType OutputType { get; set; }
            public double G { get; set; }
        }

        [Serializable]
        public class SerializableNeuron
        {
            public List<double> Weights { get; set; }
            public double Theta { get; set; }
        }

        public static void SaveModel(NeuralNetwork network, string filePath)
        {
            var model = new SerializableModel
            {
                InputValues = network.InputValues,
                HiddenLayers = new List<SerializableLayer>(),
                IsTrained = network.IsTrained
            };

            foreach (var layer in network.HiddenLayers)
            {
                var serLayer = new SerializableLayer
                {
                    Neurons = new List<SerializableNeuron>(),
                    GinType = layer.ginType,
                    ActivationType = layer.activationType,
                    OutputType = layer.outputType,
                    G = layer.g
                };

                foreach (var neuron in layer.neurons)
                {
                    serLayer.Neurons.Add(new SerializableNeuron
                    {
                        Weights = new List<double>(neuron.weights),
                        Theta = neuron.theta
                    });
                }

                model.HiddenLayers.Add(serLayer);
            }

            if (network.OutputLayer != null)
            {
                var serOutputLayer = new SerializableLayer
                {
                    Neurons = new List<SerializableNeuron>(),
                    GinType = network.OutputLayer.ginType,
                    ActivationType = network.OutputLayer.activationType,
                    OutputType = network.OutputLayer.outputType,
                    G = network.OutputLayer.g
                };

                foreach (var neuron in network.OutputLayer.neurons)
                {
                    serOutputLayer.Neurons.Add(new SerializableNeuron
                    {
                        Weights = new List<double>(neuron.weights),
                        Theta = neuron.theta
                    });
                }

                model.OutputLayer = serOutputLayer;
            }

            string json = JsonSerializer.Serialize(model, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(filePath, json);
        }

        public static NeuralNetwork LoadModel(string filePath)
        {
            string json = File.ReadAllText(filePath);
            var model = JsonSerializer.Deserialize<SerializableModel>(json);

            var network = new NeuralNetwork();
            network.InputValues = new List<double>(model.InputValues);
            network.IsTrained = model.IsTrained;

            foreach (var serLayer in model.HiddenLayers)
            {
                int inputCount = (network.HiddenLayers.Count == 0) ?
                    network.InputValues.Count :
                    network.HiddenLayers[network.HiddenLayers.Count - 1].neurons.Count;

                var layer = new Layer(serLayer.Neurons.Count, inputCount);
                layer.ginType = serLayer.GinType;
                layer.activationType = serLayer.ActivationType;
                layer.outputType = serLayer.OutputType;
                layer.g = serLayer.G;

                for (int i = 0; i < serLayer.Neurons.Count; i++)
                {
                    layer.neurons[i].weights = new List<double>(serLayer.Neurons[i].Weights);
                    layer.neurons[i].theta = serLayer.Neurons[i].Theta;
                }

                network.HiddenLayers.Add(layer);
            }

            if (model.OutputLayer != null)
            {
                int inputCount = (network.HiddenLayers.Count > 0) ?
                    network.HiddenLayers[network.HiddenLayers.Count - 1].neurons.Count :
                    network.InputValues.Count;

                var outputLayer = new Layer(model.OutputLayer.Neurons.Count, inputCount);
                outputLayer.ginType = model.OutputLayer.GinType;
                outputLayer.activationType = model.OutputLayer.ActivationType;
                outputLayer.outputType = model.OutputLayer.OutputType;
                outputLayer.g = model.OutputLayer.G;

                for (int i = 0; i < model.OutputLayer.Neurons.Count; i++)
                {
                    outputLayer.neurons[i].weights = new List<double>(model.OutputLayer.Neurons[i].Weights);
                    outputLayer.neurons[i].theta = model.OutputLayer.Neurons[i].Theta;
                }

                network.OutputLayer = outputLayer;
            }

            return network;
        }
    }
}
