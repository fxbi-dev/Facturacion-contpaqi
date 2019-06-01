using System;
using System.Collections.Generic;
using System.Text;
using SDKCompac.Nativos;
using SDKCompac.Nativos.Estructuras;

namespace SDKCompac.Modelos {
    public class Movimiento {
        private tMovimiento _estructura;

        public static class Campos {
            public const string Consecutivo = "cNumeroMovimiento";
            public const string Unidades = "cUnidades";
            public const string Precio = "cPrecio";
            public const string Costo = "cCostoCapturado";
            public const string CodProdSer = "cIdProducto";
            public const string CodAlmacen = "cIdAlmcen";
            public const string Referencia = "cReferencia";
            public const string CodClasificacion = "cIdValorClasificacion";
            public const string Observacion = "cObservaMov";
        }

        private List<string> _camposAGuardar;

        private Movimiento() {
            _estructura = new tMovimiento();
        }

        private Movimiento(tMovimiento estructura) {
            _estructura = estructura;
        }

        public static Movimiento[] ObtenerPorDocumento(int IdDocumento, params string[] campos) {
            Comercial.comprobarError(Nativos.SDK.fCancelaFiltroDocumento());
            Comercial.comprobarError(Nativos.SDK.fSetFiltroMovimiento(IdDocumento));
            Comercial.comprobarError(Nativos.SDK.fPosPrimerMovimiento());

            List<Movimiento> movimientos = new List<Movimiento>();

            do {
                Movimiento movimiento = new Movimiento();
                movimiento.ObtenerCampos(campos);
                movimientos.Add(movimiento);
            } while (Nativos.SDK.fPosSiguienteMovimiento() == 0);
            Comercial.comprobarError(Nativos.SDK.fCancelaFiltroDocumento());

            return movimientos.ToArray();
        }

        public void Guardar()
        {
            if (this.Consecutivo == -1)
            { // Movimiento Nuevo
                int ID = 0;
                Comercial.comprobarError(Nativos.SDK.fAltaMovimiento(this.CodDocumento, ref ID, ref _estructura));
                this.ID = ID;
            }
            else {
                Comercial.comprobarError(Nativos.SDK.fCancelaFiltroDocumento());
                Comercial.comprobarError(Nativos.SDK.fSetFiltroMovimiento(this.CodDocumento));
                Comercial.comprobarError(Nativos.SDK.fPosPrimerMovimiento());

                do {
                    StringBuilder sb = new StringBuilder(Nativos.Constantes.kIntGenerico);
                    Comercial.comprobarError(Nativos.SDK.fLeeDatoMovimiento(Consecutivo.ToString(), sb, Nativos.Constantes.kIntGenerico));
                    if (sb.ToString() == Consecutivo.ToString()) break;

                } while (Nativos.SDK.fPosSiguienteMovimiento() == 0);
            }

            Comercial.comprobarError(Nativos.SDK.fEditarMovimiento());
            Comercial.comprobarError(Nativos.SDK.fSetDatoMovimiento(Campos.Observacion, Observacion));

            Comercial.comprobarError(Nativos.SDK.fGuardaMovimiento());
        }

        public static Movimiento Crear(int CodDocumento, string CodProdSer)
        {
            return new Movimiento {
                CodDocumento = CodDocumento,
                Consecutivo = -1,
                Unidades = 0,
                Precio = 0,
                Costo = 0,
                CodProdSer = CodProdSer,
                CodAlmacen = "",
                Referencia = "",
                CodClasificacion = ""
            };
        }

        public void ObtenerCampos(params string[] campos) {
            foreach (string campo in campos) {
                this.ObtenerCampo(campo);
            }
        }

        private void ObtenerCampo(string campo) {
            switch (campo) {
                case Movimiento.Campos.Consecutivo:
                    break;

                case Movimiento.Campos.Unidades:
                    break;

                case Movimiento.Campos.Precio:
                    break;

                case Movimiento.Campos.Costo:
                    break;

                case Movimiento.Campos.CodProdSer:
                    break;

                case Movimiento.Campos.CodAlmacen:
                    break;

                case Movimiento.Campos.Referencia:
                    break;

                case Movimiento.Campos.CodClasificacion:
                    break;
            }
        }

        public int Consecutivo {
            get => _estructura.aConsecutivo;
            set => _estructura.aConsecutivo = value;
        }

        public int ID { get; set; }

        public int CodDocumento { get; set; }

        public string Observacion { get; set; }

        public double Unidades {
            get => _estructura.aUnidades;
            set => _estructura.aUnidades = value;
        }

        public double Precio {
            get => _estructura.aPrecio;
            set => _estructura.aPrecio = value;
        }

        public double Costo {
            get => _estructura.aCosto;
            set => _estructura.aCosto = value;
        }

        public string CodProdSer {
            get => _estructura.aCodProdSer;
            set => _estructura.aCodProdSer = value;
        }

        public string CodAlmacen {
            get => _estructura.aCodAlmacen;
            set => _estructura.aCodAlmacen = value;
        }

        public string Referencia {
            get => _estructura.aReferencia;
            set => _estructura.aReferencia = value;
        }

        public string CodClasificacion {
            get => _estructura.aCodClasificacion;
            set => _estructura.aCodClasificacion = value;
        }
    }
}