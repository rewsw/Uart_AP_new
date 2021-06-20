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

                sp.Write(wr1, 0, wr1.Length);
                Thread.Sleep(5);
                sp.Write(wr2, 0, wr2.Length);
                Thread.Sleep(5);
                while (sp.BytesToRead > 0)
                {
                    sp.ReadByte();
                }
                byte[] re1 = new byte[1] { 0x0a };
                sp.Write(re1, 0, re1.Length);
                Thread.Sleep(5);
                while (true) {
                    byte[] rs = new byte[4];
                    int rb = sp.Read(rs, 0, rs.Length);
                    if ((rs[0] & 0x01) == 0x00) {
                        break;
                    }
                }

            }
        }

        private bool TM1_CP(SerialPort sp, byte Tm, UInt32 Test_Counter)  //CP2 == CP1
        {
            if (sp.IsOpen)
            {

                byte[] RW_CTRL = new byte[5];
                byte[] RW_Start = new byte[5];
                if (Tm == 1) {
                    RW_CTRL = new byte[5] { 0x89, 0x00, 0x00, 0x01, 0x00 };
                    RW_Start = new byte[5] { 0x8a, 0x01, 0x00, 0x00, 0x00 };
                } else if (Tm == 2) {
                    RW_CTRL = new byte[5] { 0x89, 0x00, 0x00, 0x02, 0x00 };
                    RW_Start = new byte[5] { 0x8a, 0x01, 0x00, 0x00, 0x00 };
                }
                sp.Write(RW_CTRL, 0, RW_CTRL.Length);
                Thread.Sleep(5);
                sp.Write(RW_Start, 0, RW_Start.Length);
                Thread.Sleep(5);
                while (sp.BytesToRead > 0)
                {
                    sp.ReadByte();
                }
                byte[] re1 = new byte[1] { 0x0a };
                byte[] re2 = new byte[1] { 0x0b };
                sp.Write(re1, 0, re1.Length);
                Thread.Sleep(5);
                while (true)
                {
                    byte[] rs = new byte[4];
                    int rb = sp.Read(rs, 0, rs.Length);
                    if ((rs[0] & 0x01) == 0x00)
                    {
                        break;
                    }
                }
                sp.Write(re2, 0, re2.Length);
                Thread.Sleep(5);
                byte[] rs2 = new byte[4];
                int rb2 = sp.Read(rs2, 0, rs2.Length);
                UInt32 Result = (UInt32)(rs2[0] + (rs2[1] << 8) + (rs2[2] << 16) + (rs2[3] << 24));
                if (Result == Test_Counter) {
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

        private void Read4DataFromContinuousAddress(SerialPort sp, byte address, UInt32[] Data, byte Direction) {
            if (sp.IsOpen) {


                byte[] Address = new byte[5] { 0x80, (byte)((address >> 0) & 0xFF), (byte)((address >> 8) & 0xFF),
                    (byte)((address>> 16) & 0xFF), (byte)((address >> 24) & 0xFF) };
                sp.Write(Address, 0, Address.Length);
                Thread.Sleep(5);

                int index = 0;
                while (index < 4) {
                    if ((Direction & (0x1 << index)) > 0) {
                        byte[] write_data = new byte[5] {(byte)(0x81+index), (byte)((Data[index] >> 0) & 0xFF), (byte)((Data[index] >> 8) & 0xFF),
                    (byte)((Data[index] >> 16) & 0xFF), (byte)((Data[index] >> 24) & 0xFF)};
                        sp.Write(write_data, 0, write_data.Length);
                    }
                    Thread.Sleep(5);
                    index++;
                }


                byte[] RW_CTRL = new byte[5] { 0x89, 0x00, 0x01, 0x00, 0x48 };
                byte[] RW_Start = new byte[5] { 0x8a, 0x42, 0x01, 0x03, 0x00 };
                byte[] P_RW_start = new byte[1] { 0x0a };
                sp.Write(RW_CTRL, 0, RW_CTRL.Length);
                Thread.Sleep(5);
                sp.Write(RW_Start, 0, RW_Start.Length);
                Thread.Sleep(5);
                while (sp.BytesToRead > 0)
                {
                    sp.ReadByte();
                }
                byte[] re1 = new byte[1] { 0x0a };
                sp.Write(re1, 0, re1.Length);
                Thread.Sleep(5);
                while (true)
                {
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

                    }
                    else
                    {

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
    }
}
