using System.Runtime.InteropServices;

namespace SDKCompac.Nativos.Estructuras {
    // Declaración de la estructura del producto
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct tProduto
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongCodigo)]
        public string cCodigoProducto;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongNombre)]
        public string cNombreProducto;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongNombreProducto)]
        public string cDescripcionProducto;
        public int cTipoProducto; // 1 = Producto, 2 = Paquete, 3 = Servicio
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongFecha)]
        public string cFechaAltaProducto;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongFecha)]
        public string cFechaBaja;
        public int cStatusProducto; // 0 - Baja Lógica, 1 - Alta
        public int cControlExistencia;
        public int cMetodoCosteo; // 1 = Costo Promedio en Base a Entradas, 2 = Costo Promedio en Base a Entradas Almacen, 3 = Último costo, 4 = UEPS, 5 = PEPS, 6 = Costo específico, 7 = Costo Estandar
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongCodigo)]
        public string cCodigoUnidadBase;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongCodigo)]
        public string cCodigoUnidadNoConvertible;
        public double cPrecio1;
        public double cPrecio2;
        public double cPrecio3;
        public double cPrecio4;
        public double cPrecio5;
        public double cPrecio6;
        public double cPrecio7;
        public double cPrecio8;
        public double cPrecio9;
        public double cPrecio10;
        public double cImpuesto1;
        public double cImpuesto2;
        public double cImpuesto3;
        public double cRetencion1;
        public double cRetencion2;
        // N.D.8386 La estructura debe recibir el nombre de la característica padre. (ALRH)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongNombre)]
        public string cNombreCaracteristica1;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongNombre)]
        public string cNombreCaracteristica2;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongNombre)]
        public string cNombreCaracteristica3;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongCodValorClasif)]
        public string cCodigoValorClasificacion1;//[ kLongCodValorClasif + 1 ];
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongCodValorClasif)]
        public string cCodigoValorClasificacion2;//[ kLongCodValorClasif + 1 ];
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongCodValorClasif)]
        public string cCodigoValorClasificacion3;//[ kLongCodValorClasif + 1 ];
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongCodValorClasif)]
        public string cCodigoValorClasificacion4;//[ kLongCodValorClasif + 1 ];
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongCodValorClasif)]
        public string cCodigoValorClasificacion5;//[ kLongCodValorClasif + 1 ];
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongCodValorClasif)]
        public string cCodigoValorClasificacion6;//[ kLongCodValorClasif + 1 ];
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongTextoExtra)]
        public string cTextoExtra1;//[ kLongTextoExtra + 1 ];
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongTextoExtra)]
        public string cTextoExtra2;//[ kLongTextoExtra + 1 ];
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongTextoExtra)]
        public string cTextoExtra3;//[ kLongTextoExtra + 1 ];
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongFecha)]
        public string cFechaExtra;//[ kLongFecha + 1 ];
        public double cImporteExtra1;
        public double cImporteExtra2;
        public double cImporteExtra3;
        public double cImporteExtra4;
    }
}