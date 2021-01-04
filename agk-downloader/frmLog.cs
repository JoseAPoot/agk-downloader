using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace agk_downloader
{
    public partial class frmLog : Form
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

        public frmLog()
        {
            InitializeComponent();

            //Para poner los bordes redondeados del formularo
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
        }

        private void frmLog_Load(object sender, EventArgs e)
        {
            Archivos archivos = new Archivos();
            var leeLog = archivos.leeLog();
            if (leeLog.Item1.Equals(1))
            {
                lstLog.Items.AddRange(((List<string>)leeLog.Item2).ToArray());
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
            this.Close();
        }
    }
}
