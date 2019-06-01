using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SDKCompac.Modelos;

namespace UsoSDKConsola
{
    public partial class ListadoEmpresas : Form {
        private Empresa[] _empresas;
        public ListadoEmpresas() {
            InitializeComponent();
        }

        private void ListadoEmpresas_Shown(object sender, EventArgs e) {
            _empresas = Program.Sdk.obtenerEmpresas();
            foreach (Empresa empresa in _empresas) {
                dgv_empresas.Rows.Add(empresa.ID.ToString(), empresa.Nombre);
            }
        }

        private void dgv_empresas_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            this.Hide();
            Program.Sdk.abrirEmpresa(_empresas[e.RowIndex]);
            new ListadoClientes(_empresas[e.RowIndex].Nombre).ShowDialog();
            this.Close();
        }

        private void dgv_empresas_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                e.Handled = true;
                //MessageBox.Show(_empresas[dgv_empresas.SelectedRows[0].Index].ToString());
                this.Hide();
                Program.Sdk.abrirEmpresa(_empresas[dgv_empresas.SelectedRows[0].Index]);
                new ListadoClientes(_empresas[dgv_empresas.SelectedRows[0].Index].Nombre).ShowDialog();
                this.Close();
            }
        }
    }
}
