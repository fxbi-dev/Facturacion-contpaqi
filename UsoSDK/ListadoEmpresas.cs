using System;
using System.Windows.Forms;
using SDKCompac;
using SDKCompac.Modelos;

namespace UsoSDK {

    public partial class ListadoEmpresas : Form
    {
        //private readonly Comercial _sdk = SDKContainer.Sdk;
        private Empresa[] _empresas;
        public Empresa EmpresaSeleccionada { get; private set; }

        public ListadoEmpresas() {
            InitializeComponent();
            EmpresaSeleccionada = null;
        }

        public ListadoEmpresas(Empresa[] empresas) {
            InitializeComponent();
            _empresas = empresas;
            EmpresaSeleccionada = null;
        }

        private void ListadoEmpresas_Load(object sender, EventArgs e) {
            lb_status.Text = "Cargando Empresas";
        }

        private void ListadoEmpresas_Shown(object sender, EventArgs e) {
            if (_empresas == null) {
                _empresas = SDKContainer.Sdk.obtenerEmpresas();
            }

            foreach (Empresa empresa in _empresas) {
                dgv_empresas.Rows.Add(empresa.ID.ToString(), empresa.Nombre);
                lb_status.Text = "Seleccione una empresa para abrirla";
            }
        }

        private void dgv_empresas_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            EmpresaSeleccionada = _empresas[e.RowIndex];
            try {
                SDKContainer.Sdk.abrirEmpresa(EmpresaSeleccionada);
                DialogResult = DialogResult.OK;
            } catch (SDKCompacException ex) {
                MessageBox.Show(ex.Message, "Error al abrir empresa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EmpresaSeleccionada = null;
            }
        }

        private void ListadoEmpresas_FormClosing(object sender, FormClosingEventArgs e) {
            if (DialogResult != DialogResult.OK)
                DialogResult = DialogResult.Cancel;
        }
    }
}
