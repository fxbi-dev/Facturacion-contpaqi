using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UsoSDK
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main() {
            SDKContainer.init();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new Form1().Show();
            try {
                SDKContainer.Sdk.iniciarSesion();
            } catch {
                Application.Exit();
            }
            //Application.Run(new ListadoEmpresas());
            new ListadoEmpresas().Show();
        }
    }
}
