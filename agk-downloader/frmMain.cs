using System;
using System.IO;
using System.Net;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using wyDay.Controls;

namespace agk_downloader
{
    public partial class frmMain : Form
    {
        public string email = "";
        public string password = "";

        private int Accion = 2;
        private string RutaFactura = "";
        private string RutaDescarga = "";

        private ListView lstReferencia = new ListView();
        private Funcion Funcion = new Funcion();
        private Archivos Archivos = new Archivos();

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

        public frmMain()
        {
            InitializeComponent();

            //Para poner los bordes redondeados del formularo
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            int anio = DateTime.Now.Year;
            int mes = DateTime.Now.Month;

            cmbAño.Items.Clear();
            for (int i = anio - 1; i <= anio; i++)
            {
                cmbAño.Items.Add(i);
            }

            cmbAño.SelectedIndex = 1;
            cmbMes.SelectedIndex = mes - 1;
        }

        private void frmMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                moverForm();
            }
        }

        private void panelMenu_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                moverForm();
            }
        }

        private void chkVincular_Click(object sender, EventArgs e)
        {
            selAccion(chkVincular);
        }

        private void chkDescargar_Click(object sender, EventArgs e)
        {
            selAccion(chkDescargar);
        }

        private void chkEliminar_Click(object sender, EventArgs e)
        {
            selAccion(chkEliminar);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (!btnIniciar.Enabled)
            {
                if (MessageBox.Show("Hay un proceso en " + btnIniciar.Text + " de ejecución." + Environment.NewLine + "No puede cancelar el proceso, por favor espere.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    return;
                }
            }

            Archivos.eliminaLog();

            cerrarSesion();

            Application.Exit();
        }

        private void selAccion(Button btn)
        {
            if (!btnIniciar.Enabled)
            {
                return;
            }

            foreach (Control contHijo in panelMenu.Controls)
            {
                contHijo.ForeColor = Color.White;
            }

            picStatus.Location = new Point(picStatus.Location.X, btn.Location.Y);
            btn.ForeColor = Color.FromArgb(34, 153, 84);
            Accion = int.Parse(btn.Tag.ToString());
        }

        private void chkManual_CheckedChanged(object sender, EventArgs e)
        {
            txtData.Clear();
            if (chkManual.Checked)
            {
                if (Accion.Equals(1))
                {
                    txtData.Text = "Ingrese código NIA";
                }
                else
                {
                    txtData.Text = "Ingrese código de cliente";
                }

                txtData.Focus();
                txtData.Select();
                btnFile.Visible = false;
            }
            else
            {
                txtData.Text = "Seleccione archivo de layout";
                btnFile.Visible = true;
            }
            lstData.Items.Clear();
        }

        private void txtData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!chkManual.Checked)
            {
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar == 13)
                {
                    if (txtData.Text.Trim() != "")
                    {
                        ListViewItem oReg = new ListViewItem();
                        oReg = lstData.Items.Add((lstData.Items.Count + 1).ToString());

                        if (Accion.Equals(1))
                        {
                            oReg.SubItems.Add("");
                        }

                        oReg.SubItems.Add(txtData.Text.Trim());
                        txtData.Clear();
                        txtData.Focus();
                    }
                }
                else
                {
                    e.Handled = !(e.KeyChar >= 48 && e.KeyChar <= 57) && !Char.IsControl(e.KeyChar);
                }
            }
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.FileName = "";
                openFile.Title = "Seleccione el archivo";
                openFile.Filter = "Archivos Excel(*.xls;*.xlsx)|*.xls;*xlsx";
                
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    lstData.Items.Clear();
                    txtData.Text = Path.GetFileName(openFile.FileName);

                    Excel excel = new Excel();
                    var dataExcel = excel.LeerArchivo(openFile.FileName);
                    if (dataExcel.Item1.Equals(1))
                    {
                        DataTable dtExcel = (DataTable)dataExcel.Item2;
                        if (dtExcel.Rows.Count > 0)
                        {
                            for (int i = 1; i < dtExcel.Rows.Count; i++)
                            {
                                ListViewItem oReg = new ListViewItem();
                                oReg = lstData.Items.Add((lstData.Items.Count + 1).ToString());
                                oReg.SubItems.Add(dtExcel.Rows[i][0].ToString());
                                oReg.SubItems.Add(dtExcel.Rows[i][1].ToString());
                            }

                            Application.DoEvents();
                        }
                        else
                        {
                            MessageBox.Show("El archivo no cuenta con ningún registro, favor de verificar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        MessageBox.Show(dataExcel.Item2.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    txtData.Clear();
                    lstData.Items.Clear();
                }
            }
        }

        private void lstData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                if (MessageBox.Show("Desea eliminar el código seleccionado?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    for (int i = 0; i <= lstData.SelectedItems.Count; i++)
                    {
                        lstData.Items[i].Remove();
                    }

                    Application.DoEvents();
                }
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            btnIniciar.Text = "0%";
            Application.DoEvents();

            // No vincular
            if (!Accion.Equals(1))
            {
                if (lstData.Items.Count <= 0)
                {
                    MessageBox.Show("Agregue al menos un código para continuar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }

            // Descargar
            if (Accion.Equals(2))
            {
                if (!chkPDF.Checked && !chkXML.Checked && !chkBoleta.Checked && !chkHistorial.Checked)
                {
                    MessageBox.Show("No seleccionó ningún archivo a descargar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                using (FolderBrowserDialog folder = new FolderBrowserDialog())
                {
                    folder.Description = "Seleccione la ruta para almacenar las facturas";
                    folder.ShowDialog();

                    RutaFactura = folder.SelectedPath;

                    if (RutaFactura.Trim() != "")
                    {
                        if (RutaFactura.Trim().Substring(RutaFactura.Length - 1, 1) != @"\")
                        {
                            RutaFactura += @"\";
                        }
                    }
                    else
                    {
                        MessageBox.Show("No seleccionó ninguna ruta para la descarga", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }
            }

            ctrlActiva(false);

            // Iniciamos sesión para evitar cierre de sesion por inactividad
            iniciarSesion();

            lblAccion.Text = "Validando...";
            Application.DoEvents();

            // Eliminamos el archivo de log si existe
            Archivos.eliminaLog();

            bool cancelado = false;

            // Obtenemos la ruta de descarga
            RutaDescarga = RutaFactura + cmbAño.Text + @"\" + cmbMes.Text + @"\";

            // Vincular
            if (Accion.Equals(1))
            {
                webSite.Navigate("https://servicios.aguakan.com/modulos/contratos/index");
                while (webSite.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }

                if (MessageBox.Show("Va a vincular " + lstData.Items.Count.ToString() + " Contratos, Desea Continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    iniciaCiclo();
                }
                else
                {
                    cancelado = true;
                }
            }

            // Descargar
            if (Accion.Equals(2))
            {
                webSite.Navigate("https://servicios.aguakan.com//modulos/facturas/index");
                while (webSite.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }

                if (MessageBox.Show("Va a descargar la información de " + lstData.Items.Count.ToString() + " Clientes, Desea Continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    iniciaCiclo();
                }
                else
                {
                    cancelado = true;
                }

                lblAccion.Text = "Creando archivo de referencia...";
                Application.DoEvents();

                Excel excel = new Excel();
                excel.ExportaReferencia(lstReferencia);
            }

            // Eliminar
            if (Accion.Equals(3))
            {
                webSite.Navigate("https://servicios.aguakan.com/modulos/contratos/index");
                while (webSite.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }

                if (lstData.Items.Count <= 0)
                {
                    if (MessageBox.Show("Al no tener cargado ningún archivo, se eliminaran TODOS los Clientes. Esta seguro(a) que desea continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        w7.Style = ProgressBarStyle.Marquee;
                        w7.Visible = true;

                        revisionClienteDelete();
                    }
                    else
                    {
                        cancelado = true;
                    }
                }
                else
                {
                    if (MessageBox.Show("Va a eliminar " + lstData.Items.Count.ToString() + " Clientes, Desea Continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        iniciaCiclo();
                    }
                    else
                    {
                        cancelado = true;
                    }
                }
            }

            // Cerramos sesion y activamos los controles
            cerrarSesion();
            ctrlActiva(true);

            lblAccion.Text = "Listo!!!";
            btnIniciar.Text = "Iniciar";
            Application.DoEvents();

            if (!cancelado)
            {
                MessageBox.Show("   Proceso Terminado!!!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                using (frmLog frmLog = new frmLog())
                {
                    frmLog.ShowDialog();
                    frmLog.Dispose();
                    frmLog.Close();
                }

                if (Accion.Equals(2))
                {
                    if (Directory.Exists(RutaDescarga))
                    {
                        System.Diagnostics.Process.Start("explorer", RutaDescarga);
                    }
                }
            }
            else
            {
                MessageBox.Show("   Proceso Cancelado!!!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Eliminamos el archivo de log si existe
            Archivos.eliminaLog();

            lblAccion.Text = "";
            Application.DoEvents();
        }

        private void iniciaCiclo()
        {
            int Registro = 1;
            string Codigo = "";
            int Columna = Accion.Equals(1) ? 2 : 1;

            ctrlActiva(false);

            foreach (ListViewItem item in lstData.Items)
            {
                Codigo = item.SubItems[Columna].Text.ToString() == DBNull.Value.ToString() ? "" : item.SubItems[Columna].Text.ToString();

                if (Codigo != "" && Funcion.IsNumeric(Codigo))
                {
                    // Vincular
                    if (Accion.Equals(1))
                    {
                        lblAccion.Text = "Vinculando NIA: " + Codigo;
                        Application.DoEvents();

                        PHP php = new PHP();
                        var respuestaPHP = php.GetData("https://servicios.aguakan.com/modulos/contratos/alta.php", "nia=" + Codigo);
                        if (respuestaPHP.Item1.Equals(1))
                        {
                            string result = respuestaPHP.Item2.ToString();

                            if (result.Contains("Contrato ya registrado"))
                            {
                                Archivos.grabaLog("NIA: " + Codigo + " || Contrato registrado: El Contrato ya se encuentra registrado");
                            }
                            else if (result.Contains("Contrato registrado"))
                            {
                                //webSite.Document.GetElementById("boton-masnia").Focus();
                                //webSite.Document.GetElementById("boton-masnia").InvokeMember("click");
                                //Application.DoEvents();

                                //webSite.Document.GetElementById("nia").Focus();
                                //webSite.Document.GetElementById("nia").InnerText = Codigo;
                                //webSite.Document.GetElementById("nia").RemoveFocus();

                                HtmlElement txtNIA = webSite.Document.GetElementById("nia");
                                txtNIA.SetAttribute("value", Codigo);

                                webSite.Document.GetElementById("envio-vincu").Focus();
                                webSite.Document.GetElementById("envio-vincu").InvokeMember("click");
                                Application.DoEvents();

                                Archivos.grabaLog("NIA: " + Codigo + " || Registro exitoso: El Contrato se registro exitosamente");
                            }
                            else if (result.Contains("Numero de intentos excedido"))
                            {
                                Archivos.grabaLog("NIA: " + Codigo + " || Número de intentos Excedido: El Contrato no se pudo registrar, Favor de intentar mas tarde");
                            }
                            else if (result.Contains("Contrato no encontrado"))
                            {
                                Archivos.grabaLog("NIA: " + Codigo + " || Contrato no encontrado: El NIA proporcionado no fue encontrado, favor de validar e intentar nuevamente");
                            }
                            else
                            {
                                Archivos.grabaLog("NIA: " + Codigo + " || Error desconocido: Error desconocido");
                            }
                        }
                    }

                    // Descargar
                    if (Accion.Equals(2))
                    {
                        lblAccion.Text = "Revisando cliente " + Codigo;
                        Application.DoEvents();

                        revisionClienteFactura(Codigo);

                        Archivos.eliminaData();
                    }

                    // Eliminar
                    if (Accion.Equals(3))
                    {
                        lblAccion.Text = "Eliminando cliente " + Codigo;
                        Application.DoEvents();

                        eliminarCliente(Codigo);
                    }
                }
                else
                {
                    Archivos.grabaLog(Columna.ToString() == "2" ? "NIA: " : "CLIENTE: " + Codigo + " || El código es incorrecto, esta vacio o no es numérico");
                }

                btnIniciar.Text = (Registro * 100) / lstData.Items.Count + "%";
                Application.DoEvents();

                Registro++;
                pBar.Increment(1);
                w7.Increment(1);
                Application.DoEvents();
            }
        }
        
        #region "Descargar"
        private void revisionClienteFactura(string Cliente)
        {
            bool encontrado = false;

            foreach (HtmlElement elementoTD in webSite.Document.GetElementsByTagName("TD"))
            {
                if (Cliente == elementoTD.InnerText.Trim())
                {
                    encontrado = true;

                    lblAccion.Text = "Obteniendo datos cliente " + Cliente;
                    Application.DoEvents();

                    PHP php = new PHP();
                    var resultData = php.GetData("https://servicios.aguakan.com/modulos/facturas/list_fact.php", "nocliente=" + Cliente);

                    if (resultData.Item1.Equals(1))
                    {
                        Archivos.grabaData(resultData.Item2.ToString());

                        procesaArchivo(Cliente);
                    }
                    else
                    {
                        Archivos.grabaLog("CLIENTE: " + Cliente + " || " + resultData.Item2.ToString());
                    }
                }
            }

            if (!encontrado)
            {
                Archivos.grabaLog("CLIENTE: " + Cliente + " || Descarga error: No se encontro el cliente");
            }
        }

        private void procesaArchivo(string Cliente)
        {
            StreamReader ORead = null;
            string Linea = "";

            string Referencia = "";
            string Fecha = "";
            string MesDescarga = (cmbMes.SelectedIndex + 1).ToString("00");
            int Contador = 1;

            ORead = File.OpenText(Archivos.ArchivoData);

            while (!ORead.EndOfStream)
            {
                Linea = ORead.ReadLine().Trim().ToString();

                if (Linea.Length > 0)
                {
                    if (Linea.ToUpper().Contains("<TD") && Contador < 4)
                    {
                        if (Contador.Equals(2))
                        {
                            Referencia = Linea.Substring(Linea.IndexOf(">") + 1, Linea.IndexOf("</td>") - 4);

                            if (Referencia == "")
                            {
                                break;
                            }
                        }

                        if (Contador.Equals(3))
                        {
                            Fecha = Linea.Substring(Linea.IndexOf(">") + 1, Linea.IndexOf("</td>") - (Linea.IndexOf(">") + 1));

                            if (Fecha.Trim() == "</td>" || Fecha.Trim() == "")
                            {
                                Fecha = @"01/" + MesDescarga + @"/" + cmbAño.Text;
                            }

                            if (!Funcion.IsDate(Fecha))
                            {
                                break;
                            }

                            DateTime date = DateTime.Parse(Fecha);
                            if (int.Parse(cmbAño.Text) > date.Year || (int.Parse(cmbAño.Text) == date.Year && int.Parse(MesDescarga) > date.Month))
                            {
                                break;
                            }
                        }

                        Contador++;
                    }else if (Linea.ToUpper().Contains("<A CLASS=") && Contador.Equals(4)) {
                        DateTime date = DateTime.Parse(Fecha);
                        if (int.Parse(cmbAño.Text) == date.Year && int.Parse(MesDescarga) == date.Month)
                        {
                            string MyLink = "";

                            bool es_nuevo = false;
                            if (Linea.ToUpper().Contains("/NOTIFICACION/"))
                            {
                                es_nuevo = true;
                            }

                            if (Linea.ToUpper().Contains(">PDF<") || Linea.ToUpper().Contains(">XML<") || Linea.ToUpper().Contains(">BOLETA<"))
                            {
                                if (es_nuevo)
                                {
                                    MyLink = Linea.Substring(Linea.IndexOf("/?pdf=") + 6, (Linea.IndexOf("target") - Linea.IndexOf("/?pdf=")) - 8).Trim();
                                }

                                downloadFile(Cliente, Referencia, es_nuevo, MyLink);
                            }

                            lblAccion.Text = "";
                            Application.DoEvents();
                        }

                        Contador = 1;
                    }
                }
            }

            // Cerramos el archivo
            ORead.Close();
        }

        private void downloadFile(string Cliente, string Referencia, bool es_nuevo, string Link)
        {
            string MyLink = "";
            ListViewItem OReg = new ListViewItem();
            string Archivo = "";
            string[] archivoDownload = { "-Factura.pdf", "-Factura.xml", "-Boleta.pdf", "-Historial.pdf" };

            if (Cliente == "" || Referencia == "")
            {
                return;
            }

            if (!Directory.Exists(RutaDescarga))
            {
                Directory.CreateDirectory(RutaDescarga);
            }

            // Pasamos las cookies del webBrowser para mantener la session
            WebClient MyWC = new WebClient();
            MyWC.Headers.Add(HttpRequestHeader.Cookie, webSite.Document.Cookie);

            OReg = lstReferencia.Items.Add(Cliente);
            OReg.SubItems.Add(Referencia);

            // PDF
            if (chkPDF.Checked)
            {
                lblAccion.Text = "Descargando " + archivoDownload[0] + " Cliente "+ Cliente;
                Application.DoEvents();

                // Eliminamos el archivo si existe
                if (File.Exists(RutaDescarga + Cliente + "-" + Referencia + archivoDownload[0]))
                {
                    File.Delete(RutaDescarga + Cliente + "-" + Referencia + archivoDownload[0]);
                }

                if (es_nuevo)
                {
                    MyLink = "https://www.aguakan.com/fmt/cfd.php?cadena=" + Link;
                }
                else
                {
                    MyLink = "https://servicios.aguakan.com/modulos/facturas/getPDF.php?ref_fact=" + Referencia;
                }

                MyWC.DownloadFile(MyLink, RutaDescarga + Cliente + "-" + Referencia + archivoDownload[0]);

                Archivo += ", " + archivoDownload[0];
                OReg.SubItems.Add("Factura");
                OReg.SubItems.Add(Cliente + "-" + Referencia + archivoDownload[0]);
            }

            // XML
            if (chkXML.Checked)
            {
                lblAccion.Text = "Descargando " + archivoDownload[1] + " Cliente " + Cliente;
                Application.DoEvents();

                // Eliminamos el archivo si existe
                if (File.Exists(RutaDescarga + Cliente + "-" + Referencia + archivoDownload[1]))
                {
                    File.Delete(RutaDescarga + Cliente + "-" + Referencia + archivoDownload[1]);
                }

                if (es_nuevo)
                {
                    MyLink = "https://www.aguakan.com/notificacion/?xml=" + Link;
                }
                else
                {
                    MyLink = "https://servicios.aguakan.com//modulos/facturas/getXML.php?ref_fact=" + Referencia;
                }

                MyWC.DownloadFile(MyLink, RutaDescarga + Cliente + "-" + Referencia + archivoDownload[1]);

                Archivo += ", " + archivoDownload[1];
                OReg.SubItems.Add("XML");
                OReg.SubItems.Add(Cliente + "-" + Referencia + archivoDownload[1]);
            }

            // Boleta
            if (chkBoleta.Checked)
            {
                lblAccion.Text = "Descargando " + archivoDownload[2] + " Cliente " + Cliente;
                Application.DoEvents();

                // Eliminamos el archivo si existe
                if (File.Exists(RutaDescarga + Cliente + "-" + Referencia + archivoDownload[2]))
                {
                    File.Delete(RutaDescarga + Cliente + "-" + Referencia + archivoDownload[2]);
                }

                if (es_nuevo)
                {
                    MyLink = "https://servicios.aguakan.com//modulos/facturas/getBoleta.php?factura=" + Referencia;
                }
                else
                {
                    MyLink = "https://servicios.aguakan.com/modulos/facturas/getBoleta.php?factura=" + Referencia;
                }

                MyWC.DownloadFile(MyLink, RutaDescarga + Cliente + "-" + Referencia + archivoDownload[2]);

                Archivo += ", " + archivoDownload[2];
                OReg.SubItems.Add("Boleta");
                OReg.SubItems.Add(Cliente + "-" + Referencia + archivoDownload[2]);
            }

            // Historial
            if (chkHistorial.Checked)
            {
                lblAccion.Text = "Descargando " + archivoDownload[3] + " Cliente " + Cliente;
                Application.DoEvents();

                // Eliminamos el archivo si existe
                if (File.Exists(RutaDescarga + Cliente + "-" + Referencia + archivoDownload[3]))
                {
                    File.Delete(RutaDescarga + Cliente + "-" + Referencia + archivoDownload[3]);
                }

                if (es_nuevo)
                {
                    MyLink = "https://servicios.aguakan.com/modulos/estadocuenta/getCuenta.php?cliente=" + Cliente;
                }
                else
                {
                    MyLink = "https://servicios.aguakan.com/modulos/estadocuenta/getCuenta.php?cliente=" + Cliente;
                }

                MyWC.DownloadFile(MyLink, RutaDescarga + Cliente + "-" + Referencia + archivoDownload[3]);

                Archivo += ", " + archivoDownload[3];
                OReg.SubItems.Add("Historial");
                OReg.SubItems.Add(Cliente + "-" + Referencia + archivoDownload[3]);
            }


            if (Archivo != "")
            {
                Archivos.grabaLog("CLIENTE: " + Cliente + " || Descarga de archivos: Se descargaron los siguientes archivos" + Archivo);
            }
        }
        #endregion

        #region "Eliminar"
        private void revisionClienteDelete()
        {
            bool encontrado = false;

            foreach (HtmlElement elementoTD in webSite.Document.GetElementsByTagName("TD"))
            {
                lblAccion.Text = "Buscando clientes";
                Application.DoEvents();

                if (elementoTD.OuterHtml.Contains("No. Cliente"))
                {
                    encontrado = true;

                    string Cliente = ((HtmlElement)(elementoTD)).InnerText.Trim();
                    if (Cliente != "" && Funcion.IsNumeric(Cliente))
                    {
                        lblAccion.Text = "Eliminando cliente " + Cliente;
                        Application.DoEvents();

                        eliminarCliente(Cliente);
                    }
                }
            }

            if (!encontrado)
            {
                Archivos.grabaLog("Eliminar error: No se encontro ningún cliente");
            }
        }

        private void eliminarCliente(string Cliente)
        {
            bool encontrado = false;

            foreach (HtmlElement elementInput in webSite.Document.GetElementsByTagName("input"))
            {
                if (elementInput.OuterHtml.Contains(@"class=""" + Cliente + @""""))
                {
                    if (elementInput.OuterHtml.Contains(@"name=""id_contrato"""))
                    {
                        encontrado = true;

                        string value = elementInput.GetAttribute("value");
                        PHP php = new PHP();
                        var resultPHP = php.GetData("https://servicios.aguakan.com/modulos/contratos/borrar.php", "IDTCONTRATO=" + value);
                        if (resultPHP.Item1.Equals(1))
                        {
                            Archivos.grabaLog("CLIENTE: " + Cliente + " || Cliente eliminado: El cliente fue eliminado exitosamente");

                            System.Threading.Thread.Sleep(1000);

                            break;
                        }
                        else
                        {
                            Archivos.grabaLog("CLIENTE: " + Cliente + " || " + resultPHP.Item2.ToString());
                        }
                    }
                }
            }

            if (!encontrado)
            {
                Archivos.grabaLog("CLIENTE: " + Cliente + " || Eliminar error: No se encontro el cliente");
            }
        }
        #endregion

        private void iniciarSesion()
        {
            try
            {
                lblAccion.Text = "Iniciando sesión...";
                Application.DoEvents();

                webSite.Navigate("https://servicios.aguakan.com/modulos/login/login.php");
                while (webSite.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }

                HtmlElement txtEmail = webSite.Document.GetElementById("EMAIL");
                HtmlElement txtPass = webSite.Document.GetElementById("password");
                HtmlElement btnLogin = webSite.Document.GetElementById("boton-sesion");

                txtEmail.SetAttribute("value", email);
                txtPass.SetAttribute("value", password);
                btnLogin.InvokeMember("click");

                //webSite.Document.GetElementById("EMAIL").Focus();
                //webSite.Document.GetElementById("EMAIL").InnerText = email;
                //webSite.Document.GetElementById("EMAIL").RemoveFocus();

                //webSite.Document.GetElementById("password").Focus();
                //webSite.Document.GetElementById("password").InnerText = password;
                //webSite.Document.GetElementById("password").RemoveFocus();

                //Application.DoEvents();

                //webSite.Document.GetElementById("boton-sesion").Focus();
                //webSite.Document.GetElementById("boton-sesion").InvokeMember("click");
                //Application.DoEvents();

                lblAccion.Text = "Redirigiendo...";
                Application.DoEvents();

                webSite.Navigate("https://servicios.aguakan.com/");
                while (webSite.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }

                //string nombreInicio = "";
                //foreach (HtmlElement elementoDiv in webSite.Document.GetElementsByTagName("div"))
                //{
                //    if (elementoDiv.OuterHtml.Contains("id=\"nombreinicio\""))
                //    {
                //        foreach (HtmlElement elementoSpan in elementoDiv.GetElementsByTagName("span"))
                //        {
                //            nombreInicio = ((HtmlElement)(elementoSpan)).InnerText.Trim();

                //            break;
                //        }

                //        if ((nombreInicio != ""))
                //        {
                //            break;
                //        }
                //    }
                //}
            }
            catch
            {

            }
        }

        private void cerrarSesion()
        {
            lblAccion.Text = "Cerrando sesión...";
            Application.DoEvents();

            if (webSite.Document != null)
            {
                if (webSite.Document.Title.ToUpper().Trim() != "AGUAKAN")
                {
                    try
                    {
                        int cont = webSite.Document.Cookie.Length;
                        webSite.Document.Cookie.Remove(0, cont);
                        webSite.Document.Cookie = null;

                        webSite.Navigate("https://servicios.aguakan.com/modulos/login/logout");
                        Application.DoEvents();
                    }
                    catch
                    {

                    }
                }
            }
        }

        private void ctrlActiva(bool valor)
        {
            chkManual.Enabled = valor;
            txtData.Enabled = valor;
            lstData.Enabled = valor;

            cmbAño.Enabled = valor;
            cmbMes.Enabled = valor;

            chkPDF.Enabled = valor;
            chkXML.Enabled = valor;
            chkBoleta.Enabled = valor;
            chkHistorial.Enabled = valor;

            btnIniciar.Enabled = valor;

            lstReferencia.Items.Clear();

            pBar.Value = 0;
            w7.Value = 0;
            pBar.Maximum = lstData.Items.Count;
            w7.Maximum = lstData.Items.Count;

            //pBar.Visible = !valor;
            w7.Visible = false;
            w7.Style = ProgressBarStyle.Blocks;

            Application.DoEvents();
        }
    }
}
