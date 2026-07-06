namespace Proyecto_final
{
    partial class FrmCambiarIdioma_22MS
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbIdiomas_22MS = new System.Windows.Forms.ComboBox();
            this.btnCambiarIdioma_22MS = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 17;
            this.label2.Tag = "LBL_IDIOMAS";
            this.label2.Text = "Idiomas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 25);
            this.label1.TabIndex = 16;
            this.label1.Tag = "LBL_TITULO_IDIOMAS";
            this.label1.Text = "Cambiar Idioma";
            // 
            // cmbIdiomas_22MS
            // 
            this.cmbIdiomas_22MS.FormattingEnabled = true;
            this.cmbIdiomas_22MS.Location = new System.Drawing.Point(12, 72);
            this.cmbIdiomas_22MS.Name = "cmbIdiomas_22MS";
            this.cmbIdiomas_22MS.Size = new System.Drawing.Size(174, 21);
            this.cmbIdiomas_22MS.TabIndex = 15;
            // 
            // btnCambiarIdioma_22MS
            // 
            this.btnCambiarIdioma_22MS.Location = new System.Drawing.Point(46, 128);
            this.btnCambiarIdioma_22MS.Name = "btnCambiarIdioma_22MS";
            this.btnCambiarIdioma_22MS.Size = new System.Drawing.Size(105, 50);
            this.btnCambiarIdioma_22MS.TabIndex = 18;
            this.btnCambiarIdioma_22MS.Tag = "BTN_CAMBIAR_IDIOMA";
            this.btnCambiarIdioma_22MS.Text = "Cambiar idioma";
            this.btnCambiarIdioma_22MS.UseVisualStyleBackColor = true;
            this.btnCambiarIdioma_22MS.Click += new System.EventHandler(this.btnCambiarIdioma_22MS_Click);
            // 
            // FrmCambiarIdioma_22MS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(199, 189);
            this.Controls.Add(this.btnCambiarIdioma_22MS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbIdiomas_22MS);
            this.Name = "FrmCambiarIdioma_22MS";
            this.Tag = "FORM_CAMBIO_IDIOMA";
            this.Text = "FrmCambiarIdioma_22MS";
            this.Load += new System.EventHandler(this.FrmCambiarIdioma_22MS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbIdiomas_22MS;
        private System.Windows.Forms.Button btnCambiarIdioma_22MS;
    }
}