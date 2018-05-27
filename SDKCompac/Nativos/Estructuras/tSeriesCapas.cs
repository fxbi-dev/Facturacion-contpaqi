using System.Runtime.InteropServices;

namespace SDKCompac.Nativos.Estructuras {
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct tSeriesCapas
    {
        public double aUnidades;
        public double aTipoCambio;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongCodigo)]
        public string aSeries;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongDescripcion)]
        public string aPedimento;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongDescripcion)]
        public string aAgencia;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongFecha)]
        public string aFechaPedimento;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongDescripcion)]
        public string aNumeroLote;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongFecha)]
        public string aFechaFabricacion;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongFecha)]
        public string aFechaCaducidad;

    }
}