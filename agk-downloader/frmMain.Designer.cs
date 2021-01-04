namespace agk_downloader
{
    partial class frmMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.frameData = new System.Windows.Forms.GroupBox();
            this.btnFile = new System.Windows.Forms.Button();
            this.txtData = new System.Windows.Forms.TextBox();
            this.lblFle = new System.Windows.Forms.Label();
            this.lstData = new System.Windows.Forms.ListView();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCod = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chkManual = new System.Windows.Forms.CheckBox();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.picStatus = new System.Windows.Forms.PictureBox();
            this.chkVincular = new System.Windows.Forms.Button();
            this.chkDescargar = new System.Windows.Forms.Button();
            this.chkEliminar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.barStatus = new System.Windows.Forms.StatusStrip();
            this.lblAccion = new System.Windows.Forms.ToolStripStatusLabel();
            this.pBar = new System.Windows.Forms.ToolStripProgressBar();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.lblAño = new System.Windows.Forms.Label();
            this.cmbAño = new System.Windows.Forms.ComboBox();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.lblMes = new System.Windows.Forms.Label();
            this.frameFiles = new System.Windows.Forms.GroupBox();
            this.chkHistorial = new System.Windows.Forms.CheckBox();
            this.chkBoleta = new System.Windows.Forms.CheckBox();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.chkPDF = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.webSite = new System.Windows.Forms.WebBrowser();
            this.w7 = new wyDay.Controls.Windows7ProgressBar();
            this.frameData.SuspendLayout();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).BeginInit();
            this.barStatus.SuspendLayout();
            this.frameFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // frameData
            // 
            this.frameData.Controls.Add(this.btnFile);
            this.frameData.Controls.Add(this.txtData);
            this.frameData.Controls.Add(this.lblFle);
            this.frameData.Controls.Add(this.lstData);
            this.frameData.Controls.Add(this.chkManual);
            this.frameData.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frameData.Location = new System.Drawing.Point(132, 11);
            this.frameData.Name = "frameData";
            this.frameData.Size = new System.Drawing.Size(318, 272);
            this.frameData.TabIndex = 3;
            this.frameData.TabStop = false;
            this.frameData.Text = "Datos : ";
            // 
            // btnFile
            // 
            this.btnFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(153)))), ((int)(((byte)(84)))));
            this.btnFile.FlatAppearance.BorderSize = 0;
            this.btnFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFile.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFile.ForeColor = System.Drawing.Color.White;
            this.btnFile.Location = new System.Drawing.Point(282, 58);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(30, 29);
            this.btnFile.TabIndex = 4;
            this.btnFile.Text = "...";
            this.toolTip.SetToolTip(this.btnFile, "Seleccionar layout");
            this.btnFile.UseVisualStyleBackColor = false;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // txtData
            // 
            this.txtData.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtData.Location = new System.Drawing.Point(68, 62);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(208, 25);
            this.txtData.TabIndex = 3;
            this.txtData.Text = "Seleccione archivo de layout";
            this.txtData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtData_KeyPress);
            // 
            // lblFle
            // 
            this.lblFle.AutoSize = true;
            this.lblFle.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFle.Location = new System.Drawing.Point(6, 65);
            this.lblFle.Name = "lblFle";
            this.lblFle.Size = new System.Drawing.Size(56, 17);
            this.lblFle.TabIndex = 2;
            this.lblFle.Text = "Archivo :";
            // 
            // lstData
            // 
            this.lstData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colCod,
            this.colNia});
            this.lstData.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstData.FullRowSelect = true;
            this.lstData.GridLines = true;
            this.lstData.Location = new System.Drawing.Point(6, 93);
            this.lstData.Name = "lstData";
            this.lstData.Size = new System.Drawing.Size(306, 173);
            this.lstData.TabIndex = 1;
            this.lstData.UseCompatibleStateImageBehavior = false;
            this.lstData.View = System.Windows.Forms.View.Details;
            this.lstData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstData_KeyDown);
            // 
            // colID
            // 
            this.colID.Text = "";
            this.colID.Width = 0;
            // 
            // colCod
            // 
            this.colCod.Text = "Cod. Cliente";
            this.colCod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colCod.Width = 100;
            // 
            // colNia
            // 
            this.colNia.Text = "NIA";
            this.colNia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colNia.Width = 180;
            // 
            // chkManual
            // 
            this.chkManual.AutoSize = true;
            this.chkManual.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkManual.Location = new System.Drawing.Point(103, 24);
            this.chkManual.Name = "chkManual";
            this.chkManual.Size = new System.Drawing.Size(117, 21);
            this.chkManual.TabIndex = 0;
            this.chkManual.Text = "Agregar manual";
            this.chkManual.UseVisualStyleBackColor = true;
            this.chkManual.CheckedChanged += new System.EventHandler(this.chkManual_CheckedChanged);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(42)))));
            this.panelMenu.Controls.Add(this.label1);
            this.panelMenu.Controls.Add(this.pictureBox1);
            this.panelMenu.Controls.Add(this.btnSalir);
            this.panelMenu.Controls.Add(this.picStatus);
            this.panelMenu.Controls.Add(this.chkVincular);
            this.panelMenu.Controls.Add(this.chkDescargar);
            this.panelMenu.Controls.Add(this.chkEliminar);
            this.panelMenu.Controls.Add(this.label2);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(120, 470);
            this.panelMenu.TabIndex = 4;
            this.panelMenu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelMenu_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "___________________";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSalir.Location = new System.Drawing.Point(0, 434);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(120, 36);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // picStatus
            // 
            this.picStatus.BackColor = System.Drawing.Color.Transparent;
            this.picStatus.Image = ((System.Drawing.Image)(resources.GetObject("picStatus.Image")));
            this.picStatus.Location = new System.Drawing.Point(96, 232);
            this.picStatus.Name = "picStatus";
            this.picStatus.Size = new System.Drawing.Size(36, 36);
            this.picStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picStatus.TabIndex = 2;
            this.picStatus.TabStop = false;
            // 
            // chkVincular
            // 
            this.chkVincular.FlatAppearance.BorderSize = 0;
            this.chkVincular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkVincular.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVincular.ForeColor = System.Drawing.Color.White;
            this.chkVincular.Image = ((System.Drawing.Image)(resources.GetObject("chkVincular.Image")));
            this.chkVincular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkVincular.Location = new System.Drawing.Point(0, 190);
            this.chkVincular.Name = "chkVincular";
            this.chkVincular.Size = new System.Drawing.Size(120, 36);
            this.chkVincular.TabIndex = 1;
            this.chkVincular.Tag = "1";
            this.chkVincular.Text = "Vincular";
            this.chkVincular.UseVisualStyleBackColor = true;
            this.chkVincular.Click += new System.EventHandler(this.chkVincular_Click);
            // 
            // chkDescargar
            // 
            this.chkDescargar.FlatAppearance.BorderSize = 0;
            this.chkDescargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkDescargar.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDescargar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(153)))), ((int)(((byte)(84)))));
            this.chkDescargar.Image = ((System.Drawing.Image)(resources.GetObject("chkDescargar.Image")));
            this.chkDescargar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkDescargar.Location = new System.Drawing.Point(0, 232);
            this.chkDescargar.Name = "chkDescargar";
            this.chkDescargar.Size = new System.Drawing.Size(120, 36);
            this.chkDescargar.TabIndex = 3;
            this.chkDescargar.Tag = "2";
            this.chkDescargar.Text = "  Descargar";
            this.chkDescargar.UseVisualStyleBackColor = true;
            this.chkDescargar.Click += new System.EventHandler(this.chkDescargar_Click);
            // 
            // chkEliminar
            // 
            this.chkEliminar.FlatAppearance.BorderSize = 0;
            this.chkEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkEliminar.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEliminar.ForeColor = System.Drawing.Color.White;
            this.chkEliminar.Image = ((System.Drawing.Image)(resources.GetObject("chkEliminar.Image")));
            this.chkEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkEliminar.Location = new System.Drawing.Point(0, 275);
            this.chkEliminar.Name = "chkEliminar";
            this.chkEliminar.Size = new System.Drawing.Size(120, 36);
            this.chkEliminar.TabIndex = 4;
            this.chkEliminar.Tag = "3";
            this.chkEliminar.Text = "Eliminar";
            this.chkEliminar.UseVisualStyleBackColor = true;
            this.chkEliminar.Click += new System.EventHandler(this.chkEliminar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "___________________";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // barStatus
            // 
            this.barStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblAccion,
            this.pBar});
            this.barStatus.Location = new System.Drawing.Point(120, 446);
            this.barStatus.Name = "barStatus";
            this.barStatus.Size = new System.Drawing.Size(346, 24);
            this.barStatus.TabIndex = 5;
            this.barStatus.Text = "statusStrip1";
            // 
            // lblAccion
            // 
            this.lblAccion.AutoSize = false;
            this.lblAccion.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblAccion.Name = "lblAccion";
            this.lblAccion.Size = new System.Drawing.Size(191, 19);
            this.lblAccion.Spring = true;
            this.lblAccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pBar
            // 
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(100, 18);
            // 
            // btnIniciar
            // 
            this.btnIniciar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(166)))));
            this.btnIniciar.FlatAppearance.BorderSize = 0;
            this.btnIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciar.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciar.ForeColor = System.Drawing.Color.White;
            this.btnIniciar.Location = new System.Drawing.Point(132, 400);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(318, 36);
            this.btnIniciar.TabIndex = 6;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = false;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // lblAño
            // 
            this.lblAño.AutoSize = true;
            this.lblAño.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAño.Location = new System.Drawing.Point(138, 301);
            this.lblAño.Name = "lblAño";
            this.lblAño.Size = new System.Drawing.Size(37, 17);
            this.lblAño.TabIndex = 7;
            this.lblAño.Text = "Año :";
            // 
            // cmbAño
            // 
            this.cmbAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAño.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbAño.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAño.FormattingEnabled = true;
            this.cmbAño.Location = new System.Drawing.Point(181, 298);
            this.cmbAño.Name = "cmbAño";
            this.cmbAño.Size = new System.Drawing.Size(62, 25);
            this.cmbAño.TabIndex = 8;
            // 
            // cmbMes
            // 
            this.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbMes.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.cmbMes.Location = new System.Drawing.Point(312, 298);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(132, 25);
            this.cmbMes.TabIndex = 10;
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes.Location = new System.Drawing.Point(268, 302);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(38, 17);
            this.lblMes.TabIndex = 9;
            this.lblMes.Text = "Mes :";
            // 
            // frameFiles
            // 
            this.frameFiles.Controls.Add(this.chkHistorial);
            this.frameFiles.Controls.Add(this.chkBoleta);
            this.frameFiles.Controls.Add(this.chkXML);
            this.frameFiles.Controls.Add(this.chkPDF);
            this.frameFiles.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frameFiles.Location = new System.Drawing.Point(132, 331);
            this.frameFiles.Name = "frameFiles";
            this.frameFiles.Size = new System.Drawing.Size(318, 56);
            this.frameFiles.TabIndex = 11;
            this.frameFiles.TabStop = false;
            // 
            // chkHistorial
            // 
            this.chkHistorial.AutoSize = true;
            this.chkHistorial.Location = new System.Drawing.Point(237, 24);
            this.chkHistorial.Name = "chkHistorial";
            this.chkHistorial.Size = new System.Drawing.Size(75, 21);
            this.chkHistorial.TabIndex = 3;
            this.chkHistorial.Text = "Historial";
            this.toolTip.SetToolTip(this.chkHistorial, "Descargar Historial");
            this.chkHistorial.UseVisualStyleBackColor = true;
            // 
            // chkBoleta
            // 
            this.chkBoleta.AutoSize = true;
            this.chkBoleta.Location = new System.Drawing.Point(156, 24);
            this.chkBoleta.Name = "chkBoleta";
            this.chkBoleta.Size = new System.Drawing.Size(63, 21);
            this.chkBoleta.TabIndex = 2;
            this.chkBoleta.Text = "Boleta";
            this.toolTip.SetToolTip(this.chkBoleta, "Descargar Boleta");
            this.chkBoleta.UseVisualStyleBackColor = true;
            // 
            // chkXML
            // 
            this.chkXML.AutoSize = true;
            this.chkXML.Location = new System.Drawing.Point(80, 24);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(53, 21);
            this.chkXML.TabIndex = 1;
            this.chkXML.Text = "XML";
            this.toolTip.SetToolTip(this.chkXML, "Descargar XML");
            this.chkXML.UseVisualStyleBackColor = true;
            // 
            // chkPDF
            // 
            this.chkPDF.AutoSize = true;
            this.chkPDF.Location = new System.Drawing.Point(13, 24);
            this.chkPDF.Name = "chkPDF";
            this.chkPDF.Size = new System.Drawing.Size(49, 21);
            this.chkPDF.TabIndex = 0;
            this.chkPDF.Text = "PDF";
            this.toolTip.SetToolTip(this.chkPDF, "Descargar PDF");
            this.chkPDF.UseVisualStyleBackColor = true;
            // 
            // toolTip
            // 
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip.ToolTipTitle = "Agk Downloader";
            // 
            // webSite
            // 
            this.webSite.Location = new System.Drawing.Point(446, 0);
            this.webSite.MinimumSize = new System.Drawing.Size(20, 20);
            this.webSite.Name = "webSite";
            this.webSite.ScriptErrorsSuppressed = true;
            this.webSite.Size = new System.Drawing.Size(20, 20);
            this.webSite.TabIndex = 5;
            this.webSite.Visible = false;
            // 
            // w7
            // 
            this.w7.ContainerControl = this;
            this.w7.Location = new System.Drawing.Point(132, 285);
            this.w7.Name = "w7";
            this.w7.ShowInTaskbar = true;
            this.w7.Size = new System.Drawing.Size(318, 10);
            this.w7.TabIndex = 12;
            this.w7.Visible = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 470);
            this.Controls.Add(this.w7);
            this.Controls.Add(this.webSite);
            this.Controls.Add(this.frameFiles);
            this.Controls.Add(this.cmbMes);
            this.Controls.Add(this.lblMes);
            this.Controls.Add(this.cmbAño);
            this.Controls.Add(this.lblAño);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.barStatus);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.frameData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agk Downloader";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseMove);
            this.frameData.ResumeLayout(false);
            this.frameData.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).EndInit();
            this.barStatus.ResumeLayout(false);
            this.barStatus.PerformLayout();
            this.frameFiles.ResumeLayout(false);
            this.frameFiles.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox frameData;
        private System.Windows.Forms.CheckBox chkManual;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.StatusStrip barStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblAccion;
        private System.Windows.Forms.ToolStripProgressBar pBar;
        private System.Windows.Forms.PictureBox picStatus;
        private System.Windows.Forms.Button chkVincular;
        private System.Windows.Forms.Button chkDescargar;
        private System.Windows.Forms.Button chkEliminar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ListView lstData;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label lblFle;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colCod;
        private System.Windows.Forms.ColumnHeader colNia;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Label lblAño;
        private System.Windows.Forms.ComboBox cmbAño;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.GroupBox frameFiles;
        private System.Windows.Forms.CheckBox chkHistorial;
        private System.Windows.Forms.CheckBox chkBoleta;
        private System.Windows.Forms.CheckBox chkXML;
        private System.Windows.Forms.CheckBox chkPDF;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.WebBrowser webSite;
        private wyDay.Controls.Windows7ProgressBar w7;
    }
}

