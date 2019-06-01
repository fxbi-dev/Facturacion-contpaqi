using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using SDKCompac.Modelos;

namespace ConsoleApp1.GUI
{
    public partial class ListadoEmpresas : Form {
        private Empresa[] _empresas;
        public Empresa EmpresaSeleccionada { get; private set; }

        private ListadoEmpresas(Empresa[] empresas) {
            _empresas = empresas;
            InitializeComponent();
        }

        private void ListadoEmpresas_Shown(object sender, EventArgs e) {
            foreach (Empresa empresa in _empresas) {
                dgv_empresas.Rows.Add(empresa.ID.ToString(), empresa.Nombre);
            }
        }


        private void dgv_empresas_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            EmpresaSeleccionada = _empresas[e.RowIndex];
            DialogResult = DialogResult.OK;
            Close();
        }


        private void ListadoEmpresas_FormClosing(object sender, FormClosingEventArgs e) {
            if (DialogResult != DialogResult.OK) {
                DialogResult = DialogResult.Cancel;
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static Empresa SeleccionarEmpresa(Empresa[] empresas) {
            ListadoEmpresas le = new ListadoEmpresas(empresas);
            if (le.ShowDialog() == DialogResult.OK) {
                return le.EmpresaSeleccionada;
            } else {
                return null;
            }
        }
    }
}
