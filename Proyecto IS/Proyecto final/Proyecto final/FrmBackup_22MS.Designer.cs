namespace Proyecto_final
{
    partial class FrmBackup_22MS
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
            this.btnGenerarBackup = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRutaBackup = new System.Windows.Forms.TextBox();
            this.btnSeleccionarRuta = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGenerarBackup
            // 
            this.btnGenerarBackup.Location = new System.Drawing.Point(40, 240);
            this.btnGenerarBackup.Name = "btnGenerarBackup";
            this.btnGenerarBackup.Size = new System.Drawing.Size(157, 51);
            this.btnGenerarBackup.TabIndex = 3;
            this.btnGenerarBackup.Text = "Generar Backup";
            this.btnGenerarBackup.UseVisualStyleBackColor = true;
            this.btnGenerarBackup.Click += new System.EventHandler(this.btnGenerarBackup_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Seccion de Backups";
            // 
            // txtRutaBackup
            // 
            this.txtRutaBackup.Location = new System.Drawing.Point(40, 82);
            this.txtRutaBackup.Name = "txtRutaBackup";
            this.txtRutaBackup.Size = new System.Drawing.Size(157, 20);
            this.txtRutaBackup.TabIndex = 8;
            // 
            // btnSeleccionarRuta
            // 
            this.btnSeleccionarRuta.Location = new System.Drawing.Point(40, 108);
            this.btnSeleccionarRuta.Name = "btnSeleccionarRuta";
            this.btnSeleccionarRuta.Size = new System.Drawing.Size(157, 51);
            this.btnSeleccionarRuta.TabIndex = 9;
            this.btnSeleccionarRuta.Text = "Seleccionar Ruta";
            this.btnSeleccionarRuta.UseVisualStyleBackColor = true;
            this.btnSeleccionarRuta.Click += new System.EventHandler(this.btnSeleccionarRuta_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Seleccione una ruta para guardar el backup";
            // 
            // FrmBackup_22MS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 303);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSeleccionarRuta);
            this.Controls.Add(this.txtRutaBackup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGenerarBackup);
            this.Name = "FrmBackup_22MS";
            this.Text = "FrmBackup_22MS";
            this.Load += new System.EventHandler(this.FrmBackup_22MS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerarBackup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRutaBackup;
        private System.Windows.Forms.Button btnSeleccionarRuta;
        private System.Windows.Forms.Label label2;
    }
}