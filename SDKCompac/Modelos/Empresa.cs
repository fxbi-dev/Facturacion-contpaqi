using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKCompac.Modelos {
    public class Empresa {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Directorio { get; set; }

        public override string ToString() {
            return ID + ", " + Nombre + ", " + Directorio;
        }
    }
}
