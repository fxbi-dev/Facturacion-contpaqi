using System;
using System.Runtime.InteropServices;
using System.Text;
using SDKCompac.Nativos.Estructuras;

namespace SDKCompac.Nativos
{
    public class SdkAdminpaq
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

        [DllImport("MGW_SDK.DLL")]
        public static extern int fInicializaSDK();

        [DllImport("MGW_SDK.DLL")]
        public static extern void fTerminaSDK();

        [DllImport("MGW_SDK.DLL")]
        public static extern int fSetNombrePAQ(String aNombrePAQ);//CONTPAQ I COMERCIAL, AdminPAQ, 

        [DllImport("MGW_SDK.DLL")]
        public static extern int fAbreEmpresa(string Directorio);

        [DllImport("MGW_SDK.DLL")]
        public static extern void fCierraEmpresa();

        [DllImport("MGW_SDK.DLL")]
        public static extern void fError(int NumeroError, StringBuilder Mensaje, int Longitud);

        [DllImport("MGW_SDK.DLL")]
        public static extern int fAltaProducto(ref int aIdProducto, ref tProduto astProducto);

        [DllImport("MGW_SDK.DLL")]
        public static extern int fBuscaProducto(String aCodProducto);

        [DllImport("MGW_SDK.DLL")]
        public static extern int fEditaProducto();

        [DllImport("MGW_SDK.DLL")]
        public static extern int fSetDatoProducto(String aCampo, String aValor);

        [DllImport("MGW_SDK.DLL")]
        public static extern int fGuardaProducto();

        [DllImport("MGW_SDK.DLL")]
        public static extern int fEliminarProducto(String aCodProducto);

        [DllImport("MGW_SDK.DLL")]
        public static extern int fLeeDatoProducto(string aCampo, StringBuilder aValr, int aLen);

        [DllImport("MGW_SDK.DLL")]
        public static extern int fPosPrimerProducto();

        [DllImport("MGW_SDK.DLL")]
        public static extern int fPosSiguienteProducto();


        [DllImport("MGW_SDK.DLL")]
        public static extern Int32 fAltaDocumento(ref Int32 aIdDocumento, ref tDocumento atDocumento);

        [DllImport("MGW_SDK.DLL")]
        public static extern void fBorraDocumento();

        [DllImport("MGW_SDK.DLL")]
        public static extern Int32 fAltaDocumentoCargoAbono(ref tDocumento atDocumento);

        [DllImport("MGW_SDK.DLL")]
        public static extern Int32 fSaldarDocumento_Param(string aCodConcepto_Pagar, string aSerie_Pagar, double aFolio_Pagar, string aCodConcepto_Pago, string aSerie_Pago, double aFolio_Pago, double aImporte, int aIdMoneda, string aFecha);

        [DllImport("MGW_SDK.DLL")]
        public static extern int fLeeDatoDocumento(string aCampo, StringBuilder aValor, int aLen);

        [DllImport("MGW_SDK.DLL")]
        public static extern int fLeeDatoCFDI(StringBuilder aValor, int aDato);

        [DllImport("MGW_SDK.DLL")]
        public static extern int fObtieneDatosCFDI(StringBuilder atPtrPassword);

        [DllImport("MGW_SDK.DLL")]
        public static extern Int32 fSetDatoDocumento(string aCampo, string aValor);

        [DllImport("MGW_SDK.DLL")]
        public static extern Int32 fEditarDocumento();

        [DllImport("MGW_SDK.DLL")]
        public static extern Int32 fGuardaDocumento();

        [DllImport("MGW_SDK.DLL")]
        public static extern Int32 fAltaMovimiento(Int32 aIdDocumento, ref Int32 aIdMovimiento, ref tMovimiento atMovimiento);

        [DllImport("MGW_SDK.DLL")]
        public static extern Int32 fAfectaDocto(ref tDocumento atDocumento, bool aAfectarDocumento);

        [DllImport("MGW_SDK.DLL")]
        public static extern Int32 fAfectaDocto_Param([MarshalAs(UnmanagedType.LPStr)] string aCodConcepto, [MarshalAs(UnmanagedType.LPStr)] string aSerie, double aFolio, bool aAfecta);

        [DllImport("MGW_SDK.DLL")]
        public static extern Int32 fSiguienteFolio([MarshalAs(UnmanagedType.LPStr)] string aCodigoConcepto, [MarshalAs(UnmanagedType.LPStr)] StringBuilder aSerie, ref double aFolio);

        [DllImport("MGW_SDK.DLL")]
        public static extern int fInicializaLicenseInfo(byte aSistema); //0 = AdminPAQ, 1 = CONTPAQ i FACTURA ELECTRÓNICA

        [DllImport("MGW_SDK.DLL")]
        public static extern Int32 fEmitirDocumento([MarshalAs(UnmanagedType.LPStr)] string aCodConcepto, [MarshalAs(UnmanagedType.LPStr)] string aSerie, double aFolio, [MarshalAs(UnmanagedType.LPStr)] string aPassword, [MarshalAs(UnmanagedType.LPStr)] string aArchivoAdicional);

        [DllImport("MGW_SDK.DLL")]
        public static extern Int32 fEntregEnDiscoXML([MarshalAs(UnmanagedType.LPStr)] string aCodConcepto, [MarshalAs(UnmanagedType.LPStr)] string aSerie, double aFolio, int aFormato, string aFormatoAmigable);

        [DllImport("MGW_SDK.DLL")]
        public static extern Int32 fTimbraXML(string aRutaXML, string aCodConcepto, StringBuilder aUUID, string aRutaDDA, string aRutaResultado, string aPass, string aRutaFormato);

        [DllImport("MGW_SDK.DLL")]
        public static extern Int32 fBuscarDocumento(string aCodConcepto, string aSerie, string aFolio);

        [DllImport("MGW_SDK.DLL")]
        public static extern Int32 fPosPrimerEmpresa(ref int aIdEmpresa, ref StringBuilder aNombreEmpresa, ref StringBuilder aDirectorioEmpresa);

        [DllImport("MGW_SDK.DLL")]
        public static extern Int32 fPosSiguienteEmpresa(ref int aIdEmpresa, ref StringBuilder aNombreEmpresa, ref StringBuilder aDirectorioEmpresa);

        //funciones de alto nivel para Cliente Provedor

        [DllImport("MGW_SDK.DLL")]
        public static extern int fAltaCteProv(ref int aIdCliente, ref tCteProv astCliente);

        //funciones de bajo nivel para Cliente Provedor

        [DllImport("MGW_SDK.DLL")]
        public static extern int fBuscaCteProv(String aCodCteProv);

        [DllImport("MGW_SDK.DLL")]
        public static extern int fBuscaIdCteProv(int aIdCteProv);

        [DllImport("MGW_SDK.DLL")]
        public static extern int fEditaCteProv();

        [DllImport("MGW_SDK.DLL")]
        public static extern int fSetDatoCteProv(String aCampo, String aValor);

        [DllImport("MGW_SDK.DLL")]
        public static extern int fLeeDatoCteProv(string aCampo, StringBuilder aValor, int aLen);

        [DllImport("MGW_SDK.DLL")]
        public static extern int fLlenaRegistroCteProv(ref tCteProv astCtePro, int aEsAlta);

        [DllImport("MGW_SDK.DLL")]
        public static extern int fGuardaCteProv();

        [DllImport("MGW_SDK.DLL")]
        public static extern int fBorraCteProv(String aCodCteProv);

        [DllImport("MGW_SDK.DLL")]
        public static extern int fActualizaCteProv(string aCodigoCteProv, ref tCteProv astCtePro);

        [DllImport("MGW_SDK.DLL")]
        public static extern int fInformacionCliente(string aCodigo, ref int aPermiteCredito,
                                                      ref double aLimiteCredito, ref int aLimiteDoctosVencidos,
                                                      ref int aPermiteExcederCredito, string aFecha,
                                                      ref double aSaldo, ref double aSaldoPendiente,
                                                      ref int aDoctosVencidos);
        [DllImport("MGW_SDK.DLL")]
        public static extern int fPosPrimerCteProv();
        [DllImport("MGW_SDK.DLL")]
        public static extern int fPosUltimoCteProv();
        [DllImport("MGW_SDK.DLL")]
        public static extern int fPosSiguienteCteProv();
        [DllImport("MGW_SDK.DLL")]
        public static extern int fPosAnteriorCteProv();


        [DllImport("MGW_SDK.DLL")]
        public static extern Int32 fAltaDireccion(ref int lIdDireccion, ref tDireccion ltDireccion);

        [DllImport("MGW_SDK.DLL")]
        public static extern Int32 fActualizaDireccion(ref tDireccion ltDireccion);

        [DllImport("MGW_SDK.DLL")]
        public static extern Int32 fLlenaRegistroDireccion(ref tDireccion ltdDireccion, int aEsAlta);

        [DllImport("MGW_SDK.DLL")]
        public static extern Int32 fAltaMovimientoSeriesCapas(int aIdMovimiento, ref tSeriesCapas lSeries);


        [DllImport("MGW_SDK.DLL")]
        public static extern Int32 fAltaMovimientoSeriesCapas_Param(string aIdMovimiento, string aUnidades, string aTipoCambio, string aSeries,
                    string aPedimento, string aAgencia, string aFechaPedimento, string aNumeroLote, string aFechaFabricacion, string aFechaCaducidad);
        
        [DllImport("MGW_SDK.DLL")]
        public static extern Int32 fCalculaMovtoSerieCapa(Int32 lIdMovimiento);

        [DllImport("MGW_SDK.DLL")]
        public static extern int fSetDatoMovimiento(string aCampo, string aValor);

        [DllImport("MGW_SDK.DLL")]
        public static extern void fEditarMovimiento();

        [DllImport("MGW_SDK.DLL")]
        public static extern void fGuardaMovimiento();

        [DllImport("MGW_SDK.DLL")]
        public static extern int fSetFiltroMovimiento(Int32 aIdDocumento);

        [DllImport("MGW_SDK.DLL")]
        public static extern int fPosPrimerMovimiento();

        [DllImport("MGW_SDK.DLL")]
        public static extern int fLeeDatoMovimiento(string aCampo, StringBuilder aValr, int aLen);
        
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
