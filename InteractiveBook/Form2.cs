using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace InteractiveBook
{
    public partial class Form2 : Form
    {
        //Viktorija
        private Timer animationTimer;
        private int startX;

        public Form2()
        {
            InitializeComponent();
        }
        //Senanur
        private void Form2_Load(object sender, EventArgs e)
        {
            rtb1.Text = "Everyone knows that every bear love honey. It is their favourite treat. One morning, Mr. Bear goes to the cupboard, feeling very hungry. He opens the door, hoping to find a big jar of honey. But… the cupboard is empty!\r\n“Oh no! No honey!” Mr. Bear says sadly, his tummy growling.\r\n    (Animation1) \n\n\n So he goes into the forest to find some. Suddenly, Mr. Bear smells something sweet. Sniff, sniff! He looks around and sees a beehive hanging on a tree. “Mmmmm! Honey!” he says, licking his lips.\r\nMr. Bear reaches out and sticks his paw into the beehive to grab some honey. But then… ZZZZZZZZ! A bee flies out, buzzing loudly.\r\n“Hey, bear! Go away!” the bee says. “This is not your honey!”\r\n    (Animation2) \n\n\n  Mr. Bear frowns. He does not like being told “no.”\r\n“I am bigger than you,” he says in a loud voice. “And I am stronger than you too! I can do what I want! Now… buzz off!”\r\nMr. Bear pushes his paw back into the hive. But this time…\r\nZZZZZZZZZ! ZING!\r\n“OWIE!” Mr. Bear shouts. The bee stings him right on his nose! Mr. Bear holds his nose with his paw. It really hurts.\r\n    (Animation3)   ";
            HighlightWord("bear", Color.Orange);
            HighlightWord("cupboard", Color.Green);
            HighlightWord("jar", Color.Pink);
            HighlightWord("honey", Color.Pink);
            HighlightWord("Watch", Color.Black);
            HighlightWord("forest", Color.SeaGreen);
            HighlightWord("beehive", Color.Lavender);
            HighlightWord("tree", Color.BurlyWood);
            HighlightWord("bee", Color.Red);
            HighlightWord("paw", Color.Red);
            HighlightWord("hive", Color.Red);
            HighlightWord("nose", Color.Red);

            rtb1.Visible = false; // Hide initially
            InitializeAnimation();

            rtb1.MouseClick += Rtbparagraph1_MouseClick;
        }
        //Viktorija
        private void InitializeAnimation()
        {
            startX = -this.Width; // Start position off-screen
            rtb1.Left = startX;
            rtb1.Visible = true;

            animationTimer = new Timer
            {
                Interval = 15 // Adjust speed
            };
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();
        }
        //Viktorija
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (rtb1.Left >= 15) // Stop when close to final position
            {
                animationTimer.Stop();
                rtb1.Left = 15; // Final position
            }
            else
            {
                rtb1.Left += 20; // Move incrementally
            }
        }
        //Senanur
        private void Rtbparagraph1_MouseClick(object sender, MouseEventArgs e)
        {
            // Get the clicked position
            int clickedPosition = rtb1.GetCharIndexFromPosition(e.Location);
            rtb1.Select(clickedPosition, 1); // Select the clicked character

            // Get the word at the clicked position
            string clickedWord = GetWordAtPosition(clickedPosition);

            // Show corresponding image
            if (clickedWord == "bear")
            {
                ShowImage(@"C:\Users\Asus\Downloads\InteractiveBook\InteractiveBook\InteractiveBook\Media\Screenshot 2024-12-17 190501.png");
            }
            else if (clickedWord == "cupboard")
            {
                ShowImage(@"C:\Users\Hilal Saban\Downloads\cupboard.jpg");
            }
            else if (clickedWord == "jar")
            {

                ShowImage(@"C:\Users\Asus\Downloads\InteractiveBook\InteractiveBook\InteractiveBook\Media\jar.jpg");
            }
            else if (clickedWord == "honey")
            {
                ShowImage(@"C:\Users\Asus\Downloads\InteractiveBook\InteractiveBook\InteractiveBook\Media\jar.jpg");
            }
            if (clickedWord == "Animation1")
            { 
                ShowAnimatedGif(@"C:\Users\Asus\Downloads\InteractiveBook\InteractiveBook\InteractiveBook\Media\Animation1.gif");
            }
            if (clickedWord == "Animation2")
            {
                ShowAnimatedGif(@"C:\Users\Asus\Downloads\InteractiveBook\InteractiveBook\InteractiveBook\Media\Animation2.gif");
            }
            if (clickedWord == "Animation3")
            {
                ShowAnimatedGif(@"C:\Users\Asus\Downloads\InteractiveBook\InteractiveBook\InteractiveBook\Media\Animation3.gif");
            }
            else if (clickedWord == "forest")
            {
                ShowImage(@"C:\Users\Hilal Saban\Downloads\forest.jpg");
            }
            else if (clickedWord == "beehive")
            {
                ShowImage(@"C:\Users\Asus\Downloads\InteractiveBook\InteractiveBook\InteractiveBook\Media\Screenshot 2024-12-17 190718beehive.png");
            }
            else if (clickedWord == "tree")
            {
                ShowImage(@"C:\Users\Hilal Saban\Downloads\tree.jpg");
            }
            else if (clickedWord == "bee")
            {
                ShowImage(@"C:\Users\Asus\Downloads\InteractiveBook\InteractiveBook\InteractiveBook\Media\Screenshot 2024-12-17 190752 bee.png");
            }
            else if (clickedWord == "paw")
            {
                ShowImage(@"C:\Users\Asus\Downloads\InteractiveBook\InteractiveBook\InteractiveBook\Media\paw.png");
            }
            else if (clickedWord == "hive")
            {
                ShowImage(@"C:\Users\Asus\Downloads\InteractiveBook\InteractiveBook\InteractiveBook\Media\Screenshot 2024-12-17 190718beehive.png");
            }
            else if (clickedWord == "nose")
            {
                ShowImage(@"C:\Users\Asus\Downloads\InteractiveBook\InteractiveBook\InteractiveBook\Media\nose.png");
            }
        }
        
        //Senanur
        private string GetWordAtPosition(int position)
        {
            int start = position, end = position;

            // Extend the start of the word to include letters and digits
            while (start > 0 && char.IsLetterOrDigit(rtb1.Text[start - 1]))
                start--;

            // Extend the end of the word to include letters and digits
            while (end < rtb1.Text.Length && char.IsLetterOrDigit(rtb1.Text[end]))
                end++;

            return rtb1.Text.Substring(start, end - start);
        }
        //Viktorija
        private void ShowImage(string imagePath)
        {
            Form imageForm = new Form();
            PictureBox pictureBox = new PictureBox
            {
                Image = Image.FromFile(imagePath),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(300, 300), 
                Dock = DockStyle.Fill // Makes the image fit within the form
            };

            imageForm.Controls.Add(pictureBox); // Add the picture box to the form
            imageForm.Text = "Image Viewer";
            imageForm.ShowDialog(); // Show the image form
        }
        //Viktorija
        private void ShowAnimatedGif(string gifPath)
        {
            Form gifForm = new Form();
            PictureBox gifBox = new PictureBox
            {
                Image = Image.FromFile(gifPath), // Load the GIF
                SizeMode = PictureBoxSizeMode.StretchImage,
                Dock = DockStyle.Fill
            };

            // Ensure the GIF animation loops continuously
            ImageAnimator.Animate(gifBox.Image, (o, e) =>
            {
                gifBox.Invalidate();
            });

            gifBox.Paint += (sender, e) =>
            {
                ImageAnimator.UpdateFrames();
            };

            gifForm.Controls.Add(gifBox);
            gifForm.Text = "Animation";
            gifForm.Size = new Size(350, 350);
            gifForm.ShowDialog();
        }

        //Senanur
        private void HighlightWord(string word, Color color)
        {
            int startIndex = 0;
            while ((startIndex = rtb1.Text.IndexOf(word, startIndex)) != -1)
            {
                rtb1.Select(startIndex, word.Length);
                rtb1.SelectionColor = color;
                startIndex += word.Length;
            }
        }

        //Diner
        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
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

            using (Pen pen = new Pen(Color.Black))
            {
                int startX2 = 50;
                int startY2 = this.ClientSize.Height;
                int endX2 = 50;
                int endY2 = this.ClientSize.Height - 50;

                int startX1 = 50;
                int startY1 = this.ClientSize.Height - 50;
                int endX1 = 0;
                int endY1 = this.ClientSize.Height - 50;

                g.DrawLine(pen, new Point(startX2, startY2), new Point(endX2, endY2));
                g.DrawLine(pen, new Point(startX1, startY1), new Point(endX1, endY1));

            }


            
            // Starting and ending points for the shadow line
            int startX3 = 50;
            int startY3 = this.ClientSize.Height;
            int endX3 = 0;
            int endY3 = this.ClientSize.Height - 50;

            // Draw multiple lines with offsets to simulate a blur
            for (int i = 0; i < 10; i++) // 10 lines for the blur effect
            {
                using (Pen shadowPen = new Pen(Color.FromArgb(50 - i * 5, 0, 0, 0), 1)) // Gradually reduce opacity
                {
                    // Slightly offset each line
                    g.DrawLine(
                        shadowPen,
                        new Point(startX3, startY3 - i), // Offset start point
                        new Point(endX3 + i, endY3)     // Offset end point
                    );
                }
            }

            PictureBox pictureBox1 = new PictureBox
            {
                Image = Image.FromFile("C:\\Users\\Asus\\Downloads\\InteractiveBook\\InteractiveBook\\InteractiveBook\\Media\\left-arrow.png"), // Path to the icon
                SizeMode = PictureBoxSizeMode.StretchImage, // Adjust size to fit
                Size = new System.Drawing.Size(18, 18), // Set appropriate size for the icon
                Location = new System.Drawing.Point(25, this.ClientSize.Height - 45), // Correct positioning
                Cursor = Cursors.Hand, // Indicate interactivity
                BackColor = Color.Transparent // Seamless appearance
            };


            // Add the click event
            pictureBox1.Click += PictureBox_Click1;

            // Add the PictureBox to the form
            this.Controls.Add(pictureBox1);

        }
        //Diner
        private void PictureBox_Click(object sender, EventArgs e)
        {
            // Navigate to Form2 on click
            Form3 form3 = new Form3();
            form3.Show();

            // Optionally hide or close the current form
            this.Hide();
        }
        //Diner
        private void PictureBox_Click1(object sender, EventArgs e)
        {
            // Navigate to Form2 on click
            Form1 form1 = new Form1();
            form1.Show();

            // Optionally hide or close the current form
            this.Hide();
        }

    }
}