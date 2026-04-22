namespace Proyecto_final
{
    partial class FrmInicioSesion662JS
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
            this.txtUsuario662JS = new System.Windows.Forms.TextBox();
            this.txtContraseña662JS = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnIniciarSesion662JS = new System.Windows.Forms.Button();
            this.btnCrearUsuario = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUsuario662JS
            // 
            this.txtUsuario662JS.Location = new System.Drawing.Point(322, 129);
            this.txtUsuario662JS.Multiline = true;
            this.txtUsuario662JS.Name = "txtUsuario662JS";
            this.txtUsuario662JS.Size = new System.Drawing.Size(264, 44);
            this.txtUsuario662JS.TabIndex = 0;
            // 
            // txtContraseña662JS
            // 
            this.txtContraseña662JS.Location = new System.Drawing.Point(322, 199);
            this.txtContraseña662JS.Multiline = true;
            this.txtContraseña662JS.Name = "txtContraseña662JS";
            this.txtContraseña662JS.Size = new System.Drawing.Size(264, 44);
            this.txtContraseña662JS.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(96, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre de usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(96, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contraseña";
            // 
            // btnIniciarSesion662JS
            // 
            this.btnIniciarSesion662JS.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarSesion662JS.Location = new System.Drawing.Point(322, 280);
            this.btnIniciarSesion662JS.Name = "btnIniciarSesion662JS";
            this.btnIniciarSesion662JS.Size = new System.Drawing.Size(264, 41);
            this.btnIniciarSesion662JS.TabIndex = 4;
            this.btnIniciarSesion662JS.Text = "Iniciar sesion";
            this.btnIniciarSesion662JS.UseVisualStyleBackColor = true;
            this.btnIniciarSesion662JS.Click += new System.EventHandler(this.btnIniciarSesion662JS_Click);
            // 
            // btnCrearUsuario
            // 
            this.btnCrearUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearUsuario.Location = new System.Drawing.Point(322, 338);
            this.btnCrearUsuario.Name = "btnCrearUsuario";
            this.btnCrearUsuario.Size = new System.Drawing.Size(264, 41);
            this.btnCrearUsuario.TabIndex = 5;
            this.btnCrearUsuario.Text = "Crear usuario";
            this.btnCrearUsuario.UseVisualStyleBackColor = true;
            this.btnCrearUsuario.Click += new System.EventHandler(this.btnCrearUsuario_Click);
            // 
            // FrmInicioSesion662JS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCrearUsuario);
            this.Controls.Add(this.btnIniciarSesion662JS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtContraseña662JS);
            this.Controls.Add(this.txtUsuario662JS);
            this.Name = "FrmInicioSesion662JS";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmInicioSesion662JS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsuario662JS;
        private System.Windows.Forms.TextBox txtContraseña662JS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnIniciarSesion662JS;
        private System.Windows.Forms.Button btnCrearUsuario;
    }
}

