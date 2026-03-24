namespace touchProyecto
{
    partial class frmLogin
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
            groupBox1 = new GroupBox();
            txtPass = new TextBox();
            txtUser = new TextBox();
            label2 = new Label();
            label1 = new Label();
            btnSalir = new Button();
            btnIngreso = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtPass);
            groupBox1.Controls.Add(txtUser);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(21, 156);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(230, 184);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // txtPass
            // 
            txtPass.Location = new Point(82, 120);
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(142, 23);
            txtPass.TabIndex = 3;
            // 
            // txtUser
            // 
            txtUser.Location = new Point(62, 49);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(162, 23);
            txtUser.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 123);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 1;
            label2.Text = "Contraseña:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 52);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 0;
            label1.Text = "Usuario:";
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(176, 358);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 2;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnIngreso
            // 
            btnIngreso.Location = new Point(27, 358);
            btnIngreso.Name = "btnIngreso";
            btnIngreso.Size = new Size(75, 23);
            btnIngreso.TabIndex = 0;
            btnIngreso.Text = "Ingresar";
            btnIngreso.Click += btnIngreso_Click;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(281, 433);
            Controls.Add(btnIngreso);
            Controls.Add(btnSalir);
            Controls.Add(groupBox1);
            Name = "frmLogin";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private Button btnSalir;
        private TextBox txtPass;
        private TextBox txtUser;
        private Button btnIngreso;
    }
}
