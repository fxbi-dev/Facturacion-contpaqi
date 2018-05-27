using System;
using System.Runtime.InteropServices;

namespace SDKCompac.Nativos.Estructuras {
    // declaracion de la estructura de cliente Provedor
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct tCteProv
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongCodigo)]
        public String cCodigoCliente;//[ kLongCodigo + 1 ];
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongNombre)]
        public String cRazonSocial;//[ kLongNombre + 1 ];
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongFecha)]
        public String cFechaAlta;//[ kLongFecha + 1 ];
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongRFC)]
        public String cRFC;//[ kLongRFC + 1 ];
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongCURP)]
        public String cCURP;//[ kLongCURP + 1 ];
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongDenComercial)]
        public String cDenComercial;//[ kLongDenComercial + 1 ];
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongRepLegal)]
        public String cRepLegal;//[ kLongRepLegal + 1 ];
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongNombre)]
        public String cNombreMoneda;//[ kLongNombre + 1 ];
        public int cListaPreciosCliente;
        public double cDescuentoMovto;
        public int cBanVentaCredito; // 0 = No se permite venta a crédito, 1 = Se permite venta a crédito
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongCodValorClasif)]
        public String cCodigoValorClasificacionCliente1;//[ kLongCodValorClasif + 1 ];
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongCodValorClasif)]
        public String cCodigoValorClasificacionCliente2;//[ kLongCodValorClasif + 1 ];
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongCodValorClasif)]
        public String cCodigoValorClasificacionCliente3;//[ kLongCodValorClasif + 1 ];
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongCodValorClasif)]
        public String cCodigoValorClasificacionCliente4;//[ kLongCodValorClasif + 1 ];
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongCodValorClasif)]
        public String cCodigoValorClasificacionCliente5;//[ kLongCodValorClasif + 1 ];
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongCodValorClasif)]
        public String cCodigoValorClasificacionCliente6;//[ kLongCodValorClasif + 1 ];
        public int cTipoCliente; // 1 - Cliente, 2 - Cliente/Proveedor, 3 - Proveedor
        public int cEstatus; // 0. Inactivo, 1. Activo
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongFecha)]
        public String cFechaBaja;//[ kLongFecha + 1 ];
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongFecha)]
        public String cFechaUltimaRevision;//[ kLongFecha + 1 ];
        public double cLimiteCreditoCliente;
        public int cDiasCreditoCliente;
        public int cBanExcederCredito; // 0 = No se permite exceder crédito, 1 = Se permite exceder el crédito
        public double cDescuentoProntoPago;
        public int cDiasProntoPago;
        public double cInteresMoratorio;
        public int cDiaPago;
        public int cDiasRevision;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongDesCorta)]
        public String cMensajeria;//[ kLongDesCorta + 1 ];
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongDescripcion)]
        public String cCuentaMensajeria;//[ kLongDescripcion + 1 ];
        public int cDiasEmbarqueCliente;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongCodigo)]
        public String cCodigoAlmacen;//[ kLongCodigo + 1 ];
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongCodigo)]
        public String cCodigoAgenteVenta;//[ kLongCodigo + 1 ];
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongCodigo)]
        public String cCodigoAgenteCobro;//[ kLongCodigo + 1 ];
        public int cRestriccionAgente;
        public double cImpuesto1;
        public double cImpuesto2;
        public double cImpuesto3;
        public double cRetencionCliente1;
        public double cRetencionCliente2;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongCodValorClasif)]
        public String cCodigoValorClasificacionProveedor1;//[ kLongCodValorClasif + 1 ];
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongCodValorClasif)]
        public String cCodigoValorClasificacionProveedor2;//[ kLongCodValorClasif + 1 ];
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongCodValorClasif)]
        public String cCodigoValorClasificacionProveedor3;//[ kLongCodValorClasif + 1 ];
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongCodValorClasif)]
        public String cCodigoValorClasificacionProveedor4;//[ kLongCodValorClasif + 1 ];
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongCodValorClasif)]
        public String cCodigoValorClasificacionProveedor5;//[ kLongCodValorClasif + 1 ];
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongCodValorClasif)]
        public String cCodigoValorClasificacionProveedor6;//[ kLongCodValorClasif + 1 ];
        public double cLimiteCreditoProveedor;
        public int cDiasCreditoProveedor;
        public int cTiempoEntrega;
        public int cDiasEmbarqueProveedor;
        public double cImpuestoProveedor1;
        public double cImpuestoProveedor2;
        public double cImpuestoProveedor3;
        public double cRetencionProveedor1;
        public double cRetencionProveedor2;
        public int cBanInteresMoratorio; // 0 = No se le calculan intereses moratorios al cliente, 1 = Si se le calculan intereses moratorios al cliente.
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongTextoExtra)]
        public String cTextoExtra1;//[ kLongTextoExtra + 1 ];
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongTextoExtra)]
        public String cTextoExtra2;//[ kLongTextoExtra + 1 ];
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongTextoExtra)]
        public String cTextoExtra3;//[ kLongTextoExtra + 1 ];
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constantes.kLongTextoExtra)]
        public String cFechaExtra;//[ kLongFecha + 1 ];
        public double cImporteExtra1;
        public double cImporteExtra2;
        public double cImporteExtra3;
        public double cImporteExtra4;
    }
}