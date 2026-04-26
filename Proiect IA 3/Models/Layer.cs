using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IA_3.Models
{
    public class Layer
    {
        public List<Neuron> neurons { get; set; }
        public GinType ginType { get; set; }
        public ActivationType activationType { get; set; }
        public OutputType outputType { get; set; }
        public double g { get; set; }


        public Layer(int nOfNeurons, int nOfInputs)
        {
            neurons = new List<Neuron>();

            for (int i = 0; i < nOfNeurons; i++)
                neurons.Add(new Neuron(nOfInputs));

            ginType = GinType.Sum;
            activationType = ActivationType.Sigmoid;
            outputType = OutputType.Real;
            g = 1.0;

        }

        public List<double> Process(List<double> inputs)
        {
            List<double> outputs = new List<double>();

            foreach (var neuron in neurons)
            {
                neuron.CalculateGin(inputs, ginType);
                neuron.CalculateActivation(activationType, g);
                neuron.CalculateOutput(outputType);
                outputs.Add(neuron.output);
            }

            return outputs;
        }

    }
}
