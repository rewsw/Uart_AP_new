using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.IO;
namespace Uart_AP_Jerry
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SerialPort _SP;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void TM0_MC0(SerialPort sp) {
            if (sp.IsOpen) {
                byte[] wr1 = new byte[5] { 0x89, 0x00, 0x00, 0x60, 0x07 };
                byte[] wr2 = new byte[5] { 0x8a, 0x10, 0x00, 0x00, 0x00 };
                DataTb.AppendText("---------------TM0 Start---------------\r\n\r\n");
                sp.Write(wr1, 0, wr1.Length);
                DataTb.AppendText("Send Write RW_CTRL\r\n");
                Thread.Sleep(5);
                sp.Write(wr2, 0, wr2.Length);
                DataTb.AppendText("Send Write RW_Start\r\n");
                Thread.Sleep(5);
                while (sp.BytesToRead > 0)
                {
                    sp.ReadByte();
                }
                
                DataTb.AppendText("Poll RW_Start[0] tie Low\r\n");
                while (true) {
                    byte[] re1 = new byte[1] { 0x0a };
                    sp.Write(re1, 0, re1.Length);
                    Thread.Sleep(5);
                    byte[] rs = new byte[4];
                    int rb = sp.Read(rs, 0, rs.Length);
                    if ((rs[0] & 0x01) == 0x00) {
                        break;
                    }
                }
                DataTb.AppendText("---------------TM0 END---------------\r\n\r\n");
            }
        }

        private bool TM1_CP(SerialPort sp, byte Tm, UInt32 Test_Counter)  //CP2 == CP1
        {
            if (sp.IsOpen)
            {

                byte[] RW_CTRL = new byte[5];
                byte[] RW_Start = new byte[5];
                if (Tm == 1) {
                    DataTb.AppendText("---------------TM1 Start---------------\r\n\r\n");
                    RW_CTRL = new byte[5] { 0x89, 0x00, 0x00, 0x01, 0x00 };
                    RW_Start = new byte[5] { 0x8a, 0x01, 0x00, 0x00, 0x00 };
                    sp.Write(RW_CTRL, 0, RW_CTRL.Length);
                    DataTb.AppendText("Send Write RW_CTRL\r\n");
                    Thread.Sleep(5);
                    sp.Write(RW_Start, 0, RW_Start.Length);
                    DataTb.AppendText("Send Write RW_Start\r\n");
                    Thread.Sleep(5);
                } else if (Tm == 2) {
                    DataTb.AppendText("---------------TM2 Start---------------\r\n\r\n");
                    RW_CTRL = new byte[5] { 0x89, 0x00, 0x00, 0x02, 0x00 };
                    RW_Start = new byte[5] { 0x8a, 0x01, 0x00, 0x00, 0x00 };
                    sp.Write(RW_CTRL, 0, RW_CTRL.Length);
                    DataTb.AppendText("Send Write RW_CTRL\r\n");
                    Thread.Sleep(5);
                    sp.Write(RW_Start, 0, RW_Start.Length);
                    DataTb.AppendText("Send Write RW_Start\r\n");
                    Thread.Sleep(5);
                }
                
                while (sp.BytesToRead > 0)
                {
                    sp.ReadByte();
                }
                byte[] re1 = new byte[1] { 0x0a };
                byte[] re2 = new byte[1] { 0x0b };
                DataTb.AppendText("Poll RW_Start[0] tie Low\r\n");
                while (true)
                {
                    sp.Write(re1, 0, re1.Length);
                    Thread.Sleep(5);
                    byte[] rs = new byte[4];
                    int rb = sp.Read(rs, 0, rs.Length);
                    if ((rs[0] & 0x01) == 0x00)
                    {
                        break;
                    }
                }
                sp.Write(re2, 0, re2.Length);
                Thread.Sleep(5);
                DataTb.AppendText("Read Test Counter\r\n");
                byte[] rs2 = new byte[4];
                int rb2 = sp.Read(rs2, 0, rs2.Length);
                UInt32 Result = (UInt32)(rs2[0] + (rs2[1] << 8) + (rs2[2] << 16) + (rs2[3] << 24));
                if (Result == Test_Counter) { 
                    DataTb.AppendText("Data Right\r\n");
                    DataTb.AppendText("---------------TM End--------------- \r\n\r\n");
                    return true;
                }
                else
                {
                    DataTb.AppendText("Data Fault\r\n");
                    DataTb.AppendText("---------------TM End--------------- \r\n\r\n");
                    return false;
                }


            }
            else
            {
                return false;
            }
        }

        private void Read4DataFromContinuousAddress(SerialPort sp, byte address, UInt32[] Data, byte Direction) {
            if (sp.IsOpen) {
                
                byte[] Address = new byte[5] { 0x80, (byte)((address >> 0) & 0xFF), (byte)((address >> 8) & 0xFF),
                    (byte)((address>> 16) & 0xFF), (byte)((address >> 24) & 0xFF) };
                sp.Write(Address, 0, Address.Length);
                Thread.Sleep(5);

                DataTb.AppendText("---------------TM3 Start---------------\r\n");
                int index = 0;
                while (index < 4) {
                    if ((Direction & (0x1 << index)) > 0) {
                        byte[] write_data = new byte[5] {(byte)(0x81+index), (byte)((Data[index] >> 0) & 0xFF), (byte)((Data[index] >> 8) & 0xFF),
                    (byte)((Data[index] >> 16) & 0xFF), (byte)((Data[index] >> 24) & 0xFF)};
                        sp.Write(write_data, 0, write_data.Length);

                        DataTb.AppendText(string.Format("Write Data {0} --> {1:X32}\r\n",index,Data[index]));
                    }
                    Thread.Sleep(5);
                    index++;
                }


                byte[] RW_CTRL = new byte[5] { 0x89, 0x00, 0x01, 0x00, 0x48 };
                byte[] RW_Start = new byte[5] { 0x8a, 0x42, 0x01, 0x03, 0x00 };
                byte[] P_RW_start = new byte[1] { 0x0a };
                sp.Write(RW_CTRL, 0, RW_CTRL.Length);
                DataTb.AppendText("Send Write RW_CTRL\r\n");
                Thread.Sleep(5);
                sp.Write(RW_Start, 0, RW_Start.Length);
                DataTb.AppendText("Send Write RW_Start\r\n");
                Thread.Sleep(5);
                while (sp.BytesToRead > 0)
                {
                    sp.ReadByte();
                }
                DataTb.AppendText("Poll RW_Start[0] tie Low\r\n");
                while (true)
                {
                    byte[] re1 = new byte[1] { 0x0a };
                    sp.Write(re1, 0, re1.Length);
                    Thread.Sleep(5);
                    byte[] rs = new byte[4];
                    int rb = sp.Read(rs, 0, rs.Length);
                    if ((rs[0] & 0x01) == 0x00)
                    {
                        break;
                    }
                }

                while (sp.BytesToRead > 0)
                {
                    sp.ReadByte();
                }

                index = 0;
                while (index < 4)
                {
                    if ((Direction & (0x1 << index)) == 0)
                    {
                        byte[] Read_data = new byte[1] { (byte)(0x05 + index) };
                        sp.Write(Read_data, 0, Read_data.Length);
                    }
                    Thread.Sleep(5);
                    byte[] RData = new byte[4];
                    sp.Read(RData, 0, RData.Length);
                    UInt32 Decoder = hex_to_uint(RData);
                    if (Decoder == Data[index]) {
                        DataTb.AppendText(string.Format("Read Data {0} <-- {1:X32} != {2:X32}\r\n", index, Decoder, Data[index]));
                    }
                    else
                    {
                        DataTb.AppendText(string.Format("Read Data {0} <-- {1:X32} != {2:X32}\r\n", index, Decoder, Data[index]));
                    }
                    index++;
                }

            }
        }
        private UInt32 hex_to_uint(byte[] input)
        {
            return (UInt32)(input[0] + input[1] << 8 + input[2] << 16 + input[3] << 24);
        }
        List<string[]> cmd_array = new List<string[]>();

        private void LoadCmdBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog op = new OpenFileDialog()) {
                op.Title = "Chose CMD";
                op.Filter = "CMD files (*.cmd)|*.cmd|All files (*.*)|*.*";
                if (op.ShowDialog() == DialogResult.OK) {
                    var fileStream = op.OpenFile();
                    CmdTb.Clear();
                    DataTb.Clear();
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        string line;
                        cmd_array.Clear();
                        int i = 0;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] data_array = line.Split(new char[] { ' ' });
                            cmd_array.Add(data_array);
                            CmdTb.AppendText("["+i.ToString()+"] "+line+"\r\n");
                            i++;
                        }
                    }
                }
            }
        }

        private void RunTestBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cmd_array.Count; i++) {

                byte instruction = byte.Parse(cmd_array[i][0], System.Globalization.NumberStyles.HexNumber);
                switch (instruction) {
                    case 0x00:
                        DataTb.AppendText(string.Format("執行第[{0}]\r\n",i));
                        break;
                    case 0x01:
                        DataTb.AppendText(string.Format("執行第[{0}]\r\n", i));
                        break;
                    case 0x02:
                        DataTb.AppendText(string.Format("執行第[{0}]\r\n", i));
                        break;
                    case 0x03:
                        DataTb.AppendText(string.Format("執行第[{0}]\r\n", i));
                        break;
                    case 0x1e:
                        DataTb.AppendText(string.Format("執行第[{0}]\r\n", i));
                        break;
                    case 0x1f:
                        DataTb.AppendText(string.Format("執行第[{0}] End\r\n", i));
                        break;
                    default:
                        break;
                }

            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            CmdTb.Clear();
            DataTb.Clear();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comPortToolStripMenuItem.DropDownItems.Clear();
            string[] port_st = SerialPort.GetPortNames();
            for (int i = 0; i < port_st.Length; i++)
            {
                comPortToolStripMenuItem.DropDownItems.Add(port_st[i]);
                comPortToolStripMenuItem.DropDownItems[i].Click += dropdownitem_click;
            }
        }
        private void dropdownitem_click(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolStripMenuItem it = (System.Windows.Forms.ToolStripMenuItem)sender;
            Console.WriteLine(it.Text);
            try
            {
                _SP.BaudRate = 115200;
                _SP.ReadTimeout = 100;
                _SP.StopBits = StopBits.One;
                _SP.PortName = it.Text;
                _SP.Open();
                if (_SP.IsOpen)
                {
                    MessageBox.Show("Sucessful Connect " + _SP.PortName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cant't Connect");
            }
        }
    }
}
