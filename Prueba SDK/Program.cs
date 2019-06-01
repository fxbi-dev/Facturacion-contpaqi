using System;
using SDKCompac;
using SDKCompac.Modelos;

namespace Prueba_SKD {
    internal class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Hola Mundo");
            Comercial sdk = new Comercial();
            Console.WriteLine("Iniciando Sesión");
            sdk.iniciarSesion();
            Empresa[] empresas = sdk.obtenerEmpresas();
            foreach (Empresa empresa in empresas) {
                Console.WriteLine(empresa);
            }
            Console.WriteLine("Abriendo Empresa " + empresas[2]);
            sdk.abrirEmpresa(empresas[2]);
            Console.WriteLine("Obteniendo Clientes/Proveedores");
            ClienteProveedor[] clientes = ClienteProveedor.ObtenerTodos(
                ClienteProveedor.Campos.RazonSocial,
                ClienteProveedor.Campos.CodigoCliente,
                ClienteProveedor.Campos.CodigoValorClasificacionCliente1
            );
            foreach (ClienteProveedor cliente in clientes) {
                Console.WriteLine(cliente.CodigoCliente + ", " + cliente.RazonSocial);
            }
            Console.WriteLine("Obteniendo RFC de " + clientes[1]);
            clientes[1] = ClienteProveedor.Obtener(clientes[1].CodigoCliente,
                ClienteProveedor.Campos.RazonSocial,
                ClienteProveedor.Campos.CodigoCliente,
                ClienteProveedor.Campos.RFC,
                ClienteProveedor.Campos.CodigoValorClasificacionCliente1
            );
            Console.WriteLine("RFC = " + clientes[1].RFC);
            //Console.WriteLine("Clasificación 1 = " + clientes[1].CodigoValorClasificacionProveedor1);
            Console.WriteLine("Obteniendo Clasificación 1 de 3 clientes");
            Console.WriteLine(clientes[2] + "Clasificacion 1 = " + clientes[2].CodigoValorClasificacionCliente1);
            Console.WriteLine(clientes[3] + "Clasificacion 1 = " + clientes[3].CodigoValorClasificacionCliente1);
            Console.WriteLine(clientes[4] + "Clasificacion 1 = " + clientes[4].CodigoValorClasificacionCliente1);
            //--------------------------

            //Console.Clear();
            Console.WriteLine("Listando Productos");
            Producto[] productos = Producto.ObtenerTodos(
                Producto.Campos.CodigoProducto,
                Producto.Campos.NombreProducto
            );
            foreach (Producto producto in productos) {
                Console.WriteLine(producto);
            }

            Console.WriteLine("Obteniendo Tipo de Producto del producto 1");
            productos[1].ObtenerCampo(Producto.Campos.TipoProducto);
            Console.WriteLine("Tipo de Producto: " + productos[1].TipoProducto);
            Console.WriteLine("Obteniendo el Producto 005");
            Producto producto2 = Producto.Obtener("005", 
                Producto.Campos.CodigoProducto,
                Producto.Campos.NombreProducto
            );
            Console.WriteLine("Nombre del Producto: " + producto2.NombreProducto);
            Console.WriteLine("Creando Documento");
            Documento documento = Documento.Crear("42018", "", clientes[2].CodigoCliente);
            Console.WriteLine("Guardando Documento");
            documento.Guardar();
            Console.WriteLine("Creando Movimiento");
            Movimiento movimiento = Movimiento.Crear(documento.ID, producto2.CodigoProducto);
            movimiento.CodAlmacen = "1";
            movimiento.Unidades = 1;
            movimiento.Precio = 10;
            movimiento.Costo = 0;
            Console.WriteLine("Guardando documento");
            movimiento.Guardar();
            Console.WriteLine("Cerrando Empresa");
            sdk.cerrarEmpresa();
            Console.WriteLine("Cerrando Sesión");
            sdk.cerrarSesion();
            Console.WriteLine("Sesión cerrada, Presione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}