using System;
using System.Runtime.InteropServices;

namespace SDKCompac.Nativos.Estructuras {
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct tDocumento
    {
        public Double aFolio;
        public int aNumMoneda;
        public Double aTipoCambio;
        public Double aImporte;
        public Double aDescuentoDoc1;
        public Double aDescuentoDoc2;
        public int aSistemaOrigen;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongCodigo)]
        public String aCodConcepto;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongSerie)]
        public String aSerie;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongFecha)]
        public String aFecha;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongCodigo)]
        public String aCodigoCteProv;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongCodigo)]
        public String aCodigoAgente;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongReferencia)]
        public String aReferencia;
        public int aAfecta;
        public int aGasto1;
        public int aGasto2;
        public int aGasto3;
    }
}