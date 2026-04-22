namespace Proyecto_final
{
    partial class FrmAdministrador662JS
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
            this.dgvUsuarios662JS = new System.Windows.Forms.DataGridView();
            this.chkActivos662JS = new System.Windows.Forms.CheckBox();
            this.chkTodos662JS = new System.Windows.Forms.CheckBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios662JS)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUsuarios662JS
            // 
            this.dgvUsuarios662JS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios662JS.Location = new System.Drawing.Point(30, 224);
            this.dgvUsuarios662JS.Name = "dgvUsuarios662JS";
            this.dgvUsuarios662JS.RowHeadersWidth = 51;
            this.dgvUsuarios662JS.RowTemplate.Height = 24;
            this.dgvUsuarios662JS.Size = new System.Drawing.Size(804, 221);
            this.dgvUsuarios662JS.TabIndex = 0;
            this.dgvUsuarios662JS.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvUsuarios662JS_RowPrePaint);
            // 
            // chkActivos662JS
            // 
            this.chkActivos662JS.AutoSize = true;
            this.chkActivos662JS.Location = new System.Drawing.Point(30, 34);
            this.chkActivos662JS.Name = "chkActivos662JS";
            this.chkActivos662JS.Size = new System.Drawing.Size(73, 20);
            this.chkActivos662JS.TabIndex = 1;
            this.chkActivos662JS.Text = "Activos";
            this.chkActivos662JS.UseVisualStyleBackColor = true;
            // 
            // chkTodos662JS
            // 
            this.chkTodos662JS.AutoSize = true;
            this.chkTodos662JS.Location = new System.Drawing.Point(30, 76);
            this.chkTodos662JS.Name = "chkTodos662JS";
            this.chkTodos662JS.Size = new System.Drawing.Size(69, 20);
            this.chkTodos662JS.TabIndex = 2;
            this.chkTodos662JS.Text = "Todos";
            this.chkTodos662JS.UseVisualStyleBackColor = true;
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(339, 34);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(206, 22);
            this.txtDNI.TabIndex = 3;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(339, 62);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(206, 22);
            this.txtApellido.TabIndex = 4;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(339, 90);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(206, 22);
            this.txtNombre.TabIndex = 5;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(339, 118);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(206, 22);
            this.txtEmail.TabIndex = 6;
            // 
            // txtRol
            // 
            this.txtRol.Location = new System.Drawing.Point(339, 146);
            this.txtRol.Name = "txtRol";
            this.txtRol.Size = new System.Drawing.Size(206, 22);
            this.txtRol.TabIndex = 7;
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(339, 174);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(206, 22);
            this.txtLogin.TabIndex = 8;
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(30, 117);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(155, 51);
            this.btnAplicar.TabIndex = 9;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Location = new System.Drawing.Point(30, 174);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(59, 16);
            this.lblMensaje.TabIndex = 10;
            this.lblMensaje.Text = "Mensaje";
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(591, 12);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(184, 42);
            this.btnCrear.TabIndex = 11;
            this.btnCrear.Text = "Cear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(591, 60);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(184, 42);
            this.btnModificar.TabIndex = 12;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnDesbloquear
            // 
            this.btnDesbloquear.Location = new System.Drawing.Point(591, 108);
            this.btnDesbloquear.Name = "btnDesbloquear";
            this.btnDesbloquear.Size = new System.Drawing.Size(184, 42);
            this.btnDesbloquear.TabIndex = 13;
            this.btnDesbloquear.Text = "Desbloquear";
            this.btnDesbloquear.UseVisualStyleBackColor = true;
            this.btnDesbloquear.Click += new System.EventHandler(this.btnDesbloquear_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(591, 156);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(184, 42);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmAdministrador662JS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 457);
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
            this.Controls.Add(this.chkTodos662JS);
            this.Controls.Add(this.chkActivos662JS);
            this.Controls.Add(this.dgvUsuarios662JS);
            this.Name = "FrmAdministrador662JS";
            this.Text = "FrmAdministrador662JS";
            this.Load += new System.EventHandler(this.FrmAdministrador662JS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios662JS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsuarios662JS;
        private System.Windows.Forms.CheckBox chkActivos662JS;
        private System.Windows.Forms.CheckBox chkTodos662JS;
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
    }
}