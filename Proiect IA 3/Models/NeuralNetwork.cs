using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IA_3.Models
{
    public class NeuralNetwork
    {
        public List<double> InputValues { get; set; }
        public List<Layer> HiddenLayers { get; set; }

        public Layer OutputLayer { get; set; }

        public bool IsTrained { get; set; }


        public NeuralNetwork()
        {
            InputValues = new List<double>();
            HiddenLayers = new List<Layer>();
        }

        public void SetInputNeurons(int n)
        {
            InputValues.Clear();
            for (int i = 0; i < n; i++)
            {
                InputValues.Add(1.0);
            }
        }

        public void AddHiddenLayer(int nOfNeurons)
        {
            int nOfInputs;

            if (HiddenLayers.Count == 0)
                nOfInputs = InputValues.Count;
            else
                nOfInputs = HiddenLayers[HiddenLayers.Count - 1].neurons.Count;

            HiddenLayers.Add(new Layer(nOfNeurons, nOfInputs));
        }

        public void CreateOutputLayer(int nOfNeurons)
        {
            int nOfInputs;

            if (HiddenLayers.Count > 0)
                nOfInputs = HiddenLayers[HiddenLayers.Count - 1].neurons.Count;
            else
                nOfInputs = InputValues.Count;

            OutputLayer = new Layer(nOfNeurons, nOfInputs);

        }

        public List<double> ForwardPropagate()
        {
            List<double> currentOutput = new List<double>(InputValues);
            foreach (var layer in HiddenLayers)
                currentOutput = layer.Process(currentOutput);
            if (OutputLayer != null)
                currentOutput = OutputLayer.Process(currentOutput);
            return currentOutput;
        }

    }

}
