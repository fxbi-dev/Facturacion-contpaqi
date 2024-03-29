﻿using System;
using System.Collections.Generic;
using System.Text;
using SDKCompac.Nativos;
using SDKCompac.Nativos.Estructuras;

namespace SDKCompac.Modelos {
    public class ClienteProveedor : IComparable<ClienteProveedor> {
        public static class Campos {
            public const string CodigoCliente = "cCodigoCliente";
            public const string RazonSocial = "cRazonSocial";
            public const string RFC = "cRFC";
            public const string CodigoValorClasificacionCliente1 = "cIdValorClasifCliente1";
            public const string TextoExtra1 = "cTextoExtra1";
            public const string Estatus = "cEstatus";
        }

        private tCteProv _estructura;

        //public int Indice { private set; get; }

        private static void ObtenerCampo(ref ClienteProveedor cteProv, string campo) {
            StringBuilder stringBuilder;
            int intValue;
            double doubleValue;

            switch (campo) {
                case ClienteProveedor.Campos.CodigoCliente:
                    stringBuilder = new StringBuilder(Constantes.kLongCodigo);
                    Comercial.comprobarError(Nativos.SDK.fLeeDatoCteProv(campo, stringBuilder,
                        Constantes.kLongCodigo));
                    cteProv.CodigoCliente = stringBuilder.ToString();
                    break;

                case ClienteProveedor.Campos.RazonSocial:
                    stringBuilder = new StringBuilder(Constantes.kLongNombre);
                    Comercial.comprobarError(Nativos.SDK.fLeeDatoCteProv(campo, stringBuilder,
                        Constantes.kLongNombre));
                    cteProv.RazonSocial = stringBuilder.ToString();
                    break;

                case ClienteProveedor.Campos.RFC:
                    stringBuilder = new StringBuilder(Constantes.kLongRFC);
                    Comercial.comprobarError(Nativos.SDK.fLeeDatoCteProv(campo, stringBuilder,
                        Constantes.kLongRFC));
                    cteProv.RFC = stringBuilder.ToString();
                    break;

                case ClienteProveedor.Campos.CodigoValorClasificacionCliente1:
                    stringBuilder = new StringBuilder(Constantes.kLongCodValorClasif);
                    Comercial.comprobarError(Nativos.SDK.fLeeDatoCteProv(campo, stringBuilder,
                        Constantes.kLongCodValorClasif));
                    cteProv.CodigoValorClasificacionCliente1 = stringBuilder.ToString();
                    break;

                case ClienteProveedor.Campos.TextoExtra1:
                    stringBuilder = new StringBuilder(50);
                    Comercial.comprobarError(Nativos.SDK.fLeeDatoCteProv(campo, stringBuilder,
                        50));
                    cteProv.TextoExtra1 = stringBuilder.ToString();
                    break;
                case ClienteProveedor.Campos.Estatus:
                    stringBuilder = new StringBuilder(Constantes.kIntGenerico);
                    Comercial.comprobarError(Nativos.SDK.fLeeDatoCteProv(campo, stringBuilder,
                        Constantes.kIntGenerico));
                    int res = 0;
                    if (int.TryParse(stringBuilder.ToString(), out res)) {
                        cteProv.Status = res;
                    }
                    break;
            }
        }

        public static ClienteProveedor Obtener(string CodigoCliente, params string[] campos) {
            Comercial.comprobarError(Nativos.SDK.fBuscaCteProv(CodigoCliente));

            ClienteProveedor cteProv = new ClienteProveedor();
            foreach (string campo in campos) {
               ClienteProveedor.ObtenerCampo(ref cteProv, campo);
            }

            return cteProv;
        }

        public static ClienteProveedor[] ObtenerTodos(params string[] campos) {
            List<ClienteProveedor> cteProvs = new List<ClienteProveedor>();
            Comercial.comprobarError(Nativos.SDK.fPosPrimerCteProv());
            while (true) {
                ClienteProveedor cteProv = new ClienteProveedor();
                foreach (string campo in campos) {
                    ClienteProveedor.ObtenerCampo(ref cteProv, campo);
                }
                cteProvs.Add(cteProv);
                if (Nativos.SDK.fPosSiguienteCteProv() != 0) break;
            }

            return cteProvs.ToArray();
        }

        public string CodigoCliente {
            get => _estructura.cCodigoCliente;
            set => _estructura.cCodigoCliente = value;
        }
        
        public string RazonSocial {
            get => _estructura.cRazonSocial;
            set => _estructura.cRazonSocial = value;
        }
        
        public string FechaAlta {
            get => _estructura.cFechaAlta;
            set => _estructura.cFechaAlta = value;
        }
        
        public string RFC {
            get => _estructura.cRFC;
            set => _estructura.cRFC = value;
        }
        
        public string CURP {
            get => _estructura.cCURP;
            set => _estructura.cCURP = value;
        }
        
        public string DenComercial {
            get => _estructura.cDenComercial;
            set => _estructura.cDenComercial = value;
        }
        
        public string RepLegal {
            get => _estructura.cRepLegal;
            set => _estructura.cRepLegal = value;
        }
        
        public string NombreMoneda {
            get => _estructura.cNombreMoneda;
            set => _estructura.cNombreMoneda = value;
        }
        
        public int ListaPreciosCliente {
            get => _estructura.cListaPreciosCliente;
            set => _estructura.cListaPreciosCliente = value;
        }
        
        public double DescuentoMovto {
            get => _estructura.cDescuentoMovto;
            set => _estructura.cDescuentoMovto = value;
        }
        
        public int BanVentaCredito {
            get => _estructura.cBanVentaCredito;
            set => _estructura.cBanVentaCredito = value;
        }
        
        public string CodigoValorClasificacionCliente1 {
            get => _estructura.cCodigoValorClasificacionCliente1;
            set => _estructura.cCodigoValorClasificacionCliente1 = value;
        }
        
        public string CodigoValorClasificacionCliente2 {
            get => _estructura.cCodigoValorClasificacionCliente2;
            set => _estructura.cCodigoValorClasificacionCliente2 = value;
        }
        
        public string CodigoValorClasificacionCliente3 {
            get => _estructura.cCodigoValorClasificacionCliente3;
            set => _estructura.cCodigoValorClasificacionCliente3 = value;
        }
        
        public string CodigoValorClasificacionCliente4 {
            get => _estructura.cCodigoValorClasificacionCliente4;
            set => _estructura.cCodigoValorClasificacionCliente4 = value;
        }
        
        public string CodigoValorClasificacionCliente5 {
            get => _estructura.cCodigoValorClasificacionCliente5;
            set => _estructura.cCodigoValorClasificacionCliente5 = value;
        }
        
        public string CodigoValorClasificacionCliente6 {
            get => _estructura.cCodigoValorClasificacionCliente6;
            set => _estructura.cCodigoValorClasificacionCliente6 = value;
        }
        
        public int TipoCliente {
            get => _estructura.cTipoCliente;
            set => _estructura.cTipoCliente = value;
        }
        
        public int Estatus {
            get => _estructura.cEstatus;
            set => _estructura.cEstatus = value;
        }
        
        public string FechaBaja {
            get => _estructura.cFechaBaja;
            set => _estructura.cFechaBaja = value;
        }
        
        public string FechaUltimaRevision {
            get => _estructura.cFechaUltimaRevision;
            set => _estructura.cFechaUltimaRevision = value;
        }
        
        public double LimiteCreditoCliente {
            get => _estructura.cLimiteCreditoCliente;
            set => _estructura.cLimiteCreditoCliente = value;
        }
        
        public int DiasCreditoCliente {
            get => _estructura.cDiasCreditoCliente;
            set => _estructura.cDiasCreditoCliente = value;
        }
        
        public int BanExcederCredito {
            get => _estructura.cBanExcederCredito;
            set => _estructura.cBanExcederCredito = value;
        }
        
        public double DescuentoProntoPago {
            get => _estructura.cDescuentoProntoPago;
            set => _estructura.cDescuentoProntoPago = value;
        }
        
        public int DiasProntoPago {
            get => _estructura.cDiasProntoPago;
            set => _estructura.cDiasProntoPago = value;
        }
        
        public double InteresMoratorio {
            get => _estructura.cInteresMoratorio;
            set => _estructura.cInteresMoratorio = value;
        }
        
        public int DiaPago {
            get => _estructura.cDiaPago;
            set => _estructura.cDiaPago = value;
        }
        
        public int DiasRevision {
            get => _estructura.cDiasRevision;
            set => _estructura.cDiasRevision = value;
        }
        
        public string Mensajeria {
            get => _estructura.cMensajeria;
            set => _estructura.cMensajeria = value;
        }
        
        public string CuentaMensajeria {
            get => _estructura.cCuentaMensajeria;
            set => _estructura.cCuentaMensajeria = value;
        }
        
        public int DiasEmbarqueCliente {
            get => _estructura.cDiasEmbarqueCliente;
            set => _estructura.cDiasEmbarqueCliente = value;
        }
        
        public string CodigoAlmacen {
            get => _estructura.cCodigoAlmacen;
            set => _estructura.cCodigoAlmacen = value;
        }
        
        public string CodigoAgenteVenta {
            get => _estructura.cCodigoAgenteVenta;
            set => _estructura.cCodigoAgenteVenta = value;
        }
        
        public string CodigoAgenteCobro {
            get => _estructura.cCodigoAgenteCobro;
            set => _estructura.cCodigoAgenteCobro = value;
        }
        
        public int RestriccionAgente {
            get => _estructura.cRestriccionAgente;
            set => _estructura.cRestriccionAgente = value;
        }
        
        public double Impuesto1 {
            get => _estructura.cImpuesto1;
            set => _estructura.cImpuesto1 = value;
        }
        
        public double Impuesto2 {
            get => _estructura.cImpuesto2;
            set => _estructura.cImpuesto2 = value;
        }
        
        public double Impuesto3 {
            get => _estructura.cImpuesto3;
            set => _estructura.cImpuesto3 = value;
        }
        
        public double RetencionCliente1 {
            get => _estructura.cRetencionCliente1;
            set => _estructura.cRetencionCliente1 = value;
        }
        
        public double RetencionCliente2 {
            get => _estructura.cRetencionCliente2;
            set => _estructura.cRetencionCliente2 = value;
        }
        
        public string CodigoValorClasificacionProveedor1 {
            get => _estructura.cCodigoValorClasificacionProveedor1;
            set => _estructura.cCodigoValorClasificacionProveedor1 = value;
        }
        
        public string CodigoValorClasificacionProveedor2 {
            get => _estructura.cCodigoValorClasificacionProveedor2;
            set => _estructura.cCodigoValorClasificacionProveedor2 = value;
        }
        
        public string CodigoValorClasificacionProveedor3 {
            get => _estructura.cCodigoValorClasificacionProveedor3;
            set => _estructura.cCodigoValorClasificacionProveedor3 = value;
        }
        
        public string CodigoValorClasificacionProveedor4 {
            get => _estructura.cCodigoValorClasificacionProveedor4;
            set => _estructura.cCodigoValorClasificacionProveedor4 = value;
        }
        
        public string CodigoValorClasificacionProveedor5 {
            get => _estructura.cCodigoValorClasificacionProveedor5;
            set => _estructura.cCodigoValorClasificacionProveedor5 = value;
        }
        
        public string CodigoValorClasificacionProveedor6 {
            get => _estructura.cCodigoValorClasificacionProveedor6;
            set => _estructura.cCodigoValorClasificacionProveedor6 = value;
        }
        
        public double LimiteCreditoProveedor {
            get => _estructura.cLimiteCreditoProveedor;
            set => _estructura.cLimiteCreditoProveedor = value;
        }
        
        public int DiasCreditoProveedor {
            get => _estructura.cDiasCreditoProveedor;
            set => _estructura.cDiasCreditoProveedor = value;
        }
        
        public int TiempoEntrega {
            get => _estructura.cTiempoEntrega;
            set => _estructura.cTiempoEntrega = value;
        }
        
        public int DiasEmbarqueProveedor {
            get => _estructura.cDiasEmbarqueProveedor;
            set => _estructura.cDiasEmbarqueProveedor = value;
        }
        
        public double ImpuestoProveedor1 {
            get => _estructura.cImpuestoProveedor1;
            set => _estructura.cImpuestoProveedor1 = value;
        }
        
        public double ImpuestoProveedor2 {
            get => _estructura.cImpuestoProveedor2;
            set => _estructura.cImpuestoProveedor2 = value;
        }
        
        public double ImpuestoProveedor3 {
            get => _estructura.cImpuestoProveedor3;
            set => _estructura.cImpuestoProveedor3 = value;
        }
        
        public double RetencionProveedor1 {
            get => _estructura.cRetencionProveedor1;
            set => _estructura.cRetencionProveedor1 = value;
        }
        
        public double RetencionProveedor2 {
            get => _estructura.cRetencionProveedor2;
            set => _estructura.cRetencionProveedor2 = value;
        }
        
        public int BanInteresMoratorio {
            get => _estructura.cBanInteresMoratorio;
            set => _estructura.cBanInteresMoratorio = value;
        }
        
        public string TextoExtra1 {
            get => _estructura.cTextoExtra1;
            set => _estructura.cTextoExtra1 = value;
        }
        
        public string TextoExtra2 {
            get => _estructura.cTextoExtra2;
            set => _estructura.cTextoExtra2 = value;
        }
        
        public string TextoExtra3 {
            get => _estructura.cTextoExtra3;
            set => _estructura.cTextoExtra3 = value;
        }
        
        public string FechaExtra {
            get => _estructura.cFechaExtra;
            set => _estructura.cFechaExtra = value;
        }
        
        public double ImporteExtra1 {
            get => _estructura.cImporteExtra1;
            set => _estructura.cImporteExtra1 = value;
        }
        
        public double ImporteExtra12 {
            get => _estructura.cImporteExtra2;
            set => _estructura.cImporteExtra2 = value;
        }
        
        public double ImporteExtra3 {
            get => _estructura.cImporteExtra3;
            set => _estructura.cImporteExtra3 = value;
        }
        
        public double ImporteExtra4 {
            get => _estructura.cImporteExtra4;
            set => _estructura.cImporteExtra4 = value;
        }

        public int Status { get; set; }
        
        public ClienteProveedor() {
            _estructura = new tCteProv();
        }

        public ClienteProveedor(tCteProv clienteProveedorEstructura) {
            _estructura = clienteProveedorEstructura;
        }

        public int CompareTo(ClienteProveedor other) {
            int thisIntCodigoCliente = 0;
            int otherIntCodigoCliente = 0;
            string thisStringCodigoCliente = null;
            string otherStringCodigoCliente = null;

            if (!int.TryParse(this.CodigoCliente, out thisIntCodigoCliente)) {
                thisStringCodigoCliente = this.CodigoCliente;
            }
            if (!int.TryParse(other.CodigoCliente, out otherIntCodigoCliente)) {
                otherStringCodigoCliente = other.CodigoCliente;
            }

            if (thisStringCodigoCliente != null && otherStringCodigoCliente == null) {
                return 1;
            }

            if (thisStringCodigoCliente == null && otherStringCodigoCliente != null) {
                return -1;
            }

            if (thisStringCodigoCliente != null && otherStringCodigoCliente != null) {
                String.Compare(thisStringCodigoCliente, otherStringCodigoCliente);
            }

            if (thisIntCodigoCliente < otherIntCodigoCliente)
                return -1;
            if (thisIntCodigoCliente > otherIntCodigoCliente)
                return 1;
            return 0;
        }

        public override string ToString() {
            return RazonSocial;
        }
    }
}