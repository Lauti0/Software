namespace Proyecto_final
{
    partial class FrmInicioSesion_22MS
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtUsuario_22MS = new System.Windows.Forms.TextBox();
            this.txtContraseña_22MS = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnIniciarSesion_22MS = new System.Windows.Forms.Button();
            this.btnCrearUsuario = new System.Windows.Forms.Button();
            this.btnOcultarContraseña = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUsuario_22MS
            // 
            this.txtUsuario_22MS.Location = new System.Drawing.Point(242, 110);
            this.txtUsuario_22MS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUsuario_22MS.Name = "txtUsuario_22MS";
            this.txtUsuario_22MS.Size = new System.Drawing.Size(199, 20);
            this.txtUsuario_22MS.TabIndex = 0;
            // 
            // txtContraseña_22MS
            // 
            this.txtContraseña_22MS.Location = new System.Drawing.Point(242, 167);
            this.txtContraseña_22MS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtContraseña_22MS.Name = "txtContraseña_22MS";
            this.txtContraseña_22MS.Size = new System.Drawing.Size(199, 20);
            this.txtContraseña_22MS.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(72, 105);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre de usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(72, 162);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contraseña";
            // 
            // btnIniciarSesion_22MS
            // 
            this.btnIniciarSesion_22MS.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarSesion_22MS.Location = new System.Drawing.Point(242, 228);
            this.btnIniciarSesion_22MS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnIniciarSesion_22MS.Name = "btnIniciarSesion_22MS";
            this.btnIniciarSesion_22MS.Size = new System.Drawing.Size(198, 33);
            this.btnIniciarSesion_22MS.TabIndex = 4;
            this.btnIniciarSesion_22MS.Text = "Iniciar sesion";
            this.btnIniciarSesion_22MS.UseVisualStyleBackColor = true;
            this.btnIniciarSesion_22MS.Click += new System.EventHandler(this.btnIniciarSesion_22MS_Click);
            // 
            // btnCrearUsuario
            // 
            this.btnCrearUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearUsuario.Location = new System.Drawing.Point(242, 275);
            this.btnCrearUsuario.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCrearUsuario.Name = "btnCrearUsuario";
            this.btnCrearUsuario.Size = new System.Drawing.Size(198, 33);
            this.btnCrearUsuario.TabIndex = 5;
            this.btnCrearUsuario.Text = "Crear usuario";
            this.btnCrearUsuario.UseVisualStyleBackColor = true;
            // 
            // btnOcultarContraseña
            // 
            this.btnOcultarContraseña.Location = new System.Drawing.Point(466, 167);
            this.btnOcultarContraseña.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOcultarContraseña.Name = "btnOcultarContraseña";
            this.btnOcultarContraseña.Size = new System.Drawing.Size(44, 18);
            this.btnOcultarContraseña.TabIndex = 6;
            this.btnOcultarContraseña.Text = "button1";
            this.btnOcultarContraseña.UseVisualStyleBackColor = true;
            this.btnOcultarContraseña.Click += new System.EventHandler(this.btnOcultarContraseña_Click);
            // 
            // FrmInicioSesion_22MS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btnOcultarContraseña);
            this.Controls.Add(this.btnCrearUsuario);
            this.Controls.Add(this.btnIniciarSesion_22MS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtContraseña_22MS);
            this.Controls.Add(this.txtUsuario_22MS);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmInicioSesion_22MS";
            this.Text = "FrmInicioSesion_22MS";
            this.Load += new System.EventHandler(this.FrmInicioSesion_22MS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsuario_22MS;
        private System.Windows.Forms.TextBox txtContraseña_22MS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnIniciarSesion_22MS;
        private System.Windows.Forms.Button btnCrearUsuario;
        private System.Windows.Forms.Button btnOcultarContraseña;
    }
}

