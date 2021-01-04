using System;
using System.Net;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace agk_downloader
{
    public partial class frmLogin : Form
    {
        // Para mover el formulario
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void moverForm()
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    
        // Para redondear
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
         (
          int nLeftRect,        // Coordenada x de la esquina superior izquierda
          int nTopRect,         // Coordenada y de la esquina superior izquierda
          int nRightRect,       // Coordenada x de la esquina inferior derecha 
          int nBottomRect,      // Coordenada y de la esquina inferior derecha 
          int nWidthEllipse,    // Altura de la elipse
          int nHeightEllipse    // Anchura de la elipse 
         );

        public frmLogin()
        {
            InitializeComponent();

            //Para poner los bordes redondeados del formularo
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
        }

        private void frmLogin_Activated(object sender, EventArgs e)
        {
            txtEmail.Focus();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (!HayInternet())
            {
                MessageBox.Show("Es necesario una conexión a internet para continuar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.Exit();
            }
        }

        private void frmLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                moverForm();
            }
        }

        private void frmLogin_Shown(object sender, EventArgs e)
        {
            for (double FadeIn = 0; FadeIn <= 1.1; FadeIn += 0.1)
            {
                this.Opacity = FadeIn;
                this.Refresh();
                System.Threading.Thread.Sleep(30);
            }
        }

        private void panelBack_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                moverForm();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPass.Text.Trim();
            bool pass = true;

            if (email != "")
            {
                if (!ValidarEmail(email))
                {
                    MessageBox.Show("Favor de introducir un correo valido", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }

            if (email == "" || password == "")
            {
                pass = false;
            }

            if (pass)
            {
                PHP php = new PHP();
                var dataPHP = php.GetData("https://servicios.aguakan.com/modulos/login/login.php", "email=" + email + "&password=" + password);
                if (dataPHP.Item1.Equals(1))
                {
                    string resul = dataPHP.Item2.ToString();

                    switch (resul.Trim())
                    {
                        case "logindisabled":
                            MessageBox.Show("No a concluido el proceso de registro." + Environment.NewLine + "Su cuenta no ha sido confirmada, verifique su correo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;

                        case "needupdatepassword":
                            MessageBox.Show("Para que puedas usar tu cuenta anterior, necesitas actualizar tu contraseña", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;

                        case "correofail":
                            MessageBox.Show("El correo o la contraseña no son validos." + Environment.NewLine + "Por favor, verifica tus datos e intentalo de nuevo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;

                        case "ERROR":
                            Application.Exit();
                            break;

                        default:
                            this.Hide();
                            using (frmMain frmMain = new frmMain())
                            {
                                frmMain.email = email;
                                frmMain.password = password;
                                frmMain.ShowDialog();

                                frmMain.Dispose();
                                frmMain.Close();
                            }
                            break;
                    }
                }
                else
                {
                    MessageBox.Show(dataPHP.Item2.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No se pueden dejar los campos en blanco", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter || e.KeyChar == (Char)Keys.Tab)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}"); 
            }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter || e.KeyChar == (Char)Keys.Tab)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");

                btnIniciar_Click(sender, e);
            }
        }

        private bool HayInternet()
        {
            WebRequest wRequest;
            WebResponse wResponse;
            Uri Url = new Uri("https://www.google.com");

            try
            {
                wRequest = WebRequest.Create(Url);
                wRequest.Timeout = 5000;
                wResponse = wRequest.GetResponse();
                wResponse.Close();
                wRequest = null;

                return true;
            }
            catch
            {
                wRequest = null;
                return false;
            }
        }

        private bool ValidarEmail(string email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
