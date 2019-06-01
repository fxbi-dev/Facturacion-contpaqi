using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleApp1.GUI;
using SDKCompac;
using SDKCompac.Modelos;

namespace ConsoleApp1
{
    class Program {
        //private static SDK _sdk;

        private static void controlarExcepcion(Exception ex) {
            //Console.WriteLine(ex.Message);
            //Console.WriteLine("Saliendo...");
            //_sdk.cerrarSesion();
            //Console.ReadKey();
            Environment.Exit(1);
        }

        private static void Main(string[] args) {
           
           SDK _sdk = new Comercial();
            Console.WriteLine("Iniciando Sesión");
            try {
                _sdk.iniciarSesion();
            } catch (SDKCompacException ex) {
                controlarExcepcion(ex);
            }
            Console.WriteLine("Sesión iniciada");
                    Console.WriteLine("Obteniendo Empresas");
            Empresa[] empresas = null;
            empresas = _sdk.obtenerEmpresas();
            try {
                empresas = _sdk.obtenerEmpresas();
                _sdk.cerrarSesion();
            }
            catch (SDKCompacException ex) {
                controlarExcepcion(ex);
            }
            Console.WriteLine("Empresas Obtenidas");
            Console.ReadKey();
            foreach (Empresa empresa1 in empresas) {
                Console.WriteLine(empresa1);
            }
            Console.ReadKey();
            Console.WriteLine("Abriendo interfaz de empresas");
            MessageBox.Show(empresas[0].ToString());
            Empresa empresa = ListadoEmpresas.SeleccionarEmpresa(empresas);
            if (empresa == null) {
                controlarExcepcion(new SDKCompacException("No se seleccionó ninguna empresa"));
            }
            Console.WriteLine("Empresa " + empresa.Nombre + " seleccionada");
            Console.WriteLine("Abriendo Empresa");
            //try {
            //    _sdk.abrirEmpresa(empresa);
            //} catch (SDKCompacException ex) {
            //    controlarExcepcion(ex);
            //}
            //Console.WriteLine("Empresa Abierta");
            //_sdk.cerrarEmpresa();
            //_sdk.cerrarSesion();
            Console.WriteLine("Todo cerrado");
            Console.ReadKey();
        }
    }
}
