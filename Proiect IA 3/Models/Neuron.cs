using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IA_3.Models
{
    public enum ActivationType
    {
        Linear,
        Sigmoid,
        Signum,
        Tanh,
        Step,
        ReLU
    }

    public enum GinType
    {
        Sum,
        Prod,
        Min,
        Max,
    }

    public enum OutputType
    {
        Real,
        Binary
    }

    public class Neuron
    {
        public List<double> weights { get; set; }
        public double gin { get; set; }
        public double activation { get; set; }
        public double output { get; set; }
        public double delta { get; set; }

        public double theta { get; set; }

        public Neuron(int n)
        {
            weights = new List<double>();

            for (int i = 0; i < n; i++)
                weights.Add(0.0);

            theta = 0.0; 
        }

        public void CalculateGin(List<double> inputs, GinType ginType)
        {
            switch (ginType)
            {
                case GinType.Sum:
                    gin = 0;
                    for (int i = 0; i < inputs.Count; i++)
                        gin += inputs[i] * weights[i];
                    break;
                case GinType.Prod:
                    gin = 1;
                    for (int i = 0; i < inputs.Count; i++)
                        gin *= Math.Pow(inputs[i], weights[i]);
                    break;
                case GinType.Min:
                    gin = double.MaxValue;
                    for (int i = 0; i < inputs.Count; i++)
                    {
                        double value = Math.Min(inputs[i], weights[i]);
                        if (value < gin) gin = value;
                    }
                    break;
                case GinType.Max:
                    gin = double.MinValue;
                    for (int i = 0; i < inputs.Count; i++)
                    {
                        double value = Math.Max(inputs[i], weights[i]);
                        if (value > gin) gin = value;
                    }
                    break;
            }
        }

        public void CalculateActivation(ActivationType activationType, double g)
        {
            double net = gin - theta;

            switch (activationType)
            {
                case ActivationType.Linear:
                    activation = net;
                    break;
                case ActivationType.Sigmoid:
                    activation = 1.0 / (1.0 + Math.Exp(-g * net));
                    break;
                case ActivationType.Signum:
                    if (net > 0) activation = 1;
                    else if (net < 0) activation = -1;
                    else activation = 0;
                    break;
                case ActivationType.Tanh:
                    activation = Math.Tanh(g * net); 
                    break;
                case ActivationType.ReLU:
                    activation = net > 0 ? net : 0;
                    break;
                case ActivationType.Step:
                    if (net >= 0) activation = 1;
                    else activation = 0;
                    break;
            }
        }

        public void CalculateOutput(OutputType outputType)
        {
            if (outputType == OutputType.Real)
                output = activation;
            else
            {
                if (activation >= theta) 
                    output = 1;
                else
                    output = 0;
            }
        }
    }
}
