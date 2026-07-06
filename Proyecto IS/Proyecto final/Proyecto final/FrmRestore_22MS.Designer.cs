namespace Proyecto_final
{
    partial class FrmRestore_22MS
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
            this.dgvRestore = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRestore = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRestore)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRestore
            // 
            this.dgvRestore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRestore.Location = new System.Drawing.Point(12, 37);
            this.dgvRestore.Name = "dgvRestore";
            this.dgvRestore.Size = new System.Drawing.Size(435, 150);
            this.dgvRestore.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 25);
            this.label1.TabIndex = 8;
            this.label1.Tag = "LBL_TITULO_RESTORE";
            this.label1.Text = "Seccion de Restore";
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(290, 193);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(157, 51);
            this.btnRestore.TabIndex = 9;
            this.btnRestore.Tag = "BTN_RESTORE";
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // FrmRestore_22MS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 249);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvRestore);
            this.Name = "FrmRestore_22MS";
            this.Tag = "FORM_RESTORE";
            this.Text = "FrmRestore_22MS";
            this.Load += new System.EventHandler(this.FrmRestore_22MS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRestore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRestore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRestore;
    }
}