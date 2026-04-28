namespace Proyecto_final
{
    partial class FrmGestionarUsuarios_22MS
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
            this.dgvUsuarios_22MS = new System.Windows.Forms.DataGridView();
            this.chkActivos_22MS = new System.Windows.Forms.CheckBox();
            this.chkTodos_22MS = new System.Windows.Forms.CheckBox();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtRol = new System.Windows.Forms.TextBox();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.btnCrear = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnDesbloquear = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnActDesact = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios_22MS)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUsuarios_22MS
            // 
            this.dgvUsuarios_22MS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios_22MS.Location = new System.Drawing.Point(25, 250);
            this.dgvUsuarios_22MS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvUsuarios_22MS.Name = "dgvUsuarios_22MS";
            this.dgvUsuarios_22MS.RowHeadersWidth = 51;
            this.dgvUsuarios_22MS.RowTemplate.Height = 24;
            this.dgvUsuarios_22MS.Size = new System.Drawing.Size(883, 202);
            this.dgvUsuarios_22MS.TabIndex = 0;
            this.dgvUsuarios_22MS.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvUsuarios_22MS_RowPrePaint);
            this.dgvUsuarios_22MS.SelectionChanged += new System.EventHandler(this.dgvUsuarios662JS_SelectionChanged);
            // 
            // chkActivos_22MS
            // 
            this.chkActivos_22MS.AutoSize = true;
            this.chkActivos_22MS.Location = new System.Drawing.Point(22, 28);
            this.chkActivos_22MS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkActivos_22MS.Name = "chkActivos_22MS";
            this.chkActivos_22MS.Size = new System.Drawing.Size(61, 17);
            this.chkActivos_22MS.TabIndex = 1;
            this.chkActivos_22MS.Text = "Activos";
            this.chkActivos_22MS.UseVisualStyleBackColor = true;
            // 
            // chkTodos_22MS
            // 
            this.chkTodos_22MS.AutoSize = true;
            this.chkTodos_22MS.Location = new System.Drawing.Point(22, 62);
            this.chkTodos_22MS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkTodos_22MS.Name = "chkTodos_22MS";
            this.chkTodos_22MS.Size = new System.Drawing.Size(56, 17);
            this.chkTodos_22MS.TabIndex = 2;
            this.chkTodos_22MS.Text = "Todos";
            this.chkTodos_22MS.UseVisualStyleBackColor = true;
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(254, 28);
            this.txtDNI.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(156, 20);
            this.txtDNI.TabIndex = 3;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(254, 50);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(156, 20);
            this.txtApellido.TabIndex = 4;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(254, 73);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(156, 20);
            this.txtNombre.TabIndex = 5;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(254, 96);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(156, 20);
            this.txtEmail.TabIndex = 6;
            // 
            // txtRol
            // 
            this.txtRol.Location = new System.Drawing.Point(254, 119);
            this.txtRol.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtRol.Name = "txtRol";
            this.txtRol.Size = new System.Drawing.Size(156, 20);
            this.txtRol.TabIndex = 7;
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(254, 141);
            this.txtLogin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(156, 20);
            this.txtLogin.TabIndex = 8;
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(22, 95);
            this.btnAplicar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(116, 41);
            this.btnAplicar.TabIndex = 9;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Location = new System.Drawing.Point(22, 141);
            this.lblMensaje.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(47, 13);
            this.lblMensaje.TabIndex = 10;
            this.lblMensaje.Text = "Mensaje";
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(443, 10);
            this.btnCrear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(138, 34);
            this.btnCrear.TabIndex = 11;
            this.btnCrear.Text = "Cear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(443, 49);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(138, 34);
            this.btnModificar.TabIndex = 12;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnDesbloquear
            // 
            this.btnDesbloquear.Location = new System.Drawing.Point(443, 88);
            this.btnDesbloquear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDesbloquear.Name = "btnDesbloquear";
            this.btnDesbloquear.Size = new System.Drawing.Size(138, 34);
            this.btnDesbloquear.TabIndex = 13;
            this.btnDesbloquear.Text = "Desbloquear";
            this.btnDesbloquear.UseVisualStyleBackColor = true;
            this.btnDesbloquear.Click += new System.EventHandler(this.btnDesbloquear_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(443, 166);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(138, 34);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnActDesact
            // 
            this.btnActDesact.Location = new System.Drawing.Point(443, 127);
            this.btnActDesact.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnActDesact.Name = "btnActDesact";
            this.btnActDesact.Size = new System.Drawing.Size(138, 34);
            this.btnActDesact.TabIndex = 15;
            this.btnActDesact.Text = "Act/Desact";
            this.btnActDesact.UseVisualStyleBackColor = true;
            this.btnActDesact.Click += new System.EventHandler(this.btnActDesact_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(443, 205);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(138, 34);
            this.btnSalir.TabIndex = 16;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(199, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "DNI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Apellido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(199, 78);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(199, 101);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(199, 124);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Rol";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(199, 146);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Username";
            // 
            // FrmGestionarUsuarios_22MS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 532);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnActDesact);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnDesbloquear);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.txtRol);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtDNI);
            this.Controls.Add(this.chkTodos_22MS);
            this.Controls.Add(this.chkActivos_22MS);
            this.Controls.Add(this.dgvUsuarios_22MS);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmGestionarUsuarios_22MS";
            this.Text = "FrmGestionarUsuarios_22MS";
            this.Load += new System.EventHandler(this.FrmAdministrador_22MS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios_22MS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsuarios_22MS;
        private System.Windows.Forms.CheckBox chkActivos_22MS;
        private System.Windows.Forms.CheckBox chkTodos_22MS;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtRol;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnDesbloquear;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnActDesact;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}