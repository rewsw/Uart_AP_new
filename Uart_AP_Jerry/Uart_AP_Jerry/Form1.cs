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
        private delegate void SafeCallDelegate(string text);
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        bool UpdateDelegate = false;
        private void WriteTextSafe(string text)
        {
            DataTb.BeginInvoke(new MethodInvoker(() =>
            {
                DataTb.AppendText(text);
            }));
            //if (DataTb.InvokeRequired)
            //{
            //    var d = new SafeCallDelegate(WriteTextSafe);
            //    DataTb.Invoke(d, new object[] { text });
            //}
            //else
            //{

            //    DataTb.AppendText(text);
            //}
        }
        private void WriteTextSafe(string text,bool Update)
        {
            DataTb.BeginInvoke(new MethodInvoker(() =>
            {
                DataTb.AppendText(text);
            }));
            Update = true;
            //if (DataTb.InvokeRequired)
            //{
            //    var d = new SafeCallDelegate(WriteTextSafe);
            //    DataTb.Invoke(d, new object[] { text });
            //}
            //else
            //{

            //    DataTb.AppendText(text);
            //}
        }
        private void TM0_MC0(SerialPort sp,byte mco_sw,byte mco_scal) {
            if (sp.IsOpen) {
                byte[] wr1 = new byte[5] { 0x89, 0x00, 0x00, (byte)((mco_sw&0xf)<<4), mco_scal };
                byte[] wr2 = new byte[5] { 0x8a, 0x01, 0x00, 0x00, 0x00 };
                WriteTextSafe("---------------TM0 Start---------------\r\n");
                sp.Write(wr1, 0, wr1.Length);
                WriteTextSafe("Send Write RW_CTRL\r\n");
                Thread.Sleep(5);
                sp.Write(wr2, 0, wr2.Length);
                WriteTextSafe("Send Write RW_Start\r\n");
                Thread.Sleep(5);
                while (sp.BytesToRead > 0)
                {
                    sp.ReadByte();
                }
                //WriteTextSafe("Poll RW_Start[0] tie Low\r\n");
                //while (true)
                //{
                //    byte[] re1 = new byte[1] { 0x0a };
                //    sp.Write(re1, 0, re1.Length);
                //    Thread.Sleep(5);
                //    byte[] rs = new byte[4];
                //    sp.Read(rs, 0, rs.Length);
                //    if ((rs[0] & 0x01) == 0x01)
                //    {
                //        break;
                //    }

                //}
                Thread.Sleep(10);
                byte[] wr3 = new byte[5] { 0x8a, 0x00, 0x00, 0x00, 0x00 };
                sp.Write(wr3, 0, wr3.Length);
                WriteTextSafe("Send Clear RW_Start\r\n");
                WriteTextSafe("---------------TM0 END---------------\r\n", UpdateDelegate);
            }
        }

        private void TM1_CP(SerialPort sp, byte Tm, UInt32 Test_Counter)  //CP2 == CP1
        {
            if (sp.IsOpen)
            {

                byte[] RW_CTRL = new byte[5];
                byte[] RW_Start = new byte[5];
                if (Tm == 1) {
                    WriteTextSafe("---------------TM1 Start---------------\r\n");
                    RW_CTRL = new byte[5] { 0x89, 0x00, 0x00, 0x01, 0x00 };
                    RW_Start = new byte[5] { 0x8a, 0x01, 0x00, 0x00, 0x00 };
                    sp.Write(RW_CTRL, 0, RW_CTRL.Length);
                    WriteTextSafe("Send Write RW_CTRL\r\n");
                    Thread.Sleep(5);
                    sp.Write(RW_Start, 0, RW_Start.Length);
                    WriteTextSafe("Send Write RW_Start\r\n");
                    Thread.Sleep(5);
                } else if (Tm == 2) {
                    WriteTextSafe("---------------TM2 Start---------------\r\n");
                    RW_CTRL = new byte[5] { 0x89, 0x00, 0x00, 0x02, 0x00 };
                    RW_Start = new byte[5] { 0x8a, 0x01, 0x00, 0x00, 0x00 };
                    sp.Write(RW_CTRL, 0, RW_CTRL.Length);
                    WriteTextSafe("Send Write RW_CTRL\r\n");
                    Thread.Sleep(5);
                    sp.Write(RW_Start, 0, RW_Start.Length);
                    WriteTextSafe("Send Write RW_Start\r\n");
                    Thread.Sleep(5);
                }
                
                //while (sp.BytesToRead > 0)
                //{
                //    sp.ReadByte();
                //}
                byte[] re1 = new byte[1] { 0x0a };
                byte[] re2 = new byte[1] { 0x0b };
                WriteTextSafe("Poll RW_Start[0] tie Low\r\n");
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
                    //Console.WriteLine(rs[0]);
                }
                sp.Write(re2, 0, re2.Length);
                Thread.Sleep(5);
                WriteTextSafe("Read Test Counter\r\n");
                byte[] rs2 = new byte[4];
                int rb2 = sp.Read(rs2, 0, rs2.Length);
                UInt32 Result = (UInt32)(rs2[0] + (rs2[1] << 8) + (rs2[2] << 16) + (rs2[3] << 24));
                if (Result == Test_Counter) {
                    WriteTextSafe("Data Right\r\n");
                   
                    
                }
                else
                {
                    WriteTextSafe("Data Fault\r\n");
                  
                }
                WriteTextSafe("---------------TM End--------------- \r\n",UpdateDelegate);

            }
            else
            {
             
            }
        }

        private void Read4DataFromContinuousAddress(SerialPort sp, UInt32 address, UInt32[] Data, byte Direction) {
            if (sp.IsOpen) {
                WriteTextSafe("---------------TM3 Start---------------\r\n");

                byte[] Address = new byte[5] { 0x80, (byte)((address >> 0) & 0xFF), (byte)((address >> 8) & 0xFF),
                    (byte)((address>> 16) & 0xFF), (byte)((address >> 24) & 0xFF) };
                Console.Write("Address: ");
                for (int i = 0; i < Address.Length; i++)
                {
                    Console.Write(string.Format(" {0:x}", Address[i]));
                }
                Console.WriteLine();
                sp.Write(Address, 0, Address.Length);
                Thread.Sleep(5);

                int index = 0;
                while (index < 4) {
                    if ((Direction & (0x1 << index)) > 0) {
                        byte[] write_data = new byte[5] {(byte)(0x81+index), (byte)((Data[index] >> 0) & 0xFF), (byte)((Data[index] >> 8) & 0xFF),
                    (byte)((Data[index] >> 16) & 0xFF), (byte)((Data[index] >> 24) & 0xFF)};
                        Console.Write("W Index " + index);
                        for (int i = 0; i < Address.Length; i++)
                        {
                            Console.Write(string.Format(" {0:x}", write_data[i]));
                        }
                        sp.Write(write_data, 0, write_data.Length);
                        Console.WriteLine();
                        WriteTextSafe(string.Format("Write Data {0} --> {1:X8}\r\n",index,Data[index]));
                    }
                    Thread.Sleep(5);
                    index++;
                }

                Console.WriteLine("Driection : " + Direction);
                byte[] RW_CTRL = new byte[5] { 0x89, 0x42, Direction, 0x03, 0x00 };
                byte[] RW_Start = new byte[5] { 0x8a, 0x01, 0x00, 0x00, 0x00 };
                sp.Write(RW_CTRL, 0, RW_CTRL.Length);
                WriteTextSafe("Send Write RW_CTRL\r\n");
                Thread.Sleep(5);
                sp.Write(RW_Start, 0, RW_Start.Length);
                WriteTextSafe("Send Write RW_Start\r\n");
                Thread.Sleep(5);
                
                WriteTextSafe("Poll RW_Start[0] tie Low\r\n");
                while (true)
                {
                    byte[] re1 = new byte[1] { 0x0a };
                    sp.Write(re1, 0, re1.Length);
                    Thread.Sleep(5);
                    try
                    {
                        byte[] rs = new byte[4];

                        int rb = sp.Read(rs, 0, rs.Length);
                        if ((rs[0] & 0x01) == 0x00)
                        {
                            break;
                        }
                    }
                    catch (TimeoutException ex) {
                        Console.WriteLine("TimeOut error");
                        continue;
                    }
                    
                }

                //while (sp.BytesToRead > 0)
                //{
                //    sp.ReadByte();
                //}

                index = 0;
                while (index < 4)
                {
                    if ((Direction & (0x1 << index)) == 0)
                    {
                        byte[] Read_data = new byte[1] { (byte)(0x05 + index) };
                        sp.Write(Read_data, 0, Read_data.Length);
                        
                        Thread.Sleep(5);
                        byte[] RData = new byte[4];
                        int rb = sp.Read(RData, 0, RData.Length);
                        Console.Write("R Index " + index);
                        for (int i = 0; i < 4; i++) {
                            Console.Write(string.Format(" {0:x}", RData[i]));
                        }
                        Console.WriteLine();
                        UInt32 Decoder = hex_to_uint(RData);
                        if (Decoder == Data[index])
                        {
                            WriteTextSafe(string.Format("Read Data {0} <-- {1:X8} == {2:X8}\r\n", index, Decoder, Data[index]));
                        }
                        else
                        {
                            WriteTextSafe(string.Format("Read Data {0} <-- {1:X8} != {2:X8}\r\n", index, Decoder, Data[index]));
                        }
                    }
                    index++;
                }
                Console.WriteLine("--------------------------");
                WriteTextSafe("---------------TM End--------------- \r\n", UpdateDelegate);
            }
        }
        private void NewTM3(SerialPort sp, UInt32 address, UInt32 Data, UInt32 Cnt,byte Direction)
        {
            if (sp.IsOpen) {
                WriteTextSafe("---------------TM3 Start---------------\r\n");

                byte[] Address = new byte[5] { 0x80, (byte)((address >> 0) & 0xFF), (byte)((address >> 8) & 0xFF),
                    (byte)((address>> 16) & 0xFF), (byte)((address >> 24) & 0xFF) };
                Console.Write("Address: ");
                for (int i = 0; i < Address.Length; i++)
                {
                    Console.Write(string.Format(" {0:x}", Address[i]));
                }
                Console.WriteLine();
                sp.Write(Address, 0, Address.Length);
                Thread.Sleep(5);

                if ((Direction & 0x1 ) > 0)
                {
                    byte[] write_data = new byte[5] {(byte)(0x81), (byte)((Data >> 0) & 0xFF), (byte)((Data >> 8) & 0xFF),
                    (byte)((Data >> 16) & 0xFF), (byte)((Data >> 24) & 0xFF)};
                    for (int i = 0; i < Address.Length; i++)
                    {
                        Console.Write(string.Format(" {0:x}", write_data[i]));
                    }
                    sp.Write(write_data, 0, write_data.Length);
                    Console.WriteLine();
                    WriteTextSafe(string.Format("Write Data  --> {0:X8}\r\n", Data));
                }
                Thread.Sleep(5);

                Console.WriteLine("Driection : " + Direction);
                byte[] RW_CTRL = new byte[5] { 0x89, 0x12, Direction, 0x03, 0x00 };
                byte[] RW_Start = new byte[5] { 0x8a, 0x01, 0x00, 0x00, 0x00 };
                sp.Write(RW_CTRL, 0, RW_CTRL.Length);
                WriteTextSafe("Send Write RW_CTRL\r\n");
                Thread.Sleep(5);
                sp.Write(RW_Start, 0, RW_Start.Length);
                WriteTextSafe("Send Write RW_Start\r\n");
                Thread.Sleep(5);

                WriteTextSafe("Poll RW_Start[0] tie Low\r\n");
                while (true)
                {
                    byte[] re1 = new byte[1] { 0x0a };
                    sp.Write(re1, 0, re1.Length);
                    Thread.Sleep(5);
                    try
                    {
                        byte[] rs = new byte[4];

                        int rb = sp.Read(rs, 0, rs.Length);
                        if ((rs[0] & 0x01) == 0x00)
                        {
                            break;
                        }
                    }
                    catch (TimeoutException ex)
                    {
                        Console.WriteLine("TimeOut error");
                        continue;
                    }

                }

                if ((Direction & (0x1)) == 0)
                {
                    byte[] Read_data = new byte[1] { (byte)(0x05 ) };
                    sp.Write(Read_data, 0, Read_data.Length);

                    Thread.Sleep(5);
                    byte[] RData = new byte[4];
                    int rb = sp.Read(RData, 0, RData.Length);

                    for (int i = 0; i < 4; i++)
                    {
                        Console.Write(string.Format(" {0:x}", RData[i]));
                    }
                    Console.WriteLine();
                    UInt32 Decoder = hex_to_uint(RData);
                    if (Decoder == Data)
                    {
                        WriteTextSafe(string.Format("Read Data <-- {0:X8} == {1:X8}\r\n", Decoder, Data));
                    }
                    else
                    {
                        WriteTextSafe(string.Format("Read Data <-- {0:X8} != {1:X8}\r\n", Decoder, Data));
                    }
                }

                byte[] re2 = new byte[1] { 0x0b };
                sp.Write(re2, 0, re2.Length);
                Thread.Sleep(5);

                WriteTextSafe("Read Test Counter\r\n");
                byte[] rs2 = new byte[4];
                int rb2 = sp.Read(rs2, 0, rs2.Length);
                UInt32 Result = (UInt32)(rs2[0] + (rs2[1] << 8) + (rs2[2] << 16) + (rs2[3] << 24));
                if (Result == Cnt)
                {
                    WriteTextSafe("Data Right\r\n");


                }
                else
                {
                    WriteTextSafe("Data Fault\r\n");

                }
                WriteTextSafe("---------------TM End--------------- \r\n", UpdateDelegate);
            }
        }
        private void TM7(SerialPort sp,int PGA_GAIN,int LPCF,int AFE_SEL,int LQF,int SCKSW,UInt32 THEN_CNT) {
            if (sp.IsOpen)
            {
                WriteTextSafe("---------------TM7 Start---------------\r\n");
                byte[] AFESET = new byte[5] { 0x8C, (byte)(LQF<<4|PGA_GAIN), (byte)(LPCF),
                    (byte)(0), (byte)(0) };
                WriteTextSafe(string.Format("Send Write AFESET {0:X8} {1:X8} {2:X8} {3:X8}\r\n", AFESET[1], AFESET[2], AFESET[3], AFESET[4]));
                sp.Write(AFESET, 0, AFESET.Length);
                Thread.Sleep(5);

                byte[] AFESEL = new byte[5] { 0x8D, (byte)(AFE_SEL<<4|SCKSW), (byte)(0),
                    (byte)(0), (byte)(0) };
                WriteTextSafe(string.Format("Send Write AFESEL {0:X8} {1:X8} {2:X8} {3:X8}\r\n", AFESEL[1], AFESEL[2], AFESEL[3], AFESEL[4]));
                sp.Write(AFESEL, 0, AFESEL.Length);
                Thread.Sleep(5);

                byte[] ThenCNT = new byte[5] { 0x8E, (byte)((THEN_CNT >> 0) & 0xFF), (byte)((THEN_CNT >> 8) & 0xFF),
                    (byte)((THEN_CNT>> 16) & 0xFF), (byte)((THEN_CNT >> 24) & 0xFF) };
                WriteTextSafe(string.Format("Send Write ThenCNT {0:X8} {1:X8} {2:X8} {3:X8}\r\n", ThenCNT[1], ThenCNT[2], ThenCNT[3], ThenCNT[4]));
                sp.Write(ThenCNT, 0, ThenCNT.Length);
                Thread.Sleep(5);

                WriteTextSafe("Send Write RW_CTRL\r\n");
                byte[] RW_CTRL = new byte[5] { 0x89, 0, 0, 0x04, 0x00 };
                sp.Write(RW_CTRL, 0, RW_CTRL.Length);
                Thread.Sleep(5);

                WriteTextSafe("Send Write RW_Start\r\n");
                byte[] RW_Start = new byte[5] { 0x8a, 0x01, 0x00, 0x00, 0x00 };
                sp.Write(RW_Start, 0, RW_Start.Length);
                Thread.Sleep(5);

                WriteTextSafe("Poll RW_Start[0] tie Low\r\n");
                while (true)
                {
                    byte[] re1 = new byte[1] { 0x0a };
                    sp.Write(re1, 0, re1.Length);
                    Thread.Sleep(5);
                    try
                    {
                        byte[] rs = new byte[4];

                        int rb = sp.Read(rs, 0, rs.Length);
                        if ((rs[0] & 0x01) == 0x00)
                        {
                            break;
                        }
                    }
                    catch (TimeoutException ex)
                    {
                        Console.WriteLine("TimeOut error");
                        continue;
                    }

                }
                WriteTextSafe("---------------TM End--------------- \r\n", UpdateDelegate);
            }
        }
        private UInt32 hex_to_uint(byte[] input)
        {
            return (UInt32)(input[0] + (input[1] << 8) + (input[2] << 16) + (input[3] << 24));
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
        Thread t;
        void RunAll() {
            for (int i = 0; i < cmd_array.Count; i++)
            {
                WriteTextSafe(string.Format("=======================執行第[{0}]=======================\r\n\r\n", i));
                byte instruction = byte.Parse(cmd_array[i][0], System.Globalization.NumberStyles.HexNumber);
                UpdateDelegate = false;
                switch (instruction)
                {
                    case 0x00:
                     
                        byte mco_sw = byte.Parse(cmd_array[i][2], System.Globalization.NumberStyles.HexNumber);
                        byte mco_scal = byte.Parse(cmd_array[i][3], System.Globalization.NumberStyles.HexNumber);
                        WriteTextSafe(string.Format("Input Param mco_sw : {0} mco_scal : {1} \r\n", mco_sw, mco_scal));
                         TM0_MC0(_SP, mco_sw, mco_scal);
                     
                        break;
                    case 0x01:
                     //   WriteTextSafe(string.Format("=======================執行第[{0}]=======================\r\n", i));
                        UInt32 T1Counter = UInt32.Parse(cmd_array[i][1], System.Globalization.NumberStyles.HexNumber);
                        WriteTextSafe(string.Format("Input Param expected_cnt : {0}\r\n ", T1Counter));
                        TM1_CP(_SP, 0x01, T1Counter);
                        break;
                    case 0x02:
                     //   WriteTextSafe(string.Format("=======================執行第[{0}]=======================\r\n", i));
                        UInt32 T2Counter = UInt32.Parse(cmd_array[i][1], System.Globalization.NumberStyles.HexNumber);
                        WriteTextSafe(string.Format("Input Param expected_cnt : {0}\r\n ", T2Counter));
                        TM1_CP(_SP, 0x02, T2Counter);
                        break;
                    case 0x03:
                     //   WriteTextSafe(string.Format("=======================執行第[{0}]=======================\r\n", i));

                        UInt32 address = UInt32.Parse(cmd_array[i][4], System.Globalization.NumberStyles.HexNumber);
                        byte direction = byte.Parse(cmd_array[i][2], System.Globalization.NumberStyles.HexNumber);
                        int times = int.Parse(cmd_array[i][1], System.Globalization.NumberStyles.HexNumber);
                        UInt32[] Data = new UInt32[] { UInt32.Parse(cmd_array[i][5], System.Globalization.NumberStyles.HexNumber),
                                                       UInt32.Parse(cmd_array[i][6], System.Globalization.NumberStyles.HexNumber),
                                                       UInt32.Parse(cmd_array[i][7], System.Globalization.NumberStyles.HexNumber),
                                                       UInt32.Parse(cmd_array[i][8], System.Globalization.NumberStyles.HexNumber)};
                        UInt32 Cnt = UInt32.Parse(cmd_array[i][9], System.Globalization.NumberStyles.HexNumber);
                        if (times == 4)
                        {
                            Read4DataFromContinuousAddress(_SP, address, Data, direction);
                        }
                        else
                        {
                            NewTM3(_SP, address, Data[0],Cnt, direction);
                        }

                        break;
                    case 0x04:
                        //   WriteTextSafe(string.Format("=======================執行第[{0}]=======================\r\n", i));
                        int LPCF = int.Parse(cmd_array[i][1], System.Globalization.NumberStyles.HexNumber);
                        int LQF = int.Parse(cmd_array[i][2], System.Globalization.NumberStyles.HexNumber);
                        int PGA_GAIN = int.Parse(cmd_array[i][3], System.Globalization.NumberStyles.HexNumber);
                        int AFE_SEL = int.Parse(cmd_array[i][4], System.Globalization.NumberStyles.HexNumber);
                        int SCKSW = int.Parse(cmd_array[i][5], System.Globalization.NumberStyles.HexNumber);
                        UInt32 Then_CNT = UInt32.Parse(cmd_array[i][6], System.Globalization.NumberStyles.HexNumber);

                        TM7(_SP,PGA_GAIN,LPCF,AFE_SEL,LQF,SCKSW,Then_CNT);

                        break;
                    case 0x1e:
                     //   WriteTextSafe(string.Format("=======================執行第[{0}]=======================\r\n", i));
                        UpdateDelegate = true;
                        break;
                    case 0x1f:
                    //    WriteTextSafe(string.Format("=======================執行第[{0}]=======================\r\n", i));
                        UpdateDelegate = true;
                        break;
                    default:
                        break;
                }
                WriteTextSafe(string.Format("=======================END=======================\r\n\r\n", i));
                // while (!UpdateDelegate) ;

            }
        }
        private void RunTestBtn_Click(object sender, EventArgs e)
        {
            t = new Thread(new ThreadStart(RunAll));
            t.Start();
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
            _SP = new SerialPort();
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

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            DataTb.Size = new Size(DataTb.Size.Width, this.Size.Height-DataTb.Location.Y-70);
        }
    }
}
