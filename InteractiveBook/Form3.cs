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
    public partial class Form3 : Form
    {
        private Timer animationTimer;
        private int startX;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            rtb2.Text = "Now Mr. Bear is very angry. His nose still stings. “I will show that bee!” he says.\r\nMr. Bear finds a big stick on the ground. He holds it high and swings it at the bee. Whoosh! Whoosh! But the bee is too fast. It zips left, then right, and Mr. Bear cannot hit it.\r\n“GARRRRRGH!” Mr. Bear roars. “I WILL SQUASH YOU!”\r\nThe little bee flies back into the beehive. Mr. Bear smiles a big, mean smile.\r\n“AH HAH! Now you are trapped!” he says.\r\nHe swings his stick hard at the beehive. SMASH! SMASH! SMASH! The hive breaks into pieces.\r\n    (Animation4)\n\n\n ) But then something happens. Mr. Bear hears a sound. It starts small…\r\nZZZZ! ZZZZ! ZZZZZZZZZ!\r\nThe sound gets louder and louder. Suddenly, thousands of bees fly out of the broken hive.\r\nMr. Bear’s eyes get big. “Uh oh,” he whispers.\r\nThe bees fly around his head in a big, buzzing cloud.\r\nZZZZZZZZZ… ZING!\r\n“OW!” Mr. Bear shouts as a bee stings his ear.\r\nHe turns and runs as fast as he can. The bees follow him, buzzing angrily. They chase him through the forest.\r\n    (Animation5)\n\n\n Mr. Bear runs all the way home. He jumps inside and slams the door behind him. BAM!\r\nHe leans against the door, panting and holding his stung ear. Then he hears a voice.\r\n“Did you do it again?” says Mrs. Bear. She stands there, shaking her head.\r\nMr. Bear looks down at his paws and nods. “Yes,” he says. “I lost my temper.” He sniffs as he counts his bee stings.\r\nMrs. Bear smiles kindly and hands him a jar. “Here’s the bee-sting medicine,” she says. “Oh, and by the way, we do have honey. It’s in the cupboard—behind the flour.”\r\nMr. Bear’s mouth drops open. “Behind the flour?!” he groans.\r\n    (Animation6)";

            HighlightWord("bear", Color.Orange);
            HighlightWord("cupboard", Color.Green);
            HighlightWord("honey", Color.Pink);
            HighlightWord("beehive", Color.Lavender);
            HighlightWord("stick", Color.Brown);
            HighlightWord("nose", Color.Red);
            HighlightWord("forest", Color.SeaGreen);
            HighlightWord("nose", Color.Red);
            HighlightWord("jar", Color.Pink);
            HighlightWord("eyes", Color.Pink);
            HighlightWord("ear", Color.Pink);
            HighlightWord("home", Color.Pink);
            HighlightWord("door", Color.Pink);
            HighlightWord("medicine", Color.Pink);
            HighlightWord("flour", Color.Pink);

            rtb2.Visible = false; // Hide initially
            InitializeAnimation();

            rtb2.MouseClick += Rtbparagraph1_MouseClick;
        }

        private void InitializeAnimation()
        {
            startX = -this.Width; // Start position off-screen
            rtb2.Left = startX;
            rtb2.Visible = true;

            animationTimer = new Timer
            {
                Interval = 15 // Adjust speed
            };
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (rtb2.Left >= 15) // Stop when close to final position
            {
                animationTimer.Stop();
                rtb2.Left = 15; // Final position
            }
            else
            {
                rtb2.Left += 20; // Move incrementally
            }
        }

        private void Rtbparagraph1_MouseClick(object sender, MouseEventArgs e)
        {
            // Get the clicked position
            int clickedPosition = rtb2.GetCharIndexFromPosition(e.Location);
            rtb2.Select(clickedPosition, 1); // Select the clicked character

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
            else if (clickedWord == "beehive")
            {
                ShowImage(@"C:\Users\Asus\Downloads\InteractiveBook\InteractiveBook\InteractiveBook\Media\Screenshot 2024-12-17 190718beehive.png");
            }
            else if (clickedWord == "stick")
            {
                ShowImage(@"C:\Users\Asus\Downloads\InteractiveBook\InteractiveBook\InteractiveBook\Media\Screenshot 2024-12-17 190842stick.png");
            }
            else if (clickedWord == "nose")
            {
                ShowImage(@"C:\Users\Asus\Downloads\InteractiveBook\InteractiveBook\InteractiveBook\Media\nose.png");
            }
            else if (clickedWord == "forest")
            {
                ShowImage(@"C:\Users\Asus\Downloads\book (1)\book\book\a.jungle.jpg");
            }
            else if (clickedWord == "eyes")
            {
                ShowImage(@"C:\Users\Asus\Downloads\InteractiveBook\InteractiveBook\InteractiveBook\Media\eyes.jpg");
            }
            else if (clickedWord == "ear")
            {
                ShowImage(@"C:\Users\Asus\Downloads\InteractiveBook\InteractiveBook\InteractiveBook\Media\ear.jpg");
            }
            else if (clickedWord == "home")
            {
                ShowImage(@"C:\Users\Asus\Downloads\InteractiveBook\InteractiveBook\InteractiveBook\Media\Screenshot 2024-12-17 211408home.png");
            }
            else if (clickedWord == "door")
            {
                ShowImage(@"C:\Users\Asus\Downloads\InteractiveBook\InteractiveBook\InteractiveBook\Media\door.jpg");
            }
            else if (clickedWord == "medicine")
            {
                ShowImage(@"C:\Users\Asus\Downloads\InteractiveBook\InteractiveBook\InteractiveBook\Media\Screenshot 2024-12-17 190955medicine.png");
            }
            else if (clickedWord == "flour")
            {
                ShowImage(@"C:\Users\Asus\Downloads\InteractiveBook\InteractiveBook\InteractiveBook\Media\flour.jpg");
            }
            if (clickedWord == "Animation4")
            {
                ShowAnimatedGif(@"C:\Users\Asus\Downloads\InteractiveBook\InteractiveBook\InteractiveBook\Media\Animation4.gif");
            }
            if (clickedWord == "Animation5")
            {
                ShowAnimatedGif(@"C:\Users\Asus\Downloads\InteractiveBook\InteractiveBook\InteractiveBook\Media\Animation5.gif");
            }
            if (clickedWord == "Animation6")
            {
                ShowAnimatedGif(@"C:\Users\Asus\Downloads\InteractiveBook\InteractiveBook\InteractiveBook\Media\Animation6.gif");
            }
        }
        private string GetWordAtPosition(int position)
        {
            int start = position, end = position;

            // Extend the start of the word to include letters and digits
            while (start > 0 && char.IsLetterOrDigit(rtb2.Text[start - 1]))
                start--;

            // Extend the end of the word to include letters and digits
            while (end < rtb2.Text.Length && char.IsLetterOrDigit(rtb2.Text[end]))
                end++;

            return rtb2.Text.Substring(start, end - start);
        }

        private void ShowImage(string imagePath)
        {
            Form imageForm = new Form();
            PictureBox pictureBox = new PictureBox
            {
                Image = Image.FromFile(imagePath),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(300, 300), // Adjust the size if needed
                Dock = DockStyle.Fill // Makes the image fit within the form
            };

            imageForm.Controls.Add(pictureBox); // Add the picture box to the form
            imageForm.Text = "Image Viewer";
            imageForm.ShowDialog(); // Show the image form
        }
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
        private void HighlightWord(string word, Color color)
        {
            int startIndex = 0;

            while ((startIndex = rtb2.Text.IndexOf(word, startIndex)) != -1)
            {
                // Check if the word is at a word boundary
                bool isBoundaryBefore = (startIndex == 0) || !char.IsLetterOrDigit(rtb2.Text[startIndex - 1]);
                bool isBoundaryAfter = (startIndex + word.Length == rtb2.Text.Length) || !char.IsLetterOrDigit(rtb2.Text[startIndex + word.Length]);

                // If it's a whole word, highlight it
                if (isBoundaryBefore && isBoundaryAfter)
                {
                    rtb2.Select(startIndex, word.Length);
                    rtb2.SelectionColor = color;
                }

                startIndex += word.Length;
            }
        }

        private void Form3_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Color shadowColor = Color.FromArgb(50, 0, 0, 0); // Transparent black

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

        private void PictureBox_Click1(object sender, EventArgs e)
        {
            // Navigate to Form2 on click
            Form2 form2 = new Form2();
            form2.Show();

            // Optionally hide or close the current form
            this.Hide();
        }
    }

}

    
