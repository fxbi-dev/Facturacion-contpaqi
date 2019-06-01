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

namespace UsoSDK
{
    public partial class ListadoClientes : Form {
        private Comercial _sdk = SDKContainer.Sdk;
        private Empresa _empresa = null;
        private ClienteProveedor[] _clientes = null;

        public ListadoClientes(Empresa empresa) {
            InitializeComponent();
            _empresa = empresa;
        }

        public ListadoClientes(Empresa empresa, ClienteProveedor[] clientes) {
            InitializeComponent();
            _empresa = empresa;
            _clientes = clientes;
        }

        private void ListadoClientes_Load(object sender, EventArgs e) {
            this.Text = "Listado de Clientes - " + _empresa.Nombre;
        }

        private void ListadoClientes_Shown(object sender, EventArgs e) {
            if (_clientes == null) {
                _clientes = ClienteProveedor.ObtenerTodos(
                    ClienteProveedor.Campos.CodigoCliente,
                    ClienteProveedor.Campos.RazonSocial,
                    ClienteProveedor.Campos.CodigoValorClasificacionCliente1
                );
            }

            foreach (ClienteProveedor cliente in _clientes) {
                dgv_clientes.Rows.Add(cliente.CodigoCliente, cliente.RazonSocial,
                    cliente.CodigoValorClasificacionCliente1);
            }

            lb_status.Text = "Seleccione un cliente";
        }
    }
}
