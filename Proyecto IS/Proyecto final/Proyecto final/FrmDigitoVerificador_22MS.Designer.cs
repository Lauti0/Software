namespace Proyecto_final
{
    partial class FrmDigitoVerificador_22MS
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnRecalcularDV = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvErrores = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrores)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(76, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 25);
            this.label1.TabIndex = 1;
            this.label1.Tag = "LBL_TITULO_DV";
            this.label1.Text = "Administracion del Digito Verificador";
            // 
            // btnRecalcularDV
            // 
            this.btnRecalcularDV.Location = new System.Drawing.Point(369, 77);
            this.btnRecalcularDV.Name = "btnRecalcularDV";
            this.btnRecalcularDV.Size = new System.Drawing.Size(157, 51);
            this.btnRecalcularDV.TabIndex = 3;
            this.btnRecalcularDV.Tag = "BTN_RECALCULAR_DIGITOS";
            this.btnRecalcularDV.Text = "Recalcular Digitos";
            this.btnRecalcularDV.UseVisualStyleBackColor = true;
            this.btnRecalcularDV.Click += new System.EventHandler(this.btnRecalcularDV_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 20);
            this.label2.TabIndex = 4;
            this.label2.Tag = "LBL_ERRORES_ENCONTRADOS";
            this.label2.Text = "Errores encontrados:";
            // 
            // dgvErrores
            // 
            this.dgvErrores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvErrores.Location = new System.Drawing.Point(12, 134);
            this.dgvErrores.Name = "dgvErrores";
            this.dgvErrores.Size = new System.Drawing.Size(511, 153);
            this.dgvErrores.TabIndex = 5;
            // 
            // FrmDigitoVerificador_22MS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 296);
            this.Controls.Add(this.dgvErrores);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRecalcularDV);
            this.Controls.Add(this.label1);
            this.Name = "FrmDigitoVerificador_22MS";
            this.Tag = "FORM_DV";
            this.Text = "FrmDigitoVerificador_22MS";
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRecalcularDV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvErrores;
    }
}