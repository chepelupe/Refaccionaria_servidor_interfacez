using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfazDeskTop
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            // Inicializar el cliente API
            try
            {
                ApiHelper.InitializeClient();
                lbl_estado.Text = "Conectado a la API";
                lbl_estado.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                lbl_estado.Text = "Error de conexión";
                lbl_estado.ForeColor = Color.Red;
                MessageBox.Show($"Error al conectar con la API: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btn_login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_usuario.Text) || string.IsNullOrWhiteSpace(txt_contrasena.Text))
            {
                MessageBox.Show("Ingrese usuario y contraseña", "Campos requeridos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btn_login.Enabled = false;
            lbl_estado.Text = "Iniciando sesión...";
            lbl_estado.ForeColor = Color.Blue;

            try
            {
                var loginModel = new LoginModel
                {
                    NombreUsuario = txt_usuario.Text.Trim(),
                    Contrasena = txt_contrasena.Text
                };

                var response = await ApiHelper.PostAsync<LoginResponse>("api/Auth/login", loginModel);

                if (response.Exitoso)
                {
                    lbl_estado.Text = "¡Login exitoso!";
                    lbl_estado.ForeColor = Color.Green;

                    // Guardar datos del usuario (puedes crear una clase estática UsuarioActual)
                    UsuarioActual.NombreUsuario = response.NombreUsuario;
                    UsuarioActual.NombreCompleto = response.NombreCompleto;
                    UsuarioActual.Rol = response.Rol;

                    // Abrir el formulario principal
                    this.Hide();
                    var frmVentas = new FrmVentas();
                    frmVentas.ShowDialog();
                    this.Close();
                }
                else
                {
                    lbl_estado.Text = response.Mensaje;
                    lbl_estado.ForeColor = Color.Red;
                    MessageBox.Show(response.Mensaje, "Error de login",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                lbl_estado.Text = "Error de conexión";
                lbl_estado.ForeColor = Color.Red;
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btn_login.Enabled = true;
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}