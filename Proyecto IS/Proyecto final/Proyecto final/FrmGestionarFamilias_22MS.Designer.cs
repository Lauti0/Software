namespace Proyecto_final
{
    partial class FrmGestionarFamilias_22MS
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
            this.dgvFamilias = new System.Windows.Forms.DataGridView();
            this.txtNombreFamilia = new System.Windows.Forms.TextBox();
            this.btnCrear = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dgvSubFamilias = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAsignarFH = new System.Windows.Forms.Button();
            this.btnQuitarFH = new System.Windows.Forms.Button();
            this.btnFormRoles = new System.Windows.Forms.Button();
            this.btnQuitarPermiso = new System.Windows.Forms.Button();
            this.btnAsignarPermiso = new System.Windows.Forms.Button();
            this.dgvPermisos = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvCompleta = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFamilias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubFamilias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermisos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompleta)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 19;
            this.label1.Tag = "LBL_FAMILIAS";
            this.label1.Text = "Familias";
            // 
            // dgvFamilias
            // 
            this.dgvFamilias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFamilias.Location = new System.Drawing.Point(12, 75);
            this.dgvFamilias.Name = "dgvFamilias";
            this.dgvFamilias.Size = new System.Drawing.Size(258, 259);
            this.dgvFamilias.TabIndex = 19;
            this.dgvFamilias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFamilias_CellClick);
            // 
            // txtNombreFamilia
            // 
            this.txtNombreFamilia.Location = new System.Drawing.Point(45, 340);
            this.txtNombreFamilia.Name = "txtNombreFamilia";
            this.txtNombreFamilia.Size = new System.Drawing.Size(198, 20);
            this.txtNombreFamilia.TabIndex = 23;
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(45, 366);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(98, 23);
            this.btnCrear.TabIndex = 19;
            this.btnCrear.Tag = "BTN_CREAR";
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(148, 366);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(95, 23);
            this.btnEliminar.TabIndex = 20;
            this.btnEliminar.Tag = "BTN_ELIMINAR";
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(45, 395);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(98, 23);
            this.btnModificar.TabIndex = 21;
            this.btnModificar.Tag = "BTN_MODIFICAR";
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(148, 395);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(95, 23);
            this.btnLimpiar.TabIndex = 22;
            this.btnLimpiar.Tag = "BTN_LIMPIAR";
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // dgvSubFamilias
            // 
            this.dgvSubFamilias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubFamilias.Location = new System.Drawing.Point(323, 75);
            this.dgvSubFamilias.Name = "dgvSubFamilias";
            this.dgvSubFamilias.Size = new System.Drawing.Size(465, 148);
            this.dgvSubFamilias.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(319, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 19;
            this.label2.Tag = "LBL_FAMILIAS";
            this.label2.Text = "Familias";
            // 
            // btnAsignarFH
            // 
            this.btnAsignarFH.Location = new System.Drawing.Point(632, 229);
            this.btnAsignarFH.Name = "btnAsignarFH";
            this.btnAsignarFH.Size = new System.Drawing.Size(75, 23);
            this.btnAsignarFH.TabIndex = 21;
            this.btnAsignarFH.Tag = "BTN_ASIGNAR";
            this.btnAsignarFH.Text = "Asignar";
            this.btnAsignarFH.UseVisualStyleBackColor = true;
            this.btnAsignarFH.Click += new System.EventHandler(this.btnAsignarFH_Click);
            // 
            // btnQuitarFH
            // 
            this.btnQuitarFH.Location = new System.Drawing.Point(713, 229);
            this.btnQuitarFH.Name = "btnQuitarFH";
            this.btnQuitarFH.Size = new System.Drawing.Size(75, 23);
            this.btnQuitarFH.TabIndex = 22;
            this.btnQuitarFH.Tag = "BTN_QUITAR";
            this.btnQuitarFH.Text = "Quitar";
            this.btnQuitarFH.UseVisualStyleBackColor = true;
            this.btnQuitarFH.Click += new System.EventHandler(this.btnQuitarFH_Click);
            // 
            // btnFormRoles
            // 
            this.btnFormRoles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnFormRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFormRoles.ForeColor = System.Drawing.Color.Transparent;
            this.btnFormRoles.Location = new System.Drawing.Point(632, 543);
            this.btnFormRoles.Name = "btnFormRoles";
            this.btnFormRoles.Size = new System.Drawing.Size(156, 84);
            this.btnFormRoles.TabIndex = 19;
            this.btnFormRoles.Tag = "BTN_ADMIN_ROLES";
            this.btnFormRoles.Text = "Administracion de Roles";
            this.btnFormRoles.UseVisualStyleBackColor = false;
            this.btnFormRoles.Click += new System.EventHandler(this.btnFormRoles_Click);
            // 
            // btnQuitarPermiso
            // 
            this.btnQuitarPermiso.Location = new System.Drawing.Point(713, 424);
            this.btnQuitarPermiso.Name = "btnQuitarPermiso";
            this.btnQuitarPermiso.Size = new System.Drawing.Size(75, 23);
            this.btnQuitarPermiso.TabIndex = 27;
            this.btnQuitarPermiso.Tag = "BTN_QUITAR";
            this.btnQuitarPermiso.Text = "Quitar";
            this.btnQuitarPermiso.UseVisualStyleBackColor = true;
            this.btnQuitarPermiso.Click += new System.EventHandler(this.btnQuitarPermiso_Click);
            // 
            // btnAsignarPermiso
            // 
            this.btnAsignarPermiso.Location = new System.Drawing.Point(632, 424);
            this.btnAsignarPermiso.Name = "btnAsignarPermiso";
            this.btnAsignarPermiso.Size = new System.Drawing.Size(75, 23);
            this.btnAsignarPermiso.TabIndex = 26;
            this.btnAsignarPermiso.Tag = "BTN_ASIGNAR";
            this.btnAsignarPermiso.Text = "Asignar";
            this.btnAsignarPermiso.UseVisualStyleBackColor = true;
            this.btnAsignarPermiso.Click += new System.EventHandler(this.btnAsignarPermiso_Click);
            // 
            // dgvPermisos
            // 
            this.dgvPermisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPermisos.Location = new System.Drawing.Point(323, 270);
            this.dgvPermisos.Name = "dgvPermisos";
            this.dgvPermisos.Size = new System.Drawing.Size(465, 148);
            this.dgvPermisos.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(319, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 24;
            this.label3.Tag = "LBL_PERMISOS";
            this.label3.Text = "Permisos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(240, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(295, 25);
            this.label4.TabIndex = 28;
            this.label4.Tag = "LBL_TITULO_FAMILIAS";
            this.label4.Text = "Administracion de Familias";
            // 
            // dgvCompleta
            // 
            this.dgvCompleta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompleta.Location = new System.Drawing.Point(12, 465);
            this.dgvCompleta.Name = "dgvCompleta";
            this.dgvCompleta.Size = new System.Drawing.Size(381, 162);
            this.dgvCompleta.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 442);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 20);
            this.label5.TabIndex = 30;
            this.label5.Tag = "LBL_RESUMEN_FAMILIA";
            this.label5.Text = "Resumen Familia";
            // 
            // FrmGestionarFamilias_22MS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 639);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvCompleta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnQuitarPermiso);
            this.Controls.Add(this.btnAsignarPermiso);
            this.Controls.Add(this.dgvPermisos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnFormRoles);
            this.Controls.Add(this.btnQuitarFH);
            this.Controls.Add(this.txtNombreFamilia);
            this.Controls.Add(this.btnAsignarFH);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.dgvSubFamilias);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvFamilias);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnCrear);
            this.Name = "FrmGestionarFamilias_22MS";
            this.Tag = "FORM_FAMILIAS";
            this.Text = "FrmGestionarFamilias_22MS";
            this.Load += new System.EventHandler(this.FrmGestionarFamilias_22MS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFamilias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubFamilias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermisos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompleta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvFamilias;
        private System.Windows.Forms.TextBox txtNombreFamilia;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView dgvSubFamilias;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAsignarFH;
        private System.Windows.Forms.Button btnQuitarFH;
        private System.Windows.Forms.Button btnFormRoles;
        private System.Windows.Forms.Button btnQuitarPermiso;
        private System.Windows.Forms.Button btnAsignarPermiso;
        private System.Windows.Forms.DataGridView dgvPermisos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvCompleta;
        private System.Windows.Forms.Label label5;
    }
}