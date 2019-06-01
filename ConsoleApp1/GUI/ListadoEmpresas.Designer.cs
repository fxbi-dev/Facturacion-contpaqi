namespace ConsoleApp1.GUI
{
    partial class ListadoEmpresas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lb_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgv_empresas = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_empresas)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lb_status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lb_status
            // 
            this.lb_status.Name = "lb_status";
            this.lb_status.Size = new System.Drawing.Size(134, 17);
            this.lb_status.Text = "Seleccione una empresa";
            // 
            // dgv_empresas
            // 
            this.dgv_empresas.AllowUserToAddRows = false;
            this.dgv_empresas.AllowUserToDeleteRows = false;
            this.dgv_empresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_empresas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.NombreEmpresa});
            this.dgv_empresas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_empresas.Location = new System.Drawing.Point(0, 0);
            this.dgv_empresas.Name = "dgv_empresas";
            this.dgv_empresas.ReadOnly = true;
            this.dgv_empresas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_empresas.Size = new System.Drawing.Size(800, 428);
            this.dgv_empresas.TabIndex = 1;
            this.dgv_empresas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_empresas_CellDoubleClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID Empresa";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // NombreEmpresa
            // 
            this.NombreEmpresa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NombreEmpresa.HeaderText = "Nombre";
            this.NombreEmpresa.Name = "NombreEmpresa";
            this.NombreEmpresa.ReadOnly = true;
            // 
            // ListadoEmpresas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgv_empresas);
            this.Controls.Add(this.statusStrip1);
            this.Name = "ListadoEmpresas";
            this.Text = "ListadoEmpresas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ListadoEmpresas_FormClosing);
            this.Shown += new System.EventHandler(this.ListadoEmpresas_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_empresas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lb_status;
        private System.Windows.Forms.DataGridView dgv_empresas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreEmpresa;
    }
}