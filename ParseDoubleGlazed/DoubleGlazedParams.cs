using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseDoubleGlazed
{
    public class DoubleGlazedParams
    {
        /// <summary>
        /// Камерность
        /// </summary>
        public int Cameras { get; set; }
        /// <summary>
        /// Толщина СП
        /// </summary>
        public int Thickness { get; set; }
        /// <summary>
        /// Толщина стекла
        /// </summary>
        public int GlassThickness { get; set; }

    }
}
