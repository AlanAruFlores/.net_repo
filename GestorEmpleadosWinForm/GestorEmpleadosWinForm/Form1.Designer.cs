namespace GestorEmpleadosWinForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            button1 = new Button();
            label2 = new Label();
            label1 = new Label();
            textBoxNDNI = new TextBox();
            label3 = new Label();
            label4 = new Label();
            textBoxNombre = new TextBox();
            label5 = new Label();
            textBoxEdad = new TextBox();
            label6 = new Label();
            textBoxSueldo = new TextBox();
            buttonGuardarEmpleado = new Button();
            dataGridEmpleados = new DataGridView();
            DNI = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Edad = new DataGridViewTextBoxColumn();
            Sueldo = new DataGridViewTextBoxColumn();
            label7 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            textBoxDNIEliminar = new TextBox();
            label8 = new Label();
            botonEliminar = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridEmpleados).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.MenuHighlight;
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 35);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.Transparent;
            button1.Location = new Point(767, 3);
            button1.Name = "button1";
            button1.Size = new Size(33, 26);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.HotTrack;
            label2.Location = new Point(277, 38);
            label2.Name = "label2";
            label2.Size = new Size(244, 32);
            label2.TabIndex = 2;
            label2.Text = "Gestor de Empleados";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(21, 116);
            label1.Name = "label1";
            label1.Size = new Size(88, 25);
            label1.TabIndex = 3;
            label1.Text = "Registrar";
            // 
            // textBoxNDNI
            // 
            textBoxNDNI.BackColor = SystemColors.ButtonFace;
            textBoxNDNI.Location = new Point(41, 165);
            textBoxNDNI.Multiline = true;
            textBoxNDNI.Name = "textBoxNDNI";
            textBoxNDNI.Size = new Size(216, 23);
            textBoxNDNI.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.HotTrack;
            label3.Location = new Point(31, 143);
            label3.Name = "label3";
            label3.Size = new Size(34, 19);
            label3.TabIndex = 5;
            label3.Text = "DNI";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.HotTrack;
            label4.Location = new Point(31, 205);
            label4.Name = "label4";
            label4.Size = new Size(60, 19);
            label4.TabIndex = 7;
            label4.Text = "Nombre";
            // 
            // textBoxNombre
            // 
            textBoxNombre.BackColor = SystemColors.ButtonFace;
            textBoxNombre.Location = new Point(41, 227);
            textBoxNombre.Multiline = true;
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(216, 23);
            textBoxNombre.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.HotTrack;
            label5.Location = new Point(31, 269);
            label5.Name = "label5";
            label5.Size = new Size(39, 19);
            label5.TabIndex = 9;
            label5.Text = "Edad";
            // 
            // textBoxEdad
            // 
            textBoxEdad.BackColor = SystemColors.ButtonFace;
            textBoxEdad.Location = new Point(41, 291);
            textBoxEdad.Multiline = true;
            textBoxEdad.Name = "textBoxEdad";
            textBoxEdad.Size = new Size(216, 23);
            textBoxEdad.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.HotTrack;
            label6.Location = new Point(31, 333);
            label6.Name = "label6";
            label6.Size = new Size(52, 19);
            label6.TabIndex = 11;
            label6.Text = "Sueldo";
            // 
            // textBoxSueldo
            // 
            textBoxSueldo.BackColor = SystemColors.ButtonFace;
            textBoxSueldo.Location = new Point(41, 355);
            textBoxSueldo.Multiline = true;
            textBoxSueldo.Name = "textBoxSueldo";
            textBoxSueldo.Size = new Size(216, 23);
            textBoxSueldo.TabIndex = 10;
            // 
            // buttonGuardarEmpleado
            // 
            buttonGuardarEmpleado.BackColor = SystemColors.MenuHighlight;
            buttonGuardarEmpleado.FlatAppearance.BorderSize = 0;
            buttonGuardarEmpleado.FlatStyle = FlatStyle.Flat;
            buttonGuardarEmpleado.ForeColor = SystemColors.Control;
            buttonGuardarEmpleado.Location = new Point(41, 399);
            buttonGuardarEmpleado.Name = "buttonGuardarEmpleado";
            buttonGuardarEmpleado.Size = new Size(216, 28);
            buttonGuardarEmpleado.TabIndex = 12;
            buttonGuardarEmpleado.Text = "Guardar";
            buttonGuardarEmpleado.UseVisualStyleBackColor = false;
            buttonGuardarEmpleado.Click += buttonGuardarEmpleado_Click;
            // 
            // dataGridEmpleados
            // 
            dataGridEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridEmpleados.Columns.AddRange(new DataGridViewColumn[] { DNI, Nombre, Edad, Sueldo });
            dataGridEmpleados.Location = new Point(316, 165);
            dataGridEmpleados.Name = "dataGridEmpleados";
            dataGridEmpleados.Size = new Size(443, 213);
            dataGridEmpleados.TabIndex = 13;
            // 
            // DNI
            // 
            DNI.HeaderText = "DNI";
            DNI.Name = "DNI";
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.Name = "Nombre";
            // 
            // Edad
            // 
            Edad.HeaderText = "Edad";
            Edad.Name = "Edad";
            // 
            // Sueldo
            // 
            Sueldo.HeaderText = "Sueldo";
            Sueldo.Name = "Sueldo";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.HotTrack;
            label7.Location = new Point(316, 116);
            label7.Name = "label7";
            label7.Size = new Size(154, 25);
            label7.TabIndex = 14;
            label7.Text = "Tabla Empleados";
            // 
            // panel2
            // 
            panel2.BackgroundImage = (Image)resources.GetObject("panel2.BackgroundImage");
            panel2.BackgroundImageLayout = ImageLayout.Zoom;
            panel2.ForeColor = SystemColors.ControlLightLight;
            panel2.Location = new Point(476, 116);
            panel2.Name = "panel2";
            panel2.Size = new Size(45, 39);
            panel2.TabIndex = 16;
            // 
            // panel3
            // 
            panel3.BackgroundImage = (Image)resources.GetObject("panel3.BackgroundImage");
            panel3.BackgroundImageLayout = ImageLayout.Zoom;
            panel3.ForeColor = SystemColors.ControlLightLight;
            panel3.Location = new Point(115, 116);
            panel3.Name = "panel3";
            panel3.Size = new Size(45, 39);
            panel3.TabIndex = 17;
            // 
            // textBoxDNIEliminar
            // 
            textBoxDNIEliminar.BackColor = SystemColors.ButtonFace;
            textBoxDNIEliminar.Location = new Point(316, 403);
            textBoxDNIEliminar.Multiline = true;
            textBoxDNIEliminar.Name = "textBoxDNIEliminar";
            textBoxDNIEliminar.Size = new Size(130, 29);
            textBoxDNIEliminar.TabIndex = 18;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.HotTrack;
            label8.Location = new Point(316, 381);
            label8.Name = "label8";
            label8.Size = new Size(100, 19);
            label8.TabIndex = 19;
            label8.Text = "DNI a eliminar";
            // 
            // botonEliminar
            // 
            botonEliminar.BackColor = SystemColors.MenuHighlight;
            botonEliminar.FlatAppearance.BorderSize = 0;
            botonEliminar.FlatStyle = FlatStyle.Flat;
            botonEliminar.ForeColor = SystemColors.Control;
            botonEliminar.Location = new Point(461, 404);
            botonEliminar.Name = "botonEliminar";
            botonEliminar.Size = new Size(100, 28);
            botonEliminar.TabIndex = 20;
            botonEliminar.Text = "Eliminar";
            botonEliminar.UseVisualStyleBackColor = false;
            botonEliminar.Click += botonEliminar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(botonEliminar);
            Controls.Add(label8);
            Controls.Add(textBoxDNIEliminar);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(label7);
            Controls.Add(dataGridEmpleados);
            Controls.Add(buttonGuardarEmpleado);
            Controls.Add(label6);
            Controls.Add(textBoxSueldo);
            Controls.Add(label5);
            Controls.Add(textBoxEdad);
            Controls.Add(label4);
            Controls.Add(textBoxNombre);
            Controls.Add(label3);
            Controls.Add(textBoxNDNI);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridEmpleados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private Label label2;
        private Label label1;
        private TextBox textBoxNDNI;
        private Label label3;
        private Label label4;
        private TextBox textBoxNombre;
        private Label label5;
        private TextBox textBoxEdad;
        private Label label6;
        private TextBox textBoxSueldo;
        private Button buttonGuardarEmpleado;
        private DataGridView dataGridEmpleados;
        private DataGridViewTextBoxColumn DNI;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Edad;
        private DataGridViewTextBoxColumn Sueldo;
        private Label label7;
        private Panel panel2;
        private Panel panel3;
        private TextBox textBoxDNIEliminar;
        private Label label8;
        private Button botonEliminar;
    }
}
