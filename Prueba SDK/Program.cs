using System;
using SDKCompac;
using SDKCompac.Modelos;

namespace Prueba_SKD {
    internal class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Hola Mundo");
            SDK sdk = new Comercial();
            Console.WriteLine("Iniciando Sesión");
            sdk.iniciarSesion();
            Empresa[] empresas = sdk.obtenerEmpresas();
            foreach (Empresa empresa in empresas) {
                Console.WriteLine(empresa);
            }
            Console.WriteLine("Abriendo Empresa " + empresas[2]);
            sdk.abrirEmpresa(empresas[2].Directorio);
            Console.WriteLine("Obteniendo Clientes/Proveedores");
            ClienteProveedor[] clientes = sdk.obtenerClientesProveedores();
            foreach (ClienteProveedor cliente in clientes) {
                Console.WriteLine(cliente.CodigoCliente + ", " + cliente.RazonSocial);
            }
            Console.WriteLine("Obteniendo RFC de " + clientes[1]);
            clientes[1] = ClienteProveedor.Obtener(clientes[1].Indice, new string[] {
                ClienteProveedor.Campos.RazonSocial,
                ClienteProveedor.Campos.CodigoCliente,
                ClienteProveedor.Campos.RFC,
                ClienteProveedor.Campos.CodigoValorClasificacionCliente1
            });
            Console.WriteLine("RFC = " + clientes[1].RFC);
            //Console.WriteLine("Clasificación 1 = " + clientes[1].CodigoValorClasificacionProveedor1);
            Console.WriteLine("Obteniendo Clasificación 1 de 3 clientes");
            Console.WriteLine(clientes[2] + "Clasificacion 1 = " + clientes[2].CodigoValorClasificacionCliente1);
            Console.WriteLine(clientes[3] + "Clasificacion 1 = " + clientes[3].CodigoValorClasificacionCliente1);
            Console.WriteLine(clientes[4] + "Clasificacion 1 = " + clientes[4].CodigoValorClasificacionCliente1);
            Console.WriteLine("Cerrando Empresa");
            sdk.cerrarEmpresa();
            Console.WriteLine("Cerrando Sesión");
            sdk.cerrarSesion();
            Console.WriteLine("Sesión cerrada, Presione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}