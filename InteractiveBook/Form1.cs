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
        //Diner
        private PictureBox beePictureBox;
        private Timer beeTimer;
        private int centerX;
        private int centerY;
        private int radius = 100; // Radius of the circle
        private double angle = 0; // Angle for circular movement
        private int speed = 5; // Speed of the movement

        public Form1()
        {
            InitializeComponent();
        }
        //Diner
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


            Color shadowColor = Color.FromArgb(50, 0, 0, 0); // Transparent black

            // Starting and ending points for the shadow line
            int startX = this.ClientSize.Width - 50;
            int startY = this.ClientSize.Height;
            int endX = this.ClientSize.Width;
            int endY = this.ClientSize.Height - 50;

            // Draw multiple lines with offsets to simulate a blur
            for (int i = 0; i < 10; i++) // 10 lines for the blur effect
            {
                using (Pen shadowPen = new Pen(Color.FromArgb(50 - i * 5, 0, 0, 0), 1)) // Gradually reduce opacity
                {
                    // Slightly offset each line
                    g.DrawLine(
                        shadowPen,
                        new Point(startX, startY - i), // Offset start point
                        new Point(endX - i, endY)     // Offset end point
                    );
                }
            }

            PictureBox pictureBox = new PictureBox
            {
                Image = Image.FromFile("C:\\Users\\Asus\\Downloads\\InteractiveBook\\InteractiveBook\\InteractiveBook\\Media\\right.png"), // Path to the icon
                SizeMode = PictureBoxSizeMode.StretchImage, // Adjust size to fit
                Size = new System.Drawing.Size(30, 30), // Set appropriate size for the icon
                Location = new System.Drawing.Point(this.ClientSize.Width - 50, this.ClientSize.Height - 50), // Correct positioning
                Cursor = Cursors.Hand, // Indicate interactivity
                BackColor = Color.Transparent // Seamless appearance
            };

            // Add the click event
            pictureBox.Click += PictureBox_Click;

            // Add the PictureBox to the form
            this.Controls.Add(pictureBox);
        }
        //Diner
        private void PictureBox_Click(object sender, EventArgs e)
        {
            // Navigate to Form2 on click
            Form2 form2 = new Form2();
            form2.Show();

            // Optionally hide or close the current form
            this.Hide();
        }
        //Diner
        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize the bee image
            beePictureBox = new PictureBox
            {
                Image = Image.FromFile("C:\\Users\\Asus\\Downloads\\InteractiveBook\\InteractiveBook\\InteractiveBook\\Media\\bee03.PNG"), // Path to the bee image
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(50, 50), // Set size for the bee
                BackColor = Color.Transparent
            };

            // Calculate the center of the circular path
            centerX = (this.ClientSize.Width / 2)+40;
            centerY = this.ClientSize.Height / 2;

            // Set initial position
            beePictureBox.Location = new Point(centerX, centerY - radius);

            // Add the bee to the form
            this.Controls.Add(beePictureBox);

            // Initialize the Timer for the circular movement
            beeTimer = new Timer
            {
                Interval = 50 // Controls the speed of the animation
            };
            beeTimer.Tick += BeeTimer_Tick;
            beeTimer.Start();
        }
        //Diner
        private void BeeTimer_Tick(object sender, EventArgs e)
        {
            // Increment the angle for circular movement
            angle += speed * Math.PI / 180; // Convert speed to radians

            // Calculate the new position
            int beeX = centerX + (int)(radius * Math.Cos(angle));
            int beeY = centerY + (int)(radius * Math.Sin(angle));

            // Update the bee's position
            beePictureBox.Location = new Point(beeX, beeY);

            // Reset the angle to avoid overflow
            if (angle >= 2 * Math.PI)
            {
                angle = 0;
            }
        }
    }
}
