namespace elektronikNapajalnik
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.dataGridVrednosti = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelZnakUpor = new System.Windows.Forms.Label();
            this.labelZnakMoc = new System.Windows.Forms.Label();
            this.labelZnakAmp = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.buttonPobrisi = new System.Windows.Forms.Button();
            this.btnClearMINtok = new System.Windows.Forms.Button();
            this.btnClearMAXtok = new System.Windows.Forms.Button();
            this.textBoxMAXtimeTok = new System.Windows.Forms.TextBox();
            this.textBoxMINtimeTok = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBoxMINtok = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBoxMAXtok = new System.Windows.Forms.TextBox();
            this.btnClearMINnap = new System.Windows.Forms.Button();
            this.btnClearMAXnap = new System.Windows.Forms.Button();
            this.comboBoxInterval = new System.Windows.Forms.ComboBox();
            this.textBoxMAXtimeNap = new System.Windows.Forms.TextBox();
            this.textBoxMINtimeNap = new System.Windows.Forms.TextBox();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.textBoxMINnap = new System.Windows.Forms.TextBox();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.textBoxMAXnap = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.radioButtonLimitOFF = new System.Windows.Forms.RadioButton();
            this.radioButtonLimitON = new System.Windows.Forms.RadioButton();
            this.checkBoxAutoNap = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoTok = new System.Windows.Forms.CheckBox();
            this.btnNastaviNap = new System.Windows.Forms.Button();
            this.btnNastaviTok = new System.Windows.Forms.Button();
            this.btnIzhod = new System.Windows.Forms.Button();
            this.btConnect = new System.Windows.Forms.Button();
            this.comPortSelect = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Napetost = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Tok = new System.Windows.Forms.TabPage();
            this.labelTOKznak = new System.Windows.Forms.Label();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Moč = new System.Windows.Forms.TabPage();
            this.labelMOCznak = new System.Windows.Forms.Label();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.UI = new System.Windows.Forms.TabPage();
            this.buttonUIstart = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.labelTOKUInum = new System.Windows.Forms.Label();
            this.numUI_Imax = new System.Windows.Forms.NumericUpDown();
            this.numUI_Uinterval = new System.Windows.Forms.NumericUpDown();
            this.numUI_Iinterval = new System.Windows.Forms.NumericUpDown();
            this.numUI_Umax = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.labelTokUI = new System.Windows.Forms.Label();
            this.chart4 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.sliderTok = new System.Windows.Forms.TrackBar();
            this.sliderUlimit = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelUlimitNastavljena = new System.Windows.Forms.Label();
            this.labelUnastavljena = new System.Windows.Forms.Label();
            this.labelInastavljen = new System.Windows.Forms.Label();
            this.labelUtrenutna = new System.Windows.Forms.Label();
            this.labelItrenutni = new System.Windows.Forms.Label();
            this.labelUlimitTrenutni = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.ip = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelElektronik = new System.Windows.Forms.Label();
            this.buttonNastaviLimit = new System.Windows.Forms.Button();
            this.checkBoxAutoLimit = new System.Windows.Forms.CheckBox();
            this.buttonClearData = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.numTableInterval = new System.Windows.Forms.NumericUpDown();
            this.buttonShraniTable = new System.Windows.Forms.Button();
            this.buttonStartTable = new System.Windows.Forms.Button();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.sliderNapetost = new System.Windows.Forms.TrackBar();
            this.numUlimit = new System.Windows.Forms.NumericUpDown();
            this.numU = new System.Windows.Forms.NumericUpDown();
            this.numI = new System.Windows.Forms.NumericUpDown();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.btnSlave = new System.Windows.Forms.Button();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.picBoxPikaMoc = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.upoBox4 = new System.Windows.Forms.PictureBox();
            this.upoBox1 = new System.Windows.Forms.PictureBox();
            this.upoBox3 = new System.Windows.Forms.PictureBox();
            this.upoBox2 = new System.Windows.Forms.PictureBox();
            this.mocBox4 = new System.Windows.Forms.PictureBox();
            this.mocBox1 = new System.Windows.Forms.PictureBox();
            this.mocBox3 = new System.Windows.Forms.PictureBox();
            this.mocBox2 = new System.Windows.Forms.PictureBox();
            this.tokBox3 = new System.Windows.Forms.PictureBox();
            this.napBox4 = new System.Windows.Forms.PictureBox();
            this.tokBox2 = new System.Windows.Forms.PictureBox();
            this.picBoxPikaTok = new System.Windows.Forms.PictureBox();
            this.tokBox1 = new System.Windows.Forms.PictureBox();
            this.napBox1 = new System.Windows.Forms.PictureBox();
            this.napBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox26 = new System.Windows.Forms.PictureBox();
            this.napBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.comboBoxComSlave = new System.Windows.Forms.ComboBox();
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVrednosti)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.Napetost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.Tok.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.Moč.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            this.UI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUI_Imax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUI_Uinterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUI_Iinterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUI_Umax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderTok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderUlimit)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTableInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderNapetost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUlimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPikaMoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upoBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upoBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upoBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upoBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mocBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mocBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mocBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mocBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tokBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.napBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tokBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPikaTok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tokBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.napBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.napBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.napBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 38400;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // dataGridVrednosti
            // 
            this.dataGridVrednosti.AllowUserToAddRows = false;
            this.dataGridVrednosti.AllowUserToResizeColumns = false;
            this.dataGridVrednosti.AllowUserToResizeRows = false;
            this.dataGridVrednosti.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridVrednosti.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridVrednosti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridVrednosti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridVrednosti.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridVrednosti.Location = new System.Drawing.Point(541, 0);
            this.dataGridVrednosti.MultiSelect = false;
            this.dataGridVrednosti.Name = "dataGridVrednosti";
            this.dataGridVrednosti.ReadOnly = true;
            this.dataGridVrednosti.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridVrednosti.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridVrednosti.RowHeadersVisible = false;
            this.dataGridVrednosti.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridVrednosti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridVrednosti.ShowCellErrors = false;
            this.dataGridVrednosti.ShowCellToolTips = false;
            this.dataGridVrednosti.ShowEditingIcon = false;
            this.dataGridVrednosti.ShowRowErrors = false;
            this.dataGridVrednosti.Size = new System.Drawing.Size(225, 306);
            this.dataGridVrednosti.TabIndex = 105;
            this.dataGridVrednosti.TabStop = false;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column3.FillWeight = 70F;
            this.Column3.HeaderText = "Ura";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.Width = 70;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.FillWeight = 75F;
            this.Column1.HeaderText = "Napetost";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.Width = 75;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column2.FillWeight = 75F;
            this.Column2.HeaderText = "Tok";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.Width = 75;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 70F;
            this.Column4.HeaderText = "Moč";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column4.Width = 70;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 70F;
            this.Column5.HeaderText = "Upornost";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column5.Width = 70;
            // 
            // labelZnakUpor
            // 
            this.labelZnakUpor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.labelZnakUpor.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelZnakUpor.Location = new System.Drawing.Point(695, 417);
            this.labelZnakUpor.Margin = new System.Windows.Forms.Padding(0);
            this.labelZnakUpor.Name = "labelZnakUpor";
            this.labelZnakUpor.Size = new System.Drawing.Size(80, 41);
            this.labelZnakUpor.TabIndex = 160;
            this.labelZnakUpor.Text = "Ω";
            // 
            // labelZnakMoc
            // 
            this.labelZnakMoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.labelZnakMoc.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelZnakMoc.Location = new System.Drawing.Point(692, 588);
            this.labelZnakMoc.Margin = new System.Windows.Forms.Padding(0);
            this.labelZnakMoc.Name = "labelZnakMoc";
            this.labelZnakMoc.Size = new System.Drawing.Size(85, 38);
            this.labelZnakMoc.TabIndex = 155;
            this.labelZnakMoc.Text = "W";
            // 
            // labelZnakAmp
            // 
            this.labelZnakAmp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.labelZnakAmp.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelZnakAmp.Location = new System.Drawing.Point(695, 529);
            this.labelZnakAmp.Margin = new System.Windows.Forms.Padding(0);
            this.labelZnakAmp.Name = "labelZnakAmp";
            this.labelZnakAmp.Size = new System.Drawing.Size(82, 43);
            this.labelZnakAmp.TabIndex = 150;
            this.labelZnakAmp.Text = "A";
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.label18.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label18.Location = new System.Drawing.Point(695, 472);
            this.label18.Margin = new System.Windows.Forms.Padding(0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(82, 45);
            this.label18.TabIndex = 148;
            this.label18.Text = "V";
            // 
            // buttonPobrisi
            // 
            this.buttonPobrisi.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonPobrisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPobrisi.Location = new System.Drawing.Point(463, 403);
            this.buttonPobrisi.Name = "buttonPobrisi";
            this.buttonPobrisi.Size = new System.Drawing.Size(70, 23);
            this.buttonPobrisi.TabIndex = 213;
            this.buttonPobrisi.TabStop = false;
            this.buttonPobrisi.Text = "Pobriši graf";
            this.buttonPobrisi.UseVisualStyleBackColor = false;
            this.buttonPobrisi.Click += new System.EventHandler(this.buttonPobrisi_Click);
            // 
            // btnClearMINtok
            // 
            this.btnClearMINtok.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnClearMINtok.Location = new System.Drawing.Point(504, 464);
            this.btnClearMINtok.Name = "btnClearMINtok";
            this.btnClearMINtok.Size = new System.Drawing.Size(28, 20);
            this.btnClearMINtok.TabIndex = 212;
            this.btnClearMINtok.TabStop = false;
            this.btnClearMINtok.Text = "X";
            this.btnClearMINtok.UseVisualStyleBackColor = false;
            this.btnClearMINtok.Click += new System.EventHandler(this.btnClearMINtok_Click);
            // 
            // btnClearMAXtok
            // 
            this.btnClearMAXtok.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnClearMAXtok.Location = new System.Drawing.Point(504, 439);
            this.btnClearMAXtok.Name = "btnClearMAXtok";
            this.btnClearMAXtok.Size = new System.Drawing.Size(28, 20);
            this.btnClearMAXtok.TabIndex = 211;
            this.btnClearMAXtok.TabStop = false;
            this.btnClearMAXtok.Text = "X";
            this.btnClearMAXtok.UseVisualStyleBackColor = false;
            this.btnClearMAXtok.Click += new System.EventHandler(this.btnClearMAXtok_Click);
            // 
            // textBoxMAXtimeTok
            // 
            this.textBoxMAXtimeTok.Location = new System.Drawing.Point(436, 440);
            this.textBoxMAXtimeTok.Name = "textBoxMAXtimeTok";
            this.textBoxMAXtimeTok.ReadOnly = true;
            this.textBoxMAXtimeTok.Size = new System.Drawing.Size(65, 20);
            this.textBoxMAXtimeTok.TabIndex = 210;
            this.textBoxMAXtimeTok.TabStop = false;
            this.textBoxMAXtimeTok.Text = "00:00";
            this.textBoxMAXtimeTok.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxMINtimeTok
            // 
            this.textBoxMINtimeTok.Location = new System.Drawing.Point(436, 465);
            this.textBoxMINtimeTok.Name = "textBoxMINtimeTok";
            this.textBoxMINtimeTok.ReadOnly = true;
            this.textBoxMINtimeTok.Size = new System.Drawing.Size(65, 20);
            this.textBoxMINtimeTok.TabIndex = 209;
            this.textBoxMINtimeTok.TabStop = false;
            this.textBoxMINtimeTok.Text = "00:00";
            this.textBoxMINtimeTok.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox7.Location = new System.Drawing.Point(390, 463);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(45, 25);
            this.textBox7.TabIndex = 208;
            this.textBox7.TabStop = false;
            this.textBox7.Text = "Ura:";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox8.Location = new System.Drawing.Point(390, 437);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(45, 25);
            this.textBox8.TabIndex = 207;
            this.textBox8.TabStop = false;
            this.textBox8.Text = "Ura:";
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox9.Location = new System.Drawing.Point(274, 463);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(45, 25);
            this.textBox9.TabIndex = 206;
            this.textBox9.TabStop = false;
            this.textBox9.Text = "MIN:";
            this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxMINtok
            // 
            this.textBoxMINtok.Location = new System.Drawing.Point(320, 466);
            this.textBoxMINtok.Name = "textBoxMINtok";
            this.textBoxMINtok.ReadOnly = true;
            this.textBoxMINtok.Size = new System.Drawing.Size(65, 20);
            this.textBoxMINtok.TabIndex = 205;
            this.textBoxMINtok.TabStop = false;
            this.textBoxMINtok.Text = "0,00A";
            this.textBoxMINtok.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox11
            // 
            this.textBox11.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox11.Location = new System.Drawing.Point(274, 437);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(45, 25);
            this.textBox11.TabIndex = 204;
            this.textBox11.TabStop = false;
            this.textBox11.Text = "MAX:";
            this.textBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxMAXtok
            // 
            this.textBoxMAXtok.Location = new System.Drawing.Point(320, 440);
            this.textBoxMAXtok.Name = "textBoxMAXtok";
            this.textBoxMAXtok.ReadOnly = true;
            this.textBoxMAXtok.Size = new System.Drawing.Size(65, 20);
            this.textBoxMAXtok.TabIndex = 203;
            this.textBoxMAXtok.TabStop = false;
            this.textBoxMAXtok.Text = "0,00A";
            this.textBoxMAXtok.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnClearMINnap
            // 
            this.btnClearMINnap.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnClearMINnap.Location = new System.Drawing.Point(237, 464);
            this.btnClearMINnap.Name = "btnClearMINnap";
            this.btnClearMINnap.Size = new System.Drawing.Size(28, 20);
            this.btnClearMINnap.TabIndex = 202;
            this.btnClearMINnap.TabStop = false;
            this.btnClearMINnap.Text = "X";
            this.btnClearMINnap.UseVisualStyleBackColor = false;
            this.btnClearMINnap.Click += new System.EventHandler(this.btnClearMINnap_Click);
            // 
            // btnClearMAXnap
            // 
            this.btnClearMAXnap.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnClearMAXnap.Location = new System.Drawing.Point(237, 439);
            this.btnClearMAXnap.Name = "btnClearMAXnap";
            this.btnClearMAXnap.Size = new System.Drawing.Size(28, 20);
            this.btnClearMAXnap.TabIndex = 201;
            this.btnClearMAXnap.TabStop = false;
            this.btnClearMAXnap.Text = "X";
            this.btnClearMAXnap.UseVisualStyleBackColor = false;
            this.btnClearMAXnap.Click += new System.EventHandler(this.btnClearMAXnap_Click);
            // 
            // comboBoxInterval
            // 
            this.comboBoxInterval.BackColor = System.Drawing.SystemColors.ControlLight;
            this.comboBoxInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxInterval.FormattingEnabled = true;
            this.comboBoxInterval.Items.AddRange(new object[] {
            "15 sek",
            "30 sek",
            "1 min",
            "5 min",
            "10 min",
            "30 min",
            "1 h"});
            this.comboBoxInterval.Location = new System.Drawing.Point(385, 404);
            this.comboBoxInterval.Name = "comboBoxInterval";
            this.comboBoxInterval.Size = new System.Drawing.Size(70, 21);
            this.comboBoxInterval.TabIndex = 200;
            this.comboBoxInterval.TabStop = false;
            // 
            // textBoxMAXtimeNap
            // 
            this.textBoxMAXtimeNap.Location = new System.Drawing.Point(169, 440);
            this.textBoxMAXtimeNap.Name = "textBoxMAXtimeNap";
            this.textBoxMAXtimeNap.ReadOnly = true;
            this.textBoxMAXtimeNap.Size = new System.Drawing.Size(65, 20);
            this.textBoxMAXtimeNap.TabIndex = 199;
            this.textBoxMAXtimeNap.TabStop = false;
            this.textBoxMAXtimeNap.Text = "00:00";
            this.textBoxMAXtimeNap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxMINtimeNap
            // 
            this.textBoxMINtimeNap.Location = new System.Drawing.Point(169, 465);
            this.textBoxMINtimeNap.Name = "textBoxMINtimeNap";
            this.textBoxMINtimeNap.ReadOnly = true;
            this.textBoxMINtimeNap.Size = new System.Drawing.Size(65, 20);
            this.textBoxMINtimeNap.TabIndex = 198;
            this.textBoxMINtimeNap.TabStop = false;
            this.textBoxMINtimeNap.Text = "00:00";
            this.textBoxMINtimeNap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox18
            // 
            this.textBox18.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox18.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox18.Location = new System.Drawing.Point(123, 463);
            this.textBox18.Name = "textBox18";
            this.textBox18.ReadOnly = true;
            this.textBox18.Size = new System.Drawing.Size(45, 25);
            this.textBox18.TabIndex = 197;
            this.textBox18.TabStop = false;
            this.textBox18.Text = "Ura:";
            this.textBox18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox20
            // 
            this.textBox20.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox20.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox20.Location = new System.Drawing.Point(123, 437);
            this.textBox20.Name = "textBox20";
            this.textBox20.ReadOnly = true;
            this.textBox20.Size = new System.Drawing.Size(45, 25);
            this.textBox20.TabIndex = 196;
            this.textBox20.TabStop = false;
            this.textBox20.Text = "Ura:";
            this.textBox20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox21
            // 
            this.textBox21.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox21.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox21.Location = new System.Drawing.Point(7, 463);
            this.textBox21.Name = "textBox21";
            this.textBox21.ReadOnly = true;
            this.textBox21.Size = new System.Drawing.Size(45, 25);
            this.textBox21.TabIndex = 195;
            this.textBox21.TabStop = false;
            this.textBox21.Text = "MIN:";
            this.textBox21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxMINnap
            // 
            this.textBoxMINnap.Location = new System.Drawing.Point(53, 465);
            this.textBoxMINnap.Name = "textBoxMINnap";
            this.textBoxMINnap.ReadOnly = true;
            this.textBoxMINnap.Size = new System.Drawing.Size(65, 20);
            this.textBoxMINnap.TabIndex = 194;
            this.textBoxMINnap.TabStop = false;
            this.textBoxMINnap.Text = "0,00V";
            this.textBoxMINnap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox23
            // 
            this.textBox23.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox23.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox23.Location = new System.Drawing.Point(7, 437);
            this.textBox23.Name = "textBox23";
            this.textBox23.ReadOnly = true;
            this.textBox23.Size = new System.Drawing.Size(45, 25);
            this.textBox23.TabIndex = 192;
            this.textBox23.TabStop = false;
            this.textBox23.Text = "MAX:";
            this.textBox23.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxMAXnap
            // 
            this.textBoxMAXnap.Location = new System.Drawing.Point(53, 440);
            this.textBoxMAXnap.Name = "textBoxMAXnap";
            this.textBoxMAXnap.ReadOnly = true;
            this.textBoxMAXnap.Size = new System.Drawing.Size(65, 20);
            this.textBoxMAXnap.TabIndex = 191;
            this.textBoxMAXnap.TabStop = false;
            this.textBoxMAXnap.Text = "0,00V";
            this.textBoxMAXnap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSave.Location = new System.Drawing.Point(306, 403);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(70, 23);
            this.buttonSave.TabIndex = 190;
            this.buttonSave.TabStop = false;
            this.buttonSave.Text = "Shrani graf";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // radioButtonLimitOFF
            // 
            this.radioButtonLimitOFF.AutoSize = true;
            this.radioButtonLimitOFF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.radioButtonLimitOFF.Enabled = false;
            this.radioButtonLimitOFF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButtonLimitOFF.Location = new System.Drawing.Point(551, 377);
            this.radioButtonLimitOFF.Name = "radioButtonLimitOFF";
            this.radioButtonLimitOFF.Size = new System.Drawing.Size(94, 20);
            this.radioButtonLimitOFF.TabIndex = 180;
            this.radioButtonLimitOFF.Text = "Limit A OFF";
            this.radioButtonLimitOFF.UseVisualStyleBackColor = false;
            this.radioButtonLimitOFF.Click += new System.EventHandler(this.radioButtonLimitOFF_Click);
            // 
            // radioButtonLimitON
            // 
            this.radioButtonLimitON.AutoSize = true;
            this.radioButtonLimitON.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.radioButtonLimitON.Enabled = false;
            this.radioButtonLimitON.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButtonLimitON.Location = new System.Drawing.Point(551, 361);
            this.radioButtonLimitON.Name = "radioButtonLimitON";
            this.radioButtonLimitON.Size = new System.Drawing.Size(88, 20);
            this.radioButtonLimitON.TabIndex = 179;
            this.radioButtonLimitON.Text = "Limit A ON";
            this.radioButtonLimitON.UseVisualStyleBackColor = false;
            this.radioButtonLimitON.Click += new System.EventHandler(this.radioButtonLimitON_Click);
            // 
            // checkBoxAutoNap
            // 
            this.checkBoxAutoNap.AutoSize = true;
            this.checkBoxAutoNap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.checkBoxAutoNap.Enabled = false;
            this.checkBoxAutoNap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBoxAutoNap.Location = new System.Drawing.Point(399, 551);
            this.checkBoxAutoNap.Name = "checkBoxAutoNap";
            this.checkBoxAutoNap.Size = new System.Drawing.Size(54, 20);
            this.checkBoxAutoNap.TabIndex = 178;
            this.checkBoxAutoNap.TabStop = false;
            this.checkBoxAutoNap.Text = "Avto";
            this.checkBoxAutoNap.UseVisualStyleBackColor = false;
            this.checkBoxAutoNap.CheckedChanged += new System.EventHandler(this.checkBoxAutoNap_CheckedChanged);
            // 
            // checkBoxAutoTok
            // 
            this.checkBoxAutoTok.AutoSize = true;
            this.checkBoxAutoTok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.checkBoxAutoTok.Enabled = false;
            this.checkBoxAutoTok.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBoxAutoTok.Location = new System.Drawing.Point(400, 595);
            this.checkBoxAutoTok.Name = "checkBoxAutoTok";
            this.checkBoxAutoTok.Size = new System.Drawing.Size(54, 20);
            this.checkBoxAutoTok.TabIndex = 177;
            this.checkBoxAutoTok.TabStop = false;
            this.checkBoxAutoTok.Text = "Avto";
            this.checkBoxAutoTok.UseVisualStyleBackColor = false;
            this.checkBoxAutoTok.CheckedChanged += new System.EventHandler(this.checkBoxAutoTok_CheckedChanged);
            // 
            // btnNastaviNap
            // 
            this.btnNastaviNap.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnNastaviNap.Enabled = false;
            this.btnNastaviNap.Location = new System.Drawing.Point(457, 542);
            this.btnNastaviNap.Name = "btnNastaviNap";
            this.btnNastaviNap.Size = new System.Drawing.Size(75, 38);
            this.btnNastaviNap.TabIndex = 175;
            this.btnNastaviNap.TabStop = false;
            this.btnNastaviNap.Text = "Nastavi U";
            this.btnNastaviNap.UseVisualStyleBackColor = false;
            this.btnNastaviNap.Click += new System.EventHandler(this.btnNastaviNap_Click);
            // 
            // btnNastaviTok
            // 
            this.btnNastaviTok.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnNastaviTok.Enabled = false;
            this.btnNastaviTok.Location = new System.Drawing.Point(457, 586);
            this.btnNastaviTok.Name = "btnNastaviTok";
            this.btnNastaviTok.Size = new System.Drawing.Size(75, 38);
            this.btnNastaviTok.TabIndex = 174;
            this.btnNastaviTok.TabStop = false;
            this.btnNastaviTok.Text = "Nastavi A";
            this.btnNastaviTok.UseVisualStyleBackColor = false;
            this.btnNastaviTok.Click += new System.EventHandler(this.btnNastaviTok_Click);
            // 
            // btnIzhod
            // 
            this.btnIzhod.BackColor = System.Drawing.Color.Red;
            this.btnIzhod.Enabled = false;
            this.btnIzhod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnIzhod.Location = new System.Drawing.Point(661, 364);
            this.btnIzhod.Name = "btnIzhod";
            this.btnIzhod.Size = new System.Drawing.Size(100, 30);
            this.btnIzhod.TabIndex = 170;
            this.btnIzhod.TabStop = false;
            this.btnIzhod.Text = "Izklopljeno";
            this.btnIzhod.UseVisualStyleBackColor = false;
            this.btnIzhod.Click += new System.EventHandler(this.btnIzhod_Click);
            // 
            // btConnect
            // 
            this.btConnect.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btConnect.Location = new System.Drawing.Point(86, 403);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(70, 23);
            this.btConnect.TabIndex = 167;
            this.btConnect.TabStop = false;
            this.btConnect.Text = "Poveži";
            this.btConnect.UseVisualStyleBackColor = false;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // comPortSelect
            // 
            this.comPortSelect.BackColor = System.Drawing.SystemColors.ControlLight;
            this.comPortSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comPortSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comPortSelect.FormattingEnabled = true;
            this.comPortSelect.Location = new System.Drawing.Point(8, 404);
            this.comPortSelect.Name = "comPortSelect";
            this.comPortSelect.Size = new System.Drawing.Size(70, 21);
            this.comPortSelect.TabIndex = 8;
            this.comPortSelect.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Napetost);
            this.tabControl1.Controls.Add(this.Tok);
            this.tabControl1.Controls.Add(this.Moč);
            this.tabControl1.Controls.Add(this.UI);
            this.tabControl1.Location = new System.Drawing.Point(2, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(539, 396);
            this.tabControl1.TabIndex = 218;
            this.tabControl1.TabStop = false;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // Napetost
            // 
            this.Napetost.BackColor = System.Drawing.Color.White;
            this.Napetost.Controls.Add(this.label8);
            this.Napetost.Controls.Add(this.chart1);
            this.Napetost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Napetost.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Napetost.Location = new System.Drawing.Point(4, 22);
            this.Napetost.Name = "Napetost";
            this.Napetost.Padding = new System.Windows.Forms.Padding(3);
            this.Napetost.Size = new System.Drawing.Size(531, 370);
            this.Napetost.TabIndex = 0;
            this.Napetost.Text = "Prikaz napetosti";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(5, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 16);
            this.label8.TabIndex = 106;
            this.label8.Text = "U [V]";
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            this.chart1.BackImageTransparentColor = System.Drawing.Color.Transparent;
            this.chart1.BackSecondaryColor = System.Drawing.Color.Transparent;
            this.chart1.BorderlineColor = System.Drawing.Color.Transparent;
            this.chart1.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.chart1.Location = new System.Drawing.Point(-5, 9);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(530, 374);
            this.chart1.TabIndex = 102;
            this.chart1.TabStop = false;
            this.chart1.Text = "chart1";
            // 
            // Tok
            // 
            this.Tok.Controls.Add(this.labelTOKznak);
            this.Tok.Controls.Add(this.chart2);
            this.Tok.Location = new System.Drawing.Point(4, 22);
            this.Tok.Name = "Tok";
            this.Tok.Padding = new System.Windows.Forms.Padding(3);
            this.Tok.Size = new System.Drawing.Size(531, 370);
            this.Tok.TabIndex = 1;
            this.Tok.Text = "Prikaz toka";
            this.Tok.UseVisualStyleBackColor = true;
            // 
            // labelTOKznak
            // 
            this.labelTOKznak.AutoSize = true;
            this.labelTOKznak.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTOKznak.Location = new System.Drawing.Point(5, 3);
            this.labelTOKznak.Name = "labelTOKznak";
            this.labelTOKznak.Size = new System.Drawing.Size(31, 16);
            this.labelTOKznak.TabIndex = 106;
            this.labelTOKznak.Text = "I [A]";
            // 
            // chart2
            // 
            this.chart2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chart2.BackColor = System.Drawing.Color.Transparent;
            this.chart2.BackImageTransparentColor = System.Drawing.Color.Transparent;
            this.chart2.BackSecondaryColor = System.Drawing.Color.Transparent;
            this.chart2.BorderlineColor = System.Drawing.Color.Transparent;
            this.chart2.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.chart2.Location = new System.Drawing.Point(-5, 9);
            this.chart2.Name = "chart2";
            this.chart2.Size = new System.Drawing.Size(530, 374);
            this.chart2.TabIndex = 103;
            this.chart2.TabStop = false;
            this.chart2.Text = "chart2";
            // 
            // Moč
            // 
            this.Moč.Controls.Add(this.labelMOCznak);
            this.Moč.Controls.Add(this.chart3);
            this.Moč.Location = new System.Drawing.Point(4, 22);
            this.Moč.Name = "Moč";
            this.Moč.Size = new System.Drawing.Size(531, 370);
            this.Moč.TabIndex = 2;
            this.Moč.Text = "Prikaz moči";
            this.Moč.UseVisualStyleBackColor = true;
            // 
            // labelMOCznak
            // 
            this.labelMOCznak.AutoSize = true;
            this.labelMOCznak.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelMOCznak.Location = new System.Drawing.Point(5, 3);
            this.labelMOCznak.Name = "labelMOCznak";
            this.labelMOCznak.Size = new System.Drawing.Size(41, 16);
            this.labelMOCznak.TabIndex = 105;
            this.labelMOCznak.Text = "P [W]";
            // 
            // chart3
            // 
            this.chart3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chart3.BackColor = System.Drawing.Color.Transparent;
            this.chart3.BackImageTransparentColor = System.Drawing.Color.Transparent;
            this.chart3.BackSecondaryColor = System.Drawing.Color.Transparent;
            this.chart3.BorderlineColor = System.Drawing.Color.Transparent;
            this.chart3.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.chart3.Location = new System.Drawing.Point(-5, 9);
            this.chart3.Name = "chart3";
            this.chart3.Size = new System.Drawing.Size(530, 374);
            this.chart3.TabIndex = 104;
            this.chart3.TabStop = false;
            this.chart3.Text = "chart3";
            // 
            // UI
            // 
            this.UI.Controls.Add(this.buttonUIstart);
            this.UI.Controls.Add(this.label24);
            this.UI.Controls.Add(this.label21);
            this.UI.Controls.Add(this.label20);
            this.UI.Controls.Add(this.labelTOKUInum);
            this.UI.Controls.Add(this.numUI_Imax);
            this.UI.Controls.Add(this.numUI_Uinterval);
            this.UI.Controls.Add(this.numUI_Iinterval);
            this.UI.Controls.Add(this.numUI_Umax);
            this.UI.Controls.Add(this.label11);
            this.UI.Controls.Add(this.labelTokUI);
            this.UI.Controls.Add(this.chart4);
            this.UI.Location = new System.Drawing.Point(4, 22);
            this.UI.Name = "UI";
            this.UI.Size = new System.Drawing.Size(531, 370);
            this.UI.TabIndex = 3;
            this.UI.Text = "Merjenje U/I";
            this.UI.UseVisualStyleBackColor = true;
            // 
            // buttonUIstart
            // 
            this.buttonUIstart.Enabled = false;
            this.buttonUIstart.Location = new System.Drawing.Point(2, 338);
            this.buttonUIstart.Name = "buttonUIstart";
            this.buttonUIstart.Size = new System.Drawing.Size(53, 31);
            this.buttonUIstart.TabIndex = 0;
            this.buttonUIstart.Text = "Začni";
            this.buttonUIstart.UseVisualStyleBackColor = true;
            this.buttonUIstart.Click += new System.EventHandler(this.buttonUIstart_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(300, 332);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(51, 16);
            this.label24.TabIndex = 121;
            this.label24.Text = "U Max";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label21.Location = new System.Drawing.Point(380, 332);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(74, 16);
            this.label21.TabIndex = 118;
            this.label21.Text = "U interval";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label20.Location = new System.Drawing.Point(202, 332);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(67, 16);
            this.label20.TabIndex = 117;
            this.label20.Text = "I interval";
            // 
            // labelTOKUInum
            // 
            this.labelTOKUInum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTOKUInum.Location = new System.Drawing.Point(104, 332);
            this.labelTOKUInum.Name = "labelTOKUInum";
            this.labelTOKUInum.Size = new System.Drawing.Size(80, 16);
            this.labelTOKUInum.TabIndex = 115;
            this.labelTOKUInum.Text = "I Max [A]";
            this.labelTOKUInum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numUI_Imax
            // 
            this.numUI_Imax.DecimalPlaces = 2;
            this.numUI_Imax.Enabled = false;
            this.numUI_Imax.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numUI_Imax.Location = new System.Drawing.Point(104, 349);
            this.numUI_Imax.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numUI_Imax.Name = "numUI_Imax";
            this.numUI_Imax.Size = new System.Drawing.Size(80, 20);
            this.numUI_Imax.TabIndex = 1;
            this.numUI_Imax.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numUI_Imax.ValueChanged += new System.EventHandler(this.numUI_Imax_ValueChanged);
            // 
            // numUI_Uinterval
            // 
            this.numUI_Uinterval.DecimalPlaces = 2;
            this.numUI_Uinterval.Enabled = false;
            this.numUI_Uinterval.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numUI_Uinterval.Location = new System.Drawing.Point(377, 349);
            this.numUI_Uinterval.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numUI_Uinterval.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numUI_Uinterval.Name = "numUI_Uinterval";
            this.numUI_Uinterval.Size = new System.Drawing.Size(80, 20);
            this.numUI_Uinterval.TabIndex = 4;
            this.numUI_Uinterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUI_Uinterval.ValueChanged += new System.EventHandler(this.numUI_Uinterval_ValueChanged);
            // 
            // numUI_Iinterval
            // 
            this.numUI_Iinterval.DecimalPlaces = 2;
            this.numUI_Iinterval.Enabled = false;
            this.numUI_Iinterval.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numUI_Iinterval.Location = new System.Drawing.Point(195, 349);
            this.numUI_Iinterval.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numUI_Iinterval.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numUI_Iinterval.Name = "numUI_Iinterval";
            this.numUI_Iinterval.Size = new System.Drawing.Size(80, 20);
            this.numUI_Iinterval.TabIndex = 2;
            this.numUI_Iinterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUI_Iinterval.ValueChanged += new System.EventHandler(this.numUI_Iinterval_ValueChanged);
            // 
            // numUI_Umax
            // 
            this.numUI_Umax.DecimalPlaces = 1;
            this.numUI_Umax.Enabled = false;
            this.numUI_Umax.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.numUI_Umax.Location = new System.Drawing.Point(286, 349);
            this.numUI_Umax.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numUI_Umax.Name = "numUI_Umax";
            this.numUI_Umax.Size = new System.Drawing.Size(80, 20);
            this.numUI_Umax.TabIndex = 3;
            this.numUI_Umax.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUI_Umax.ValueChanged += new System.EventHandler(this.numUI_Umax_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.Location = new System.Drawing.Point(490, 333);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 16);
            this.label11.TabIndex = 107;
            this.label11.Text = "U [V]";
            // 
            // labelTokUI
            // 
            this.labelTokUI.AutoSize = true;
            this.labelTokUI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTokUI.Location = new System.Drawing.Point(5, 3);
            this.labelTokUI.Name = "labelTokUI";
            this.labelTokUI.Size = new System.Drawing.Size(31, 16);
            this.labelTokUI.TabIndex = 106;
            this.labelTokUI.Text = "I [A]";
            // 
            // chart4
            // 
            this.chart4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chart4.BackColor = System.Drawing.Color.Transparent;
            this.chart4.BackImageTransparentColor = System.Drawing.Color.Transparent;
            this.chart4.BackSecondaryColor = System.Drawing.Color.Transparent;
            this.chart4.BorderlineColor = System.Drawing.Color.Transparent;
            this.chart4.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.chart4.Location = new System.Drawing.Point(-6, 9);
            this.chart4.Name = "chart4";
            this.chart4.Size = new System.Drawing.Size(531, 339);
            this.chart4.TabIndex = 104;
            this.chart4.TabStop = false;
            this.chart4.Text = "chart4";
            // 
            // sliderTok
            // 
            this.sliderTok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.sliderTok.Enabled = false;
            this.sliderTok.Location = new System.Drawing.Point(70, 599);
            this.sliderTok.Maximum = 1600;
            this.sliderTok.Name = "sliderTok";
            this.sliderTok.Size = new System.Drawing.Size(323, 45);
            this.sliderTok.TabIndex = 219;
            this.sliderTok.TabStop = false;
            this.sliderTok.TickFrequency = 100;
            this.sliderTok.Scroll += new System.EventHandler(this.sliderTok_Scroll);
            // 
            // sliderUlimit
            // 
            this.sliderUlimit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.sliderUlimit.Enabled = false;
            this.sliderUlimit.Location = new System.Drawing.Point(70, 511);
            this.sliderUlimit.Maximum = 1600;
            this.sliderUlimit.Name = "sliderUlimit";
            this.sliderUlimit.Size = new System.Drawing.Size(323, 45);
            this.sliderUlimit.TabIndex = 221;
            this.sliderUlimit.TabStop = false;
            this.sliderUlimit.TickFrequency = 100;
            this.sliderUlimit.Scroll += new System.EventHandler(this.sliderUlimit_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(9, 586);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 222;
            this.label2.Text = "Nastevi tok";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(9, 542);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 223;
            this.label3.Text = "Nastevi napetost";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(9, 497);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 224;
            this.label4.Text = "Nastevi U limit";
            // 
            // labelUlimitNastavljena
            // 
            this.labelUlimitNastavljena.AutoSize = true;
            this.labelUlimitNastavljena.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.labelUlimitNastavljena.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelUlimitNastavljena.Location = new System.Drawing.Point(108, 497);
            this.labelUlimitNastavljena.Name = "labelUlimitNastavljena";
            this.labelUlimitNastavljena.Size = new System.Drawing.Size(40, 13);
            this.labelUlimitNastavljena.TabIndex = 225;
            this.labelUlimitNastavljena.Text = "0.00V";
            // 
            // labelUnastavljena
            // 
            this.labelUnastavljena.AutoSize = true;
            this.labelUnastavljena.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelUnastavljena.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelUnastavljena.Location = new System.Drawing.Point(122, 543);
            this.labelUnastavljena.Name = "labelUnastavljena";
            this.labelUnastavljena.Size = new System.Drawing.Size(40, 13);
            this.labelUnastavljena.TabIndex = 226;
            this.labelUnastavljena.Text = "0.00V";
            // 
            // labelInastavljen
            // 
            this.labelInastavljen.AutoSize = true;
            this.labelInastavljen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.labelInastavljen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelInastavljen.Location = new System.Drawing.Point(91, 586);
            this.labelInastavljen.Name = "labelInastavljen";
            this.labelInastavljen.Size = new System.Drawing.Size(40, 13);
            this.labelInastavljen.TabIndex = 227;
            this.labelInastavljen.Text = "0.00A";
            // 
            // labelUtrenutna
            // 
            this.labelUtrenutna.AutoSize = true;
            this.labelUtrenutna.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.labelUtrenutna.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelUtrenutna.Location = new System.Drawing.Point(334, 543);
            this.labelUtrenutna.Name = "labelUtrenutna";
            this.labelUtrenutna.Size = new System.Drawing.Size(40, 13);
            this.labelUtrenutna.TabIndex = 228;
            this.labelUtrenutna.Text = "0.00V";
            // 
            // labelItrenutni
            // 
            this.labelItrenutni.AutoSize = true;
            this.labelItrenutni.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.labelItrenutni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelItrenutni.Location = new System.Drawing.Point(334, 586);
            this.labelItrenutni.Name = "labelItrenutni";
            this.labelItrenutni.Size = new System.Drawing.Size(40, 13);
            this.labelItrenutni.TabIndex = 229;
            this.labelItrenutni.Text = "0.00A";
            // 
            // labelUlimitTrenutni
            // 
            this.labelUlimitTrenutni.AutoSize = true;
            this.labelUlimitTrenutni.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.labelUlimitTrenutni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelUlimitTrenutni.Location = new System.Drawing.Point(334, 498);
            this.labelUlimitTrenutni.Name = "labelUlimitTrenutni";
            this.labelUlimitTrenutni.Size = new System.Drawing.Size(40, 13);
            this.labelUlimitTrenutni.TabIndex = 230;
            this.labelUlimitTrenutni.Text = "0.00V";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(261, 497);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 226;
            this.label12.Text = "Trenutno:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label13.Location = new System.Drawing.Point(261, 542);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 13);
            this.label13.TabIndex = 231;
            this.label13.Text = "Trenutno:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label14.Location = new System.Drawing.Point(261, 585);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 13);
            this.label14.TabIndex = 232;
            this.label14.Text = "Trenutno:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelTime,
            this.ip,
            this.labelStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 630);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(766, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 233;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labelTime
            // 
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(34, 17);
            this.labelTime.Text = "Time";
            // 
            // ip
            // 
            this.ip.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(4, 17);
            // 
            // labelStatus
            // 
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(109, 17);
            this.labelStatus.Text = "Status: ni povezano";
            // 
            // labelElektronik
            // 
            this.labelElektronik.AutoSize = true;
            this.labelElektronik.BackColor = System.Drawing.SystemColors.Control;
            this.labelElektronik.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelElektronik.Location = new System.Drawing.Point(653, 633);
            this.labelElektronik.Name = "labelElektronik";
            this.labelElektronik.Size = new System.Drawing.Size(109, 16);
            this.labelElektronik.TabIndex = 234;
            this.labelElektronik.Text = "www.elektronik.si";
            this.labelElektronik.Click += new System.EventHandler(this.labelElektronik_Click);
            // 
            // buttonNastaviLimit
            // 
            this.buttonNastaviLimit.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonNastaviLimit.Enabled = false;
            this.buttonNastaviLimit.Location = new System.Drawing.Point(457, 498);
            this.buttonNastaviLimit.Name = "buttonNastaviLimit";
            this.buttonNastaviLimit.Size = new System.Drawing.Size(75, 38);
            this.buttonNastaviLimit.TabIndex = 235;
            this.buttonNastaviLimit.TabStop = false;
            this.buttonNastaviLimit.Text = "Nastavi limit";
            this.buttonNastaviLimit.UseVisualStyleBackColor = false;
            this.buttonNastaviLimit.Click += new System.EventHandler(this.buttonNastaviLimit_Click);
            // 
            // checkBoxAutoLimit
            // 
            this.checkBoxAutoLimit.AutoSize = true;
            this.checkBoxAutoLimit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.checkBoxAutoLimit.Enabled = false;
            this.checkBoxAutoLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBoxAutoLimit.Location = new System.Drawing.Point(397, 508);
            this.checkBoxAutoLimit.Name = "checkBoxAutoLimit";
            this.checkBoxAutoLimit.Size = new System.Drawing.Size(54, 20);
            this.checkBoxAutoLimit.TabIndex = 236;
            this.checkBoxAutoLimit.TabStop = false;
            this.checkBoxAutoLimit.Text = "Avto";
            this.checkBoxAutoLimit.UseVisualStyleBackColor = false;
            this.checkBoxAutoLimit.CheckedChanged += new System.EventHandler(this.checkBoxAutoLimit_CheckedChanged);
            // 
            // buttonClearData
            // 
            this.buttonClearData.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonClearData.Location = new System.Drawing.Point(547, 312);
            this.buttonClearData.Name = "buttonClearData";
            this.buttonClearData.Size = new System.Drawing.Size(65, 22);
            this.buttonClearData.TabIndex = 237;
            this.buttonClearData.TabStop = false;
            this.buttonClearData.Text = "Pobriši";
            this.buttonClearData.UseVisualStyleBackColor = false;
            this.buttonClearData.Click += new System.EventHandler(this.buttonClearData_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(549, 337);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 239;
            this.label1.Text = "Vzorčenje:";
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // numTableInterval
            // 
            this.numTableInterval.Enabled = false;
            this.numTableInterval.Location = new System.Drawing.Point(632, 336);
            this.numTableInterval.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numTableInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTableInterval.Name = "numTableInterval";
            this.numTableInterval.Size = new System.Drawing.Size(107, 20);
            this.numTableInterval.TabIndex = 240;
            this.numTableInterval.TabStop = false;
            this.numTableInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTableInterval.ValueChanged += new System.EventHandler(this.numTableInterval_ValueChanged);
            // 
            // buttonShraniTable
            // 
            this.buttonShraniTable.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonShraniTable.Location = new System.Drawing.Point(622, 312);
            this.buttonShraniTable.Name = "buttonShraniTable";
            this.buttonShraniTable.Size = new System.Drawing.Size(65, 22);
            this.buttonShraniTable.TabIndex = 242;
            this.buttonShraniTable.TabStop = false;
            this.buttonShraniTable.Text = "Shrani";
            this.buttonShraniTable.UseVisualStyleBackColor = false;
            this.buttonShraniTable.Click += new System.EventHandler(this.buttonShraniTable_Click);
            // 
            // buttonStartTable
            // 
            this.buttonStartTable.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonStartTable.Enabled = false;
            this.buttonStartTable.Location = new System.Drawing.Point(696, 312);
            this.buttonStartTable.Name = "buttonStartTable";
            this.buttonStartTable.Size = new System.Drawing.Size(65, 22);
            this.buttonStartTable.TabIndex = 243;
            this.buttonStartTable.TabStop = false;
            this.buttonStartTable.Text = "Start";
            this.buttonStartTable.UseVisualStyleBackColor = false;
            this.buttonStartTable.Click += new System.EventHandler(this.buttonStartTable_Click);
            // 
            // saveFileDialog2
            // 
            this.saveFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog2_FileOk);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(740, 336);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 20);
            this.label5.TabIndex = 244;
            this.label5.Text = "s";
            // 
            // sliderNapetost
            // 
            this.sliderNapetost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.sliderNapetost.Enabled = false;
            this.sliderNapetost.Location = new System.Drawing.Point(70, 556);
            this.sliderNapetost.Maximum = 1600;
            this.sliderNapetost.Name = "sliderNapetost";
            this.sliderNapetost.Size = new System.Drawing.Size(323, 45);
            this.sliderNapetost.TabIndex = 220;
            this.sliderNapetost.TabStop = false;
            this.sliderNapetost.TickFrequency = 100;
            this.sliderNapetost.Scroll += new System.EventHandler(this.sliderNapetost_Scroll);
            // 
            // numUlimit
            // 
            this.numUlimit.DecimalPlaces = 2;
            this.numUlimit.Enabled = false;
            this.numUlimit.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numUlimit.Location = new System.Drawing.Point(12, 515);
            this.numUlimit.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numUlimit.Name = "numUlimit";
            this.numUlimit.Size = new System.Drawing.Size(55, 20);
            this.numUlimit.TabIndex = 245;
            this.numUlimit.TabStop = false;
            this.numUlimit.ValueChanged += new System.EventHandler(this.numUlimit_ValueChanged);
            // 
            // numU
            // 
            this.numU.DecimalPlaces = 2;
            this.numU.Enabled = false;
            this.numU.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numU.Location = new System.Drawing.Point(12, 560);
            this.numU.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numU.Name = "numU";
            this.numU.Size = new System.Drawing.Size(55, 20);
            this.numU.TabIndex = 246;
            this.numU.TabStop = false;
            this.numU.ValueChanged += new System.EventHandler(this.numU_ValueChanged);
            // 
            // numI
            // 
            this.numI.DecimalPlaces = 2;
            this.numI.Enabled = false;
            this.numI.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numI.Location = new System.Drawing.Point(12, 604);
            this.numI.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numI.Name = "numI";
            this.numI.Size = new System.Drawing.Size(55, 20);
            this.numI.TabIndex = 247;
            this.numI.TabStop = false;
            this.numI.ValueChanged += new System.EventHandler(this.numI_ValueChanged);
            // 
            // timer3
            // 
            this.timer3.Interval = 500;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // btnSlave
            // 
            this.btnSlave.BackColor = System.Drawing.Color.Red;
            this.btnSlave.Enabled = false;
            this.btnSlave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSlave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSlave.Location = new System.Drawing.Point(242, 403);
            this.btnSlave.Name = "btnSlave";
            this.btnSlave.Size = new System.Drawing.Size(56, 23);
            this.btnSlave.TabIndex = 122;
            this.btnSlave.TabStop = false;
            this.btnSlave.Text = "Slave";
            this.btnSlave.UseVisualStyleBackColor = false;
            this.btnSlave.Click += new System.EventHandler(this.btnSlave_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(541, 360);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(300, 1);
            this.pictureBox6.TabIndex = 241;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(-13, 490);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(555, 1);
            this.pictureBox5.TabIndex = 217;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(-14, 431);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(555, 1);
            this.pictureBox4.TabIndex = 216;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(541, 306);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(1, 700);
            this.pictureBox3.TabIndex = 165;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(-9, 397);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(800, 1);
            this.pictureBox2.TabIndex = 164;
            this.pictureBox2.TabStop = false;
            // 
            // picBoxPikaMoc
            // 
            this.picBoxPikaMoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.picBoxPikaMoc.Image = ((System.Drawing.Image)(resources.GetObject("picBoxPikaMoc.Image")));
            this.picBoxPikaMoc.Location = new System.Drawing.Point(620, 612);
            this.picBoxPikaMoc.Name = "picBoxPikaMoc";
            this.picBoxPikaMoc.Size = new System.Drawing.Size(10, 10);
            this.picBoxPikaMoc.TabIndex = 163;
            this.picBoxPikaMoc.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(620, 445);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(10, 10);
            this.pictureBox8.TabIndex = 162;
            this.pictureBox8.TabStop = false;
            // 
            // upoBox4
            // 
            this.upoBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.upoBox4.Image = ((System.Drawing.Image)(resources.GetObject("upoBox4.Image")));
            this.upoBox4.Location = new System.Drawing.Point(661, 405);
            this.upoBox4.Name = "upoBox4";
            this.upoBox4.Size = new System.Drawing.Size(35, 50);
            this.upoBox4.TabIndex = 161;
            this.upoBox4.TabStop = false;
            // 
            // upoBox1
            // 
            this.upoBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.upoBox1.Location = new System.Drawing.Point(549, 405);
            this.upoBox1.Name = "upoBox1";
            this.upoBox1.Size = new System.Drawing.Size(35, 50);
            this.upoBox1.TabIndex = 159;
            this.upoBox1.TabStop = false;
            this.upoBox1.Tag = "10";
            // 
            // upoBox3
            // 
            this.upoBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.upoBox3.Image = ((System.Drawing.Image)(resources.GetObject("upoBox3.Image")));
            this.upoBox3.Location = new System.Drawing.Point(627, 405);
            this.upoBox3.Name = "upoBox3";
            this.upoBox3.Size = new System.Drawing.Size(35, 50);
            this.upoBox3.TabIndex = 158;
            this.upoBox3.TabStop = false;
            // 
            // upoBox2
            // 
            this.upoBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.upoBox2.Image = ((System.Drawing.Image)(resources.GetObject("upoBox2.Image")));
            this.upoBox2.Location = new System.Drawing.Point(583, 405);
            this.upoBox2.Name = "upoBox2";
            this.upoBox2.Size = new System.Drawing.Size(35, 50);
            this.upoBox2.TabIndex = 157;
            this.upoBox2.TabStop = false;
            // 
            // mocBox4
            // 
            this.mocBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.mocBox4.Image = ((System.Drawing.Image)(resources.GetObject("mocBox4.Image")));
            this.mocBox4.Location = new System.Drawing.Point(661, 572);
            this.mocBox4.Name = "mocBox4";
            this.mocBox4.Size = new System.Drawing.Size(35, 50);
            this.mocBox4.TabIndex = 156;
            this.mocBox4.TabStop = false;
            // 
            // mocBox1
            // 
            this.mocBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.mocBox1.Location = new System.Drawing.Point(549, 572);
            this.mocBox1.Name = "mocBox1";
            this.mocBox1.Size = new System.Drawing.Size(35, 50);
            this.mocBox1.TabIndex = 154;
            this.mocBox1.TabStop = false;
            // 
            // mocBox3
            // 
            this.mocBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.mocBox3.Image = ((System.Drawing.Image)(resources.GetObject("mocBox3.Image")));
            this.mocBox3.Location = new System.Drawing.Point(627, 572);
            this.mocBox3.Name = "mocBox3";
            this.mocBox3.Size = new System.Drawing.Size(35, 50);
            this.mocBox3.TabIndex = 153;
            this.mocBox3.TabStop = false;
            // 
            // mocBox2
            // 
            this.mocBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.mocBox2.Image = ((System.Drawing.Image)(resources.GetObject("mocBox2.Image")));
            this.mocBox2.Location = new System.Drawing.Point(583, 572);
            this.mocBox2.Name = "mocBox2";
            this.mocBox2.Size = new System.Drawing.Size(35, 50);
            this.mocBox2.TabIndex = 152;
            this.mocBox2.TabStop = false;
            // 
            // tokBox3
            // 
            this.tokBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.tokBox3.Image = ((System.Drawing.Image)(resources.GetObject("tokBox3.Image")));
            this.tokBox3.Location = new System.Drawing.Point(661, 517);
            this.tokBox3.Name = "tokBox3";
            this.tokBox3.Size = new System.Drawing.Size(35, 50);
            this.tokBox3.TabIndex = 151;
            this.tokBox3.TabStop = false;
            // 
            // napBox4
            // 
            this.napBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.napBox4.Image = ((System.Drawing.Image)(resources.GetObject("napBox4.Image")));
            this.napBox4.Location = new System.Drawing.Point(661, 461);
            this.napBox4.Name = "napBox4";
            this.napBox4.Size = new System.Drawing.Size(35, 50);
            this.napBox4.TabIndex = 149;
            this.napBox4.TabStop = false;
            // 
            // tokBox2
            // 
            this.tokBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.tokBox2.Image = ((System.Drawing.Image)(resources.GetObject("tokBox2.Image")));
            this.tokBox2.Location = new System.Drawing.Point(627, 517);
            this.tokBox2.Name = "tokBox2";
            this.tokBox2.Size = new System.Drawing.Size(35, 50);
            this.tokBox2.TabIndex = 147;
            this.tokBox2.TabStop = false;
            // 
            // picBoxPikaTok
            // 
            this.picBoxPikaTok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.picBoxPikaTok.Image = ((System.Drawing.Image)(resources.GetObject("picBoxPikaTok.Image")));
            this.picBoxPikaTok.Location = new System.Drawing.Point(620, 557);
            this.picBoxPikaTok.Name = "picBoxPikaTok";
            this.picBoxPikaTok.Size = new System.Drawing.Size(10, 10);
            this.picBoxPikaTok.TabIndex = 146;
            this.picBoxPikaTok.TabStop = false;
            // 
            // tokBox1
            // 
            this.tokBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.tokBox1.Image = ((System.Drawing.Image)(resources.GetObject("tokBox1.Image")));
            this.tokBox1.Location = new System.Drawing.Point(583, 517);
            this.tokBox1.Name = "tokBox1";
            this.tokBox1.Size = new System.Drawing.Size(35, 50);
            this.tokBox1.TabIndex = 145;
            this.tokBox1.TabStop = false;
            // 
            // napBox1
            // 
            this.napBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.napBox1.Location = new System.Drawing.Point(549, 461);
            this.napBox1.Name = "napBox1";
            this.napBox1.Size = new System.Drawing.Size(35, 50);
            this.napBox1.TabIndex = 144;
            this.napBox1.TabStop = false;
            // 
            // napBox3
            // 
            this.napBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.napBox3.Image = ((System.Drawing.Image)(resources.GetObject("napBox3.Image")));
            this.napBox3.Location = new System.Drawing.Point(627, 461);
            this.napBox3.Name = "napBox3";
            this.napBox3.Size = new System.Drawing.Size(35, 50);
            this.napBox3.TabIndex = 143;
            this.napBox3.TabStop = false;
            // 
            // pictureBox26
            // 
            this.pictureBox26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.pictureBox26.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox26.Image")));
            this.pictureBox26.Location = new System.Drawing.Point(620, 501);
            this.pictureBox26.Name = "pictureBox26";
            this.pictureBox26.Size = new System.Drawing.Size(10, 10);
            this.pictureBox26.TabIndex = 142;
            this.pictureBox26.TabStop = false;
            // 
            // napBox2
            // 
            this.napBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.napBox2.Image = ((System.Drawing.Image)(resources.GetObject("napBox2.Image")));
            this.napBox2.Location = new System.Drawing.Point(583, 461);
            this.napBox2.Name = "napBox2";
            this.napBox2.Size = new System.Drawing.Size(35, 50);
            this.napBox2.TabIndex = 141;
            this.napBox2.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Enabled = false;
            this.pictureBox10.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox10.Image")));
            this.pictureBox10.Location = new System.Drawing.Point(-7, 306);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(782, 340);
            this.pictureBox10.TabIndex = 140;
            this.pictureBox10.TabStop = false;
            // 
            // comboBoxComSlave
            // 
            this.comboBoxComSlave.BackColor = System.Drawing.SystemColors.ControlLight;
            this.comboBoxComSlave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxComSlave.Enabled = false;
            this.comboBoxComSlave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxComSlave.FormattingEnabled = true;
            this.comboBoxComSlave.Location = new System.Drawing.Point(164, 404);
            this.comboBoxComSlave.Name = "comboBoxComSlave";
            this.comboBoxComSlave.Size = new System.Drawing.Size(70, 21);
            this.comboBoxComSlave.TabIndex = 248;
            this.comboBoxComSlave.TabStop = false;
            this.comboBoxComSlave.SelectedIndexChanged += new System.EventHandler(this.comboBoxComSlave_SelectedIndexChanged);
            // 
            // serialPort2
            // 
            this.serialPort2.BaudRate = 38400;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 652);
            this.Controls.Add(this.comboBoxComSlave);
            this.Controls.Add(this.btnSlave);
            this.Controls.Add(this.numI);
            this.Controls.Add(this.numU);
            this.Controls.Add(this.numUlimit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonStartTable);
            this.Controls.Add(this.buttonShraniTable);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.numTableInterval);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonClearData);
            this.Controls.Add(this.checkBoxAutoLimit);
            this.Controls.Add(this.buttonNastaviLimit);
            this.Controls.Add(this.labelElektronik);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.labelUlimitTrenutni);
            this.Controls.Add(this.labelItrenutni);
            this.Controls.Add(this.labelUtrenutna);
            this.Controls.Add(this.labelInastavljen);
            this.Controls.Add(this.labelUnastavljena);
            this.Controls.Add(this.labelUlimitNastavljena);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sliderUlimit);
            this.Controls.Add(this.sliderNapetost);
            this.Controls.Add(this.sliderTok);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.buttonPobrisi);
            this.Controls.Add(this.btnClearMINtok);
            this.Controls.Add(this.btnClearMAXtok);
            this.Controls.Add(this.textBoxMAXtimeTok);
            this.Controls.Add(this.textBoxMINtimeTok);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBoxMINtok);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.textBoxMAXtok);
            this.Controls.Add(this.btnClearMINnap);
            this.Controls.Add(this.btnClearMAXnap);
            this.Controls.Add(this.comboBoxInterval);
            this.Controls.Add(this.textBoxMAXtimeNap);
            this.Controls.Add(this.textBoxMINtimeNap);
            this.Controls.Add(this.textBox18);
            this.Controls.Add(this.textBox20);
            this.Controls.Add(this.textBox21);
            this.Controls.Add(this.textBoxMINnap);
            this.Controls.Add(this.textBox23);
            this.Controls.Add(this.textBoxMAXnap);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.radioButtonLimitOFF);
            this.Controls.Add(this.radioButtonLimitON);
            this.Controls.Add(this.checkBoxAutoNap);
            this.Controls.Add(this.checkBoxAutoTok);
            this.Controls.Add(this.btnNastaviNap);
            this.Controls.Add(this.btnNastaviTok);
            this.Controls.Add(this.btnIzhod);
            this.Controls.Add(this.btConnect);
            this.Controls.Add(this.comPortSelect);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.picBoxPikaMoc);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.upoBox4);
            this.Controls.Add(this.labelZnakUpor);
            this.Controls.Add(this.upoBox1);
            this.Controls.Add(this.upoBox3);
            this.Controls.Add(this.upoBox2);
            this.Controls.Add(this.mocBox4);
            this.Controls.Add(this.labelZnakMoc);
            this.Controls.Add(this.mocBox1);
            this.Controls.Add(this.mocBox3);
            this.Controls.Add(this.mocBox2);
            this.Controls.Add(this.tokBox3);
            this.Controls.Add(this.labelZnakAmp);
            this.Controls.Add(this.napBox4);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.tokBox2);
            this.Controls.Add(this.picBoxPikaTok);
            this.Controls.Add(this.tokBox1);
            this.Controls.Add(this.napBox1);
            this.Controls.Add(this.napBox3);
            this.Controls.Add(this.pictureBox26);
            this.Controls.Add(this.napBox2);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.dataGridVrednosti);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elektronik.si napajalnik";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVrednosti)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.Napetost.ResumeLayout(false);
            this.Napetost.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.Tok.ResumeLayout(false);
            this.Tok.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.Moč.ResumeLayout(false);
            this.Moč.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            this.UI.ResumeLayout(false);
            this.UI.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUI_Imax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUI_Uinterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUI_Iinterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUI_Umax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderTok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderUlimit)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTableInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderNapetost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUlimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPikaMoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upoBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upoBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upoBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upoBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mocBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mocBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mocBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mocBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tokBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.napBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tokBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPikaTok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tokBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.napBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.napBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.napBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridView dataGridVrednosti;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox upoBox4;
        private System.Windows.Forms.Label labelZnakUpor;
        private System.Windows.Forms.PictureBox upoBox1;
        private System.Windows.Forms.PictureBox upoBox3;
        private System.Windows.Forms.PictureBox upoBox2;
        private System.Windows.Forms.PictureBox mocBox4;
        private System.Windows.Forms.Label labelZnakMoc;
        private System.Windows.Forms.PictureBox mocBox1;
        private System.Windows.Forms.PictureBox mocBox3;
        private System.Windows.Forms.PictureBox mocBox2;
        private System.Windows.Forms.PictureBox tokBox3;
        private System.Windows.Forms.Label labelZnakAmp;
        private System.Windows.Forms.PictureBox napBox4;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.PictureBox tokBox2;
        private System.Windows.Forms.PictureBox picBoxPikaTok;
        private System.Windows.Forms.PictureBox tokBox1;
        private System.Windows.Forms.PictureBox napBox1;
        private System.Windows.Forms.PictureBox napBox3;
        private System.Windows.Forms.PictureBox pictureBox26;
        private System.Windows.Forms.PictureBox napBox2;
        private System.Windows.Forms.PictureBox picBoxPikaMoc;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button buttonPobrisi;
        private System.Windows.Forms.Button btnClearMINtok;
        private System.Windows.Forms.Button btnClearMAXtok;
        private System.Windows.Forms.TextBox textBoxMAXtimeTok;
        private System.Windows.Forms.TextBox textBoxMINtimeTok;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBoxMINtok;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBoxMAXtok;
        private System.Windows.Forms.Button btnClearMINnap;
        private System.Windows.Forms.Button btnClearMAXnap;
        private System.Windows.Forms.ComboBox comboBoxInterval;
        private System.Windows.Forms.TextBox textBoxMAXtimeNap;
        private System.Windows.Forms.TextBox textBoxMINtimeNap;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.TextBox textBox21;
        private System.Windows.Forms.TextBox textBoxMINnap;
        private System.Windows.Forms.TextBox textBox23;
        private System.Windows.Forms.TextBox textBoxMAXnap;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.RadioButton radioButtonLimitOFF;
        private System.Windows.Forms.RadioButton radioButtonLimitON;
        private System.Windows.Forms.CheckBox checkBoxAutoNap;
        private System.Windows.Forms.CheckBox checkBoxAutoTok;
        private System.Windows.Forms.Button btnNastaviNap;
        private System.Windows.Forms.Button btnNastaviTok;
        private System.Windows.Forms.Button btnIzhod;
        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.ComboBox comPortSelect;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Napetost;
        private System.Windows.Forms.TabPage Tok;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.TabPage Moč;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.TabPage UI;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart4;
        private System.Windows.Forms.TrackBar sliderTok;
        private System.Windows.Forms.TrackBar sliderUlimit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelUlimitNastavljena;
        private System.Windows.Forms.Label labelUnastavljena;
        private System.Windows.Forms.Label labelInastavljen;
        private System.Windows.Forms.Label labelUtrenutna;
        private System.Windows.Forms.Label labelItrenutni;
        private System.Windows.Forms.Label labelUlimitTrenutni;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labelTime;
        private System.Windows.Forms.ToolStripStatusLabel ip;
        private System.Windows.Forms.ToolStripStatusLabel labelStatus;
        private System.Windows.Forms.Label labelElektronik;
        private System.Windows.Forms.Button buttonNastaviLimit;
        private System.Windows.Forms.CheckBox checkBoxAutoLimit;
        private System.Windows.Forms.Button buttonClearData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.NumericUpDown numTableInterval;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Button buttonShraniTable;
        private System.Windows.Forms.Button buttonStartTable;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar sliderNapetost;
        private System.Windows.Forms.Label labelMOCznak;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelTOKznak;
        private System.Windows.Forms.Label labelTokUI;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numUI_Umax;
        private System.Windows.Forms.NumericUpDown numUI_Iinterval;
        private System.Windows.Forms.NumericUpDown numUI_Imax;
        private System.Windows.Forms.NumericUpDown numUI_Uinterval;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label labelTOKUInum;
        private System.Windows.Forms.Button buttonUIstart;
        private System.Windows.Forms.NumericUpDown numUlimit;
        private System.Windows.Forms.NumericUpDown numU;
        private System.Windows.Forms.NumericUpDown numI;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Button btnSlave;
        private System.Windows.Forms.ComboBox comboBoxComSlave;
        private System.IO.Ports.SerialPort serialPort2;
    }
}

