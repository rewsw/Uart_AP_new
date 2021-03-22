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
using System.IO;
using System.Threading;
namespace Uart_AP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        byte[] reg = new byte[42];
        private void Form1_Load(object sender, EventArgs e)
        {
            //Console.WriteLine(sp1.ReadTimeout);
            KeyPreview = true;
            string[] port_st = SerialPort.GetPortNames();
            for(int i = 0; i < port_st.Length; i++)
            {
                comportToolStripMenuItem.DropDownItems.Add(port_st[i]);
                comportToolStripMenuItem.DropDownItems[i].Click += dropdownitem_click;
            }
            reg_datagrid.ColumnCount = 4;
            reg_datagrid.RowCount = 7;
            reg_datagrid.RowHeadersVisible = false;
            reg_datagrid.ColumnHeadersVisible = false;
            for (int i = 0; i < 4; i++)
            {
                reg_datagrid.Columns[i].Width = reg_datagrid.Width / 4-1;
            }
            for (int i = 0; i < 7; i++)
            {
                reg_datagrid.Rows[i].Height = reg_datagrid.Height / 7-3;
                reg_datagrid.Rows[i].Cells[0].Value = "0x" + i.ToString("D2");
                reg_datagrid.Rows[i].Cells[2].Value = "0x" + (7+i).ToString("D2");
            }
            #region FIFO reg db
            FIFO_reg_db.RowHeadersVisible = false;

            FIFO_reg_db.Columns.Add("NUM", "NUM");
            FIFO_reg_db.Columns.Add("ADC0_DAT", "ADC0_DAT");
            FIFO_reg_db.Columns.Add("ADC1_DAT", "ADC1_DAT");
            FIFO_reg_db.Columns.Add("ADC2_DAT", "ADC2_DAT");
            FIFO_reg_db.Columns.Add("ADC3_DAT", "ADC3_DAT");
            for(int i = 0; i < 5; i++)
            {
                FIFO_reg_db.Columns[i].Width = FIFO_reg_db.Width / 5;
            }
            #endregion
            #region New FIFO reg db
            New_FIFO_db.RowHeadersVisible = false;
            New_FIFO_db.Columns.Add("NUM", "NUM");
            New_FIFO_db.Columns[0].Width = 60;
            for (int i = 0; i < 16; i++) {
                
                New_FIFO_db.Columns.Add("S"+i.ToString(), "S" + i.ToString());
                New_FIFO_db.Columns[i+1].Width = 60;
            }

            #endregion
        }
        SerialPort sp1 = new SerialPort();
        Thread sp_t;
        private void dropdownitem_click(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolStripMenuItem it = (System.Windows.Forms.ToolStripMenuItem)sender;
            Console.WriteLine(it.Text);
            try
            {
                sp1.BaudRate = 115200;
                sp1.ReadTimeout = 100;
                sp1.StopBits = StopBits.One;
                sp1.PortName = it.Text;
                sp1.Open();
                if (sp1.IsOpen) {
                    MessageBox.Show("Sucessful Connect "+sp1.PortName);
                }
            }
            catch(Exception ex )
            {
                MessageBox.Show("Cant't Connect");
            }
        }
        private void Get_Value_btn_Click(object sender, EventArgs e)
        {
            if (sp1.IsOpen)
            {
                while (sp1.BytesToRead>0)
                {
                    sp1.ReadByte();
                }
                for (int i = 0; i < 14; i++)
                {
                    byte[] sw = new byte[] { (byte)(i + 128) };

                    sp1.Write(sw, 0, sw.Length);
                    Thread.Sleep(5);
                    byte[] rs = new byte[3];
                    try
                    {
                        int sc = sp1.Read(rs, 0, rs.Length);
                        reg[i * 3 + 0] = rs[0];
                        reg[i * 3 + 1] = rs[1];
                        reg[i * 3 + 2] = rs[2];
                    }
                    catch (TimeoutException ex) {
                        MessageBox.Show("Over Time");
                        break;
                    }
                    if (i < 7)
                    {
                        reg_datagrid.Rows[i].Cells[1].Value = "0x" + reg[i * 3 + 2].ToString("X2")
                            + reg[i * 3 + 1].ToString("X2") + reg[i * 3 + 0].ToString("X2");
                    }
                    else
                    {
                        reg_datagrid.Rows[i - 7].Cells[3].Value = "0x" + reg[i * 3 + 2].ToString("X2")
                            + reg[i * 3 + 1].ToString("X2") + reg[i * 3 + 0].ToString("X2");
                    }
                }
                update_tb_box();

            }
            else
            {
                MessageBox.Show("Uart Not Connect");
            }
        }
        private void update_tb_box()
        {
            reg0x00_tb.Text = hex_to_int(ref reg, 0).ToString();
            reg0x01_tb.Text = hex_to_int(ref reg, 1).ToString();
            reg0x03_tb.Text = hex_to_int(ref reg, 3).ToString();
            reg0x04_tb.Text = hex_to_int(ref reg, 4).ToString();
            reg0x05_tb.Text = hex_to_int(ref reg, 5).ToString();
            reg0x06_tb.Text = hex_to_int(ref reg, 6).ToString();
            reg0x07_tb.Text = hex_to_int(ref reg, 7).ToString();
            reg0x08_tb.Text = hex_to_int(ref reg, 8).ToString();
            reg0x09_tb.Text = hex_to_int(ref reg, 9).ToString();
            reg0x0a_tb.Text = hex_to_int(ref reg, 10).ToString();
            reg0x0b_tb.Text = hex_to_int(ref reg, 11).ToString();
           // reg0x0c_tb.Text = hex_to_int(ref reg, 12).ToString();
            if (reg[39] == 1)
            {
                EN_1_rbn.Checked = true;
            }
            else
            {
                EN_0_rbn.Checked = true;
            }
           
            if ((reg[6]&0x10) == 16)
            {
                ADC_EN_1_rtn.Checked = true;
                ADC_EN_0_rbn.Checked = false;
            }
            else
            {
                ADC_EN_0_rbn.Checked = true;
                ADC_EN_1_rtn.Checked = false;
            }
            if ((reg[6]&0x01) == 1)
            {
                TH_1_rbn.Checked = true;
                TH_0_rbn.Checked = false;
            }
            else
            {
                TH_0_rbn.Checked = true;
                TH_1_rbn.Checked = false;
            }
            if ((reg[36] & 0x01) == 1)
            {
                ADC_DATo_MUX_1_rbn.Checked = true;
                ADC_DATo_MUX_0_rbn.Checked = false;
            }
            else
            {
                ADC_DATo_MUX_0_rbn.Checked = true;
                ADC_DATo_MUX_1_rbn.Checked = false;
            }
        }
        private int hex_to_int(ref byte[] input,int start)
        {
            return input[start*3 + 2] * 65536 + input[start*3 + 1] * 256 + input[start * 3];
        }
        private void Write_all_btn_Click(object sender, EventArgs e)
        {
            if (sp1.IsOpen)
            {
                for (int i = 0; i < 13; i++)
                {
                    byte[] write_reg = new byte[4];
                    write_reg[0] = (byte)i;
                    write_reg[1] = reg[i * 3];
                    write_reg[2] = reg[i * 3+1];
                    write_reg[3] = reg[i * 3+2];
                    sp1.Write(write_reg, 0, write_reg.Length);
                }
                Get_Value_btn_Click(new object(),new EventArgs());
            }
            else
            {
                MessageBox.Show("Uart Not Connect");
            }
        }
        private void Set_EN_btn_Click(object sender, EventArgs e)
        {
            Write_all_btn.Enabled = false;
            Get_value_btn.Enabled = false;
            Set_EN_btn.Enabled = false;
            EN_1_rbn.Checked = true;
            FIFO_reg_db.Rows.Clear();
            FIFO_Read_btn.Enabled = false;
            sp_t = new Thread(new ThreadStart(callback_method));
            sp_t.Start();

        }
        private void callback_method()
        {
            if (sp1.IsOpen)
            {
                while (sp1.BytesToRead > 0)
                {
                    sp1.ReadByte();
                }
                byte[] write_reg = new byte[4];
                write_reg[0] = (byte)0x0d;
                reg[39] = 0x01;
                write_reg[1] = reg[39];
                write_reg[2] = reg[40];
                write_reg[3] = reg[41];
                sp1.Write(write_reg, 0, write_reg.Length);
            }
            Thread.Sleep(5);
            while (true)
            {
                if (sp1.IsOpen)
                {
                    byte[] sw = new byte[] { (byte)(13 + 128) };

                    sp1.Write(sw, 0, sw.Length);
                    Thread.Sleep(10);
                    byte[] rs = new byte[3];
                    int sc = sp1.Read(rs, 0, rs.Length);
                    reg[39] = rs[0];
                    reg[40] = rs[1];
                    reg[41] = rs[2];
                    Console.WriteLine(rs[0]);
                    if ((reg[39] & 0x01) == 0)
                    {
                        Thread.Sleep(100);
                        BeginInvoke(new MethodInvoker(() => {
                            EN_0_rbn.Checked = true;
                            Set_EN_btn.Enabled = true;
                            Get_value_btn.Enabled = true;
                            Write_all_btn.Enabled = true;
                            FIFO_Read_btn.Enabled = true;

                        }));
                        break;
                    }
                }
            }

        }
        DataTable dt = new DataTable("table");
        private void Rst_FIFO_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (sp1.IsOpen)
                {
                    byte[] sw = new byte[] { 14,0x00,0x00,0x01 };
                    sp1.Write(sw, 0, sw.Length);

                }
                FIFO_Read_btn.Enabled = true;
                FIFO_reg_db.Rows.Clear();
             
            }
            catch (Exception ex)
            {

            }
        }
        private void FIFO_Read_btn_Click(object sender, EventArgs e)
        {
            //dt = new DataTable("table");

            //FIFO_Read_btn.Enabled = false;
            //    int read_times = ((reg[5 * 3] + 5) * reg[11 * 3] % 2 != 0) ?
            //                        (reg[5 * 3] + 5) * reg[11 * 3] / 2 + 1 : ((reg[5 * 3] + 5) * reg[11 * 3] / 2);


            //    dt.Columns.Add(new DataColumn("NUM", Type.GetType("System.String")));
            //    dt.Columns.Add(new DataColumn("ADC01", Type.GetType("System.String")));
            //    dt.Columns.Add(new DataColumn("ADC02", Type.GetType("System.String")));
            //    dt.Columns.Add(new DataColumn("ADC03", Type.GetType("System.String")));
            //    dt.Columns.Add(new DataColumn("ADC04", Type.GetType("System.String")));


            //    for (int i = 0; i < (reg[5 * 3] + 5) * reg[11 * 3]; i++) {
            //        DataRow dr = dt.NewRow();

            //        dt.Rows.Add(dr);
            //    }

            //    for (int i = 0; i < 4; i++)
            //    {
            //        if ((reg[5 * 3] + 5) * reg[11 * 3] % 2 != 0)// odd
            //        {
            //            byte[] sw = new byte[] { (byte)(15 + i + 128) };
            //            byte[] rs = new byte[3];
            //            for (int j = 0; j < read_times - 1; j++)
            //            {
            //                sp1.Write(sw, 0, sw.Length);
            //                Thread.Sleep(5);
            //                int sc = sp1.Read(rs, 0, rs.Length);
            //                dt.Rows[j * 2][0] = j * 2;
            //                dt.Rows[j * 2 + 1][0] = j * 2 + 1;
            //                dt.Rows[j * 2][i + 1] = rs[0] + (rs[1] % 16) * 256;
            //                dt.Rows[j * 2 + 1][i + 1] = rs[2] * 16 + (rs[1] / 16);
            //            }
            //            sp1.Write(sw, 0, sw.Length);
            //            Thread.Sleep(5);
            //            int sc_odd = sp1.Read(rs, 0, rs.Length);
            //            dt.Rows[(reg[5 * 3] + 5) * reg[11 * 3] - 1][i] = rs[0] + (rs[1] % 16) * 256;
            //            dt.Rows[(reg[5 * 3] + 5) * reg[11 * 3] - 1][0] = (reg[5 * 3] + 5) * reg[11 * 3] - 1;

            //        }
            //        else
            //        {
            //            byte[] sw = new byte[] { (byte)(15 + i + 128) };
            //            byte[] rs = new byte[3];
            //            for (int j = 0; j < read_times; j++)
            //            {
            //                sp1.Write(sw, 0, sw.Length);
            //                Thread.Sleep(5);
            //                int sc = sp1.Read(rs, 0, rs.Length);
            //                dt.Rows[j * 2][i + 1] = rs[0] + (rs[1] % 16) * 256;
            //                dt.Rows[j * 2 + 1][i + 1] = rs[2] * 16 + (rs[1] / 16);
            //                dt.Rows[j * 2][0] = j * 2;
            //                dt.Rows[j * 2 + 1][0] = j * 2 + 1;
            //            }
            //        }
            //    }
            //    FIFO_reg_db.DataSource = dt;
            //    New_FIFO_db.RowCount = reg[11 * 3];
            //    for (int i = 0; i < reg[11 * 3]; i++)
            //    {
            //        New_FIFO_db.Rows[i].Cells[0].Value = i;
            //        for (int j = 0; j < 4; j++)
            //        {
            //            New_FIFO_db.Rows[i].Cells[j * 4 + 1].Value = FIFO_reg_db.Rows[i * 5 + 1].Cells[j + 1].Value;
            //            New_FIFO_db.Rows[i].Cells[j * 4 + 2].Value = FIFO_reg_db.Rows[i * 5 + 2].Cells[j + 1].Value;
            //            New_FIFO_db.Rows[i].Cells[j * 4 + 3].Value = FIFO_reg_db.Rows[i * 5 + 3].Cells[j + 1].Value;
            //            New_FIFO_db.Rows[i].Cells[j * 4 + 4].Value = FIFO_reg_db.Rows[i * 5 + 4].Cells[j + 1].Value;
            //        }
            //    }



            try
            {
                FIFO_Read_btn.Enabled = false;
                int read_times = ((reg[5 * 3] + 5) * reg[11 * 3] % 2 != 0) ?
                                    (reg[5 * 3] + 5) * reg[11 * 3] / 2 + 1 : ((reg[5 * 3] + 5) * reg[11 * 3] / 2);
                FIFO_reg_db.RowCount = (reg[5 * 3] + 5) * reg[11 * 3];
                for (int i = 0; i < 4; i++)
                {
                    if ((reg[5 * 3] + 5) * reg[11 * 3] % 2 != 0)// odd
                    {
                        byte[] sw = new byte[] { (byte)(15 + i + 128) };
                        byte[] rs = new byte[3];
                        for (int j = 0; j < read_times - 1; j++)
                        {
                            sp1.Write(sw, 0, sw.Length);
                            Thread.Sleep(5);
                            int sc = sp1.Read(rs, 0, rs.Length);
                            FIFO_reg_db.Rows[j * 2].Cells[0].Value = j * 2;
                            FIFO_reg_db.Rows[j * 2 + 1].Cells[0].Value = j * 2 + 1;
                            FIFO_reg_db.Rows[j * 2].Cells[i + 1].Value = rs[0] + (rs[1] % 16) * 256;
                            FIFO_reg_db.Rows[j * 2 + 1].Cells[i + 1].Value = rs[2] * 16 + (rs[1] / 16);
                        }
                        sp1.Write(sw, 0, sw.Length);
                        Thread.Sleep(5);
                        int sc_odd = sp1.Read(rs, 0, rs.Length);
                        FIFO_reg_db.Rows[(reg[5 * 3] + 5) * reg[11 * 3] - 1].Cells[i].Value = rs[0] + (rs[1] % 16) * 256;
                        FIFO_reg_db.Rows[(reg[5 * 3] + 5) * reg[11 * 3] - 1].Cells[0].Value = (reg[5 * 3] + 5) * reg[11 * 3] - 1;

                    }
                    else
                    {
                        byte[] sw = new byte[] { (byte)(15 + i + 128) };
                        byte[] rs = new byte[3];
                        for (int j = 0; j < read_times; j++)
                        {
                            sp1.Write(sw, 0, sw.Length);
                            Thread.Sleep(5);
                            int sc = sp1.Read(rs, 0, rs.Length);
                            FIFO_reg_db.Rows[j * 2].Cells[i + 1].Value = rs[0] + (rs[1] % 16) * 256;
                            FIFO_reg_db.Rows[j * 2 + 1].Cells[i + 1].Value = rs[2] * 16 + (rs[1] / 16);
                            FIFO_reg_db.Rows[j * 2].Cells[0].Value = j * 2;
                            FIFO_reg_db.Rows[j * 2 + 1].Cells[0].Value = j * 2 + 1;
                        }
                    }
                }
                New_FIFO_db.RowCount = reg[11 * 3];
                for (int i = 0; i < reg[11 * 3]; i++)
                {
                    New_FIFO_db.Rows[i].Cells[0].Value = i;
                    for (int j = 0; j < 4; j++)
                    {
                        New_FIFO_db.Rows[i].Cells[j * 4 + 1].Value = FIFO_reg_db.Rows[i * 5 + 1].Cells[j + 1].Value;
                        New_FIFO_db.Rows[i].Cells[j * 4 + 2].Value = FIFO_reg_db.Rows[i * 5 + 2].Cells[j + 1].Value;
                        New_FIFO_db.Rows[i].Cells[j * 4 + 3].Value = FIFO_reg_db.Rows[i * 5 + 3].Cells[j + 1].Value;
                        New_FIFO_db.Rows[i].Cells[j * 4 + 4].Value = FIFO_reg_db.Rows[i * 5 + 4].Cells[j + 1].Value;
                    }
                }

            }
            catch (Exception ex)
            {

            }

        }
        #region En
        private void EN_0_rbn_CheckedChanged(object sender, EventArgs e)
        {
            reg[39] = 0x00;
        }
        private void EN_1_rbn_CheckedChanged(object sender, EventArgs e)
        {
            reg[39] = 0x01;
        }
        #endregion
        #region TH
        private void TH_1_rbn_CheckedChanged(object sender, EventArgs e)
        {
            reg[6]|= 0x01;
        }

        private void TH_0_rbn_CheckedChanged(object sender, EventArgs e)
        {
            reg[6]&= 0xf0;
        }
        #endregion
        #region ADC_EN
        private void ADC_EN_1_rtn_CheckedChanged(object sender, EventArgs e)
        {
            reg[6] |= 0x10;
        }
        private void ADC_EN_rbn_CheckedChanged(object sender, EventArgs e)
        {
     
            reg[6] &= 0x0f;

        }
        #endregion
        #region ADC_DATo_MUX
        private void ADC_DATo_MUX_1_rbn_CheckedChanged(object sender, EventArgs e)
        {
            reg[36] = 0x01;
        }
        private void ADC_DATo_MUX_0_rbn_CheckedChanged(object sender, EventArgs e)
        {
            reg[36] = 0x00;
        }
        #endregion
        private void reg0x00_tb_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            try
            {
                int value = int.Parse(tb.Text);
                reg[0] = (byte)(value % 256);
                reg[1] = (byte)(value % 65536 / 256);
                reg[2] = (byte)(value / 65536);
                Console.WriteLine(reg[2].ToString("X2") + reg[1].ToString("X2") + reg[0].ToString("X2"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void reg0x01_tb_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            try
            {
                int value = int.Parse(tb.Text);
                reg[3] = (byte)(value % 256);
                reg[4] = (byte)(value % 65536 / 256);
                reg[5] = (byte)(value / 65536);
                Console.WriteLine(reg[5].ToString("X2") + reg[4].ToString("X2") + reg[3].ToString("X2"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void reg0x03_tb_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            try
            {
                int value = int.Parse(tb.Text);
                reg[9] = (byte)(value % 256);
                reg[10] = (byte)(value % 65536 / 256);
                reg[11] = (byte)(value / 65536);
                Console.WriteLine(reg[11].ToString("X2") + reg[10].ToString("X2") + reg[9].ToString("X2"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void reg0x04_tb_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            try
            {
                int value = int.Parse(tb.Text);
                reg[12] = (byte)(value % 256);
                reg[13] = (byte)(value % 65536 / 256);
                reg[14] = (byte)(value / 65536);
                Console.WriteLine(reg[14].ToString("X2") + reg[13].ToString("X2") + reg[12].ToString("X2"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void reg0x05_tb_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            try
            {
                int value = int.Parse(tb.Text);
                reg[15] = (byte)(value % 256);
                reg[16] = (byte)(value % 65536 / 256);
                reg[17] = (byte)(value / 65536);
                Console.WriteLine(reg[17].ToString("X2") + reg[16].ToString("X2") + reg[15].ToString("X2"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void reg0x06_tb_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            try
            {
                int value = int.Parse(tb.Text);
                reg[18] = (byte)(value % 256);
                reg[19] = (byte)(value % 65536 / 256);
                reg[20] = (byte)(value / 65536);
                Console.WriteLine(reg[20].ToString("X2") + reg[19].ToString("X2") + reg[18].ToString("X2"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void reg0x07_tb_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            try
            {
                int value = int.Parse(tb.Text);
                reg[21] = (byte)(value % 256);
                reg[22] = (byte)(value % 65536 / 256);
                reg[23] = (byte)(value / 65536);
                Console.WriteLine(reg[23].ToString("X2") + reg[22].ToString("X2") + reg[21].ToString("X2"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void reg0x08_tb_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            try
            {
                int value = int.Parse(tb.Text);
                reg[24] = (byte)(value % 256);
                reg[25] = (byte)(value % 65536 / 256);
                reg[26] = (byte)(value / 65536);
                Console.WriteLine(reg[26].ToString("X2") + reg[25].ToString("X2") + reg[24].ToString("X2"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void reg0x09_tb_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            try
            {
                int value = int.Parse(tb.Text);
                reg[27] = (byte)(value % 256);
                reg[28] = (byte)(value % 65536 / 256);
                reg[29] = (byte)(value / 65536);
                Console.WriteLine(reg[29].ToString("X2") + reg[28].ToString("X2") + reg[27].ToString("X2"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void reg0x0a_tb_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            try
            {
                int value = int.Parse(tb.Text);
                reg[30] = (byte)(value % 256);
                reg[31] = (byte)(value % 65536 / 256);
                reg[32] = (byte)(value / 65536);
                Console.WriteLine(reg[32].ToString("X2") + reg[31].ToString("X2") + reg[30].ToString("X2"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void reg0x0b_tb_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            try
            {
                int value = int.Parse(tb.Text);
                reg[33] = (byte)(value % 256);
                reg[34] = (byte)(value % 65536 / 256);
                reg[35] = (byte)(value / 65536);
                Console.WriteLine(reg[35].ToString("X2") + reg[34].ToString("X2") + reg[33].ToString("X2"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void reg0x0c_tb_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            try
            {
                int value = int.Parse(tb.Text);
                reg[36] = (byte)(value % 256);
                reg[37] = (byte)(value % 65536 / 256);
                reg[38] = (byte)(value / 65536);
                Console.WriteLine(reg[38].ToString("X2") + reg[37].ToString("X2") + reg[36].ToString("X2"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sp1.IsOpen)
            {

                byte[] s = new byte[] { 0x9a };
                sp1.Write(s, 0, s.Length);
                Thread.Sleep(10);
                byte[] rs = new byte[3];
                Console.WriteLine(sp1.BytesToRead);
                try
                {
                    int sc = sp1.Read(rs, 0, rs.Length);
                }
                catch (TimeoutException ex) {
                }
                Console.WriteLine(rs[0]);
                Console.WriteLine(rs[1]);
                Console.WriteLine(rs[2]);


            }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sp1.IsOpen) {
                sp1.Close();
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.S:
                    Set_EN_btn_Click(new object(), new EventArgs());
                    break;
                default:
                    break;
            }
        }

        private void savecsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog save = new SaveFileDialog()) {
                save.Filter = "Csv|*.csv";
                if (save.ShowDialog() == DialogResult.OK) {
                    String csv_path = save.FileName;
                    StreamWriter swd = new StreamWriter(csv_path, true);
                    StringBuilder sbd = new StringBuilder();

                    sbd.Append("Num").Append(",").Append("ADC0_DAT").Append(",").Append("ADC1_DAT").Append(",").Append("ADC2_DAT").Append(",").Append("ADC3_DAT");
                    swd.WriteLine(sbd);
                    for (int i = 0; i < FIFO_reg_db.Rows.Count; i++)
                    {
                        sbd.Clear();
                        sbd.Append(FIFO_reg_db.Rows[i].Cells[0].Value)
                            .Append(",").Append(FIFO_reg_db.Rows[i].Cells[1].Value)
                            .Append(",").Append(FIFO_reg_db.Rows[i].Cells[2].Value)
                            .Append(",").Append(FIFO_reg_db.Rows[i].Cells[3].Value)
                            .Append(",").Append(FIFO_reg_db.Rows[i].Cells[4].Value);
                        swd.WriteLine(sbd);
                        swd.Flush();
                    }
                    swd.Close();
                }
            }

                
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {

            int tabc_y = tabControl2.Location.Y;
            int tabc_x = tabControl2.Size.Width;

            tabControl2.Size = new Size(tabc_x, this.Height - 50 - tabc_y);
            FIFO_reg_db.Size = new Size(FIFO_reg_db.Width, tabControl2.Size.Height - 50);
        }

        private void comportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comportToolStripMenuItem.DropDownItems.Clear();
            string[] port_st = SerialPort.GetPortNames();
            for (int i = 0; i < port_st.Length; i++)
            {
                comportToolStripMenuItem.DropDownItems.Add(port_st[i]);
                comportToolStripMenuItem.DropDownItems[i].Click += dropdownitem_click;
            }
        }
    }
}
