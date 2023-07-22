using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCPSelector
{
    public class SelectionData
    {
        public Dictionary<int, int> PlayerSelections { get; set; }

        public SelectionData()
        {
            PlayerSelections = new Dictionary<int, int>();
        }
    }
}
