using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Timers;
// базу еще не подрубал
// На данный момент присутствует множество ненужных библиотек
// Так-же изображение не удобно просматривать стоит подумать над масштабированием
//checkbox тоже бесполезен


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private bool pod,dat,dhost,phost,click;
        int i=1,j;
        public Form1()
        {
            InitializeComponent();
           

        }

        private void reset()
        {
                    
        }

      


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
           // pod = true;
           // click = true; 
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            //Musor
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            //Trash
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            //Othodi
        }
       

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Useless
        }
      
        private void button2_Click(object sender, EventArgs e)
        { if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {// открытие изображения в пикбокс 2
                System.IO.FileStream fs = new System.IO.FileStream(openFileDialog1.FileName, System.IO.FileMode.Open);
                System.Drawing.Image img = System.Drawing.Image.FromStream(fs);
                fs.Close();
                pictureBox2.Image = img;
               // pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }


      

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void подписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //timer1.Start();//Мусор

            pod = true;
            phost = true;
        }
        private void датаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dat = true;
            dhost = true;
        }


        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //Мусор
        }

   

        interface isub
        {
            void vrem();//Кусок интерфейса
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          //Нерабочий кусок
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            //if (pod == true) { picturebox[i].Location = new Point(MousePosition.X, MousePosition.Y); }=> Код для перемещения пикбокса
            ////////////////////////////////// Создает пикбокс почти по координатам мыши и сразу, не смог придумать как пользователю выбрать позицию, создается на переднем плане
            if (pod == true)
            {
                PictureBox[] Pics = new PictureBox[11];
                while (phost == true)
                {
                    i++;
                    Pics[i] = new PictureBox() { Width = 200, Height = 200};
                    Pics[i].BorderStyle = BorderStyle.FixedSingle;
                    Pics[i].BringToFront();                
                        Pics[i].Location = new Point(MousePosition.X, MousePosition.Y);                                                   
                        phost = false;                    
                }               
                Controls["pictureBox2"].SuspendLayout();
                Controls["pictureBox2"].Controls.AddRange(Pics);
                Controls["pictureBox2"].ResumeLayout();
            }

            /////////////////////////////////
            //  if (dat==true) { dateTimePicker1.Location = new Point(MousePosition.X, MousePosition.Y); }=> перемещение поля даты
            ///////////////////////////////////////\ С датой тоже самое
            if (dat == true)
            {
                DateTimePicker[] Dat = new DateTimePicker[11];
                while (dhost == true)
                {
                    i++;
                    Dat[i] = new DateTimePicker() {  };
                    Dat[i].BringToFront();
                    Dat[i].Location = new Point(MousePosition.X, MousePosition.Y);
                    dhost = false;
                }
                Controls["pictureBox2"].SuspendLayout();
                Controls["pictureBox2"].Controls.AddRange(Dat);
                Controls["pictureBox2"].ResumeLayout();
            }
            ///////////////////////////////////////\
        }

        private void dateTimePicker1_MouseDown(object sender, MouseEventArgs e)
        {
           // dat = true;//Ненужный
        }

        class Member :isub
        {
          public void vrem () { }//Кусок интерфейса тестового
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
          //  pod = false;
          //  dat = false;///тоже безполезно
           // click = true;
        }
    }
  
    }

