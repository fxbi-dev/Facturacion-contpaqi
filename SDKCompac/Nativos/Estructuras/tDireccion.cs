using System.Runtime.InteropServices;

namespace SDKCompac.Nativos.Estructuras {
   // definicion de la estructura de direcciones
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct tDireccion
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongCodigo)]
        public string cCodCteProv;
        public int cTipoCatalogo; // 1=Clientes y 2=Proveedores
        public int cTipoDireccion; // 1=Domicilio Fiscal, 2=Domicilio Envio
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongDescripcion)]
        public string cNombreCalle;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongNumeroExpandido)]
        public string cNumeroExterior;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongNumeroExpandido)]
        public string cNumeroInterior;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongDescripcion)]
        public string cColonia;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongCodigoPostal)]
        public string cCodigoPostal;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongTelefono)]
        public string cTelefono1;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongTelefono)]
        public string cTelefono2;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongTelefono)]
        public string cTelefono3;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongTelefono)]
        public string cTelefono4;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongEmailWeb)]
        public string cEmail;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongEmailWeb)]
        public string cDireccionWeb;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongDescripcion)]
        public string cCiudad;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongDescripcion)]
        public string cEstado;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongDescripcion)]
        public string cPais;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongDescripcion)]
        public string cTextoExtra;
    }
}