using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemaMVP {
    [Serializable]
    public class GridData {
        [Serializable]
        public struct MatrixElement {
            public bool visibility;
            public string filePath;
        }
        public MatrixElement[,] ButtonStates { get; set; }
    }
}
