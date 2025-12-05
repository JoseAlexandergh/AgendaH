namespace AgendaH
{
    partial class Form1
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtBoxNombre = new System.Windows.Forms.TextBox();
            this.txtBoxApellido = new System.Windows.Forms.TextBox();
            this.txtBoxDireccion = new System.Windows.Forms.TextBox();
            this.txtBoxNotas = new System.Windows.Forms.TextBox();
            this.txtBoxCedula = new System.Windows.Forms.TextBox();
            this.dateTimePickerFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.comboBoxSexo = new System.Windows.Forms.ComboBox();
            this.dataGridPersonas = new System.Windows.Forms.DataGridView();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnAbrirContactos = new System.Windows.Forms.Button();
            this.btnCitas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPersonas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Apellido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 329);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sexo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Cedula";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(301, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Direccion";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(322, 292);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Notas";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 411);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Fecha de nacimiento";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(12, 12);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtBoxNombre
            // 
            this.txtBoxNombre.Location = new System.Drawing.Point(12, 211);
            this.txtBoxNombre.Name = "txtBoxNombre";
            this.txtBoxNombre.Size = new System.Drawing.Size(174, 22);
            this.txtBoxNombre.TabIndex = 8;
            // 
            // txtBoxApellido
            // 
            this.txtBoxApellido.Location = new System.Drawing.Point(15, 286);
            this.txtBoxApellido.Name = "txtBoxApellido";
            this.txtBoxApellido.Size = new System.Drawing.Size(171, 22);
            this.txtBoxApellido.TabIndex = 9;
            // 
            // txtBoxDireccion
            // 
            this.txtBoxDireccion.Location = new System.Drawing.Point(268, 153);
            this.txtBoxDireccion.Multiline = true;
            this.txtBoxDireccion.Name = "txtBoxDireccion";
            this.txtBoxDireccion.Size = new System.Drawing.Size(150, 112);
            this.txtBoxDireccion.TabIndex = 10;
            // 
            // txtBoxNotas
            // 
            this.txtBoxNotas.Location = new System.Drawing.Point(270, 320);
            this.txtBoxNotas.Multiline = true;
            this.txtBoxNotas.Name = "txtBoxNotas";
            this.txtBoxNotas.Size = new System.Drawing.Size(155, 118);
            this.txtBoxNotas.TabIndex = 11;
            // 
            // txtBoxCedula
            // 
            this.txtBoxCedula.Location = new System.Drawing.Point(12, 152);
            this.txtBoxCedula.Name = "txtBoxCedula";
            this.txtBoxCedula.Size = new System.Drawing.Size(100, 22);
            this.txtBoxCedula.TabIndex = 12;
            // 
            // dateTimePickerFechaNacimiento
            // 
            this.dateTimePickerFechaNacimiento.Location = new System.Drawing.Point(15, 443);
            this.dateTimePickerFechaNacimiento.Name = "dateTimePickerFechaNacimiento";
            this.dateTimePickerFechaNacimiento.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerFechaNacimiento.TabIndex = 13;
            // 
            // comboBoxSexo
            // 
            this.comboBoxSexo.FormattingEnabled = true;
            this.comboBoxSexo.Items.AddRange(new object[] {
            "Masculino",
            "Femenino"});
            this.comboBoxSexo.Location = new System.Drawing.Point(15, 361);
            this.comboBoxSexo.Name = "comboBoxSexo";
            this.comboBoxSexo.Size = new System.Drawing.Size(121, 24);
            this.comboBoxSexo.TabIndex = 14;
            // 
            // dataGridPersonas
            // 
            this.dataGridPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPersonas.Location = new System.Drawing.Point(618, 12);
            this.dataGridPersonas.Name = "dataGridPersonas";
            this.dataGridPersonas.RowHeadersWidth = 51;
            this.dataGridPersonas.RowTemplate.Height = 24;
            this.dataGridPersonas.Size = new System.Drawing.Size(690, 506);
            this.dataGridPersonas.TabIndex = 15;
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(304, 12);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(75, 23);
            this.btnBorrar.TabIndex = 16;
            this.btnBorrar.Text = "Eliminar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(111, 12);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 17;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(208, 12);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 18;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnAbrirContactos
            // 
            this.btnAbrirContactos.Location = new System.Drawing.Point(504, 12);
            this.btnAbrirContactos.Name = "btnAbrirContactos";
            this.btnAbrirContactos.Size = new System.Drawing.Size(108, 71);
            this.btnAbrirContactos.TabIndex = 19;
            this.btnAbrirContactos.Text = "Contactos";
            this.btnAbrirContactos.UseVisualStyleBackColor = true;
            this.btnAbrirContactos.Click += new System.EventHandler(this.btnAbrirContactos_Click);
            // 
            // btnCitas
            // 
            this.btnCitas.Location = new System.Drawing.Point(504, 119);
            this.btnCitas.Name = "btnCitas";
            this.btnCitas.Size = new System.Drawing.Size(108, 80);
            this.btnCitas.TabIndex = 20;
            this.btnCitas.Text = "Citas";
            this.btnCitas.UseVisualStyleBackColor = true;
            this.btnCitas.Click += new System.EventHandler(this.btnCitas_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1353, 530);
            this.Controls.Add(this.btnCitas);
            this.Controls.Add(this.btnAbrirContactos);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.dataGridPersonas);
            this.Controls.Add(this.comboBoxSexo);
            this.Controls.Add(this.dateTimePickerFechaNacimiento);
            this.Controls.Add(this.txtBoxCedula);
            this.Controls.Add(this.txtBoxNotas);
            this.Controls.Add(this.txtBoxDireccion);
            this.Controls.Add(this.txtBoxApellido);
            this.Controls.Add(this.txtBoxNombre);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Agenda Principal";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPersonas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtBoxNombre;
        private System.Windows.Forms.TextBox txtBoxApellido;
        private System.Windows.Forms.TextBox txtBoxDireccion;
        private System.Windows.Forms.TextBox txtBoxNotas;
        private System.Windows.Forms.TextBox txtBoxCedula;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaNacimiento;
        private System.Windows.Forms.ComboBox comboBoxSexo;
        private System.Windows.Forms.DataGridView dataGridPersonas;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnAbrirContactos;
        private System.Windows.Forms.Button btnCitas;
    }
}

