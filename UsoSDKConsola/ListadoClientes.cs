using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SDKCompac.Modelos;

namespace UsoSDKConsola
{
    public partial class ListadoClientes : Form {

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private ClienteProveedor[] _clientes;
        private ClasificacionesValores[] _clasificaciones;
        private List<ClienteProveedor> _clientesSeleccionados;
        private int cantSeleccionados = 0;
        private bool actualizando = false;

        public ListadoClientes(string titulo) {
            _clientesSeleccionados = new List<ClienteProveedor>();
            InitializeComponent();
            this.Text = "Listado de Clientes - " + titulo;
        }

        private void ListadoClientes_Shown(object sender, EventArgs e) {
            //this.Text = "Obteniendo Clientes";
            filtrosToolStripMenuItem.DropDown.Closing += (sender2, ev) => {
                //MessageBox.Show("DropDown Cerrando");
                if (ev.CloseReason == ToolStripDropDownCloseReason.ItemClicked && !((ToolStripMenuItem)filtrosToolStripMenuItem.DropDownItems[0]).Checked) {
                    ev.Cancel = true;
                } else {
                    ((ToolStripMenuItem) filtrosToolStripMenuItem.DropDownItems[0]).Checked = false;
                    aplicarFiltros();
                }
            };
            actualizar();
            //this.Text = "Listado de Clientes";
        }

        private void aplicarFiltros() {
            actualizando = true;
            Console.WriteLine("Aplicando Filtros");
            List<string> seleccionados = new List<string>();
            cantSeleccionados = 0;
            foreach (ToolStripMenuItem dropDownItem in filtrosToolStripMenuItem.DropDownItems) {
                Console.WriteLine(dropDownItem.Text + ": " + dropDownItem.Checked);
                if (dropDownItem.Checked) {
                    seleccionados.Add(dropDownItem.Text);
                }
            }

            cantSeleccionados = 0;
            if (seleccionados.Count > 0) {
                foreach (DataGridViewRow row in dgv_clientes.Rows) {
                    row.Visible = seleccionados.Contains(row.Cells[2].Value.ToString());
                    row.Cells[3].Value = row.Visible;
                    if (row.Visible) {
                        cantSeleccionados += 1;
                    }
                }
            } else {
                foreach (DataGridViewRow row in dgv_clientes.Rows) {
                    row.Visible = true;
                    row.Cells[3].Value = true;
                    if (row.Visible) {
                        cantSeleccionados += 1;
                    }
                }
            }
            Console.WriteLine("Filtros Aplicados");
            lb_CantSeleccionados.Text = "Seleccionados: " + cantSeleccionados + "/" + dgv_clientes.Rows.GetRowCount(DataGridViewElementStates.Visible);
            actualizando = false;
        }

        private void actualizar() {
            actualizando = true;
            cantSeleccionados = 0;
            bool todos = true;
            dgv_clientes.Rows.Clear();
            filtrosToolStripMenuItem.DropDownItems.Clear();

            Console.WriteLine("Obteniendo Clientes");
            _clientes = ClienteProveedor.ObtenerTodos(
                ClienteProveedor.Campos.CodigoCliente,
                ClienteProveedor.Campos.RazonSocial,
                ClienteProveedor.Campos.CodigoValorClasificacionCliente1,
                ClienteProveedor.Campos.TextoExtra1,
                ClienteProveedor.Campos.Estatus
            );
            Console.WriteLine("Obteniendo Clasificaciones");
            _clasificaciones = Program.Sdk.ObtenerClasificacionesValoreses();
            var _clasificacionesArr = new List<ClasificacionesValores>(_clasificaciones);
            _clasificacionesArr.RemoveAt(0);
            _clasificaciones = _clasificacionesArr.ToArray();
            List<ClienteProveedor> _clientesArr = new List<ClienteProveedor>(_clientes);

            foreach (ClienteProveedor cliente in _clientes)
            {
                string clasificacionStr = "";
                foreach (ClasificacionesValores clasificacion in _clasificaciones)
                {
                    if (cliente.CodigoValorClasificacionCliente1 == clasificacion.ID.ToString())
                    {
                        if (clasificacion.ValorClasificacion.Split('-').Length != 3) {
                            todos = false;
                            break;
                        }
                        clasificacionStr = clasificacion.ValorClasificacion.Split('-')[2];
                        break;
                    }
                }

                if (clasificacionStr != "" && cliente.Status == 1) {
                    dgv_clientes.Rows.Add(cliente.CodigoCliente, cliente.RazonSocial, clasificacionStr, true);
                    DataGridViewRow row = dgv_clientes.Rows[dgv_clientes.RowCount - 1];
                    row.Cells[0].ReadOnly = true;
                    row.Cells[1].ReadOnly = true;
                    row.Cells[2].ReadOnly = true;
                    cantSeleccionados++;
                } else {
                    _clientesArr.Remove(cliente);
                }
            }
            _clientes = _clientesArr.ToArray();
            lb_CantSeleccionados.Text = "Seleccionados: " + cantSeleccionados + "/" + dgv_clientes.Rows.GetRowCount(DataGridViewElementStates.Visible);

            filtrosToolStripMenuItem.DropDownItems.Clear();
            var bt_AplicarFiltros = new ToolStripMenuItem {
                Text = "Aplicar Filtros",
                CheckOnClick = true
            };
            bt_AplicarFiltros.Click += (sender, e) => {
                //MessageBox.Show("bt_AplicarFiltros Click, " + bt_AplicarFiltros.Checked);
                filtrosToolStripMenuItem.DropDown.Close();
            };
            filtrosToolStripMenuItem.DropDownItems.Add(bt_AplicarFiltros);

            foreach (ClasificacionesValores clasificacion in _clasificaciones)
            {
                Console.WriteLine(clasificacion);
                if (clasificacion.ValorClasificacion.Split('-').Length == 3) {
                    var menuItem = new ToolStripMenuItem {
                        Text = clasificacion.ValorClasificacion.Split('-')[2],
                        CheckOnClick = true
                    };
                    filtrosToolStripMenuItem.DropDownItems.Add(menuItem);
                }
            }

            if (!todos) {
                MessageBox.Show(
                    "No se muestran todos los clientes debido a que existen algunos que no tienen una clasificación asignada con la sintaxis correcta.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            actualizando = false;
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e) {
            var result = MessageBox.Show("¿Seguro que desea actualizar la lista de clientes?",
                "Actualizar listado",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes) {
                actualizar();
            }
        }

        private void seleccionarTodoToolStripMenuItem_Click(object sender, EventArgs e) {
            foreach (DataGridViewRow row in dgv_clientes.Rows) {
                if (row.Visible) {
                    row.Cells[3].Value = true;
                    Console.WriteLine(row.Cells[0].Value + " -> " + row.Cells[3].Value);
                }
            }
            Console.WriteLine("---------------------------");

        }

        private void dgv_clientes_CurrentCellDirtyStateChanged(object sender, EventArgs e) {
            dgv_clientes.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void button1_Click(object sender, EventArgs e) {
            if (MessageBox.Show(
                    @"¿Seguro que desea proceder con la creación de las facturas?

Sólo se crearán las facturas seleccionadas y que estén dentro de los filtros",
                    "Generar Facturas",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes) {
                _clientesSeleccionados.Clear();
                foreach (DataGridViewRow row in dgv_clientes.Rows) {
                    DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell) row.Cells[3];
                    if (row.Visible && cell.Value.ToString() == "True") {
                        _clientesSeleccionados.Add(_clientes[row.Index]);
                    }
                }

                var console = GetConsoleWindow();
                ShowWindow(console, 5);
                Console.Clear();
                Console.WriteLine("Por Favor, no cierre esta ventana mientras el proceso de creación de facturas está activo..");
                Console.WriteLine();
                Console.WriteLine("Progreso: ");
                Console.WriteLine("Agregando factura de: ");

                int count = 1;
                foreach (ClienteProveedor cp in _clientesSeleccionados) {
                    ClasificacionesValores cv = null;
                    foreach (ClasificacionesValores clasificacion in _clasificaciones) {
                        if (clasificacion.ID.ToString() == cp.CodigoValorClasificacionCliente1) {
                            cv = clasificacion;
                            break;
                        }
                    }

                    if (cv != null) {
                        string[] valores = cv.ValorClasificacion.Split('-');
                        string idProducto = valores[0];
                        double.TryParse(valores[1], out var precio);
                        Console.SetCursorPosition(0, 2);
                        Console.WriteLine("Progreso: (" + count + "/" + _clientesSeleccionados.Count + ")");
                        for (int i = 0; i < Console.WindowWidth; i++) {
                            Console.Write(" ");
                        }
                        Console.SetCursorPosition(0, 3);
                        Console.WriteLine("Agregando factura de: " + cp);
                        Documento doc = Documento.Crear("42018", "", cp.CodigoCliente);
                        doc.Guardar();
                        Movimiento movimiento = Movimiento.Crear(doc.ID, idProducto);
                        movimiento.CodAlmacen = "1";
                        movimiento.Unidades = 1;
                        movimiento.Precio = precio;
                        movimiento.Costo = 0;
                        movimiento.Observacion = cp.TextoExtra1;
                        movimiento.Guardar();
                        Console.WriteLine("Documento del cliente " + cp + " Creado");
                    }

                    count++;
                }
                ShowWindow(console, 0);
                MessageBox.Show("Facturas Agregadas con éxito", "Facturas Agregadas", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void dgv_clientes_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (!actualizando) {
                if (e.ColumnIndex == 3) {
                    if (((DataGridViewCheckBoxCell) dgv_clientes.Rows[e.RowIndex].Cells[3]).Value.ToString() ==
                        "True") {
                        cantSeleccionados++;
                    }
                    else {
                        cantSeleccionados--;
                    }
                }
                lb_CantSeleccionados.Text = "Seleccionados: " + cantSeleccionados + "/" + dgv_clientes.Rows.GetRowCount(DataGridViewElementStates.Visible);
            }
        }

        private void dgv_clientes_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.ColumnIndex == 3) {
                dgv_clientes.EndEdit();
            }
        }
    }
}
