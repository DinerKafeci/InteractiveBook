using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InteractiveBook
{
    public partial class Form1 : Form
    {
        private PictureBox beePictureBox;
        private Timer beeTimer;
        private int centerX;
        private int centerY;
        private int radius = 100; 
        private double angle = 0; 
        private int speed = 5; 

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawImage(Bitmap.FromFile("C:\\Users\\Asus\\Downloads\\InteractiveBook\\InteractiveBook\\InteractiveBook\\Media\\bearandbee.PNG"), new Rectangle(0, 0, this.ClientSize.Width - 50, this.ClientSize.Height));


            using (Pen pen = new Pen(Color.Black))
            {
                int startX2 = this.ClientSize.Width - 50;
                int startY2 = this.ClientSize.Height;
                int endX2 = this.ClientSize.Width - 50;
                int endY2 = this.ClientSize.Height - 50;

                int startX1 = this.ClientSize.Width - 50;
                int startY1 = this.ClientSize.Height - 50;
                int endX1 = this.ClientSize.Width;
                int endY1 = this.ClientSize.Height - 50;

                g.DrawLine(pen, new Point(startX2, startY2), new Point(endX2, endY2));
                g.DrawLine(pen, new Point(startX1, startY1), new Point(endX1, endY1));

            }


            Color shadowColor = Color.FromArgb(50, 0, 0, 0); 

            int startX = this.ClientSize.Width - 50;
            int startY = this.ClientSize.Height;
            int endX = this.ClientSize.Width;
            int endY = this.ClientSize.Height - 50;

            for (int i = 0; i < 10; i++) 
            {
                using (Pen shadowPen = new Pen(Color.FromArgb(50 - i * 5, 0, 0, 0), 1)) 
                {
                    g.DrawLine(
                        shadowPen,
                        new Point(startX, startY - i), 
                        new Point(endX - i, endY)     
                    );
                }
            }

            PictureBox pictureBox = new PictureBox
            {
                Image = Image.FromFile("C:\\Users\\Asus\\Downloads\\InteractiveBook\\InteractiveBook\\InteractiveBook\\Media\\right.png"), // Path to the icon
                SizeMode = PictureBoxSizeMode.StretchImage, 
                Size = new System.Drawing.Size(30, 30), 
                Location = new System.Drawing.Point(this.ClientSize.Width - 50, this.ClientSize.Height - 50), 
                Cursor = Cursors.Hand, 
                BackColor = Color.Transparent 
            };

            pictureBox.Click += PictureBox_Click;

            this.Controls.Add(pictureBox);
        }
        private void PictureBox_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();

            this.Hide();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            beePictureBox = new PictureBox
            {
                Image = Image.FromFile("C:\\Users\\Asus\\Downloads\\InteractiveBook\\InteractiveBook\\InteractiveBook\\Media\\bee03.PNG"), // Path to the bee image
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(50, 50), 
                BackColor = Color.Transparent
            };

            centerX = (this.ClientSize.Width / 2)+40;
            centerY = this.ClientSize.Height / 2;

            beePictureBox.Location = new Point(centerX, centerY - radius);

            this.Controls.Add(beePictureBox);

            beeTimer = new Timer
            {
                Interval = 30 
            };
            beeTimer.Tick += BeeTimer_Tick;
            beeTimer.Start();
        }
        private void BeeTimer_Tick(object sender, EventArgs e)
        {
            angle += speed * Math.PI / 180; 

            int beeX = centerX + (int)(radius * Math.Cos(angle));
            int beeY = centerY + (int)(radius * Math.Sin(angle));

            beePictureBox.Location = new Point(beeX, beeY);

            if (angle >= 2 * Math.PI)
            {
                angle = 0;
            }
        }
    }
}
