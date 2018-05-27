using System;
using System.Runtime.InteropServices;

namespace SDKCompac.Nativos.Estructuras {
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct tMovimiento
    {
        public int aConsecutivo;
        public Double aUnidades;
        public Double aPrecio;
        public Double aCosto;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongCodigo)]
        public String aCodProdSer;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongCodigo)]
        public String aCodAlmacen;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongReferencia)]
        public String aReferencia;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongCodigo)]
        public String aCodClasificacion;
    }
}