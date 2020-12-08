using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using motores.Properties;
using System.Threading;

namespace motores
{


    public partial class Form1 : Form
    {

        private void timer1_Tick(object sender, EventArgs e)
        {
            num();
         
        }

        int num1, num2, num3, da, db, dc;//los num son las trackbar y los d de las leds 
        bool d1, d2, d3;//los de son los leds
        int bd,tom;//tom para automatico
        int na, porc, tota, res,resul, sum, menos;//para mover los labels de los tracbar
        string abrir,envia;
        bool sen, ex, con, bp, au ;//sen para encender, con para canbiar tamaños1, ex para extender
                                   //au para el encendidido automatico
        private void button4_Click(object sender, EventArgs e)
        {
            d2 = !d2;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            d3 = !d3;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
           // labela.Text= trackBar1.Value.ToString();
            mover_label();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
           // labelb.Text = trackBar2.Value.ToString();
            mover_label();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
           // labelc.Text = trackBar3.Value.ToString();
            mover_label();
        }

        void mover_label()
        {
            labela.Text = trackBar1.Value.ToString();
            labelb.Text = trackBar2.Value.ToString();
            labelc.Text = trackBar3.Value.ToString();
            //la posicicion inicial(0%) de los labels es de 470
            //la posicion final(100%) de los labels es de 250
            //la distancia entre los dos es de 220
            //el resultado de la porcentualizacion le multiplicaremos 2.2 y sumaremos 250
            //o solo le sumeremos 250 a la 220 porcentualizacion na*220/tracbar
            // int na, porc, tota, res, sum;//para mover los labels de los tracbar

            porc = 220;
            sum = 250;
            res = 220;
            menos = -1;
            tota = trackBar1.Maximum;      
            
            //tracbbar 1
            na = trackBar1.Value;
          
            //ecuacion
            resul = ((((na * porc) / tota)-res)*menos)+sum;

            label20.Text = resul.ToString();
            labela.Location = new Point(210, resul);

            //tracbbar 2
            na = trackBar2.Value;

            //ecuacion
            resul = ((((na * porc) / tota) - res) * menos) + sum;

            label20.Text = resul.ToString();
            labelb.Location = new Point(475, resul);

            //tracbbar 3
            na = trackBar3.Value;

            //ecuacion
            resul = ((((na * porc) / tota) - res) * menos) + sum;

            label20.Text = resul.ToString();
            labelc.Location = new Point(725, resul);

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (trackBar1.Value < 100)
            {
                buma.Image = Resources.bv;
                buma.Refresh();

                d1 = true;

                trackBar1.Value += 1;
                mover_label();
            }
            else if (trackBar2.Value < 100)
            {
                bumb.Image = Resources.bv;
                bumb.Refresh();

              d2 = true;

                trackBar2.Value += 1;
                mover_label();
            }
            else if (trackBar3.Value < 100)
            {

                bumc.Image = Resources.bv;
                bumc.Refresh();

               d3 = true;

                trackBar3.Value += 1;
                mover_label();
            }
            else
            {
                timer2.Stop();
                timer1.Start();
            }

            num();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            d1 = !d1;
        }

        private void num()
        {
            /*int num1, num2, num3;//los num son las trackbar 
            int d1, d2, d3;//los de son los leds
            */
            //timer1.Stop();

            num1 = trackBar1.Value;
            num2 = trackBar2.Value;
            num3 = trackBar3.Value;

            LMA.Text = num1.ToString();
            LMB.Text = num2.ToString();
            LMC.Text = num3.ToString();

            LMA.Refresh();
            LMB.Refresh();
            LMC.Refresh();

            label5.Text = sen.ToString();

            label7.Text = d1.ToString();
            label9.Text = d2.ToString();
            label11.Text = d3.ToString();

            label15.Text = num1.ToString();
            label16.Text = num2.ToString();
            label17.Text = num3.ToString();

            label5.Refresh();

            label7.Refresh();
            label9.Refresh();
            label11.Refresh();

            label15.Refresh();
            label16.Refresh();
            label17.Refresh();


            //ordenamos tooodooo
            if (d1) { da = 1; }
            else    { da = 0; }

            if (d2) { db = 1; }
            else    { db = 0; }

            if (d3) { dc = 1; }
            else    { dc = 0; }

            //enviamos tooodooo


            if (serialPort1.IsOpen==true)
            {
                serialPort1.WriteLine(da.ToString() + "," + num1.ToString() + ","+num2.ToString() + ","+num3.ToString() + "," + da.ToString() + "," + db.ToString() + "," + dc.ToString() );
               // label21.Text = (da.ToString() + "," + num1.ToString() + "," + num2.ToString() + "," + num3.ToString() + "," + da.ToString() + "," + db.ToString() + "," + dc.ToString());
                //label21.Refresh();
            }

            //  timer1.Start();
            //Thread.Sleep(50);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            sen = !sen;
            label5.Text = sen.ToString();          

            trackBar1.Value = 0;
            trackBar2.Value = 0;
            trackBar3.Value = 0;

            if (sen)
            {
                timer2.Start();
                LON.Text = "APAGAR";
                pion.Image = Resources.bv;
                pion.Refresh();

                buma.Image = Resources.bv;
                buma.Refresh();
                /*
                d1 = !d1;
                d2 = !d2;
                d3 = !d3;
                /*
                for (int i = 0; i < 5; i++)
                {
                    
                    trackBar1.Value = trackBar1.Value + 10;
                    num();
                    
                    Thread.Sleep(3000);
                    
                }

                bumb.Image = Resources.bv;
                bumb.Refresh();
                d2 = !d2;

                for (int i = 0; i < 10; i++)
                {                 
                  
                    trackBar2.Value = trackBar2.Value + 10;
                    num();
                   //   Thread.Sleep(2000);
                }

                bumc.Image = Resources.bv;
                bumc.Refresh();
                d3 = !d3;

                for (int i = 0; i < 10; i++)
                {
                   
                    trackBar3.Value = trackBar3.Value + 10;
                    num();
                 //  Thread.Sleep(2000);
                
                }

                timer1.Start();*/

            }
            else
            {
                timer2.Stop();
                LON.Text = "ENCENDER";
                pion.Image = Resources.br;
                trackBar1.Value = 0;
                trackBar2.Value = 0;
                trackBar3.Value = 0;
                buma.Image = Resources.br;
                buma.Refresh();
                bumb.Image = Resources.br;
                bumb.Refresh();
                bumc.Image = Resources.br;
                bumc.Refresh();
               
                num1 = trackBar1.Value;
                num2 = trackBar2.Value;
                num3 = trackBar3.Value;
                d1 = !d1;
                d2 = !d2;
                d3 = !d3;

                label5.Text = sen.ToString();

                label7.Text = d1.ToString();
                label9.Text = d2.ToString();
                label11.Text = d3.ToString();

                label15.Text = num1.ToString();
                label16.Text = num2.ToString();
                label17.Text = num3.ToString();

                timer1.Start();
                d1 = false;
                d1 = false;
                d1 = false;
                num();
                mover_label();
                //serialPort1.Close();
            }
        }
        
        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            ex = !ex;
            if (ex)
            {
                Size = new Size(1000, 600);
                MaximumSize = new Size(1200, 600);
                MinimumSize = new Size(1200, 600);
            }
            else {
                Size = new Size(1000, 600);

                MaximumSize = new Size(880, 600);
                MinimumSize = new Size(880, 600);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            label5.Text = sen.ToString();

            label7.Text = d1.ToString();
            label9.Text = d2.ToString();
            label11.Text = d3.ToString();

            label15.Text = num1.ToString();
            label16.Text = num2.ToString();
            label17.Text = num3.ToString();         

        }
        private void button2_Click(object sender, EventArgs e)
        {
            bp = !bp;
            //timer1.Start();
            //serialPort1.WriteLine(bp.ToString());
            if (serialPort1.IsOpen == true)
            {
                if (bp)
                {
                    serialPort1.WriteLine("1");
                }
                else
                {
                    serialPort1.WriteLine("0");
                }

            }

        }     

        //label 1 location 212,472
        //label 2 location 474,472
        //label 3 location 724,472

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            serialPort1.Close();
        }       

        public Form1()
        {
            InitializeComponent();
            Size = new Size(1000, 600);
            //Size = new Size(400, 500);
            //MaximumSize = new Size(400, 500);
            MinimumSize = new Size(400, 500);
            groupBox1.Location = new Point(0, 0);

            button1.Visible = true;
            groupBox2.Visible = true;

            string[] puertos = SerialPort.GetPortNames();//
            foreach (string mostrar in puertos) //
            {
                comboBox1.Items.Add(mostrar);//
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Size = new Size(1000, 600);

            MaximumSize = new Size(880, 600);
            MinimumSize = new Size(880, 600);

            groupBox2.Location = new Point(0, 0);

            groupBox1.Visible = false;
            groupBox2.Visible = true;
 
  //          /&con = !con;
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //serialPort1.WriteLine(bd.ToString());

            envia = serialPort1.ReadLine();
            label19.Text = envia;
            label19.Refresh();
            Console.WriteLine(envia);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.Close();//
            serialPort1.Dispose();//
           abrir = comboBox1.Text;//
            serialPort1.PortName = abrir;//
            serialPort1.Open();
            CheckForIllegalCrossThreadCalls = false;//

            if (serialPort1.IsOpen == true)
            {
                button1.Visible = true;
            }

            else
            {
                return;
            }
        }
    }
}
