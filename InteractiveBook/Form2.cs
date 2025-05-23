﻿using System;
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
        private Timer animationTimer;
        private int startX;

        public Form2()
        {
            InitializeComponent();
        }
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

            rtb1.Visible = false; 
            InitializeAnimation();

            rtb1.MouseClick += Rtbparagraph1_MouseClick;
        }
        private void InitializeAnimation()
        {
            startX = -this.Width; 
            rtb1.Left = startX;
            rtb1.Visible = true;

            animationTimer = new Timer
            {
                Interval = 15 
            };
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();
        }
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (rtb1.Left >= 15) 
            {
                animationTimer.Stop();
                rtb1.Left = 15; 
            }
            else
            {
                rtb1.Left += 20;
            }
        }
        private void Rtbparagraph1_MouseClick(object sender, MouseEventArgs e)
        {
            int clickedPosition = rtb1.GetCharIndexFromPosition(e.Location);
            rtb1.Select(clickedPosition, 1); 

            string clickedWord = GetWordAtPosition(clickedPosition);

            if (clickedWord == "bear")
            {
                ShowImage(@"C:\Users\Asus\Downloads\InteractiveBook\InteractiveBook\InteractiveBook\Media\Screenshot 2024-12-17 190501.png");
            }
            else if (clickedWord == "cupboard")
            {
                ShowImage(@"C:\Users\Asus\Downloads\InteractiveBook\InteractiveBook\InteractiveBook\Media\cupboard.png");
            }
            else if (clickedWord == "jar")
            {

                ShowImage(@"C:\Users\Asus\Downloads\InteractiveBook\InteractiveBook\InteractiveBook\Media\jar.jpg");
            }
            else if (clickedWord == "honey")
            {
                ShowImage(@"C:\Users\Asus\Downloads\InteractiveBook\InteractiveBook\InteractiveBook\Media\honey.png");
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
                ShowImage(@"C:\Users\Asus\Downloads\InteractiveBook\InteractiveBook\InteractiveBook\Media\forest.png");
            }
            else if (clickedWord == "beehive")
            {
                ShowImage(@"C:\Users\Asus\Downloads\InteractiveBook\InteractiveBook\InteractiveBook\Media\Screenshot 2024-12-17 190718beehive.png");
            }
            else if (clickedWord == "tree")
            {
                ShowImage(@"C:\Users\Asus\Downloads\InteractiveBook\InteractiveBook\InteractiveBook\Media\forest.png");
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
        private string GetWordAtPosition(int position)
        {
            int start = position, end = position;

            while (start > 0 && char.IsLetterOrDigit(rtb1.Text[start - 1]))
                start--;

            while (end < rtb1.Text.Length && char.IsLetterOrDigit(rtb1.Text[end]))
                end++;

            return rtb1.Text.Substring(start, end - start);
        }
        private void ShowImage(string imagePath)
        {
            Form imageForm = new Form();
            PictureBox pictureBox = new PictureBox
            {
                Image = Image.FromFile(imagePath),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(300, 300), 
                Dock = DockStyle.Fill 
            };

            imageForm.Controls.Add(pictureBox); 
            imageForm.Text = "Image Viewer";
            imageForm.ShowDialog(); 
        }
        private void ShowAnimatedGif(string gifPath)
        {
            Form gifForm = new Form();
            PictureBox gifBox = new PictureBox
            {
                Image = Image.FromFile(gifPath), 
                SizeMode = PictureBoxSizeMode.StretchImage,
                Dock = DockStyle.Fill
            };

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

        private void HighlightWord(string word, Color color)
        {
            int startIndex = 0;
            while ((startIndex = rtb1.Text.IndexOf(word, startIndex, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                rtb1.Select(startIndex, word.Length);
                rtb1.SelectionColor = color;
                startIndex += word.Length;
            }
        }

   
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
            
            int startX3 = 50;
            int startY3 = this.ClientSize.Height;
            int endX3 = 0;
            int endY3 = this.ClientSize.Height - 50;

            for (int i = 0; i < 10; i++) 
            {
                using (Pen shadowPen = new Pen(Color.FromArgb(50 - i * 5, 0, 0, 0), 1)) 
                {
                    g.DrawLine(
                        shadowPen,
                        new Point(startX3, startY3 - i), 
                        new Point(endX3 + i, endY3)     
                    );
                }
            }

            PictureBox pictureBox1 = new PictureBox
            {
                Image = Image.FromFile("C:\\Users\\Asus\\Downloads\\InteractiveBook\\InteractiveBook\\InteractiveBook\\Media\\left-arrow.png"), // Path to the icon
                SizeMode = PictureBoxSizeMode.StretchImage, 
                Size = new System.Drawing.Size(18, 18), 
                Location = new System.Drawing.Point(25, this.ClientSize.Height - 45), 
                Cursor = Cursors.Hand, 
                BackColor = Color.Transparent 
            };


            pictureBox1.Click += PictureBox_Click1;

            this.Controls.Add(pictureBox1);

        }
        
        private void PictureBox_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();

            this.Hide();
        }
        
        private void PictureBox_Click1(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();

            this.Hide();
        }

    }
}