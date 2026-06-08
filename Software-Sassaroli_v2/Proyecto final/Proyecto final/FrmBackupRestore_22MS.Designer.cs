namespace Proyecto_final
{
    partial class FrmBackupRestore_22MS
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
            this.dgvBackups = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVerBackups = new System.Windows.Forms.Button();
            this.btnRestaurarBackup = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackups)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerarBackup
            // 
            this.btnGenerarBackup.Location = new System.Drawing.Point(12, 57);
            this.btnGenerarBackup.Name = "btnGenerarBackup";
            this.btnGenerarBackup.Size = new System.Drawing.Size(157, 51);
            this.btnGenerarBackup.TabIndex = 3;
            this.btnGenerarBackup.Text = "Generar Backup";
            this.btnGenerarBackup.UseVisualStyleBackColor = true;
            this.btnGenerarBackup.Click += new System.EventHandler(this.btnGenerarBackup_Click);
            // 
            // dgvBackups
            // 
            this.dgvBackups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBackups.Location = new System.Drawing.Point(12, 131);
            this.dgvBackups.Name = "dgvBackups";
            this.dgvBackups.Size = new System.Drawing.Size(511, 153);
            this.dgvBackups.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(158, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Seccion de Backups";
            // 
            // btnVerBackups
            // 
            this.btnVerBackups.Location = new System.Drawing.Point(188, 57);
            this.btnVerBackups.Name = "btnVerBackups";
            this.btnVerBackups.Size = new System.Drawing.Size(157, 51);
            this.btnVerBackups.TabIndex = 8;
            this.btnVerBackups.Text = "Ver Backups";
            this.btnVerBackups.UseVisualStyleBackColor = true;
            this.btnVerBackups.Click += new System.EventHandler(this.btnVerBackups_Click);
            // 
            // btnRestaurarBackup
            // 
            this.btnRestaurarBackup.Location = new System.Drawing.Point(366, 57);
            this.btnRestaurarBackup.Name = "btnRestaurarBackup";
            this.btnRestaurarBackup.Size = new System.Drawing.Size(157, 51);
            this.btnRestaurarBackup.TabIndex = 9;
            this.btnRestaurarBackup.Text = "Restaurar Backup";
            this.btnRestaurarBackup.UseVisualStyleBackColor = true;
            this.btnRestaurarBackup.Click += new System.EventHandler(this.btnRestaurarBackup_Click);
            // 
            // FrmBackupRestore_22MS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 303);
            this.Controls.Add(this.btnRestaurarBackup);
            this.Controls.Add(this.btnVerBackups);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvBackups);
            this.Controls.Add(this.btnGenerarBackup);
            this.Name = "FrmBackupRestore_22MS";
            this.Text = "FrmBackupRestore_22MS";
            this.Load += new System.EventHandler(this.FrmBackupRestore_22MS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackups)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerarBackup;
        private System.Windows.Forms.DataGridView dgvBackups;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVerBackups;
        private System.Windows.Forms.Button btnRestaurarBackup;
    }
}