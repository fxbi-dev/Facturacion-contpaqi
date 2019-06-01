using System;
using System.Collections.Generic;
using System.Text;
using SDKCompac.Nativos;
using SDKCompac.Nativos.Estructuras;

namespace SDKCompac.Modelos {
    public class Producto {
        // Datos coincidentes con la estructura
        public static class Campos
        {
            public const string CodigoProducto = "cCodigoProducto";
            public const string NombreProducto = "cNombreProducto";
            public const string DescripcionProducto = "cDescripcionProducto";
            public const string TipoProducto = "cTipoProducto";
            public const string FechaAltaProducto = "cFechaAltaProducto";
            public const string FechaBaja = "cFechaBaja";
            public const string StatusProducto = "cStatusProducto";
            public const string ControlExistencia = "cControlExistencia";
            public const string MetodoCosteo = "cMetodoCosteo";
            public const string CodigoUnidadBase = "cCodigoUnidadBase";
            public const string CodigoUnidadNoConvertible = "cCodigoUnidadNoConvertible";
            public const string Precio1 = "cPrecio1";
            public const string Precio2 = "cPrecio2";
            public const string Precio3 = "cPrecio3";
            public const string Precio4 = "cPrecio4";
            public const string Precio5 = "cPrecio5";
            public const string Precio6 = "cPrecio6";
            public const string Precio7 = "cPrecio7";
            public const string Precio8 = "cPrecio8";
            public const string Precio9 = "cPrecio9";
            public const string Precio10 = "cPrecio10";
            public const string Impuesto1 = "cImpuesto1";
            public const string Impuesto2 = "cImpuesto2";
            public const string Impuesto3 = "cImpuesto3";
            public const string Retencion1 = "cRetencion1";
            public const string Retencion2 = "cRetencion2";
            public const string NombreCaracteristica1 = "cNombreCaracteristica1";
            public const string NombreCaracteristica2 = "cNombreCaracteristica2";
            public const string NombreCaracteristica3 = "cNombreCaracteristica3";
            public const string CodigoValorClasificacion1 = "cCodigoValorClasificacion1";
            public const string CodigoValorClasificacion2 = "cCodigoValorClasificacion2";
            public const string CodigoValorClasificacion3 = "cCodigoValorClasificacion3";
            public const string CodigoValorClasificacion4 = "cCodigoValorClasificacion4";
            public const string CodigoValorClasificacion5 = "cCodigoValorClasificacion5";
            public const string CodigoValorClasificacion6 = "cCodigoValorClasificacion6";
            public const string TextoExtra1 = "cTextoExtra1";
            public const string TextoExtra2 = "cTextoExtra2";
            public const string TextoExtra3 = "cTextoExtra3";
            public const string FechaExtra = "cFechaExtra";
            public const string ImporteExtra1 = "cImporteExtra1";
            public const string ImporteExtra2 = "cImporteExtra2";
            public const string ImporteExtra3 = "cImporteExtra3";
            public const string ImporteExtra4 = "cImporteExtra4";
        }

        private tProduto _estructura = new tProduto();

        public override string ToString() {
            return CodigoProducto + ", " + NombreProducto;
        }

        public static Producto Obtener(string CodigoProducto, params string[] Campos) {
            Comercial.comprobarError(Nativos.SDK.fBuscaProducto(CodigoProducto));

            Producto producto = new Producto();

            foreach (string campo in Campos) {
                Producto.ObtenerCampo(ref producto, campo);
            }

            return producto;
        }

        public static Producto[] ObtenerTodos(params string[] Campos) {
            Comercial.comprobarError(Nativos.SDK.fPosPrimerProducto());

            List<Producto> productos = new List<Producto>();

            while (true) {
                Producto producto = new Producto();
                foreach (string campo in Campos) {
                    Producto.ObtenerCampo(ref producto, campo);
                }
                productos.Add(producto);
                if (Nativos.SDK.fPosSiguienteProducto() != 0) break;
            }

            return productos.ToArray();
        }

        public void ObtenerCampo(string campo) {
            Comercial.comprobarError(Nativos.SDK.fBuscaProducto(this.CodigoProducto));
            Producto _this = this;
            Producto.ObtenerCampo(ref _this, campo);
        }

        private static void ObtenerCampo(ref Producto producto, string campo)
        {
            StringBuilder stringBuilder;
            int intValue;
            double doubleValue;
            switch (campo)
            {
                case Producto.Campos.CodigoProducto:
                    stringBuilder = new StringBuilder(Constantes.kLongCodigo);
                    Comercial.comprobarError(Nativos.SDK.fLeeDatoProducto(campo, stringBuilder,
                        Constantes.kLongCodigo));
                    producto.CodigoProducto = stringBuilder.ToString();
                    break;

                case Producto.Campos.NombreProducto:
                    stringBuilder = new StringBuilder(Constantes.kLongNombre);
                    Comercial.comprobarError(Nativos.SDK.fLeeDatoProducto(campo, stringBuilder,
                        Constantes.kLongNombre));
                    producto.NombreProducto = stringBuilder.ToString();
                    break;

                case Producto.Campos.DescripcionProducto:
                    stringBuilder = new StringBuilder(Constantes.kLongNombreProducto);
                    Comercial.comprobarError(Nativos.SDK.fLeeDatoProducto(campo, stringBuilder,
                        Constantes.kLongNombreProducto));
                    producto.DescripcionProducto = stringBuilder.ToString();
                    break;

                case Producto.Campos.TipoProducto:
                    stringBuilder = new StringBuilder(Constantes.kIntGenerico); // 1 = Producto, 2 = Paquete, 3 = Servicio
                    Comercial.comprobarError(Nativos.SDK.fLeeDatoProducto(campo, stringBuilder, Constantes.kIntGenerico));
                    if (int.TryParse(stringBuilder.ToString(), out intValue))
                    {
                        producto.TipoProducto = intValue;
                    }
                    break;

                case Producto.Campos.FechaAltaProducto:
                    stringBuilder = new StringBuilder(Constantes.kLongFecha);
                    Comercial.comprobarError(Nativos.SDK.fLeeDatoProducto(campo, stringBuilder,
                        Constantes.kLongFecha));
                    producto.FechaAltaProducto = stringBuilder.ToString();
                    break;

                case Producto.Campos.FechaBaja:
                    stringBuilder = new StringBuilder(Constantes.kLongFecha);
                    Comercial.comprobarError(Nativos.SDK.fLeeDatoProducto(campo, stringBuilder,
                        Constantes.kLongFecha));
                    producto.FechaBaja = stringBuilder.ToString();
                    break;

                case Producto.Campos.StatusProducto:
                    stringBuilder = new StringBuilder(Constantes.kIntGenerico); // 0 - Baja Lógica, 1 - Alta
                    Comercial.comprobarError(Nativos.SDK.fLeeDatoProducto(campo, stringBuilder,
                        Constantes.kIntGenerico));
                    if (int.TryParse(stringBuilder.ToString(), out intValue))
                    {
                        producto.StatusProducto = intValue;
                    }
                    break;

                case Producto.Campos.ControlExistencia:
                    stringBuilder = new StringBuilder(Constantes.kIntGenerico); // 0 - Baja Lógica, 1 - Alta
                    Comercial.comprobarError(Nativos.SDK.fLeeDatoProducto(campo, stringBuilder,
                        Constantes.kIntGenerico));
                    if (int.TryParse(stringBuilder.ToString(), out intValue))
                    {
                        producto.ControlExistencia = intValue;
                    }
                    break;

                case Producto.Campos.MetodoCosteo:
                    stringBuilder = new StringBuilder(Constantes.kIntGenerico); // 1 = Costo Promedio en Base a Entradas, 2 = Costo Promedio en Base a Entradas Almacen, 3 = Último costo, 4 = UEPS, 5 = PEPS, 6 = Costo específico, 7 = Costo Estandar
                    Comercial.comprobarError(Nativos.SDK.fLeeDatoProducto(campo, stringBuilder,
                        Constantes.kIntGenerico));
                    if (int.TryParse(stringBuilder.ToString(), out intValue))
                    {
                        producto.MetodoCosteo = intValue;
                    }
                    break;

                case Producto.Campos.CodigoUnidadBase:
                    break;

                case Producto.Campos.CodigoUnidadNoConvertible:
                    break;

                case Producto.Campos.Precio1:
                    break;

                case Producto.Campos.Precio2:
                    break;

                case Producto.Campos.Precio3:
                    break;

                case Producto.Campos.Precio4:
                    break;

                case Producto.Campos.Precio5:
                    break;

                case Producto.Campos.Precio6:
                    break;

                case Producto.Campos.Precio7:
                    break;

                case Producto.Campos.Precio8:
                    break;

                case Producto.Campos.Precio9:
                    break;

                case Producto.Campos.Precio10:
                    break;

                case Producto.Campos.Impuesto1:
                    break;

                case Producto.Campos.Impuesto2:
                    break;

                case Producto.Campos.Impuesto3:
                    break;

                case Producto.Campos.Retencion1:
                    break;

                case Producto.Campos.Retencion2:
                    break;

                case Producto.Campos.NombreCaracteristica1:
                    break;

                case Producto.Campos.NombreCaracteristica2:
                    break;

                case Producto.Campos.NombreCaracteristica3:
                    break;

                case Producto.Campos.CodigoValorClasificacion1:
                    break;

                case Producto.Campos.CodigoValorClasificacion2:
                    break;

                case Producto.Campos.CodigoValorClasificacion3:
                    break;

                case Producto.Campos.CodigoValorClasificacion4:
                    break;

                case Producto.Campos.CodigoValorClasificacion5:
                    break;

                case Producto.Campos.CodigoValorClasificacion6:
                    break;

                case Producto.Campos.TextoExtra1:
                    break;

                case Producto.Campos.TextoExtra2:
                    break;

                case Producto.Campos.TextoExtra3:
                    break;

                case Producto.Campos.FechaExtra:
                    break;

                case Producto.Campos.ImporteExtra1:
                    break;

                case Producto.Campos.ImporteExtra2:
                    break;

                case Producto.Campos.ImporteExtra3:
                    break;

                case Producto.Campos.ImporteExtra4:
                    break;
            }
        }

        public string CodigoProducto {
            get => _estructura.cCodigoProducto;
            set => _estructura.cCodigoProducto = value;
        }

        public string NombreProducto {
            get => _estructura.cNombreProducto;
            set => _estructura.cNombreProducto = value;
        }

        public string DescripcionProducto {
            get => _estructura.cDescripcionProducto;
            set => _estructura.cDescripcionProducto = value;
        }

        public int TipoProducto {
            get => _estructura.cTipoProducto;
            set => _estructura.cTipoProducto = value;
        }

        public string FechaAltaProducto {
            get => _estructura.cFechaAltaProducto;
            set => _estructura.cFechaAltaProducto = value;
        }

        public string FechaBaja {
            get => _estructura.cFechaBaja;
            set => _estructura.cFechaBaja = value;
        }

        public int StatusProducto {
            get => _estructura.cStatusProducto;
            set => _estructura.cStatusProducto = value;
        }

        public int ControlExistencia {
            get => _estructura.cControlExistencia;
            set => _estructura.cControlExistencia = value;
        }

        public int MetodoCosteo {
            get => _estructura.cMetodoCosteo;
            set => _estructura.cMetodoCosteo = value;
        }

        public string CodigoUnidadBase {
            get => _estructura.cCodigoUnidadBase;
            set => _estructura.cCodigoUnidadBase = value;
        }

        public string CodigoUnidadNoConvertible {
            get => _estructura.cCodigoUnidadNoConvertible;
            set => _estructura.cCodigoUnidadNoConvertible = value;
        }

        public double Precio1 {
            get => _estructura.cPrecio1;
            set => _estructura.cPrecio1 = value;
        }

        public double Precio2 {
            get => _estructura.cPrecio2;
            set => _estructura.cPrecio2 = value;
        }

        public double Precio3 {
            get => _estructura.cPrecio3;
            set => _estructura.cPrecio3 = value;
        }

        public double Precio4 {
            get => _estructura.cPrecio1;
            set => _estructura.cPrecio4 = value;
        }

        public double Precio5 {
            get => _estructura.cPrecio5;
            set => _estructura.cPrecio5 = value;
        }

        public double Precio6 {
            get => _estructura.cPrecio6;
            set => _estructura.cPrecio6 = value;
        }

        public double Precio7 {
            get => _estructura.cPrecio7;
            set => _estructura.cPrecio7 = value;
        }

        public double Precio8 {
            get => _estructura.cPrecio8;
            set => _estructura.cPrecio8 = value;
        }

        public double Precio9 {
            get => _estructura.cPrecio9;
            set => _estructura.cPrecio9 = value;
        }

        public double Precio10 {
            get => _estructura.cPrecio10;
            set => _estructura.cPrecio10 = value;
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

        public double Retencion1 {
            get => _estructura.cRetencion1;
            set => _estructura.cRetencion1 = value;
        }

        public double Retencion2 {
            get => _estructura.cRetencion2;
            set => _estructura.cRetencion2 = value;
        }

        public string NombreCaracteristica1 {
            get => _estructura.cNombreCaracteristica1;
            set => _estructura.cNombreCaracteristica1 = value;
        }

        public string NombreCaracteristica2 {
            get => _estructura.cNombreCaracteristica2;
            set => _estructura.cNombreCaracteristica2 = value;
        }

        public string NombreCaracteristica3 {
            get => _estructura.cNombreCaracteristica3;
            set => _estructura.cNombreCaracteristica3 = value;
        }

        public string CodigoValorClasificacion1 {
            get => _estructura.cCodigoValorClasificacion1;
            set => _estructura.cCodigoValorClasificacion1 = value;
        }

        public string CodigoValorClasificacion2 {
            get => _estructura.cCodigoValorClasificacion2;
            set => _estructura.cCodigoValorClasificacion2 = value;
        }

        public string CodigoValorClasificacion3 {
            get => _estructura.cCodigoValorClasificacion3;
            set => _estructura.cCodigoValorClasificacion3 = value;
        }

        public string CodigoValorClasificacion4 {
            get => _estructura.cCodigoValorClasificacion4;
            set => _estructura.cCodigoValorClasificacion4 = value;
        }

        public string CodigoValorClasificacion5 {
            get => _estructura.cCodigoValorClasificacion5;
            set => _estructura.cCodigoValorClasificacion5 = value;
        }

        public string CodigoValorClasificacion6 {
            get => _estructura.cCodigoValorClasificacion6;
            set => _estructura.cCodigoValorClasificacion6 = value;
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

        public double ImporteExtra2 {
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
    }
}