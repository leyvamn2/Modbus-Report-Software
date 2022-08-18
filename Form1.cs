using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyModbus;

namespace ProtonModbus
{
    public partial class Form1 : Form
    {
        public int x = 0;
        int[] dx, dy;
        ModbusClient mbclient;
        public Form1()
        {
           
            InitializeComponent();

            try
            {
                mbclient = new ModbusClient("192.168.1.170", 502);
                mbclient.Connect();
                MessageBox.Show("Conexión establecida");
                //
                ////dy =o[0];
                timer1.Start();

            }
            catch (Exception ex)                         
            {
                MessageBox.Show(ex.ToString());
            }
        }



        private void Timer1_Tick(object sender, EventArgs e)
        {
            x = x + 1;
            if (x == 10)
            {
                if (mbclient.Connected == true)
                {

                    dy = mbclient.ReadInputRegisters(7, 1);
                    dx = mbclient.ReadHoldingRegisters(5, 1);
                    
                }
                textBox2.Text = (dx[0]).ToString();
                textBox3.Text = (dy[0]).ToString();
                x = 0;
            }
        }
    }
}
