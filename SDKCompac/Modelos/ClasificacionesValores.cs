using System;
using System.Collections.Generic;
using System.Text;
using SDKCompac.Nativos;

namespace SDKCompac.Modelos {
    public class ClasificacionesValores : IComparable<ClasificacionesValores> {
        public static class Constantes {
            public const int lID = 4;
            public const int lValorClasificacion = 61;
            public const int lIDClasificacion = 4;
            public const int lCodigo = 4;
        }

        public int Indice { get; private set; }
        public int ID { get; set; }
        public string ValorClasificacion { get; set; }
        public int IDClasificacion { get; set; }
        public string Codigo { get; set; }

        public ClasificacionesValores(int indice) {
            Indice = indice;
        }

        public static ClasificacionesValores Obtener(int indice) {
            if (indice >= 0) {
                Comercial.comprobarError(Nativos.SDK.fPosPrimerValorClasif());
                for (int i = 0; i < indice; i++) {
                    Comercial.comprobarError(Nativos.SDK.fPosSiguienteValorClasif());
                }
            } else {
                indice = Math.Abs(indice) - 1;
            }

            ClasificacionesValores cv = new ClasificacionesValores(indice);
            StringBuilder value;

            value = new StringBuilder(Constantes.lID);
            Nativos.SDK.fLeeDatoValorClasif("cIdValorClasificacion", value, Constantes.lID);
            cv.ID = int.Parse(value.ToString());

            value = new StringBuilder(Constantes.lValorClasificacion);
            Nativos.SDK.fLeeDatoValorClasif("cValorClasificacion", value, Constantes.lValorClasificacion);
            cv.ValorClasificacion = value.ToString();

            value = new StringBuilder(Constantes.lIDClasificacion);
            Nativos.SDK.fLeeDatoValorClasif("cIdClasificacion", value, Constantes.lIDClasificacion);
            cv.IDClasificacion = int.Parse(value.ToString());

            value = new StringBuilder(Constantes.lCodigo);
            Nativos.SDK.fLeeDatoValorClasif("cCodigoValorClasificacion", value, Constantes.lCodigo);
            cv.Codigo = value.ToString();

            return cv;
        }

        public int CompareTo(ClasificacionesValores other) {
            if (other == null)
                return -1;
            if (this.ID < other.ID)
                return -1;
            if (this.ID > other.ID)
                return 1;
            return 0;
        }

        public override string ToString() {
            return this.ID + ", " + this.Codigo + ", " + this.ValorClasificacion;
        }
    }
}