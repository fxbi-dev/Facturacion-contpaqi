using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SDKCompac;

namespace UsoSDKConsola
{
    class Program
    {

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public static Comercial Sdk = new Comercial();

        static void Main(string[] args) {
            IntPtr console = GetConsoleWindow();
            ShowWindow(console, 0);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Inicio inicio = new Inicio();
            inicio.Show();
            try {
                try {
                    Sdk.iniciarSesion();
                } catch {
                    Environment.Exit(0);
                }
                
                inicio.Close();
                Application.Run(new ListadoEmpresas());
            }
            catch (Exception ex) {
                ShowWindow(console, 5);
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
            Sdk.cerrarEmpresa();
            Sdk.cerrarSesion();
        }
    }
}
