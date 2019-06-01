using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SDKCompac;
using SDKCompac.Modelos;

namespace UsoSDK {

    public partial class Form1 : Form
    {
        private readonly Comercial _sdk = SDKContainer.Sdk;

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e) {
            try {
                SDKContainer.Sdk.iniciarSesion();
                new ListadoEmpresas().Show();
                this.Close();
                Console.Write("asdasd");
                //this.Hide();
                //ListadoEmpresas le = new ListadoEmpresas();
                //if (le.ShowDialog(this) == DialogResult.OK) {
                //    Empresa empresa = le.EmpresaSeleccionada;
                //    //ClienteProveedor[] clientes = _sdk.obtenerClientesProveedores();
                //    ListadoClientes lc = new ListadoClientes(empresa);
                //    this.Close();
                //    //lc.ShowDialog();
                //    //_sdk.cerrarSesion();
                //    //Application.Exit();
                //} else {
                //    // Si no se selecciona una empresa
                //    _sdk.cerrarSesion();
                //    Application.Exit();
                //}
            } catch {
                Application.Exit();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            //_sdk.cerrarSesion();
        }
    }
}
