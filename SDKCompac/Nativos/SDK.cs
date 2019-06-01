﻿using System;
using System.Runtime.InteropServices;
using System.Text;
using SDKCompac.Nativos.Estructuras;

namespace SDKCompac.Nativos
{
    public class SDK
    {
        // Declaración de las funciones

        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        public static extern int RegOpenKeyEx(
          UIntPtr hKey,
          string subKey,
          int ulOptions,
          int samDesired,
          out UIntPtr hkResult);


        [DllImport("advapi32")]
        public static extern int RegCloseKey(UIntPtr hKey);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegQueryValueExW", SetLastError = true)]
        public static extern int RegQueryValueEx(
            UIntPtr hKey,
            string lpValueName,
            int lpReserved,
            out uint lpType,
            StringBuilder lpData,
            ref uint lpcbData);

        [DllImport("KERNEL32")]
        public static extern int SetCurrentDirectory(string pPtrDirActual);

        [DllImport("MGWServicios.dll")]
        public static extern int fInicializaSDK();

        [DllImport("MGWServicios.dll")]
        public static extern void fTerminaSDK();

        [DllImport("MGWServicios.dll")]
        public static extern int fSetNombrePAQ(String aNombrePAQ);//CONTPAQ I COMERCIAL, AdminPAQ, 

        [DllImport("MGWServicios.dll")]
        public static extern int fAbreEmpresa(string Directorio);

        [DllImport("MGWServicios.dll")]
        public static extern void fCierraEmpresa();

        [DllImport("MGWServicios.dll")]
        public static extern void fError(int NumeroError, StringBuilder Mensaje, int Longitud);

        [DllImport("MGWServicios.dll")]
        public static extern int fAltaProducto(ref int aIdProducto, ref tProduto astProducto);

        [DllImport("MGWServicios.dll")]
        public static extern int fBuscaProducto(String aCodProducto);

        [DllImport("MGWServicios.dll")]
        public static extern int fEditaProducto();

        [DllImport("MGWServicios.dll")]
        public static extern int fSetDatoProducto(String aCampo, String aValor);

        [DllImport("MGWServicios.dll")]
        public static extern int fGuardaProducto();

        [DllImport("MGWServicios.dll")]
        public static extern int fEliminarProducto(String aCodProducto);

        [DllImport("MGWServicios.dll")]
        public static extern int fLeeDatoProducto(string aCampo, StringBuilder aValr, int aLen);

        [DllImport("MGWServicios.dll")]
        public static extern int fPosPrimerProducto();

        [DllImport("MGWServicios.dll")]
        public static extern int fPosSiguienteProducto();


        [DllImport("MGWServicios.dll")]
        public static extern Int32 fAltaDocumento(ref Int32 aIdDocumento, ref tDocumento atDocumento);

        [DllImport("MGWServicios.dll")]
        public static extern void fBorraDocumento();

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fAltaDocumentoCargoAbono(ref tDocumento atDocumento);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fSaldarDocumento_Param(string aCodConcepto_Pagar, string aSerie_Pagar, double aFolio_Pagar, string aCodConcepto_Pago, string aSerie_Pago, double aFolio_Pago, double aImporte, int aIdMoneda, string aFecha);

        [DllImport("MGWServicios.dll")]
        public static extern int fLeeDatoDocumento(string aCampo, StringBuilder aValor, int aLen);

        [DllImport("MGWServicios.dll")]
        public static extern int fLeeDatoCFDI(StringBuilder aValor, int aDato);

        [DllImport("MGWServicios.dll")]
        public static extern int fObtieneDatosCFDI(StringBuilder atPtrPassword);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fSetDatoDocumento(string aCampo, string aValor);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fEditarDocumento();

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fGuardaDocumento();

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fAltaMovimiento(Int32 aIdDocumento, ref Int32 aIdMovimiento, ref tMovimiento atMovimiento);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fAfectaDocto(ref tDocumento atDocumento, bool aAfectarDocumento);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fAfectaDocto_Param([MarshalAs(UnmanagedType.LPStr)] string aCodConcepto, [MarshalAs(UnmanagedType.LPStr)] string aSerie, double aFolio, bool aAfecta);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fSiguienteFolio([MarshalAs(UnmanagedType.LPStr)] string aCodigoConcepto, [MarshalAs(UnmanagedType.LPStr)] StringBuilder aSerie, ref double aFolio);

        [DllImport("MGWServicios.dll")]
        public static extern int fInicializaLicenseInfo(byte aSistema); //0 = AdminPAQ, 1 = CONTPAQ i FACTURA ELECTRÓNICA

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fEmitirDocumento([MarshalAs(UnmanagedType.LPStr)] string aCodConcepto, [MarshalAs(UnmanagedType.LPStr)] string aSerie, double aFolio, [MarshalAs(UnmanagedType.LPStr)] string aPassword, [MarshalAs(UnmanagedType.LPStr)] string aArchivoAdicional);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fEntregEnDiscoXML([MarshalAs(UnmanagedType.LPStr)] string aCodConcepto, [MarshalAs(UnmanagedType.LPStr)] string aSerie, double aFolio, int aFormato, string aFormatoAmigable);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fTimbraXML(string aRutaXML, string aCodConcepto, StringBuilder aUUID, string aRutaDDA, string aRutaResultado, string aPass, string aRutaFormato);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fPosPrimerDocumento();

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fPosUltimoDocumento();

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fPosSiguienteDocumento();

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fPosAnteriorDocumento();

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fBuscarDocumento(string aCodConcepto, string aSerie, string aFolio);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fPosPrimerEmpresa(ref int aIdEmpresa, StringBuilder aNombreEmpresa, StringBuilder aDirectorioEmpresa);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fPosSiguienteEmpresa(ref int aIdEmpresa, StringBuilder aNombreEmpresa, StringBuilder aDirectorioEmpresa);

        //funciones de alto nivel para Cliente Provedor

        [DllImport("MGWServicios.dll")]
        public static extern int fAltaCteProv(ref int aIdCliente, ref tCteProv astCliente);

        //funciones de bajo nivel para Cliente Provedor

        [DllImport("MGWServicios.dll")]
        public static extern int fBuscaCteProv(String aCodCteProv);

        [DllImport("MGWServicios.dll")]
        public static extern int fBuscaIdCteProv(int aIdCteProv);

        [DllImport("MGWServicios.dll")]
        public static extern int fEditaCteProv();

        [DllImport("MGWServicios.dll")]
        public static extern int fSetDatoCteProv(String aCampo, String aValor);

        [DllImport("MGWServicios.dll")]
        public static extern int fLeeDatoCteProv(string aCampo, StringBuilder aValor, int aLen);

        [DllImport("MGWServicios.dll")]
        public static extern int fLlenaRegistroCteProv(ref tCteProv astCtePro, int aEsAlta);

        [DllImport("MGWServicios.dll")]
        public static extern int fGuardaCteProv();

        [DllImport("MGWServicios.dll")]
        public static extern int fBorraCteProv(String aCodCteProv);

        [DllImport("MGWServicios.dll")]
        public static extern int fActualizaCteProv(string aCodigoCteProv, ref tCteProv astCtePro);

        [DllImport("MGWServicios.dll")]
        public static extern int fInformacionCliente(string aCodigo, ref int aPermiteCredito,
                                                      ref double aLimiteCredito, ref int aLimiteDoctosVencidos,
                                                      ref int aPermiteExcederCredito, string aFecha,
                                                      ref double aSaldo, ref double aSaldoPendiente,
                                                      ref int aDoctosVencidos);
        [DllImport("MGWServicios.dll")]
        public static extern int fPosPrimerCteProv();
        [DllImport("MGWServicios.dll")]
        public static extern int fPosUltimoCteProv();
        [DllImport("MGWServicios.dll")]
        public static extern int fPosSiguienteCteProv();
        [DllImport("MGWServicios.dll")]
        public static extern int fPosAnteriorCteProv();


        [DllImport("MGWServicios.dll")]
        public static extern Int32 fAltaDireccion(ref int lIdDireccion, ref tDireccion ltDireccion);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fActualizaDireccion(ref tDireccion ltDireccion);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fLlenaRegistroDireccion(ref tDireccion ltdDireccion, int aEsAlta);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fAltaMovimientoSeriesCapas(int aIdMovimiento, ref tSeriesCapas lSeries);


        [DllImport("MGWServicios.dll")]
        public static extern Int32 fAltaMovimientoSeriesCapas_Param(string aIdMovimiento, string aUnidades, string aTipoCambio, string aSeries,
                    string aPedimento, string aAgencia, string aFechaPedimento, string aNumeroLote, string aFechaFabricacion, string aFechaCaducidad);
        
        [DllImport("MGWServicios.dll")]
        public static extern Int32 fCalculaMovtoSerieCapa(Int32 lIdMovimiento);

        [DllImport("MGWServicios.dll")]
        public static extern int fSetDatoMovimiento(string aCampo, string aValor);

        [DllImport("MGWServicios.dll")]
        public static extern int fEditarMovimiento();

        [DllImport("MGWServicios.dll")]
        public static extern int fGuardaMovimiento();

        [DllImport("MGWServicios.dll")]
        public static extern int fSetFiltroMovimiento(Int32 aIdDocumento);

        [DllImport("MGWServicios.dll")]
        public static extern int fCancelaFiltroDocumento();

        [DllImport("MGWServicios.dll")]
        public static extern int fPosPrimerMovimiento();

        [DllImport("MGWServicios.dll")]
        public static extern int fPosUltimoMovimiento();

        [DllImport("MGWServicios.dll")]
        public static extern int fPosSiguienteMovimiento();

        [DllImport("MGWServicios.dll")]
        public static extern int fPosAnteriorMovimiento();

        [DllImport("MGWServicios.dll")]
        public static extern int fLeeDatoMovimiento(string aCampo, StringBuilder aValr, int aLen);

        [DllImport("MGWServicios.dll")]
        public static extern int fPosPrimerValorClasif();

        [DllImport("MGWServicios.dll")]
        public static extern int fPosUltimoValorClasif();

        [DllImport("MGWServicios.dll")]
        public static extern int fPosSiguienteValorClasif();

        [DllImport("MGWServicios.dll")]
        public static extern int fPosAnteriorValorClasif();
        
        [DllImport("MGWServicios.dll")]
        public static extern int fLeeDatoValorClasif(string aCampo, StringBuilder aValr, int aLen);

        


        public static string getError(int lResult) {
            StringBuilder mensaje = new StringBuilder(255);
            string sRetorno = null;
            fError(lResult, mensaje, 255);
            if (mensaje.Length > 0) {
                sRetorno = mensaje.ToString();
            }
            return sRetorno;
        }
    }//Fin clase
}//Fin namespace
