using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Runtime.InteropServices;
using System.Windows.Forms.DataVisualization.Charting;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO; 

struct nap_status
{
    public UInt16 Umax; // max U, ki jo napajalnik zmore
    public UInt16 Ulim; // max U, soft omejitev
    public UInt16 Uset; // nastavljena U
    public UInt16 Uizh; // dejanska U
    public UInt16 Imax; // max I, ki ga napajalnik zmore
    public UInt16 Ilim; // nastavljena limita I
    public UInt16 Iizh; // dejanski I
    public byte enable; // izhod on/off    
    public byte limit;  // limit on/off
}

struct nap_cmd
{
    public UInt16 Ulim; // max U, soft omejitev
    public UInt16 Uset; // nastavljena U
    public UInt16 Ilim; // nastavljena limita I
    public byte enable; // izhod on/off    
    public byte limit;  // limit on/off
}

namespace elektronikNapajalnik
{
    public partial class Form1 : Form
    {
        static int stanje = 0, a = 0;
        static private byte[] dataBuffer = new byte[16];
        static bool toggle = false;
        static bool UsetSet = false;
        static bool IlimSet = false;
        static int CurrentLimitSet = 0;
        static bool limitStatus = false;
        static bool UmaxSet = false, UsetLimit = false;

        System.Threading.Timer timer;
        private const int CHART_30SEC = 150, CHART_1MIN = 250, CHART_5MIN = 600, CHART_10MIN = 1300, CHART_30MIN = 3500, CHART_1H = 15000;
        private int b = 1, c = 1;
        UInt16 UmerjenaMAX, UmerjenaMIN, ImerjenaMAX, ImerjenaMIN, UIZHOD, IIZHOD;
        UInt16 UMAX_Shranjena, IMAX_Shranjena;
        float napUI = 0;

        public UInt16 UlimSave; // max U, soft omejitev
        public UInt16 UsetSave; // nastavljena U
        public UInt16 IlimSave; // nastavljena limita I
        public byte enableSave; // izhod on/off    
        public byte limitSave;  // limit on/off

        public delegate void Delegate();

        public Form1()
        {
            InitializeComponent();

            chart1.Series.Add("Napetost");
            chart1.Series["Napetost"].Points.AddXY(0, 0);

            chart2.Series.Add("Tok");
            chart2.Series["Tok"].Points.AddXY(0, 0);

            chart3.Series.Add("Moc");
            chart3.Series["Moc"].Points.AddXY(0, 0);

            chart4.Series.Add("ui");
            chart4.Series["ui"].Points.AddXY(0, 0);

        }

        private static byte _crc_ibutton_update(byte icrc, byte data)
        {
            byte i;

            icrc = (byte)(icrc ^ data);
            for (i = 0; i < 8; i++)
            {
                if ((icrc & 0x01) != 0)
                    icrc = (byte)((icrc >> 1) ^ 0x8C);
                else
                    icrc >>= 1;
            }

            return icrc;
        }

        private static byte CalcCRC(byte[] data, byte len)
        {
            byte crc = 0x42;
            int i;

            for (i = 0; i < len; i++)
                crc = _crc_ibutton_update(crc, data[i]);
            return (crc);
        }

        static void Send_CMD(SerialPort sp, nap_cmd cmd)
        {
            byte[] tx_buf = new byte[16];

            if (sp.IsOpen)
            {
                Marshal.StructureToPtr(cmd, Marshal.UnsafeAddrOfPinnedArrayElement(tx_buf, 0), false);
                tx_buf[8] = CalcCRC(tx_buf, 8);
                sp.Write(new byte[] { 0xaa, 0xaa, 0xaa, 0xaa, 0xab }, 0, 5);
                sp.Write(tx_buf, 0, 9);
            }
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == false)
            {
                try
                {
                    string portname = comPortSelect.SelectedItem.ToString();
                    serialPort1.PortName = portname;
                    try
                    {
                        serialPort1.Open();
                    }
                    catch (Exception el)
                    {
                        MessageBox.Show(el.ToString());
                        return;
                    }
                    btConnect.Text = "Prekini";
                    comPortSelect.Enabled = false;
                    labelStatus.Text = "Status: povezano";

                    sliderNapetost.Enabled = true;
                    sliderTok.Enabled = true;
                    radioButtonLimitOFF.Enabled = true;
                    radioButtonLimitON.Enabled = true;
                    sliderUlimit.Enabled = true;
                    buttonStartTable.Enabled = true;
                    numTableInterval.Enabled = true;
                    numU.Enabled = true;
                    numI.Enabled = true;
                    numUlimit.Enabled = true;

                    if (tabControl1.SelectedIndex != 3)
                    {
                        checkBoxAutoLimit.Enabled = true;
                        buttonNastaviLimit.Enabled = true;
                        checkBoxAutoNap.Enabled = true;
                        checkBoxAutoTok.Enabled = true;
                        btnIzhod.Enabled = true;
                        btnNastaviNap.Enabled = true;
                        btnNastaviTok.Enabled = true;
                    }

                    numUI_Iinterval.Enabled = true;
                    numUI_Imax.Enabled = true;
                    numUI_Uinterval.Enabled = true;
                    numUI_Umax.Enabled = true;
                    buttonUIstart.Enabled = true;

                    btnSlave.Enabled = true;
                    comboBoxComSlave.Enabled = true;
                }
                catch (Exception b)
                {
                    MessageBox.Show(b.ToString());
                    comPortSelect.Enabled = true;
                    btConnect.Text = "Poveži";
                    labelStatus.Text = "Status: ni povezano";

                    sliderNapetost.Enabled = false;
                    sliderTok.Enabled = false;
                    btnIzhod.Enabled = false;
                    btnNastaviNap.Enabled = false;
                    btnNastaviTok.Enabled = false;
                    radioButtonLimitOFF.Enabled = false;
                    radioButtonLimitON.Enabled = false;
                    checkBoxAutoNap.Enabled = false;
                    checkBoxAutoTok.Enabled = false;
                    sliderUlimit.Enabled = false;
                    buttonNastaviLimit.Enabled = false;
                    checkBoxAutoLimit.Enabled = false;
                    buttonStartTable.Enabled = false;
                    numTableInterval.Enabled = false;
                    numU.Enabled = false;
                    numI.Enabled = false;
                    numUlimit.Enabled = false;

                    timer2.Stop();
                    timer2.Enabled = false;
                    timer3.Stop();
                    timer3.Enabled = false;
                    numUI_Iinterval.Enabled = false;
                    numUI_Imax.Enabled = false;
                    numUI_Uinterval.Enabled = false;
                    numUI_Umax.Enabled = false;
                    buttonUIstart.Text = "Začni";
                    buttonUIstart.Enabled = false;
                    chart4.Series["ui"].Points.Clear();
                    chart4.Series["ui"].Points.AddXY(0, 0);

                    btnSlave.Enabled = false;
                    comboBoxComSlave.Enabled = false;
                }

            }
            else
            {
                try
                {
                    try
                    {
                        serialPort1.Close();
                    }
                    catch (Exception el)
                    {
                        MessageBox.Show(el.ToString());
                        return;
                    }

                    try
                    {
                        serialPort2.Close();
                        comboBoxComSlave.Enabled = true;
                        btnSlave.BackColor = Color.Red;
                        btnSlave.Text = "Slave COM";
                    }
                    catch (Exception el)
                    {
                        MessageBox.Show(el.ToString());
                        comboBoxComSlave.Enabled = true;
                        btnSlave.BackColor = Color.Red;
                        btnSlave.Text = "Slave COM";
                    }

                    btConnect.Text = "Poveži";
                    comPortSelect.Enabled = true;
                    labelStatus.Text = "Status: ni povezano";

                    sliderNapetost.Enabled = false;
                    sliderTok.Enabled = false;
                    btnIzhod.Enabled = false;
                    btnNastaviNap.Enabled = false;
                    btnNastaviTok.Enabled = false;
                    radioButtonLimitOFF.Enabled = false;
                    radioButtonLimitON.Enabled = false;
                    checkBoxAutoNap.Enabled = false;
                    checkBoxAutoTok.Enabled = false;
                    sliderUlimit.Enabled = false;
                    buttonNastaviLimit.Enabled = false;
                    checkBoxAutoLimit.Enabled = false;
                    buttonStartTable.Enabled = false;
                    numTableInterval.Enabled = false;
                    numU.Enabled = false;
                    numI.Enabled = false;
                    numUlimit.Enabled = false;
                    timer2.Stop();
                    timer2.Enabled = false;

                    timer3.Stop();
                    timer3.Enabled = false;

                    numUI_Iinterval.Enabled = false;
                    numUI_Imax.Enabled = false;
                    numUI_Uinterval.Enabled = false;
                    numUI_Umax.Enabled = false;
                    buttonUIstart.Text = "Začni";
                    buttonUIstart.Enabled = false;
                    chart4.Series["ui"].Points.Clear();
                    chart4.Series["ui"].Points.AddXY(0, 0);

                    btnSlave.Enabled = false;
                    comboBoxComSlave.Enabled = false;
                }
                catch (Exception b)
                {
                    MessageBox.Show(b.ToString());
                    btConnect.Text = "Poveži";
                    comPortSelect.Enabled = true;
                    labelStatus.Text = "Status: ni povezano";

                    sliderNapetost.Enabled = false;
                    sliderTok.Enabled = false;
                    btnIzhod.Enabled = false;
                    btnNastaviNap.Enabled = false;
                    btnNastaviTok.Enabled = false;
                    radioButtonLimitOFF.Enabled = false;
                    radioButtonLimitON.Enabled = false;
                    checkBoxAutoNap.Enabled = false;
                    checkBoxAutoTok.Enabled = false;
                    sliderUlimit.Enabled = false;
                    buttonNastaviLimit.Enabled = false;
                    checkBoxAutoLimit.Enabled = false;
                    buttonStartTable.Enabled = false;
                    numTableInterval.Enabled = false;
                    numU.Enabled = false;
                    numI.Enabled = false;
                    numUlimit.Enabled = false;
                    timer2.Stop();
                    timer2.Enabled = false;

                    timer3.Stop();
                    timer3.Enabled = false;

                    numUI_Iinterval.Enabled = false;
                    numUI_Imax.Enabled = false;
                    numUI_Uinterval.Enabled = false;
                    numUI_Umax.Enabled = false;
                    buttonUIstart.Text = "Začni";
                    buttonUIstart.Enabled = false;
                    chart4.Series["ui"].Points.Clear();
                    chart4.Series["ui"].Points.AddXY(0, 0);

                    btnSlave.Enabled = false;
                    comboBoxComSlave.Enabled = false;
                }

            }
        }


        private void btnIzhod_Click(object sender, EventArgs e)
        {
            toggle = true;
        }

        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
                serialPort1.Close();

        }

        private void nastaviNapetost(string napetost)
        {
            try
            {
                try
                {
                    napetost = napetost.Replace(",", string.Empty);
                }
                catch
                {
                    napetost = napetost.Replace(".", string.Empty);
                }

                int len = napetost.Length;

                if (len == 3)
                {
                    int prva = Convert.ToInt16(napetost.Substring(0, 1));
                    int druga = Convert.ToInt16(napetost.Substring(1, 1));
                    int tretja = Convert.ToInt16(napetost.Substring(2, 1));

                    napBox1.Image = null;

                    switch (prva)
                    {
                        case 0: napBox2.Image = elektronikNapajalnik.Properties.Resources._0; break;
                        case 1: napBox2.Image = elektronikNapajalnik.Properties.Resources._1; break;
                        case 2: napBox2.Image = elektronikNapajalnik.Properties.Resources._2; break;
                        case 3: napBox2.Image = elektronikNapajalnik.Properties.Resources._3; break;
                        case 4: napBox2.Image = elektronikNapajalnik.Properties.Resources._4; break;
                        case 5: napBox2.Image = elektronikNapajalnik.Properties.Resources._5; break;
                        case 6: napBox2.Image = elektronikNapajalnik.Properties.Resources._6; break;
                        case 7: napBox2.Image = elektronikNapajalnik.Properties.Resources._7; break;
                        case 8: napBox2.Image = elektronikNapajalnik.Properties.Resources._8; break;
                        case 9: napBox2.Image = elektronikNapajalnik.Properties.Resources._9; break;
                    }

                    switch (druga)
                    {
                        case 0: napBox3.Image = elektronikNapajalnik.Properties.Resources._0; break;
                        case 1: napBox3.Image = elektronikNapajalnik.Properties.Resources._1; break;
                        case 2: napBox3.Image = elektronikNapajalnik.Properties.Resources._2; break;
                        case 3: napBox3.Image = elektronikNapajalnik.Properties.Resources._3; break;
                        case 4: napBox3.Image = elektronikNapajalnik.Properties.Resources._4; break;
                        case 5: napBox3.Image = elektronikNapajalnik.Properties.Resources._5; break;
                        case 6: napBox3.Image = elektronikNapajalnik.Properties.Resources._6; break;
                        case 7: napBox3.Image = elektronikNapajalnik.Properties.Resources._7; break;
                        case 8: napBox3.Image = elektronikNapajalnik.Properties.Resources._8; break;
                        case 9: napBox3.Image = elektronikNapajalnik.Properties.Resources._9; break;
                    }

                    switch (tretja)
                    {
                        case 0: napBox4.Image = elektronikNapajalnik.Properties.Resources._0; break;
                        case 1: napBox4.Image = elektronikNapajalnik.Properties.Resources._1; break;
                        case 2: napBox4.Image = elektronikNapajalnik.Properties.Resources._2; break;
                        case 3: napBox4.Image = elektronikNapajalnik.Properties.Resources._3; break;
                        case 4: napBox4.Image = elektronikNapajalnik.Properties.Resources._4; break;
                        case 5: napBox4.Image = elektronikNapajalnik.Properties.Resources._5; break;
                        case 6: napBox4.Image = elektronikNapajalnik.Properties.Resources._6; break;
                        case 7: napBox4.Image = elektronikNapajalnik.Properties.Resources._7; break;
                        case 8: napBox4.Image = elektronikNapajalnik.Properties.Resources._8; break;
                        case 9: napBox4.Image = elektronikNapajalnik.Properties.Resources._9; break;
                    }

                }
                else
                {
                    int prva = Convert.ToInt16(napetost.Substring(0, 1));
                    int druga = Convert.ToInt16(napetost.Substring(1, 1));
                    int tretja = Convert.ToInt16(napetost.Substring(2, 1));
                    int cetrta = Convert.ToInt16(napetost.Substring(3, 1));

                    switch (prva)
                    {
                        case 0: napBox1.Image = elektronikNapajalnik.Properties.Resources._0; break;
                        case 1: napBox1.Image = elektronikNapajalnik.Properties.Resources._1; break;
                        case 2: napBox1.Image = elektronikNapajalnik.Properties.Resources._2; break;
                        case 3: napBox1.Image = elektronikNapajalnik.Properties.Resources._3; break;
                        case 4: napBox1.Image = elektronikNapajalnik.Properties.Resources._4; break;
                        case 5: napBox1.Image = elektronikNapajalnik.Properties.Resources._5; break;
                        case 6: napBox1.Image = elektronikNapajalnik.Properties.Resources._6; break;
                        case 7: napBox1.Image = elektronikNapajalnik.Properties.Resources._7; break;
                        case 8: napBox1.Image = elektronikNapajalnik.Properties.Resources._8; break;
                        case 9: napBox1.Image = elektronikNapajalnik.Properties.Resources._9; break;
                    }

                    switch (druga)
                    {
                        case 0: napBox2.Image = elektronikNapajalnik.Properties.Resources._0; break;
                        case 1: napBox2.Image = elektronikNapajalnik.Properties.Resources._1; break;
                        case 2: napBox2.Image = elektronikNapajalnik.Properties.Resources._2; break;
                        case 3: napBox2.Image = elektronikNapajalnik.Properties.Resources._3; break;
                        case 4: napBox2.Image = elektronikNapajalnik.Properties.Resources._4; break;
                        case 5: napBox2.Image = elektronikNapajalnik.Properties.Resources._5; break;
                        case 6: napBox2.Image = elektronikNapajalnik.Properties.Resources._6; break;
                        case 7: napBox2.Image = elektronikNapajalnik.Properties.Resources._7; break;
                        case 8: napBox2.Image = elektronikNapajalnik.Properties.Resources._8; break;
                        case 9: napBox2.Image = elektronikNapajalnik.Properties.Resources._9; break;
                    }

                    switch (tretja)
                    {
                        case 0: napBox3.Image = elektronikNapajalnik.Properties.Resources._0; break;
                        case 1: napBox3.Image = elektronikNapajalnik.Properties.Resources._1; break;
                        case 2: napBox3.Image = elektronikNapajalnik.Properties.Resources._2; break;
                        case 3: napBox3.Image = elektronikNapajalnik.Properties.Resources._3; break;
                        case 4: napBox3.Image = elektronikNapajalnik.Properties.Resources._4; break;
                        case 5: napBox3.Image = elektronikNapajalnik.Properties.Resources._5; break;
                        case 6: napBox3.Image = elektronikNapajalnik.Properties.Resources._6; break;
                        case 7: napBox3.Image = elektronikNapajalnik.Properties.Resources._7; break;
                        case 8: napBox3.Image = elektronikNapajalnik.Properties.Resources._8; break;
                        case 9: napBox3.Image = elektronikNapajalnik.Properties.Resources._9; break;
                    }

                    switch (cetrta)
                    {
                        case 0: napBox4.Image = elektronikNapajalnik.Properties.Resources._0; break;
                        case 1: napBox4.Image = elektronikNapajalnik.Properties.Resources._1; break;
                        case 2: napBox4.Image = elektronikNapajalnik.Properties.Resources._2; break;
                        case 3: napBox4.Image = elektronikNapajalnik.Properties.Resources._3; break;
                        case 4: napBox4.Image = elektronikNapajalnik.Properties.Resources._4; break;
                        case 5: napBox4.Image = elektronikNapajalnik.Properties.Resources._5; break;
                        case 6: napBox4.Image = elektronikNapajalnik.Properties.Resources._6; break;
                        case 7: napBox4.Image = elektronikNapajalnik.Properties.Resources._7; break;
                        case 8: napBox4.Image = elektronikNapajalnik.Properties.Resources._8; break;
                        case 9: napBox4.Image = elektronikNapajalnik.Properties.Resources._9; break;
                    }

                }
            }
            catch (Exception)
            {

            }
        }

        private void nastaviTok(string tok)
        {
            try
            {
                if (IMAX_Shranjena < 1000)
                {
                    picBoxPikaTok.Visible = false;
                    tokBox1.Location = new Point(593, 517);
                    labelZnakAmp.Text = "mA";
                }
                else
                {
                    picBoxPikaTok.Visible = true;
                    tokBox1.Location = new Point(583, 517);
                    labelZnakAmp.Text = "A";
                }

                try
                {
                    tok = tok.Replace(",", string.Empty);
                }
                catch
                {
                    tok = tok.Replace(".", string.Empty);
                }

                int prva = Convert.ToInt16(tok.Substring(0, 1));
                int druga = Convert.ToInt16(tok.Substring(1, 1));
                int tretja = Convert.ToInt16(tok.Substring(2, 1));

                switch (prva)
                {
                    case 0: tokBox1.Image = elektronikNapajalnik.Properties.Resources._0; break;
                    case 1: tokBox1.Image = elektronikNapajalnik.Properties.Resources._1; break;
                    case 2: tokBox1.Image = elektronikNapajalnik.Properties.Resources._2; break;
                    case 3: tokBox1.Image = elektronikNapajalnik.Properties.Resources._3; break;
                    case 4: tokBox1.Image = elektronikNapajalnik.Properties.Resources._4; break;
                    case 5: tokBox1.Image = elektronikNapajalnik.Properties.Resources._5; break;
                    case 6: tokBox1.Image = elektronikNapajalnik.Properties.Resources._6; break;
                    case 7: tokBox1.Image = elektronikNapajalnik.Properties.Resources._7; break;
                    case 8: tokBox1.Image = elektronikNapajalnik.Properties.Resources._8; break;
                    case 9: tokBox1.Image = elektronikNapajalnik.Properties.Resources._9; break;
                }

                switch (druga)
                {
                    case 0: tokBox2.Image = elektronikNapajalnik.Properties.Resources._0; break;
                    case 1: tokBox2.Image = elektronikNapajalnik.Properties.Resources._1; break;
                    case 2: tokBox2.Image = elektronikNapajalnik.Properties.Resources._2; break;
                    case 3: tokBox2.Image = elektronikNapajalnik.Properties.Resources._3; break;
                    case 4: tokBox2.Image = elektronikNapajalnik.Properties.Resources._4; break;
                    case 5: tokBox2.Image = elektronikNapajalnik.Properties.Resources._5; break;
                    case 6: tokBox2.Image = elektronikNapajalnik.Properties.Resources._6; break;
                    case 7: tokBox2.Image = elektronikNapajalnik.Properties.Resources._7; break;
                    case 8: tokBox2.Image = elektronikNapajalnik.Properties.Resources._8; break;
                    case 9: tokBox2.Image = elektronikNapajalnik.Properties.Resources._9; break;
                }

                switch (tretja)
                {
                    case 0: tokBox3.Image = elektronikNapajalnik.Properties.Resources._0; break;
                    case 1: tokBox3.Image = elektronikNapajalnik.Properties.Resources._1; break;
                    case 2: tokBox3.Image = elektronikNapajalnik.Properties.Resources._2; break;
                    case 3: tokBox3.Image = elektronikNapajalnik.Properties.Resources._3; break;
                    case 4: tokBox3.Image = elektronikNapajalnik.Properties.Resources._4; break;
                    case 5: tokBox3.Image = elektronikNapajalnik.Properties.Resources._5; break;
                    case 6: tokBox3.Image = elektronikNapajalnik.Properties.Resources._6; break;
                    case 7: tokBox3.Image = elektronikNapajalnik.Properties.Resources._7; break;
                    case 8: tokBox3.Image = elektronikNapajalnik.Properties.Resources._8; break;
                    case 9: tokBox3.Image = elektronikNapajalnik.Properties.Resources._9; break;
                }
            }
            catch (Exception)
            {

            }
        }

        private void nastaviMoc(string moc)
        {

            try
            {

                if (Convert.ToDouble(moc) < 1 && Convert.ToDouble(moc) >= 0.100)
                {
                    labelZnakMoc.Text = "mW";
                    mocBox1.Visible = false;
                    mocBox2.Visible = true;
                    mocBox3.Visible = true;
                    picBoxPikaMoc.Visible = false;
                    mocBox2.Location = new Point(593, 572);
                }
                else if (Convert.ToDouble(moc) < 0.100 && Convert.ToDouble(moc) >= 0.010)
                {
                    labelZnakMoc.Text = "mW";
                    mocBox1.Visible = false;
                    mocBox2.Visible = false;
                    mocBox3.Visible = true;
                    picBoxPikaMoc.Visible = false;
                    mocBox2.Location = new Point(593, 572);
                }
                else if (Convert.ToDouble(moc) < 0.010)
                {
                    labelZnakMoc.Text = "mW";
                    mocBox1.Visible = false;
                    mocBox2.Visible = false;
                    mocBox3.Visible = false;
                    picBoxPikaMoc.Visible = false;
                    mocBox2.Location = new Point(593, 572);
                }
                else
                {
                    labelZnakMoc.Text = "W";
                    mocBox1.Visible = true;
                    mocBox3.Visible = true;
                    mocBox2.Visible = true;
                    picBoxPikaMoc.Visible = true;
                    mocBox2.Location = new Point(583, 572);
                    moc = moc.Substring(0, moc.Length - 1);
                }

                try
                {
                    moc = moc.Replace(",", string.Empty);
                }
                catch
                {
                    moc = moc.Replace(".", string.Empty);
                }

                int len = moc.Length;

                if (len == 3)
                {
                    int prva = Convert.ToInt16(moc.Substring(0, 1));
                    int druga = Convert.ToInt16(moc.Substring(1, 1));
                    int tretja = Convert.ToInt16(moc.Substring(2, 1));

                    mocBox1.Image = null;

                    switch (prva)
                    {
                        case 0: mocBox2.Image = elektronikNapajalnik.Properties.Resources._0; break;
                        case 1: mocBox2.Image = elektronikNapajalnik.Properties.Resources._1; break;
                        case 2: mocBox2.Image = elektronikNapajalnik.Properties.Resources._2; break;
                        case 3: mocBox2.Image = elektronikNapajalnik.Properties.Resources._3; break;
                        case 4: mocBox2.Image = elektronikNapajalnik.Properties.Resources._4; break;
                        case 5: mocBox2.Image = elektronikNapajalnik.Properties.Resources._5; break;
                        case 6: mocBox2.Image = elektronikNapajalnik.Properties.Resources._6; break;
                        case 7: mocBox2.Image = elektronikNapajalnik.Properties.Resources._7; break;
                        case 8: mocBox2.Image = elektronikNapajalnik.Properties.Resources._8; break;
                        case 9: mocBox2.Image = elektronikNapajalnik.Properties.Resources._9; break;
                    }

                    switch (druga)
                    {
                        case 0: mocBox3.Image = elektronikNapajalnik.Properties.Resources._0; break;
                        case 1: mocBox3.Image = elektronikNapajalnik.Properties.Resources._1; break;
                        case 2: mocBox3.Image = elektronikNapajalnik.Properties.Resources._2; break;
                        case 3: mocBox3.Image = elektronikNapajalnik.Properties.Resources._3; break;
                        case 4: mocBox3.Image = elektronikNapajalnik.Properties.Resources._4; break;
                        case 5: mocBox3.Image = elektronikNapajalnik.Properties.Resources._5; break;
                        case 6: mocBox3.Image = elektronikNapajalnik.Properties.Resources._6; break;
                        case 7: mocBox3.Image = elektronikNapajalnik.Properties.Resources._7; break;
                        case 8: mocBox3.Image = elektronikNapajalnik.Properties.Resources._8; break;
                        case 9: mocBox3.Image = elektronikNapajalnik.Properties.Resources._9; break;
                    }

                    switch (tretja)
                    {
                        case 0: mocBox4.Image = elektronikNapajalnik.Properties.Resources._0; break;
                        case 1: mocBox4.Image = elektronikNapajalnik.Properties.Resources._1; break;
                        case 2: mocBox4.Image = elektronikNapajalnik.Properties.Resources._2; break;
                        case 3: mocBox4.Image = elektronikNapajalnik.Properties.Resources._3; break;
                        case 4: mocBox4.Image = elektronikNapajalnik.Properties.Resources._4; break;
                        case 5: mocBox4.Image = elektronikNapajalnik.Properties.Resources._5; break;
                        case 6: mocBox4.Image = elektronikNapajalnik.Properties.Resources._6; break;
                        case 7: mocBox4.Image = elektronikNapajalnik.Properties.Resources._7; break;
                        case 8: mocBox4.Image = elektronikNapajalnik.Properties.Resources._8; break;
                        case 9: mocBox4.Image = elektronikNapajalnik.Properties.Resources._9; break;
                    }

                }
                else
                {
                    int prva = Convert.ToInt16(moc.Substring(0, 1));
                    int druga = Convert.ToInt16(moc.Substring(1, 1));
                    int tretja = Convert.ToInt16(moc.Substring(2, 1));
                    int cetrta = Convert.ToInt16(moc.Substring(3, 1));

                    switch (prva)
                    {
                        case 0: mocBox1.Image = elektronikNapajalnik.Properties.Resources._0; break;
                        case 1: mocBox1.Image = elektronikNapajalnik.Properties.Resources._1; break;
                        case 2: mocBox1.Image = elektronikNapajalnik.Properties.Resources._2; break;
                        case 3: mocBox1.Image = elektronikNapajalnik.Properties.Resources._3; break;
                        case 4: mocBox1.Image = elektronikNapajalnik.Properties.Resources._4; break;
                        case 5: mocBox1.Image = elektronikNapajalnik.Properties.Resources._5; break;
                        case 6: mocBox1.Image = elektronikNapajalnik.Properties.Resources._6; break;
                        case 7: mocBox1.Image = elektronikNapajalnik.Properties.Resources._7; break;
                        case 8: mocBox1.Image = elektronikNapajalnik.Properties.Resources._8; break;
                        case 9: mocBox1.Image = elektronikNapajalnik.Properties.Resources._9; break;
                    }

                    switch (druga)
                    {
                        case 0: mocBox2.Image = elektronikNapajalnik.Properties.Resources._0; break;
                        case 1: mocBox2.Image = elektronikNapajalnik.Properties.Resources._1; break;
                        case 2: mocBox2.Image = elektronikNapajalnik.Properties.Resources._2; break;
                        case 3: mocBox2.Image = elektronikNapajalnik.Properties.Resources._3; break;
                        case 4: mocBox2.Image = elektronikNapajalnik.Properties.Resources._4; break;
                        case 5: mocBox2.Image = elektronikNapajalnik.Properties.Resources._5; break;
                        case 6: mocBox2.Image = elektronikNapajalnik.Properties.Resources._6; break;
                        case 7: mocBox2.Image = elektronikNapajalnik.Properties.Resources._7; break;
                        case 8: mocBox2.Image = elektronikNapajalnik.Properties.Resources._8; break;
                        case 9: mocBox2.Image = elektronikNapajalnik.Properties.Resources._9; break;
                    }

                    switch (tretja)
                    {
                        case 0: mocBox3.Image = elektronikNapajalnik.Properties.Resources._0; break;
                        case 1: mocBox3.Image = elektronikNapajalnik.Properties.Resources._1; break;
                        case 2: mocBox3.Image = elektronikNapajalnik.Properties.Resources._2; break;
                        case 3: mocBox3.Image = elektronikNapajalnik.Properties.Resources._3; break;
                        case 4: mocBox3.Image = elektronikNapajalnik.Properties.Resources._4; break;
                        case 5: mocBox3.Image = elektronikNapajalnik.Properties.Resources._5; break;
                        case 6: mocBox3.Image = elektronikNapajalnik.Properties.Resources._6; break;
                        case 7: mocBox3.Image = elektronikNapajalnik.Properties.Resources._7; break;
                        case 8: mocBox3.Image = elektronikNapajalnik.Properties.Resources._8; break;
                        case 9: mocBox3.Image = elektronikNapajalnik.Properties.Resources._9; break;
                    }

                    switch (cetrta)
                    {
                        case 0: mocBox4.Image = elektronikNapajalnik.Properties.Resources._0; break;
                        case 1: mocBox4.Image = elektronikNapajalnik.Properties.Resources._1; break;
                        case 2: mocBox4.Image = elektronikNapajalnik.Properties.Resources._2; break;
                        case 3: mocBox4.Image = elektronikNapajalnik.Properties.Resources._3; break;
                        case 4: mocBox4.Image = elektronikNapajalnik.Properties.Resources._4; break;
                        case 5: mocBox4.Image = elektronikNapajalnik.Properties.Resources._5; break;
                        case 6: mocBox4.Image = elektronikNapajalnik.Properties.Resources._6; break;
                        case 7: mocBox4.Image = elektronikNapajalnik.Properties.Resources._7; break;
                        case 8: mocBox4.Image = elektronikNapajalnik.Properties.Resources._8; break;
                        case 9: mocBox4.Image = elektronikNapajalnik.Properties.Resources._9; break;
                    }

                }
            
            }
            catch (Exception)
            {

            }
        }

        private void nastaviUpo(string upo, float imax)
        {
            try
            {
                //upo = upo.Replace(",", string.Empty);
                double value = Math.Abs(Convert.ToDouble(upo));
                int len = 0;

                if (((float)IIZHOD / 1000) != 0.00 && double.IsInfinity(value) == false && double.IsNaN(value) == false && double.IsNegativeInfinity(value) == false && double.IsPositiveInfinity(value) == false)
                {

                    if (value < 10)
                    {
                        labelZnakUpor.Text = "Ω";
                        upo = value.ToString("0.00");
                        try
                        {
                            upo = upo.Replace(",", string.Empty);
                        }
                        catch
                        {
                            upo = upo.Replace(".", string.Empty);
                        }

                        len = 3;
                    }
                    else if (value >= 10 && value < 100)
                    {
                        labelZnakUpor.Text = "Ω";
                        upo = value.ToString("0.00");
                        try
                        {
                            upo = upo.Replace(",", string.Empty);
                        }
                        catch
                        {
                            upo = upo.Replace(".", string.Empty);
                        }
                        len = 4;
                    }
                    else if (value >= 100 && value < 1000)
                    {
                        labelZnakUpor.Text = "kΩ";
                        value = value / 1000;
                        upo = value.ToString("0.00");
                        try
                        {
                            upo = upo.Replace(",", string.Empty);
                        }
                        catch
                        {
                            upo = upo.Replace(".", string.Empty);
                        }
                        len = 3;
                    }
                    else if (value >= 1000 && value < 10000)
                    {
                        labelZnakUpor.Text = "kΩ";
                        value = value / 10;
                        upo = value.ToString("0.00");
                        try
                        {
                            upo = upo.Replace(",", string.Empty);
                        }
                        catch
                        {
                            upo = upo.Replace(".", string.Empty);
                        }
                        len = 3;
                    }
                    else if (value >= 10000 && value < 100000)
                    {
                        labelZnakUpor.Text = "k";
                        upo = value.ToString("0.00");
                        len = 4;
                    }
                    else if (value >= 100000 && value < 10000000)
                    {
                        labelZnakUpor.Text = "MΩ";
                        value = value / 1000000;
                        upo = value.ToString("0.00");
                        if (value < 10)
                            len = 3;
                        else
                            len = 4;
                    }
                    else
                    {
                        upo = "XXXX";
                        len = 4;
                    }
                }
                else
                {
                    upoBox1.Image = null;
                    upoBox1.Tag = 10;
                    upoBox2.Tag = 11;
                    upoBox3.Tag = 11;
                    upoBox4.Tag = 11;
                    upoBox2.Image = elektronikNapajalnik.Properties.Resources.X;
                    upoBox3.Image = elektronikNapajalnik.Properties.Resources.X;
                    upoBox4.Image = elektronikNapajalnik.Properties.Resources.X;
                    labelZnakUpor.Text = "Ω";
                    return;
                }


                int prva;
                int druga;
                int tretja;
                int cetrta;

                if (len == 3)
                {
                    druga = Convert.ToInt16(upo.Substring(0, 1));
                    tretja = Convert.ToInt16(upo.Substring(1, 1));
                    cetrta = Convert.ToInt16(upo.Substring(2, 1));
                    upoBox1.Image = null;
                    prva = 10;
                }
                else
                {
                    prva = Convert.ToInt16(upo.Substring(0, 1));
                    druga = Convert.ToInt16(upo.Substring(1, 1));
                    tretja = Convert.ToInt16(upo.Substring(2, 1));
                    cetrta = Convert.ToInt16(upo.Substring(3, 1));
                }


                switch (prva)
                {
                    case 0: upoBox1.Image = elektronikNapajalnik.Properties.Resources._0; upoBox1.Tag = 0; break;
                    case 1: upoBox1.Image = elektronikNapajalnik.Properties.Resources._1; upoBox1.Tag = 1; break;
                    case 2: upoBox1.Image = elektronikNapajalnik.Properties.Resources._2; upoBox1.Tag = 2; break;
                    case 3: upoBox1.Image = elektronikNapajalnik.Properties.Resources._3; upoBox1.Tag = 3; break;
                    case 4: upoBox1.Image = elektronikNapajalnik.Properties.Resources._4; upoBox1.Tag = 4; break;
                    case 5: upoBox1.Image = elektronikNapajalnik.Properties.Resources._5; upoBox1.Tag = 5; break;
                    case 6: upoBox1.Image = elektronikNapajalnik.Properties.Resources._6; upoBox1.Tag = 6; break;
                    case 7: upoBox1.Image = elektronikNapajalnik.Properties.Resources._7; upoBox1.Tag = 7; break;
                    case 8: upoBox1.Image = elektronikNapajalnik.Properties.Resources._8; upoBox1.Tag = 8; break;
                    case 9: upoBox1.Image = elektronikNapajalnik.Properties.Resources._9; upoBox1.Tag = 9; break;
                }

                switch (druga)
                {
                    case 0: upoBox2.Image = elektronikNapajalnik.Properties.Resources._0; upoBox2.Tag = 0; break;
                    case 1: upoBox2.Image = elektronikNapajalnik.Properties.Resources._1; upoBox2.Tag = 1; break;
                    case 2: upoBox2.Image = elektronikNapajalnik.Properties.Resources._2; upoBox2.Tag = 2; break;
                    case 3: upoBox2.Image = elektronikNapajalnik.Properties.Resources._3; upoBox2.Tag = 3; break;
                    case 4: upoBox2.Image = elektronikNapajalnik.Properties.Resources._4; upoBox2.Tag = 4; break;
                    case 5: upoBox2.Image = elektronikNapajalnik.Properties.Resources._5; upoBox2.Tag = 5; break;
                    case 6: upoBox2.Image = elektronikNapajalnik.Properties.Resources._6; upoBox2.Tag = 6; break;
                    case 7: upoBox2.Image = elektronikNapajalnik.Properties.Resources._7; upoBox2.Tag = 7; break;
                    case 8: upoBox2.Image = elektronikNapajalnik.Properties.Resources._8; upoBox2.Tag = 8; break;
                    case 9: upoBox2.Image = elektronikNapajalnik.Properties.Resources._9; upoBox2.Tag = 9; break;
                }

                switch (tretja)
                {
                    case 0: upoBox3.Image = elektronikNapajalnik.Properties.Resources._0; upoBox3.Tag = 0; break;
                    case 1: upoBox3.Image = elektronikNapajalnik.Properties.Resources._1; upoBox3.Tag = 1; break;
                    case 2: upoBox3.Image = elektronikNapajalnik.Properties.Resources._2; upoBox3.Tag = 2; break;
                    case 3: upoBox3.Image = elektronikNapajalnik.Properties.Resources._3; upoBox3.Tag = 3; break;
                    case 4: upoBox3.Image = elektronikNapajalnik.Properties.Resources._4; upoBox3.Tag = 4; break;
                    case 5: upoBox3.Image = elektronikNapajalnik.Properties.Resources._5; upoBox3.Tag = 5; break;
                    case 6: upoBox3.Image = elektronikNapajalnik.Properties.Resources._6; upoBox3.Tag = 6; break;
                    case 7: upoBox3.Image = elektronikNapajalnik.Properties.Resources._7; upoBox3.Tag = 7; break;
                    case 8: upoBox3.Image = elektronikNapajalnik.Properties.Resources._8; upoBox3.Tag = 8; break;
                    case 9: upoBox3.Image = elektronikNapajalnik.Properties.Resources._9; upoBox3.Tag = 9; break;
                }

                switch (cetrta)
                {
                    case 0: upoBox4.Image = elektronikNapajalnik.Properties.Resources._0; upoBox4.Tag = 0; break;
                    case 1: upoBox4.Image = elektronikNapajalnik.Properties.Resources._1; upoBox4.Tag = 1; break;
                    case 2: upoBox4.Image = elektronikNapajalnik.Properties.Resources._2; upoBox4.Tag = 2; break;
                    case 3: upoBox4.Image = elektronikNapajalnik.Properties.Resources._3; upoBox4.Tag = 3; break;
                    case 4: upoBox4.Image = elektronikNapajalnik.Properties.Resources._4; upoBox4.Tag = 4; break;
                    case 5: upoBox4.Image = elektronikNapajalnik.Properties.Resources._5; upoBox4.Tag = 5; break;
                    case 6: upoBox4.Image = elektronikNapajalnik.Properties.Resources._6; upoBox4.Tag = 6; break;
                    case 7: upoBox4.Image = elektronikNapajalnik.Properties.Resources._7; upoBox4.Tag = 7; break;
                    case 8: upoBox4.Image = elektronikNapajalnik.Properties.Resources._8; upoBox4.Tag = 8; break;
                    case 9: upoBox4.Image = elektronikNapajalnik.Properties.Resources._9; upoBox4.Tag = 9; break;
                }

            }
            catch (Exception)
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dataGridVrednosti.Rows.Count == 0)
            {
                buttonClearData.Enabled = false;
                buttonShraniTable.Enabled = false;
            }

            DateTime dt = DateTime.Now;
            labelTime.Text = dt.ToString();

            int count = System.IO.Ports.SerialPort.GetPortNames().Count();

            if (btConnect.Text == "Poveži" && count != comPortSelect.Items.Count)
            {
                comPortSelect.Items.Clear();

                comPortSelect.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());

                if (comPortSelect.Items.Count > 0)
                {
                    comPortSelect.SelectedIndex = 0;
                }

            }

            if (btnSlave.BackColor == Color.Red && count != comboBoxComSlave.Items.Count)
            {
                comboBoxComSlave.Items.Clear();

                comboBoxComSlave.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());

                if (comboBoxComSlave.Items.Count > 0)
                {
                    comboBoxComSlave.SelectedIndex = 0;
                }
            }

            while (serialPort1.IsOpen && serialPort1.BytesToRead > 0)
            {

                byte oneByte = (byte)serialPort1.ReadByte();

                switch (stanje)
                {
                    case 0:
                    case 1:
                    case 2:
                        if (oneByte == 0xAA) stanje++; else stanje = 0;
                        break;
                    case 3:
                        if (oneByte == 0xAB) { stanje++; a = 0; } else if (oneByte != 0xAA) stanje = 0;
                        break;
                    case 4:
                        dataBuffer[a++] = oneByte;
                        if (a == 16) { a = 0; stanje++; }
                        break;
                    case 5:
                        stanje = 0;
                        byte icrc = CalcCRC(dataBuffer, 16);
                        if (icrc == oneByte)
                        {
                            nap_status ns = (nap_status)Marshal.PtrToStructure(System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(dataBuffer, 0), typeof(nap_status));

                            UMAX_Shranjena = ns.Umax;
                            IMAX_Shranjena = ns.Imax;

                            UIZHOD = ns.Uizh;
                            IIZHOD = ns.Iizh;
                            nap_cmd nc = new nap_cmd();

                            nc.Ulim = ns.Ulim;
                            nc.Uset = ns.Uset;
                            nc.Ilim = ns.Ilim;
                            nc.enable = ns.enable;
                            nc.limit = ns.limit;

                            UlimSave = ns.Ulim;
                            UsetSave = ns.Uset;
                            IlimSave = ns.Ilim;
                            enableSave = ns.enable;
                            limitSave = ns.limit;

                            if (serialPort2.IsOpen)
                            {
                                Send_CMD(serialPort2, nc);
                            }

                            Invoke(new Delegate(delegate()
                            {
                                nastaviNapetost(string.Format("{0:F}", ((float)ns.Uizh) / 1000));

                                if (IMAX_Shranjena < 1000)
                                {
                                    if ((int)ns.Iizh < 10)
                                    {
                                        tokBox1.Visible = false;
                                        tokBox2.Visible = false;
                                    }
                                    else if ((int)ns.Iizh >= 10 && (int)ns.Iizh < 100)
                                    {
                                        tokBox1.Visible = false;
                                        tokBox2.Visible = true;
                                    }
                                    else
                                    {
                                        tokBox1.Visible = true;
                                        tokBox2.Visible = true;
                                    }
                                    nastaviTok(ns.Iizh.ToString("000"));
                                }
                                else
                                {
                                    tokBox1.Visible = true;
                                    tokBox2.Visible = true;
                                    nastaviTok(string.Format("{0:F}", ((float)ns.Iizh) / 1000));
                                }

                                nastaviMoc((((float)ns.Uizh / 1000) * ((float)ns.Iizh / 1000)).ToString("0.000"));
                                nastaviUpo(string.Format("{0:F}", (((float)ns.Uizh / 1000) / ((float)ns.Iizh / 1000))), ns.Imax);

                                labelUtrenutna.Text = string.Format("{0:F}V", (float)ns.Uset / 1000);

                                if (IMAX_Shranjena < 1000)
                                {
                                    if ((int)ns.Ilim < 10)
                                    {
                                        labelItrenutni.Text = ns.Ilim.ToString("0") + "mA";
                                    }
                                    else if ((int)ns.Ilim >= 10 && (int)ns.Ilim < 100)
                                    {
                                        labelItrenutni.Text = ns.Ilim.ToString("00") + "mA";
                                    }
                                    else
                                    {
                                        labelItrenutni.Text = ns.Ilim.ToString("000") + "mA";
                                    }
                                }
                                else
                                    labelItrenutni.Text = string.Format("{0:F}A", (float)ns.Ilim / 1000);

                                labelUlimitTrenutni.Text = string.Format("{0:F}V", ((float)ns.Ulim) / 1000);

                                if (ns.enable == 0)
                                {
                                    btnIzhod.Text = "Izklopljeno";
                                    btnIzhod.BackColor = Color.Red;

                                    if (timer3.Enabled == true && UsetSave != 0)
                                    {
                                        buttonUIstart.Text = "Začni";
                                        numUI_Iinterval.Enabled = true;
                                        numUI_Imax.Enabled = true;
                                        numUI_Uinterval.Enabled = true;
                                        numUI_Umax.Enabled = true;
                                        buttonPobrisi.Enabled = true;

                                        napUI = 0;

                                        nc.Uset = 0;
                                        nc.enable = 0;
                                        nc.Ulim = UlimSave;
                                        nc.Ilim = IlimSave;
                                        nc.limit = limitSave;
                                        Send_CMD(serialPort1, nc);

                                        timer3.Stop();
                                        timer3.Enabled = false;
                                    }
                                }
                                else
                                {
                                    btnIzhod.Text = "Vklopljeno";
                                    btnIzhod.BackColor = Color.Green;
                                }

                                //NAP
                                if (ns.Uizh > UmerjenaMAX)
                                {
                                    UmerjenaMAX = ns.Uizh;
                                    textBoxMAXnap.Text = string.Format("{0:F}V", ((float)ns.Uizh) / 1000);
                                    textBoxMAXtimeNap.Text = dt.ToString("T");
                                }
                                if (b == 1)
                                {
                                    UmerjenaMIN = ns.Uizh;
                                    b = 0;
                                }

                                if (UmerjenaMIN > ns.Uizh)
                                {
                                    UmerjenaMIN = ns.Uizh;
                                    textBoxMINnap.Text = string.Format("{0:F}V", ((float)ns.Uizh) / 1000);
                                    textBoxMINtimeNap.Text = dt.ToString("T");
                                }

                                //TOK
                                if (ns.Iizh > ImerjenaMAX)
                                {
                                    ImerjenaMAX = ns.Iizh;
                                    textBoxMAXtok.Text = string.Format("{0:F}A", ((float)ns.Iizh) / 1000);
                                    textBoxMAXtimeTok.Text = dt.ToString("T");
                                }
                                if (c == 1)
                                {
                                    ImerjenaMAX = ns.Iizh;
                                    c = 0;
                                }

                                if (ImerjenaMIN > ns.Iizh)
                                {
                                    ImerjenaMIN = ns.Iizh;
                                    textBoxMINtok.Text = string.Format("{0:F}A", ((float)ns.Iizh) / 1000);
                                    textBoxMINtimeTok.Text = dt.ToString("T");
                                }

                                // GRAF 1 NAPETOSTNI RIŠE 

                                DataPoint maxDataPointNapetost = chart1.Series["Napetost"].Points.FindMaxByValue();
                                float maxYValue = (float)maxDataPointNapetost.YValues[0];

                                chart1.ChartAreas[0].AxisY.Maximum = auto_125(maxYValue, 1);

                                chart1.ChartAreas[0].AxisY.Interval = chart1.ChartAreas[0].AxisY.Maximum / 10;

                                chart1.ChartAreas[0].AxisY.MinorGrid.Interval = chart1.ChartAreas[0].AxisY.Maximum / 50;

                                double removeBefore = 0;

                                DateTime timeStamp = DateTime.Now;

                                chart1.Series["Napetost"].Points.AddXY(timeStamp, ((float)ns.Uizh / 1000));

                                int value = comboBoxInterval.SelectedIndex;
                                switch (value)
                                {
                                    case 0: removeBefore = timeStamp.AddSeconds(-CHART_30SEC).ToOADate(); break;
                                    case 1: removeBefore = timeStamp.AddSeconds(-CHART_1MIN).ToOADate(); break;
                                    case 2: removeBefore = timeStamp.AddSeconds(-CHART_5MIN).ToOADate(); break;
                                    case 3: removeBefore = timeStamp.AddSeconds(-CHART_10MIN).ToOADate(); break;
                                    case 4: removeBefore = timeStamp.AddSeconds(-CHART_30MIN).ToOADate(); break;
                                    case 5: removeBefore = timeStamp.AddSeconds(-CHART_1H).ToOADate(); break;
                                }

                                chart1.ChartAreas[0].AxisX.LabelStyle.Format = "t";

                                if (value == 0)
                                {
                                    chart1.ChartAreas[0].AxisX.Interval = 1;
                                    chart1.ChartAreas[0].AxisX.MinorGrid.Interval = 30;
                                    chart1.ChartAreas[0].AxisX.MinorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
                                } else {
                                    chart1.ChartAreas[0].AxisX.Interval = 1;
                                    chart1.ChartAreas[0].AxisX.MinorGrid.Interval = 1;
                                    chart1.ChartAreas[0].AxisX.MinorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
                                }

                                while (chart1.Series["Napetost"].Points[0].XValue < removeBefore)
                                {
                                    chart1.Series["Napetost"].Points.RemoveAt(0);
                                }

                                chart1.ChartAreas[0].AxisX.Minimum = chart1.Series["Napetost"].Points[0].XValue;
                                switch (value)
                                {
                                    case 0: chart1.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(chart1.Series["Napetost"].Points[0].XValue).AddSeconds(CHART_30SEC).ToOADate(); chart1.ChartAreas[0].AxisX.Interval = 1; chart1.ChartAreas[0].AxisX.MinorGrid.Interval = 30; break;
                                    case 1: chart1.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(chart1.Series["Napetost"].Points[0].XValue).AddSeconds(CHART_1MIN).ToOADate(); chart1.ChartAreas[0].AxisX.Interval = 1; chart1.ChartAreas[0].AxisX.MinorGrid.Interval = 1; break;
                                    case 2: chart1.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(chart1.Series["Napetost"].Points[0].XValue).AddSeconds(CHART_5MIN).ToOADate(); chart1.ChartAreas[0].AxisX.Interval = 5; chart1.ChartAreas[0].AxisX.MinorGrid.Interval = 1; break;
                                    case 3: chart1.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(chart1.Series["Napetost"].Points[0].XValue).AddSeconds(CHART_10MIN).ToOADate(); chart1.ChartAreas[0].AxisX.Interval = 10; chart1.ChartAreas[0].AxisX.MinorGrid.Interval = 5; break;
                                    case 4: chart1.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(chart1.Series["Napetost"].Points[0].XValue).AddSeconds(CHART_30MIN).ToOADate(); chart1.ChartAreas[0].AxisX.Interval = 30; chart1.ChartAreas[0].AxisX.MinorGrid.Interval = 10; break;
                                    case 5: chart1.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(chart1.Series["Napetost"].Points[0].XValue).AddSeconds(CHART_1H).ToOADate(); chart1.ChartAreas[0].AxisX.Interval = 60; chart1.ChartAreas[0].AxisX.MinorGrid.Interval = 15; break;

                                }
                                chart1.Invalidate();

                                // GRAF 2 TOK RIŠE

                                chart2.ChartAreas[0].AxisX.LabelStyle.Format = "t";

                                if (ns.Imax < 1000)
                                {
                                    chart2.Series["Tok"].Points.AddXY(timeStamp, (float)ns.Iizh);
                                    labelTOKznak.Text = "I [mA]";
                                }
                                else
                                {
                                    chart2.Series["Tok"].Points.AddXY(timeStamp, ((float)ns.Iizh / 1000));
                                    labelTOKznak.Text = "I [A]";
                                }

                                DataPoint maxDataPointTok = chart2.Series["Tok"].Points.FindMaxByValue();
                                maxYValue = (float)maxDataPointTok.YValues[0];

                                chart2.ChartAreas[0].AxisY.Maximum = auto_125(maxYValue, 1);

                                chart2.ChartAreas[0].AxisY.Interval = chart2.ChartAreas[0].AxisY.Maximum / 10;

                                chart2.ChartAreas[0].AxisY.MinorGrid.Interval = chart2.ChartAreas[0].AxisY.Maximum / 50;

                                if (value == 0)
                                {
                                    chart2.ChartAreas[0].AxisX.Interval = 1;
                                    chart2.ChartAreas[0].AxisX.MinorGrid.Interval = 30;
                                    chart2.ChartAreas[0].AxisX.MinorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
                                }
                                else
                                {
                                    chart2.ChartAreas[0].AxisX.Interval = 1;
                                    chart2.ChartAreas[0].AxisX.MinorGrid.Interval = 1;
                                    chart2.ChartAreas[0].AxisX.MinorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
                                }

                                while (chart2.Series["Tok"].Points[0].XValue < removeBefore)
                                {
                                    chart2.Series["Tok"].Points.RemoveAt(0);
                                }

                                chart2.ChartAreas[0].AxisX.Minimum = chart2.Series["Tok"].Points[0].XValue;
                                switch (value)
                                {
                                    case 0: chart2.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(chart2.Series["Tok"].Points[0].XValue).AddSeconds(CHART_30SEC).ToOADate(); chart2.ChartAreas[0].AxisX.Interval = 1; chart2.ChartAreas[0].AxisX.MinorGrid.Interval = 30; break;
                                    case 1: chart2.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(chart2.Series["Tok"].Points[0].XValue).AddSeconds(CHART_1MIN).ToOADate(); chart2.ChartAreas[0].AxisX.Interval = 1; chart2.ChartAreas[0].AxisX.MinorGrid.Interval = 1; break;
                                    case 2: chart2.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(chart2.Series["Tok"].Points[0].XValue).AddSeconds(CHART_5MIN).ToOADate(); chart2.ChartAreas[0].AxisX.Interval = 5; chart2.ChartAreas[0].AxisX.MinorGrid.Interval = 1; break;
                                    case 3: chart2.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(chart2.Series["Tok"].Points[0].XValue).AddSeconds(CHART_10MIN).ToOADate(); chart2.ChartAreas[0].AxisX.Interval = 10; chart2.ChartAreas[0].AxisX.MinorGrid.Interval = 5; break;
                                    case 4: chart2.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(chart2.Series["Tok"].Points[0].XValue).AddSeconds(CHART_30MIN).ToOADate(); chart2.ChartAreas[0].AxisX.Interval = 30; chart2.ChartAreas[0].AxisX.MinorGrid.Interval = 10; break;
                                    case 5: chart2.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(chart2.Series["Tok"].Points[0].XValue).AddSeconds(CHART_1H).ToOADate(); chart2.ChartAreas[0].AxisX.Interval = 60; chart2.ChartAreas[0].AxisX.MinorGrid.Interval = 15; break;

                                }
                                chart2.Invalidate();


                                // GRAF 3 MOČ RIŠE

                                chart3.ChartAreas[0].AxisX.LabelStyle.Format = "t";
                                /*
                                float moc = (((float)ns.Uizh / 1000) * ((float)ns.Iizh / 1000));
                                if (moc < 1)
                                {
                                    labelMOCznak.Text = "mW";
                                    chart3.Series["Moc"].Points.AddXY(timeStamp, moc * 1000);

                                }
                                else
                                {
                                    labelMOCznak.Text = "W";
                                    chart3.Series["Moc"].Points.AddXY(timeStamp, moc);
                                }
                                */
                                float moc = (((float)ns.Uizh / 1000) * ((float)ns.Iizh / 1000));
                                labelMOCznak.Text = "W";
                                chart3.Series["Moc"].Points.AddXY(timeStamp, moc);

                                DataPoint maxDataPointMoc = chart3.Series["Moc"].Points.FindMaxByValue();
                                maxYValue = (float)maxDataPointMoc.YValues[0];

                                chart3.ChartAreas[0].AxisY.Maximum = auto_125(maxYValue, 1);

                                chart3.ChartAreas[0].AxisY.Interval = chart3.ChartAreas[0].AxisY.Maximum / 10;

                                chart3.ChartAreas[0].AxisY.MinorGrid.Interval = chart3.ChartAreas[0].AxisY.Maximum / 50;

                        
                                if (value == 0)
                                {
                                    chart3.ChartAreas[0].AxisX.Interval = 1;
                                    chart3.ChartAreas[0].AxisX.MinorGrid.Interval = 30;
                                    chart3.ChartAreas[0].AxisX.MinorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
                                }
                                else
                                {
                                    chart3.ChartAreas[0].AxisX.Interval = 1;
                                    chart3.ChartAreas[0].AxisX.MinorGrid.Interval = 1;
                                    chart3.ChartAreas[0].AxisX.MinorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
                                }

                                while (chart3.Series["Moc"].Points[0].XValue < removeBefore)
                                {
                                    chart3.Series["Moc"].Points.RemoveAt(0);
                                }

                                chart3.ChartAreas[0].AxisX.Minimum = chart3.Series["Moc"].Points[0].XValue;
                                switch (value)
                                {
                                    case 0: chart3.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(chart3.Series["Moc"].Points[0].XValue).AddSeconds(CHART_30SEC).ToOADate(); chart3.ChartAreas[0].AxisX.Interval = 1; chart3.ChartAreas[0].AxisX.MinorGrid.Interval = 30; break;
                                    case 1: chart3.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(chart3.Series["Moc"].Points[0].XValue).AddSeconds(CHART_1MIN).ToOADate(); chart3.ChartAreas[0].AxisX.Interval = 1; chart3.ChartAreas[0].AxisX.MinorGrid.Interval = 1; break;
                                    case 2: chart3.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(chart3.Series["Moc"].Points[0].XValue).AddSeconds(CHART_5MIN).ToOADate(); chart3.ChartAreas[0].AxisX.Interval = 5; chart3.ChartAreas[0].AxisX.MinorGrid.Interval = 1; break;
                                    case 3: chart3.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(chart3.Series["Moc"].Points[0].XValue).AddSeconds(CHART_10MIN).ToOADate(); chart3.ChartAreas[0].AxisX.Interval = 10; chart3.ChartAreas[0].AxisX.MinorGrid.Interval = 5; break;
                                    case 4: chart3.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(chart3.Series["Moc"].Points[0].XValue).AddSeconds(CHART_30MIN).ToOADate(); chart3.ChartAreas[0].AxisX.Interval = 30; chart3.ChartAreas[0].AxisX.MinorGrid.Interval = 10; break;
                                    case 5: chart3.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(chart3.Series["Moc"].Points[0].XValue).AddSeconds(CHART_1H).ToOADate(); chart3.ChartAreas[0].AxisX.Interval = 60; chart3.ChartAreas[0].AxisX.MinorGrid.Interval = 15; break;
                                }

                                chart3.Invalidate();

                            }));
                            
                            if (sliderNapetost.Maximum != ns.Umax / 10)
                            {
                                sliderNapetost.Maximum = ns.Umax / 10;
                                labelUnastavljena.Text = "0.00V";
                                numU.Maximum = Convert.ToDecimal(((float)ns.Umax / 1000));
                                numU.Value = 0;
                                sliderNapetost.Value = 0;
                            }
                            if (sliderNapetost.Value > ns.Ulim / 10)
                            {
                                sliderNapetost.Value = ns.Ulim / 10;
                                labelUnastavljena.Text = string.Format("{0:F}V", ((float)ns.Ulim / 1000));
                                numU.Value = Convert.ToDecimal(((float)ns.Ulim / 1000));
                            }

                            /*
                            if ((numI.Maximum * 1000) != ns.Imax)
                            {
                                numI.Maximum = Convert.ToDecimal(((float)ns.Imax / 1000));
                            }
                            */
                            if (sliderTok.Value > ns.Imax || sliderTok.Maximum != ns.Imax)
                            {
                                sliderTok.Maximum = ns.Imax;
                                sliderTok.Value = 0;

                                if (sliderTok.Maximum < 1000)
                                {
                                    sliderTok.TickFrequency = 10;
                                    numI.DecimalPlaces = 0;
                                    numI.Maximum = ns.Imax;
                                    numI.Increment = 1;

                                    labelInastavljen.Text = "0mA";

                                    numI.Value = 0;
                                }
                                else
                                {
                                    sliderTok.TickFrequency = 100;
                                    numI.DecimalPlaces = 2;
                                    numI.Maximum = Convert.ToDecimal(((float)ns.Imax / 1000));
                                    numI.Increment = 0.01m;
                                    labelInastavljen.Text = "0.00A";
                                    numI.Value = 0;
                                }

                            }
                            if (sliderUlimit.Maximum != ns.Umax / 10)
                            {
                                sliderUlimit.Maximum = ns.Umax / 10;
                                labelUlimitNastavljena.Text = string.Format("{0:F}V", ((float)ns.Umax / 1000));
                                numUlimit.Maximum = Convert.ToDecimal(((float)ns.Umax / 1000));
                                numUlimit.Value = Convert.ToDecimal(((float)ns.Umax / 1000));
                            }

                            if (ns.Imax < 1000)
                            {
                                if (numUI_Imax.Maximum != ns.Imax) 
                                {
                                    labelTokUI.Text = "I [mA]";
                                    labelTOKUInum.Text = "I Max [mA]";
                                    numUI_Imax.DecimalPlaces = 0;
                                    numUI_Imax.Increment = 1;
                                    numUI_Iinterval.DecimalPlaces = 0;
                                    numUI_Iinterval.Increment = 1;
                                    numUI_Imax.Maximum = ns.Imax;
                                    numUI_Imax.Value = ns.Imax;
                                    numUI_Iinterval.Maximum = ns.Imax;
                                    numUI_Iinterval.Value = 20;
                                    if (numUI_Iinterval.Value > ns.Imax) numUI_Iinterval.Value = ns.Imax;
                                    chart4.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(numUI_Imax.Value);
                                    chart4.ChartAreas[0].AxisY.Interval = Convert.ToDouble(numUI_Iinterval.Value);
                                    chart4.ChartAreas[0].AxisY.MinorGrid.Interval = (int)(numUI_Iinterval.Value/2);
                                }
                            }
                            else
                            {
                                if (numUI_Imax.Maximum != ns.Imax / 1000)
                                {
                                    labelTokUI.Text = "I [A]";
                                    labelTOKUInum.Text = "I Max [A]";
                                    numUI_Imax.DecimalPlaces = 2;
                                    numUI_Imax.Increment = 0.05m;
                                    numUI_Iinterval.DecimalPlaces = 2;
                                    numUI_Iinterval.Increment = 0.05m;
                                    numUI_Imax.Value = ns.Imax / 1000;
                                    numUI_Iinterval.Value = (ns.Imax / 1000) / 2;
                                    numUI_Imax.Maximum = ns.Imax / 1000;
                                    numUI_Iinterval.Maximum = ns.Imax / 1000;
                                    if (numUI_Iinterval.Value > ns.Imax / 1000) numUI_Iinterval.Value = ns.Imax / 1000;
                                    chart4.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(numUI_Imax.Value);
                                    chart4.ChartAreas[0].AxisY.Interval = Convert.ToDouble(numUI_Iinterval.Value);
                                    chart4.ChartAreas[0].AxisY.MinorGrid.Interval = (float)(numUI_Iinterval.Value / 2);
                                }
                            }
                            if (numUI_Umax.Maximum != ns.Umax / 1000) { numUI_Umax.Maximum = ns.Umax / 1000; numUI_Uinterval.Maximum = ns.Umax / 1000; if (numUI_Uinterval.Value > ns.Umax / 1000) numUI_Uinterval.Value = ns.Umax / 1000; }                            
                            //if (Convert.ToDecimal(((float)ns.Umax / 1000)) != sliderUlimit.Maximum)
                            //    sliderUlimit.Maximum = ns.Umax;

                            
                            if (toggle)
                            {
                                nc.Ulim = ns.Ulim;
                                nc.Uset = ns.Uset;
                                nc.Ilim = ns.Ilim;
                                if (ns.enable == 1)
                                    nc.enable = 0;
                                else
                                    nc.enable = 1;
                                nc.limit = ns.limit;
                                Send_CMD(serialPort1, nc);
                                toggle = false;
                            }

                            if (UmaxSet)
                            {
                                nc.Ulim = (ushort)((float)sliderUlimit.Value * 1000);
                                Send_CMD(serialPort1, nc);
                                UmaxSet = false;
                            }

                            if (UsetSet)
                            {
                                nc.Uset = (ushort)((float)sliderNapetost.Value * 10);
                                Send_CMD(serialPort1, nc);
                                UsetSet = false;
                            }

                            if (IlimSet)
                            {
                                nc.Ilim = (ushort)((float)sliderTok.Value);
                                Send_CMD(serialPort1, nc);
                                IlimSet = false;
                            }

                            if (UsetLimit)
                            {
                                nc.Ulim = (ushort)((float)sliderUlimit.Value * 10);
                                Send_CMD(serialPort1, nc);
                                UsetLimit = false;
                            }

                            Invoke(new Delegate(delegate()
                            {

                                if (CurrentLimitSet == 2)
                                {
                                    if (limitStatus == true)
                                        nc.limit = 0;
                                    else
                                        nc.limit = 1;

                                    Send_CMD(serialPort1, nc);
                                    CurrentLimitSet = 0;

                                }

       
                                if (ns.limit == 1)
                                {
                                    limitStatus = true;
                                    radioButtonLimitON.Checked = false;
                                    radioButtonLimitOFF.Checked = true;
                                }
                                else
                                {
                                    if (CurrentLimitSet == 0)
                                    {
                                        limitStatus = false;
                                        radioButtonLimitON.Checked = true;
                                        radioButtonLimitOFF.Checked = false;
                                    }
                                }

             
                            }));

                        }

                        break;
                }
            }
        }

        private double auto_125(float max, float min)
        {
            float x=min; 
            bool ok = false; 
 
            while (!ok) 
            { 
                if (max > x) 
                    x *= 2; 
                else 
                    ok = true; 
                if (max > x) 
                    x *= (float)2.5; 
                else 
                    ok = true; 
                if (max > x) 
                    x *= 2; 
                else 
                    ok = true; 
            }
            return (x); 
        }

        private void sliderNapetost_Scroll(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                float nap = ((float)sliderNapetost.Value / 100);
                float lim = float.Parse(labelUlimitTrenutni.Text.ToString().Substring(0, labelUlimitTrenutni.Text.Length-1));
                if (nap > lim)
                {
                    sliderNapetost.Value = (int)((float)lim * 100);
                    labelUnastavljena.Text = string.Format("{0:F}V", (float)lim);
                    numU.Value = Convert.ToDecimal(lim);
                }
                else
                {
                    labelUnastavljena.Text = string.Format("{0:F}V", nap);
                    numU.Value = Convert.ToDecimal(nap);
                }
                if (checkBoxAutoNap.Checked)
                {
                    timer = new System.Threading.Timer(obj => { UizhPrevSet(); }, null, 100, System.Threading.Timeout.Infinite);
                }
            }
        }

        public void UizhPrevSet()
        {
            UsetSet = true;
        }

        private void sliderTok_Scroll(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {

                if (IMAX_Shranjena < 1000)
                {
                    numI.DecimalPlaces = 0;
                    numI.Maximum = IMAX_Shranjena;
                    numI.Increment = 1;
                    sliderTok.TickFrequency = 10;
                    if ((int)sliderTok.Value < 10)
                    {
                        labelInastavljen.Text = sliderTok.Value.ToString("0") + "mA";
                    }
                    else if ((int)sliderTok.Value >= 10 && sliderTok.Value < 100)
                    {
                        labelInastavljen.Text = sliderTok.Value.ToString("00") + "mA";
                    }
                    else
                    {
                        labelInastavljen.Text = sliderTok.Value.ToString("000") + "mA";
                    }

                    numI.Value = Convert.ToDecimal((int)sliderTok.Value);

                }
                else
                {
                    numI.DecimalPlaces = 2;
                    numI.Maximum = Convert.ToDecimal(((float)IMAX_Shranjena / 1000));
                    numI.Increment = 0.01m;
                    sliderTok.TickFrequency = 100;
                    float tok = ((float)sliderTok.Value / 1000);
                    labelInastavljen.Text = string.Format("{0:F}A", tok);
                    numI.Value = Convert.ToDecimal(tok);

                }

                if (checkBoxAutoTok.Checked)
                {
                    timer = new System.Threading.Timer(obj => { IlimPrevSet(); }, null, 100, System.Threading.Timeout.Infinite);
                }
            }
        }

        private void IlimPrevSet()
        {
            IlimSet = true;
        }

        private void checkBoxAutoNap_CheckedChanged(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (checkBoxAutoNap.Checked)
                    btnNastaviNap.Enabled = false;
                else
                    btnNastaviNap.Enabled = true;
            }
        }

        private void btnNastaviNap_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (!checkBoxAutoNap.Checked)
                    UsetSet = true;
            }
        }

        private void checkBoxAutoTok_CheckedChanged(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (checkBoxAutoTok.Checked)
                    btnNastaviTok.Enabled = false;
                else
                    btnNastaviTok.Enabled = true;
            }
        }

        private void btnNastaviTok_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (!checkBoxAutoTok.Checked)
                    IlimSet = true;
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            int index = saveFileDialog1.FilterIndex;

            if (tabControl1.SelectedIndex == 0)
            {
                switch (index)
                {
                    case 1: chart1.SaveImage(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png); break;
                    case 2: chart1.SaveImage(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg); break;
                    case 3: chart1.SaveImage(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Gif); break;
                }
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                switch (index)
                {
                    case 1: chart2.SaveImage(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png); break;
                    case 2: chart2.SaveImage(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg); break;
                    case 3: chart2.SaveImage(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Gif); break;
                }
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                switch (index)
                {
                    case 1: chart3.SaveImage(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png); break;
                    case 2: chart3.SaveImage(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg); break;
                    case 3: chart3.SaveImage(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Gif); break;
                }
            }

            saveFileDialog1.Reset();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.Filter = "PNG (*.png)|*.png|JPEG (*.jpg)|*.jpg|GIF (*.gif)|*.gif";
            saveFileDialog1.ShowDialog();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

            timer2.Stop();
            timer2.Enabled = false;

            chart1.ChartAreas.Add("area");

            comboBoxInterval.SelectedIndex = 0;

            DateTime minValue = DateTime.Now;
            DateTime maxValue = minValue.AddSeconds(CHART_30SEC);
            chart1.ChartAreas[0].AxisX.Minimum = minValue.ToOADate();
            chart1.ChartAreas[0].AxisX.Maximum = maxValue.ToOADate();
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "t";
            chart1.ChartAreas[0].AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.DarkGray;
            chart1.ChartAreas[0].AxisX.MinorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chart1.ChartAreas[0].AxisX.MinorGrid.Interval = 30;
            chart1.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = true;

            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 10;
            chart1.ChartAreas[0].AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chart1.ChartAreas[0].AxisY.Interval = 1;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.DarkGray;
            chart1.ChartAreas[0].AxisY.MinorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chart1.ChartAreas[0].AxisY.MinorGrid.Interval = 0.2;
            chart1.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = true;

            chart1.Series["Napetost"].Color = Color.Blue;

            chart1.Series["Napetost"].BorderWidth = 2;

            chart1.Series["Napetost"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;

            chart1.Series["Napetost"].XValueType = ChartValueType.DateTime;

            chart2.ChartAreas.Add("area");

            chart2.ChartAreas[0].AxisX.Minimum = minValue.ToOADate();
            chart2.ChartAreas[0].AxisX.Maximum = maxValue.ToOADate();
            chart2.ChartAreas[0].AxisX.LabelStyle.Format = "t";
            chart2.ChartAreas[0].AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
            chart2.ChartAreas[0].AxisX.Interval = 1;
            chart2.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.DarkGray;
            chart2.ChartAreas[0].AxisX.MinorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chart2.ChartAreas[0].AxisX.MinorGrid.Interval = 30;
            chart2.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.LightGray;
            chart2.ChartAreas[0].AxisX.MinorGrid.Enabled = true;


            chart2.ChartAreas[0].AxisY.Minimum = 0;
            chart2.ChartAreas[0].AxisY.Maximum = 10;
            chart2.ChartAreas[0].AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chart2.ChartAreas[0].AxisY.Interval = 1;
            chart2.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.DarkGray;
            chart2.ChartAreas[0].AxisY.MinorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chart2.ChartAreas[0].AxisY.MinorGrid.Interval = 0.2;
            chart2.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.LightGray;
            chart2.ChartAreas[0].AxisY.MinorGrid.Enabled = true;


            chart2.Series["Tok"].Color = Color.Blue;

            chart2.Series["Tok"].BorderWidth = 2;

            chart2.Series["Tok"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;

            chart2.Series["Tok"].XValueType = ChartValueType.DateTime;


            chart3.ChartAreas.Add("area");

            chart3.ChartAreas[0].AxisX.Minimum = minValue.ToOADate();
            chart3.ChartAreas[0].AxisX.Maximum = maxValue.ToOADate();
            chart3.ChartAreas[0].AxisX.LabelStyle.Format = "t";
            chart3.ChartAreas[0].AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
            chart3.ChartAreas[0].AxisX.Interval = 1;
            chart3.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.DarkGray;
            chart3.ChartAreas[0].AxisX.MinorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chart3.ChartAreas[0].AxisX.MinorGrid.Interval = 30;
            chart3.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.LightGray;
            chart3.ChartAreas[0].AxisX.MinorGrid.Enabled = true;


            chart3.ChartAreas[0].AxisY.Minimum = 0;
            chart3.ChartAreas[0].AxisY.Maximum = 10;
            chart3.ChartAreas[0].AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chart3.ChartAreas[0].AxisY.Interval = 1;
            chart3.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.DarkGray;
            chart3.ChartAreas[0].AxisY.MinorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chart3.ChartAreas[0].AxisY.MinorGrid.Interval = 0.2;
            chart3.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.LightGray;
            chart3.ChartAreas[0].AxisY.MinorGrid.Enabled = true;


            chart3.Series["Moc"].Color = Color.Blue;

            chart3.Series["Moc"].BorderWidth = 2;

            chart3.Series["Moc"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;

            chart3.Series["Moc"].XValueType = ChartValueType.DateTime;
        
            chart4.ChartAreas.Add("area");

            chart4.ChartAreas[0].AxisX.Minimum = 0;
            chart4.ChartAreas[0].AxisX.Maximum = 10;
            chart4.ChartAreas[0].AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chart4.ChartAreas[0].AxisX.Interval = 1;
            chart4.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.DarkGray;
            chart4.ChartAreas[0].AxisX.MinorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chart4.ChartAreas[0].AxisX.MinorGrid.Interval = 0.2;
            chart4.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.LightGray;
            chart4.ChartAreas[0].AxisX.MinorGrid.Enabled = true;


            chart4.ChartAreas[0].AxisY.Minimum = 0;
            chart4.ChartAreas[0].AxisY.Maximum = 2;
            chart4.ChartAreas[0].AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chart4.ChartAreas[0].AxisY.Interval = 1;
            chart4.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.DarkGray;
            chart4.ChartAreas[0].AxisY.MinorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chart4.ChartAreas[0].AxisY.MinorGrid.Interval = 0.2;
            chart4.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.LightGray;
            chart4.ChartAreas[0].AxisY.MinorGrid.Enabled = true;


            chart4.Series["ui"].Color = Color.Blue;

            chart4.Series["ui"].BorderWidth = 2;

            chart4.Series["ui"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;

        }

        private void buttonPobrisi_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                chart1.Series["Napetost"].Points.Clear();
                chart1.Series["Napetost"].Points.AddXY(0, 0);
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                chart2.Series["Tok"].Points.Clear();
                chart2.Series["Tok"].Points.AddXY(0, 0);
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                chart3.Series["Moc"].Points.Clear();
                chart3.Series["Moc"].Points.AddXY(0, 0);
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                chart4.Series["ui"].Points.Clear();
                chart4.Series["ui"].Points.AddXY(0, 0);
                napUI = 0;
            }
        }

        private void labelElektronik_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://elektronik.si");
        }

        private void btnClearMAXnap_Click(object sender, EventArgs e)
        {
            UmerjenaMAX = 0;
            textBoxMAXnap.Text = string.Format("{0:F}V", ((float)UIZHOD) / 1000);
            if (btnIzhod.Text == "ON")
            {
                DateTime dt = DateTime.Now;
                textBoxMAXtimeNap.Text = dt.ToString("T");
            }
            else
            {
                textBoxMAXtimeNap.Text = "00:00";
            }
        }

        private void btnClearMINnap_Click(object sender, EventArgs e)
        {
            UmerjenaMIN = 0;
            textBoxMINnap.Text = string.Format("{0:F}V", ((float)UIZHOD) / 1000);
            if (btnIzhod.Text == "ON")
            {
                DateTime dt = DateTime.Now;
                textBoxMINtimeNap.Text = dt.ToString("T");
            }
            else
            {
                textBoxMINtimeNap.Text = "00:00";
            }
            b = 1;
        }

        private void btnClearMAXtok_Click(object sender, EventArgs e)
        {
            ImerjenaMAX = 0;
            textBoxMAXtok.Text = string.Format("{0:F}A", ((float)IIZHOD) / 1000);
            if (btnIzhod.Text == "ON")
            {
                DateTime dt = DateTime.Now;
                textBoxMAXtimeTok.Text = dt.ToString("T");
            }
            else
            {
                textBoxMAXtimeTok.Text = "00:00";
            }
        }

        private void btnClearMINtok_Click(object sender, EventArgs e)
        {
            ImerjenaMIN = 0;
            textBoxMINtok.Text = string.Format("{0:F}A", ((float)IIZHOD) / 1000);
            if (btnIzhod.Text == "ON")
            {
                DateTime dt = DateTime.Now;
                textBoxMINtimeTok.Text = dt.ToString("T");
            }
            else
            {
                textBoxMINtimeTok.Text = "00:00";
            }
            c = 1;
        }

        private void radioButtonLimitOFF_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                CurrentLimitSet = 2;
                limitStatus = false;
            }
        }

        private void radioButtonLimitON_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                CurrentLimitSet = 2;
                limitStatus = true;
            }
        }

        private void sliderUlimit_Scroll(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                float value = ((float)sliderUlimit.Value / 100);
                if (value > (float)sliderUlimit.Value)
                {
                    value = (float)sliderUlimit.Value;
                    sliderUlimit.Value = (int)((float)value * 100);
                }
                labelUlimitNastavljena.Text = string.Format("{0:F}V", value);
                numUlimit.Value = Convert.ToDecimal((float)sliderUlimit.Value / 100);

                if (checkBoxAutoLimit.Checked)
                {
                    if (sliderUlimit.Value < sliderNapetost.Value)
                    {
                        sliderNapetost.Value = sliderUlimit.Value;
                        numU.Value = Convert.ToDecimal((float)sliderUlimit.Value / 100);
                        labelUnastavljena.Text = string.Format("{0:F}V", sliderUlimit.Value / 100);
                    }
                    timer = new System.Threading.Timer(obj => { UlimitSet(); }, null, 100, System.Threading.Timeout.Infinite);

                }
            }
        }

        public void UlimitSet()
        {
            UsetLimit = true;
        }
        
        private void buttonNastaviLimit_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (sliderUlimit.Value < sliderNapetost.Value)
                {
                    sliderNapetost.Value = sliderUlimit.Value;
                    numU.Value = Convert.ToDecimal((float)sliderUlimit.Value / 100);
                    labelUnastavljena.Text = labelUlimitNastavljena.Text;
                }
                if (!checkBoxAutoLimit.Checked)
                    UsetLimit = true;
            }
        }

        private void checkBoxAutoLimit_CheckedChanged(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (checkBoxAutoLimit.Checked)
                    buttonNastaviLimit.Enabled = false;
                else
                    buttonNastaviLimit.Enabled = true;
            }
        }

        private void buttonClearData_Click(object sender, EventArgs e)
        {
            int row = dataGridVrednosti.Rows.Count;
            if (row > 0)
            {
                dataGridVrednosti.Rows.Clear();
            }
        }

        private void numTableInterval_ValueChanged(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                timer2.Interval = (int)(numTableInterval.Value*1000);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                DateTime dt = DateTime.Now;

                string[] rowArray = new string[] { dt.ToString("T"), string.Format("{0:F}V", ((float)UIZHOD) / 1000), string.Format("{0:F}A", ((float)IIZHOD) / 1000), (((float)UIZHOD / 1000) * ((float)IIZHOD / 1000)).ToString("0.000")+"W", returnUpornost() };
                dataGridVrednosti.Rows.Add(rowArray);

                if(dataGridVrednosti.Rows.Count>5)
                dataGridVrednosti.FirstDisplayedScrollingRowIndex = dataGridVrednosti.Rows.Count - 1;
            }
        }

        string returnUpornost()
        {
            string value="";
            string znak = "";
            int tag = 0;

            for (int x = 0; x < 4; x++)
            {
            
                switch (x)
                {
                    case 0: tag = int.Parse(upoBox1.Tag.ToString()); break;
                    case 1: tag = int.Parse(upoBox2.Tag.ToString()); break;
                    case 2: tag = int.Parse(upoBox3.Tag.ToString()); break;
                    case 3: tag = int.Parse(upoBox4.Tag.ToString()); break;
                }
                
                switch (tag)
                {
                    case 0: znak = "0"; break;
                    case 1: znak = "1"; break;
                    case 2: znak = "2"; break;
                    case 3: znak = "3"; break;
                    case 4: znak = "4"; break;
                    case 5: znak = "5"; break;
                    case 6: znak = "6"; break;
                    case 7: znak = "7"; break;
                    case 8: znak = "8"; break;
                    case 9: znak = "9"; break;
                    case 10: znak = ""; break;
                    case 11: znak = "-"; break;
                }
                if (x == 2) znak = "," + znak;
                value = value + znak;
            }

            value = value + labelZnakUpor.Text.ToString();

            return value;
        }

        private void buttonStartTable_Click(object sender, EventArgs e)
        {
            if (buttonStartTable.Text == "Start")
            {
                buttonClearData.Enabled = false;
                buttonShraniTable.Enabled = false;
                buttonStartTable.Text = "Stop";
                timer2.Enabled = true;
                timer2.Start();
                
            }
            else
            {
                buttonClearData.Enabled = true;
                buttonShraniTable.Enabled = true;
                buttonStartTable.Text = "Start";
                timer2.Stop();
                timer2.Enabled = false;
            }
        }

        private void buttonShraniTable_Click(object sender, EventArgs e)
        {
            saveFileDialog2.FilterIndex = 1;
            saveFileDialog2.Filter = "Excel Workbook (*.xls)|*.xls|Text Documents (*.txt)|*.txt";
            saveFileDialog2.ShowDialog();
        }

        private void saveFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            int index = saveFileDialog1.FilterIndex;
            if (index == 0)
            {
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Excel.ApplicationClass();
                xlWorkBook = xlApp.Workbooks.Add(misValue);

                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                xlWorkSheet.Cells[1, 1] = "Napetost";
                xlWorkSheet.Cells[1, 2] = "Tok";
                xlWorkSheet.Cells[1, 3] = "Ura";
                xlWorkSheet.Cells[1, 4] = "Moč";
                xlWorkSheet.Cells[1, 5] = "Upornost";

                for (int x = 0; x < dataGridVrednosti.Rows.Count; x++)
                {
                    xlWorkSheet.Cells[x + 2, 1] = dataGridVrednosti.Rows[x].Cells[0].Value;
                    xlWorkSheet.Cells[x + 2, 2] = dataGridVrednosti.Rows[x].Cells[1].Value;
                    xlWorkSheet.Cells[x + 2, 3] = dataGridVrednosti.Rows[x].Cells[2].Value;
                    xlWorkSheet.Cells[x + 2, 4] = dataGridVrednosti.Rows[x].Cells[3].Value;
                    xlWorkSheet.Cells[x + 2, 5] = dataGridVrednosti.Rows[x].Cells[4].Value;
                }

                xlWorkBook.SaveAs(saveFileDialog2.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

            }
            else if (index == 1)
            {
                StreamWriter MyStream = null;

                try
                {
                    MyStream = File.CreateText(saveFileDialog2.FileName);
                    MyStream.WriteLine("Napetost,Tok,Ura,Moč,Upornost");

                    for (int x = 0; x < dataGridVrednosti.Rows.Count; x++)
                    {
                        MyStream.WriteLine(dataGridVrednosti.Rows[x].Cells[0].Value+","+dataGridVrednosti.Rows[x].Cells[1].Value+","+dataGridVrednosti.Rows[x].Cells[2].Value+","+dataGridVrednosti.Rows[x].Cells[3].Value+","+dataGridVrednosti.Rows[x].Cells[4].Value);
                    }
                }
                catch (IOException el)
                {
                    Console.WriteLine(el);
                }
                catch (Exception el)
                {
                    Console.WriteLine(el);
                }
                finally
                {
                    if (MyStream != null)
                        MyStream.Close();
                }

            }

            saveFileDialog2.Reset();

        }

        private void releaseObject(object obj)
        {

            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }

        }

        private void numUI_Imax_ValueChanged(object sender, EventArgs e)
        {
            if (numUI_Imax.Value < numUI_Iinterval.Value) { numUI_Imax.Value = numUI_Iinterval.Value; return; }
            chart4.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(numUI_Imax.Value);
            chart4.ChartAreas[0].AxisY.Interval = Convert.ToDouble(numUI_Iinterval.Value);

            chart4.ChartAreas[0].AxisX.Maximum = Convert.ToDouble(numUI_Umax.Value);
            chart4.ChartAreas[0].AxisX.Interval = Convert.ToDouble(numUI_Uinterval.Value);
        }

        private void numUI_Iinterval_ValueChanged(object sender, EventArgs e)
        {
            chart4.ChartAreas[0].AxisY.MinorGrid.Interval = (float)(numUI_Iinterval.Value / 2);

            if (numUI_Iinterval.Value > numUI_Imax.Value) { numUI_Iinterval.Value = numUI_Imax.Value; return; }
            chart4.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(numUI_Imax.Value);
            chart4.ChartAreas[0].AxisY.Interval = Convert.ToDouble(numUI_Iinterval.Value);

            chart4.ChartAreas[0].AxisX.Maximum = Convert.ToDouble(numUI_Umax.Value);
            chart4.ChartAreas[0].AxisX.Interval = Convert.ToDouble(numUI_Uinterval.Value);

        }

        private void numUI_Umax_ValueChanged(object sender, EventArgs e)
        {
            chart4.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(numUI_Imax.Value);
            chart4.ChartAreas[0].AxisY.Interval = Convert.ToDouble(numUI_Iinterval.Value);

            chart4.ChartAreas[0].AxisX.Maximum = Convert.ToDouble(numUI_Umax.Value);
            chart4.ChartAreas[0].AxisX.Interval = Convert.ToDouble(numUI_Uinterval.Value);
        }

        private void numUI_Uinterval_ValueChanged(object sender, EventArgs e)
        {
            chart4.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(numUI_Imax.Value);
            chart4.ChartAreas[0].AxisY.Interval = Convert.ToDouble(numUI_Iinterval.Value);

            chart4.ChartAreas[0].AxisX.Maximum = Convert.ToDouble(numUI_Umax.Value);
            chart4.ChartAreas[0].AxisX.Interval = Convert.ToDouble(numUI_Uinterval.Value);
        }

        private void numU_ValueChanged(object sender, EventArgs e)
        {
                float lim = float.Parse(labelUlimitTrenutni.Text.ToString().Substring(0, labelUlimitTrenutni.Text.Length-1));
                if ((float)numU.Value > lim)
                {
                    sliderNapetost.Value = (int)((float)lim * 100);
                    labelUnastavljena.Text = string.Format("{0:F}V", (float)lim);
                    numU.Value = Convert.ToDecimal(lim);
                }
                else
                {
                    sliderNapetost.Value = (int)(numU.Value * 100);
                    labelUnastavljena.Text = string.Format("{0:F}V", (float)numU.Value);
                }
                if (checkBoxAutoNap.Checked)
                {
                    timer = new System.Threading.Timer(obj => { UizhPrevSet(); }, null, 100, System.Threading.Timeout.Infinite);
                }
        }

        private void numI_ValueChanged(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (IMAX_Shranjena < 1000)
                {
                    sliderTok.TickFrequency = 10;
                    numI.DecimalPlaces = 0;
                    numI.Maximum = IMAX_Shranjena;
                    numI.Increment = 1;
                    sliderTok.Value = (int)numI.Value;
                    if ((int)sliderTok.Value < 10)
                    {
                        labelInastavljen.Text = ((int)sliderTok.Value).ToString("0") + "mA";
                    }
                    else if ((int)sliderTok.Value >= 10 && sliderTok.Value < 100)
                    {
                        labelInastavljen.Text = ((int)sliderTok.Value).ToString("00") + "mA";
                    }
                    else
                    {
                        labelInastavljen.Text = ((int)sliderTok.Value).ToString("000") + "mA";
                    }

                }
                else
                {
                    sliderTok.TickFrequency = 100;
                    numI.DecimalPlaces = 2;
                    Convert.ToDecimal(((float)IMAX_Shranjena / 1000));
                    numI.Increment = (decimal)0.01m;
                    labelInastavljen.Text = string.Format("{0:F}A", numI.Value);
                    sliderTok.Value = (int)(numI.Value * 1000);
                }


                if (checkBoxAutoTok.Checked)
                {
                    timer = new System.Threading.Timer(obj => { IlimPrevSet(); }, null, 100, System.Threading.Timeout.Infinite);
                }
            }
        }

        private void numUlimit_ValueChanged(object sender, EventArgs e)
        {
            sliderUlimit.Value = (int)(numUlimit.Value * 100);
            labelUlimitNastavljena.Text = string.Format("{0:F}V", numUlimit.Value);
            if (checkBoxAutoLimit.Checked)
            {
                if (sliderUlimit.Value < sliderNapetost.Value)
                {
                    sliderNapetost.Value = sliderUlimit.Value;
                    numU.Value = Convert.ToDecimal((float)sliderUlimit.Value / 100);
                    labelUnastavljena.Text = string.Format("{0:F}V", sliderUlimit.Value / 100);
                }
                timer = new System.Threading.Timer(obj => { UlimitSet(); }, null, 100, System.Threading.Timeout.Infinite);

            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (tabControl1.SelectedIndex == 3)
                {
                    comboBoxInterval.Enabled = false;

                    buttonNastaviLimit.Enabled = false;
                    btnNastaviNap.Enabled = false;
                    btnNastaviTok.Enabled = false;
                    checkBoxAutoLimit.Enabled = false;
                    checkBoxAutoNap.Enabled = false;
                    checkBoxAutoTok.Enabled = false;
                    btnIzhod.Enabled = false;
                    sliderNapetost.Enabled = false;
                    sliderTok.Enabled = false;
                    sliderUlimit.Enabled = false;
                    numUlimit.Enabled = false;
                    numI.Enabled = false;
                    numU.Enabled = false;
                }
                else
                {
                    comboBoxInterval.Enabled = true;

                    buttonNastaviLimit.Enabled = true;
                    btnNastaviNap.Enabled = true;
                    btnNastaviTok.Enabled = true;
                    checkBoxAutoTok.Enabled = true;
                    checkBoxAutoNap.Enabled = true;
                    checkBoxAutoLimit.Enabled = true;
                    btnIzhod.Enabled = true;
                    sliderNapetost.Enabled = true;
                    sliderTok.Enabled = true;
                    sliderUlimit.Enabled = true;
                    numUlimit.Enabled = true;
                    numI.Enabled = true;
                    numU.Enabled = true;

                }
            }
        }

        int o = 0;


        private void buttonUIstart_Click(object sender, EventArgs e)
        {
            o = 0;

            if (buttonUIstart.Text == "Začni")
            {
                timer3.Enabled = true;
                timer3.Start();
                buttonUIstart.Text = "Končaj";
                buttonPobrisi.Enabled = false;
                numUI_Iinterval.Enabled = false;
                numUI_Imax.Enabled = false;
                numUI_Uinterval.Enabled = false;
                numUI_Umax.Enabled = false;

                chart4.Series["ui"].Points.Clear();
                chart4.Series["ui"].Points.AddXY(0, 0);

                UsetSave = 0;
                napUI = 0;
                nap_cmd nc = new nap_cmd();
                nc.Uset = (ushort)((float)0);
                nc.enable = 0;
                nc.Ulim = UlimSave;
                if (IMAX_Shranjena < 1000)
                    nc.Ilim = (ushort)(numUI_Imax.Value);
                else
                    nc.Ilim = (ushort)(numUI_Imax.Value * 1000);
                nc.limit = limitSave;
                Send_CMD(serialPort1, nc);
            }
            else
            {
                timer3.Stop();
                timer3.Enabled = false;
                buttonUIstart.Text = "Začni";
                buttonPobrisi.Enabled = true;
                numUI_Iinterval.Enabled = true;
                numUI_Imax.Enabled = true;
                numUI_Uinterval.Enabled = true;
                numUI_Umax.Enabled = true;

                napUI = 0;
                nap_cmd nc = new nap_cmd();
                nc.Uset = (ushort)((float)0);
                nc.enable = 0;
                nc.Ulim = UlimSave;
                nc.Ilim = IlimSave;
                nc.limit = limitSave;
                Send_CMD(serialPort1, nc);

            }
        }


        private void timer3_Tick(object sender, EventArgs e)
        {
            nap_cmd nc = new nap_cmd();

                //napUI = napUI + (float)numUI_Uinterval.Value;

                if (o == 0)
                {
                    nc.Uset = (ushort)((float)napUI);
                    nc.enable = 1;
                    nc.Ulim = UlimSave;
                    if (IMAX_Shranjena < 1000)
                        nc.Ilim = (ushort)(numUI_Imax.Value);
                    else
                        nc.Ilim = (ushort)(numUI_Imax.Value * 1000);
                    nc.limit = limitSave;
                    Send_CMD(serialPort1, nc);

                    Thread.Sleep(100);

                    nc.Uset = (ushort)((float)napUI);
                    nc.enable = 1;
                    nc.Ulim = UlimSave;
                    if (IMAX_Shranjena < 1000)
                        nc.Ilim = (ushort)(numUI_Imax.Value);
                    else
                        nc.Ilim = (ushort)(numUI_Imax.Value * 1000);
                    nc.limit = limitSave;
                    Send_CMD(serialPort1, nc);
                    o = 1;
                }
                else
                {
                    if(IMAX_Shranjena < 1000)
                        chart4.Series["ui"].Points.AddXY(((float)UIZHOD / 1000), (float)IIZHOD);
                    else
                        chart4.Series["ui"].Points.AddXY(((float)UIZHOD / 1000), ((float)IIZHOD / 1000));
                    napUI = (float)(napUI + (float)Convert.ToDecimal(numUI_Uinterval.Value * 1000));

                    o = 0;

                    if (UsetSave == napUI)
                    {
                        nc.Uset = (ushort)((float)napUI);
                        nc.enable = 1;
                        nc.Ulim = UlimSave;
                        if (IMAX_Shranjena < 1000)
                            nc.Ilim = (ushort)(numUI_Imax.Value);
                        else
                            nc.Ilim = (ushort)(numUI_Imax.Value * 1000);
                        nc.limit = limitSave;
                        Send_CMD(serialPort1, nc);
                    }

                    if (timer3.Enabled == true && UsetSave != 0 && ((UsetSave / 1000) >= (float)Convert.ToDecimal(numUI_Umax.Value)))
                    {
                        buttonUIstart.Text = "Začni";
                        numUI_Iinterval.Enabled = true;
                        numUI_Imax.Enabled = true;
                        numUI_Uinterval.Enabled = true;
                        numUI_Umax.Enabled = true;
                        buttonPobrisi.Enabled = true;

                        napUI = 0;

                        nc.Uset = 0;
                        nc.enable = 0;
                        nc.Ulim = UlimSave;
                        nc.Ilim = IlimSave;
                        nc.limit = limitSave;
                        Send_CMD(serialPort1, nc);

                        timer3.Stop();
                        timer3.Enabled = false;
                    }
                }

                chart4.Invalidate();
        }
        /*
        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();

        void chart4_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chart4.HitTest(pos.X, pos.Y, false,
                                            ChartElementType.DataPoint);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    var prop = result.Object as DataPoint;
                    if (prop != null)
                    {
                        var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                        var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);
                        Console.WriteLine(pointXPixel.ToString());
                        // check if the cursor is really close to the point (2 pixels around the point)
                        if (Math.Abs(pos.X - pointXPixel) < 2 &&
                            Math.Abs(pos.Y - pointYPixel) < 2)
                        {
                            tooltip.Show("U=" + prop.XValue + ", I=" + prop.YValues[0], this.chart4,
                                            pos.X, pos.Y - 15);
                        }
                    }
                }
            }
        }
        */
        private void btnSlave_Click(object sender, EventArgs e)
        {
            if (serialPort2.IsOpen == false)
            {
                try
                {
                    string portname = comboBoxComSlave.SelectedItem.ToString();
                    serialPort2.PortName = portname;
                    try
                    {
                        serialPort2.Open();
                        comboBoxComSlave.Enabled = false;
                        btnSlave.BackColor = Color.Green;
                        btnSlave.Text = "Slave " + portname;
                    }
                    catch (Exception el)
                    {
                        MessageBox.Show(el.ToString());
                        comboBoxComSlave.Enabled = true;
                        btnSlave.BackColor = Color.Red;
                        btnSlave.Text = "Slave COM";
                        return;
                    }

                }
                catch (Exception b)
                {
                    MessageBox.Show(b.ToString());
                    comboBoxComSlave.Enabled = true;
                    btnSlave.BackColor = Color.Red;
                    btnSlave.Text = "Slave COM";

                }

            }
            else
            {
                try
                {
                    try
                    {
                        serialPort2.Close();
                        comboBoxComSlave.Enabled = true;
                        btnSlave.BackColor = Color.Red;
                        btnSlave.Text = "Slave COM";
                    }
                    catch (Exception el)
                    {
                        MessageBox.Show(el.ToString());
                        comboBoxComSlave.Enabled = true;
                        btnSlave.BackColor = Color.Red;
                        btnSlave.Text = "Slave COM";
                        return;
                    }
                }
                catch (Exception b)
                {
                    MessageBox.Show(b.ToString());
                    comboBoxComSlave.Enabled = true;
                    btnSlave.BackColor = Color.Red;
                    btnSlave.Text = "Slave COM";
                }

            }
        }

        private void comboBoxComSlave_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxComSlave.SelectedItem.ToString() == serialPort1.PortName.ToString() && serialPort1.IsOpen)
            {
                MessageBox.Show("COM port je zaseden","Serial port error!");
                comboBoxComSlave.SelectedIndex = 0;
            }
        }

    }
}
