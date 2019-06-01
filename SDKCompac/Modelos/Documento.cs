using System;
using System.Collections.Generic;
using System.Text;
using SDKCompac.Nativos;
using SDKCompac.Nativos.Estructuras;

namespace SDKCompac.Modelos {
    public class Documento {
        // Datos coincidentes con la estructura
        public static class Campos {
            public const string ID = "cIdDocumento";
            public const string Folio = "cFolio";
            public const string NumMoneda = "cIdMoneda";
            public const string TipoCambio = "cTipoCambio";
            public const string Importe = "aTotal";
            public const string DescuentoDoc1 = "cDescuentoDoc1";
            public const string DescuentoDoc2 = "cDescuentoDoc2";
            public const string SistemaOrigen = "cSistOrig";
            public const string CodConcepto = "aCodConcepto";
            public const string Serie = "cSerieDocumento";
            public const string Fecha = "cFecha";
            public const string CodigoCteProv = "aIdClienteProveedor";
            public const string CodigoAgente = "aIdAgente";
            public const string Referencia = "cReferencia";
            public const string Afecta = "cAfectado";
            public const string Gasto1 = "cGasto1";
            public const string Gasto2 = "cGasto2";
            public const string Gasto3 = "cGasto3";
            public const string MetodoPag = "cMetodoPag";
            public const string CantParci = "cCantParci";

        }
        private List<string> camposGuardados = new List<string>();
        private tDocumento _estructura;

        private Documento() {
            _estructura = new tDocumento();
        }

        private Documento(tDocumento estructura) {
            _estructura = estructura;
        }

        public static Documento Crear(string CodConcepto, string Serie, string CodigoCteProv) {
            return new Documento {
                ID = -1,
                Folio = -1,
                NumMoneda = 1,
                TipoCambio = 1.0,
                Importe = 0,
                DescuentoDoc1 = 0,
                DescuentoDoc2 = 0,
                SistemaOrigen = 202,
                CodConcepto = CodConcepto,
                Serie = Serie,
                Fecha = DateTime.Today.ToString("MM/dd/yyyy"),
                CodigoCteProv = CodigoCteProv,
                CodigoAgente = "",
                Referencia = "",
                Afecta = 0,
                Gasto1 = 0.0,
                Gasto2 = 0.0,
                Gasto3 = 0.0
            };
        }

        public void Guardar() {
            if (this.Folio == -1) { // Documento Nuevo
                int ID = 0;
                double Folio = 0.0;

                StringBuilder Serie = new StringBuilder(Constantes.kLongSerie);
                Comercial.comprobarError(Nativos.SDK.fSiguienteFolio(this.CodConcepto, Serie, ref Folio));
                this.Folio = Folio;
                //Console.WriteLine(Folio);
                this.Serie = Serie.ToString();
                Comercial.comprobarError(Nativos.SDK.fAltaDocumento(ref ID, ref _estructura));
                this.ID = ID;
            } else { // Modificación de documento

            }
            Comercial.comprobarError(Nativos.SDK.fBuscarDocumento(this.CodConcepto, Serie, this.Folio.ToString()));
            Comercial.comprobarError(Nativos.SDK.fEditarDocumento());
            Comercial.comprobarError(Nativos.SDK.fSetDatoDocumento(Documento.Campos.MetodoPag, "99"));
            Comercial.comprobarError(Nativos.SDK.fSetDatoDocumento(Documento.Campos.CantParci, "2"));
            Comercial.comprobarError(Nativos.SDK.fGuardaDocumento());
        }

        public static Documento[] ObtenerTodos(params string[] campos) {
            Comercial.comprobarError(Nativos.SDK.fPosPrimerDocumento());

            List<Documento> documentos = new List<Documento>();

            do {
                Documento documento = new Documento();
                documento.ObtenerCampos(campos);
                documentos.Add(documento);
            } while (Nativos.SDK.fPosSiguienteDocumento() != 0);

            return documentos.ToArray();
        }

        public static Documento Obtener(string CodConcepto, string Serie, double Folio, params string[] campos) {
            Comercial.comprobarError(Nativos.SDK.fBuscarDocumento(CodConcepto, Serie, Folio.ToString()));

            Documento docuemnto = new Documento();
            docuemnto.ObtenerCampo(Documento.Campos.ID);
            docuemnto.ObtenerCampos(campos);
            return docuemnto;
        }

        public void ObtenerCampos(params string[] campos) {
            Comercial.comprobarError(Nativos.SDK.fBuscarDocumento(this.CodConcepto, this.Serie, this.Folio.ToString()));

            foreach (string campo in campos) {
                this.ObtenerCampo(campo);
            }
        }

        private void ObtenerCampo(string campo) {
            switch (campo) {
                case Documento.Campos.ID:
                    break;

                case Documento.Campos.Folio:
                    break;

                case Documento.Campos.NumMoneda:
                    break;

                case Documento.Campos.TipoCambio:
                    break;

                case Documento.Campos.Importe:
                    break;

                case Documento.Campos.DescuentoDoc1:
                    break;

                case Documento.Campos.DescuentoDoc2:
                    break;

                case Documento.Campos.SistemaOrigen:
                    break;

                case Documento.Campos.CodConcepto:
                    break;

                case Documento.Campos.Serie:
                    break;

                case Documento.Campos.Fecha:
                    break;

                case Documento.Campos.CodigoCteProv:
                    break;

                case Documento.Campos.CodigoAgente:
                    break;

                case Documento.Campos.Referencia:
                    break;

                case Documento.Campos.Afecta:
                    break;

                case Documento.Campos.Gasto1:
                    break;

                case Documento.Campos.Gasto2:
                    break;

                case Documento.Campos.Gasto3:
                    break;
            }
        }

        public int ID { get; set; }

        public double Folio {
            get => _estructura.aFolio;
            set => _estructura.aFolio = value;
        }

        public int NumMoneda {
            get => _estructura.aNumMoneda;
            set => _estructura.aNumMoneda = value;
        }

        public double TipoCambio {
            get => _estructura.aTipoCambio;
            set => _estructura.aTipoCambio = value;
        }

        public double Importe {
            get => _estructura.aImporte;
            set => _estructura.aImporte = value;
        }

        public double DescuentoDoc1 {
            get => _estructura.aDescuentoDoc1;
            set => _estructura.aDescuentoDoc1 = value;
        }

        public double DescuentoDoc2 {
            get => _estructura.aDescuentoDoc2;
            set => _estructura.aDescuentoDoc2 = value;
        }

        public int SistemaOrigen {
            get => _estructura.aSistemaOrigen;
            set => _estructura.aSistemaOrigen = value;
        }

        public string CodConcepto {
            get => _estructura.aCodConcepto;
            set => _estructura.aCodConcepto = value;
        }

        public string Serie {
            get => _estructura.aSerie;
            set => _estructura.aSerie = value;
        }

        public string Fecha {
            get => _estructura.aFecha;
            set => _estructura.aFecha = value;
        }

        public string CodigoCteProv {
            get => _estructura.aCodigoCteProv;
            set => _estructura.aCodigoCteProv = value;
        }

        public string CodigoAgente {
            get => _estructura.aCodigoAgente;
            set => _estructura.aCodigoAgente = value;
        }

        public string Referencia {
            get => _estructura.aReferencia;
            set => _estructura.aReferencia = value;
        }

        public int Afecta {
            get => _estructura.aAfecta;
            set => _estructura.aAfecta = value;
        }

        public double Gasto1 {
            get => _estructura.aGasto1;
            set => _estructura.aGasto1 = value;
        }

        public double Gasto2 {
            get => _estructura.aGasto2;
            set => _estructura.aGasto2 = value;
        }

        public double Gasto3 {
            get => _estructura.aGasto3;
            set => _estructura.aGasto3 = value;
        }
    }
}