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
            string[] clientes = sdk.obtenerClientesProveedores();
            foreach (string cliente in clientes) {
                Console.WriteLine(cliente);
            }
            Console.WriteLine("Cerrando Empresa");
            sdk.cerrarEmpresa();
            Console.WriteLine("Cerrando Sesión");
            sdk.cerrarSesion();
            Console.ReadKey();
        }
    }
}