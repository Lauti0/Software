namespace Proyecto_final
{
    partial class FrmBitacoraEventos_22MS
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
            this.dataGridViewEventos_22MS = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbLogin_22MS = new System.Windows.Forms.ComboBox();
            this.cmbModulo_22MS = new System.Windows.Forms.ComboBox();
            this.cmbEvento_22MS = new System.Windows.Forms.ComboBox();
            this.cmbCriticidad_22MS = new System.Windows.Forms.ComboBox();
            this.dateTimePickerFechaIni_22MS = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFechaFin_22MS = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNombre_22MS = new System.Windows.Forms.TextBox();
            this.txtApellido_22MS = new System.Windows.Forms.TextBox();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnSalir_22MS = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEventos_22MS)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewEventos_22MS
            // 
            this.dataGridViewEventos_22MS.AllowUserToAddRows = false;
            this.dataGridViewEventos_22MS.AllowUserToDeleteRows = false;
            this.dataGridViewEventos_22MS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEventos_22MS.Location = new System.Drawing.Point(23, 223);
            this.dataGridViewEventos_22MS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewEventos_22MS.Name = "dataGridViewEventos_22MS";
            this.dataGridViewEventos_22MS.ReadOnly = true;
            this.dataGridViewEventos_22MS.RowHeadersWidth = 51;
            this.dataGridViewEventos_22MS.RowTemplate.Height = 24;
            this.dataGridViewEventos_22MS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEventos_22MS.Size = new System.Drawing.Size(616, 152);
            this.dataGridViewEventos_22MS.TabIndex = 0;
            this.dataGridViewEventos_22MS.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEventos_22MS_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Tag = "LBL_LOGIN";
            this.label1.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Tag = "LBL_MODULO";
            this.label2.Text = "Modulo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 3;
            this.label3.Tag = "LBL_FECHA_INICIO";
            this.label3.Text = "Fecha ini";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 49);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 4;
            this.label4.Tag = "LBL_EVENTO";
            this.label4.Text = "Evento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(438, 11);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 5;
            this.label5.Tag = "LBL_FECHA_FIN";
            this.label5.Text = "Fecha fin";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(438, 46);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 6;
            this.label6.Tag = "LBL_CRITICIDAD";
            this.label6.Text = "Criticidad";
            // 
            // cmbLogin_22MS
            // 
            this.cmbLogin_22MS.FormattingEnabled = true;
            this.cmbLogin_22MS.Location = new System.Drawing.Point(80, 11);
            this.cmbLogin_22MS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbLogin_22MS.Name = "cmbLogin_22MS";
            this.cmbLogin_22MS.Size = new System.Drawing.Size(134, 21);
            this.cmbLogin_22MS.TabIndex = 7;
            // 
            // cmbModulo_22MS
            // 
            this.cmbModulo_22MS.FormattingEnabled = true;
            this.cmbModulo_22MS.Location = new System.Drawing.Point(80, 46);
            this.cmbModulo_22MS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbModulo_22MS.Name = "cmbModulo_22MS";
            this.cmbModulo_22MS.Size = new System.Drawing.Size(134, 21);
            this.cmbModulo_22MS.TabIndex = 8;
            // 
            // cmbEvento_22MS
            // 
            this.cmbEvento_22MS.FormattingEnabled = true;
            this.cmbEvento_22MS.Location = new System.Drawing.Point(272, 46);
            this.cmbEvento_22MS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbEvento_22MS.Name = "cmbEvento_22MS";
            this.cmbEvento_22MS.Size = new System.Drawing.Size(151, 21);
            this.cmbEvento_22MS.TabIndex = 9;
            // 
            // cmbCriticidad_22MS
            // 
            this.cmbCriticidad_22MS.FormattingEnabled = true;
            this.cmbCriticidad_22MS.Location = new System.Drawing.Point(490, 43);
            this.cmbCriticidad_22MS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbCriticidad_22MS.Name = "cmbCriticidad_22MS";
            this.cmbCriticidad_22MS.Size = new System.Drawing.Size(151, 21);
            this.cmbCriticidad_22MS.TabIndex = 10;
            // 
            // dateTimePickerFechaIni_22MS
            // 
            this.dateTimePickerFechaIni_22MS.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFechaIni_22MS.Location = new System.Drawing.Point(272, 11);
            this.dateTimePickerFechaIni_22MS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePickerFechaIni_22MS.Name = "dateTimePickerFechaIni_22MS";
            this.dateTimePickerFechaIni_22MS.Size = new System.Drawing.Size(151, 20);
            this.dateTimePickerFechaIni_22MS.TabIndex = 11;
            // 
            // dateTimePickerFechaFin_22MS
            // 
            this.dateTimePickerFechaFin_22MS.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFechaFin_22MS.Location = new System.Drawing.Point(490, 10);
            this.dateTimePickerFechaFin_22MS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePickerFechaFin_22MS.Name = "dateTimePickerFechaFin_22MS";
            this.dateTimePickerFechaFin_22MS.Size = new System.Drawing.Size(151, 20);
            this.dateTimePickerFechaFin_22MS.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 103);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 13;
            this.label7.Tag = "LBL_NOMBRE";
            this.label7.Text = "Nombre";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(259, 103);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 14;
            this.label8.Tag = "LBL_APELLIDO";
            this.label8.Text = "Apellido";
            // 
            // txtNombre_22MS
            // 
            this.txtNombre_22MS.Location = new System.Drawing.Point(80, 103);
            this.txtNombre_22MS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNombre_22MS.Name = "txtNombre_22MS";
            this.txtNombre_22MS.ReadOnly = true;
            this.txtNombre_22MS.Size = new System.Drawing.Size(134, 20);
            this.txtNombre_22MS.TabIndex = 15;
            // 
            // txtApellido_22MS
            // 
            this.txtApellido_22MS.Location = new System.Drawing.Point(314, 101);
            this.txtApellido_22MS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtApellido_22MS.Name = "txtApellido_22MS";
            this.txtApellido_22MS.ReadOnly = true;
            this.txtApellido_22MS.Size = new System.Drawing.Size(134, 20);
            this.txtApellido_22MS.TabIndex = 16;
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(490, 88);
            this.btnAplicar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(118, 28);
            this.btnAplicar.TabIndex = 17;
            this.btnAplicar.Tag = "BTN_APLICAR";
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(261, 168);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(118, 28);
            this.btnLimpiar.TabIndex = 18;
            this.btnLimpiar.Tag = "BTN_LIMPIAR";
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(80, 168);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(118, 28);
            this.btnImprimir.TabIndex = 19;
            this.btnImprimir.Tag = "BTN_IMPRIMIR";
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnSalir_22MS
            // 
            this.btnSalir_22MS.Location = new System.Drawing.Point(453, 168);
            this.btnSalir_22MS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSalir_22MS.Name = "btnSalir_22MS";
            this.btnSalir_22MS.Size = new System.Drawing.Size(118, 28);
            this.btnSalir_22MS.TabIndex = 20;
            this.btnSalir_22MS.Tag = "BTN_SALIR";
            this.btnSalir_22MS.Text = "Salir";
            this.btnSalir_22MS.UseVisualStyleBackColor = true;
            this.btnSalir_22MS.Click += new System.EventHandler(this.btnSalir_22MS_Click);
            // 
            // FrmBitacoraEventos_22MS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 421);
            this.Controls.Add(this.btnSalir_22MS);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.txtApellido_22MS);
            this.Controls.Add(this.txtNombre_22MS);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateTimePickerFechaFin_22MS);
            this.Controls.Add(this.dateTimePickerFechaIni_22MS);
            this.Controls.Add(this.cmbCriticidad_22MS);
            this.Controls.Add(this.cmbEvento_22MS);
            this.Controls.Add(this.cmbModulo_22MS);
            this.Controls.Add(this.cmbLogin_22MS);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewEventos_22MS);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmBitacoraEventos_22MS";
            this.Tag = "FORM_BITACORA";
            this.Text = "FrmBitacoraEventos_22MS";
            this.Load += new System.EventHandler(this.FrmBitacoraEventos_22MS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEventos_22MS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewEventos_22MS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbLogin_22MS;
        private System.Windows.Forms.ComboBox cmbModulo_22MS;
        private System.Windows.Forms.ComboBox cmbEvento_22MS;
        private System.Windows.Forms.ComboBox cmbCriticidad_22MS;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaIni_22MS;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaFin_22MS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNombre_22MS;
        private System.Windows.Forms.TextBox txtApellido_22MS;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnSalir_22MS;
    }
}