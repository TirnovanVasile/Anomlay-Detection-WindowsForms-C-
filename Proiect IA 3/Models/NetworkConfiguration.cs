using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IA_3.Models
{
    public class NetworkConfiguration
    {
        public int InputNeurons { get; set; }
        public int HiddenLayerCount { get; set; }
        public int OutputNeurons { get; set; }
        public List<int> HiddenNeuronCounts { get; set; }
    }
}
