namespace InterfazDeskTop
{
    partial class FrmLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lbl_titulo = new System.Windows.Forms.Label();
            this.lbl_usuario = new System.Windows.Forms.Label();
            this.txt_usuario = new System.Windows.Forms.TextBox();
            this.lbl_contrasena = new System.Windows.Forms.Label();
            this.txt_contrasena = new System.Windows.Forms.TextBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.lbl_estado = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lbl_titulo
            this.lbl_titulo.AutoSize = true;
            this.lbl_titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lbl_titulo.Location = new System.Drawing.Point(150, 30);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(200, 31);
            this.lbl_titulo.TabIndex = 0;
            this.lbl_titulo.Text = "Iniciar Sesión";

            // lbl_usuario
            this.lbl_usuario.AutoSize = true;
            this.lbl_usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbl_usuario.Location = new System.Drawing.Point(80, 100);
            this.lbl_usuario.Name = "lbl_usuario";
            this.lbl_usuario.Size = new System.Drawing.Size(73, 20);
            this.lbl_usuario.TabIndex = 1;
            this.lbl_usuario.Text = "Usuario:";

            // txt_usuario
            this.txt_usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txt_usuario.Location = new System.Drawing.Point(180, 97);
            this.txt_usuario.Name = "txt_usuario";
            this.txt_usuario.Size = new System.Drawing.Size(220, 26);
            this.txt_usuario.TabIndex = 2;

            // lbl_contrasena
            this.lbl_contrasena.AutoSize = true;
            this.lbl_contrasena.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbl_contrasena.Location = new System.Drawing.Point(80, 150);
            this.lbl_contrasena.Name = "lbl_contrasena";
            this.lbl_contrasena.Size = new System.Drawing.Size(99, 20);
            this.lbl_contrasena.TabIndex = 3;
            this.lbl_contrasena.Text = "Contraseña:";

            // txt_contrasena
            this.txt_contrasena.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txt_contrasena.Location = new System.Drawing.Point(180, 147);
            this.txt_contrasena.Name = "txt_contrasena";
            this.txt_contrasena.PasswordChar = '*';
            this.txt_contrasena.Size = new System.Drawing.Size(220, 26);
            this.txt_contrasena.TabIndex = 4;

            // btn_login
            this.btn_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_login.Location = new System.Drawing.Point(120, 210);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(100, 35);
            this.btn_login.TabIndex = 5;
            this.btn_login.Text = "Ingresar";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);

            // btn_cancelar
            this.btn_cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_cancelar.Location = new System.Drawing.Point(260, 210);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(100, 35);
            this.btn_cancelar.TabIndex = 6;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);

            // lbl_estado
            this.lbl_estado.AutoSize = true;
            this.lbl_estado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lbl_estado.Location = new System.Drawing.Point(120, 270);
            this.lbl_estado.Name = "lbl_estado";
            this.lbl_estado.Size = new System.Drawing.Size(0, 18);
            this.lbl_estado.TabIndex = 7;

            // FrmLogin
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 350);
            this.Controls.Add(this.lbl_estado);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.txt_contrasena);
            this.Controls.Add(this.lbl_contrasena);
            this.Controls.Add(this.txt_usuario);
            this.Controls.Add(this.lbl_usuario);
            this.Controls.Add(this.lbl_titulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login - Refaccionaria";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lbl_titulo;
        private System.Windows.Forms.Label lbl_usuario;
        private System.Windows.Forms.TextBox txt_usuario;
        private System.Windows.Forms.Label lbl_contrasena;
        private System.Windows.Forms.TextBox txt_contrasena;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Label lbl_estado;
    }
}