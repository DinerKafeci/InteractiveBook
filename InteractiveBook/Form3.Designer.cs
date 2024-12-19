namespace InteractiveBook
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtb2 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtb2
            // 
            this.rtb2.BackColor = System.Drawing.Color.White;
            this.rtb2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb2.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb2.Location = new System.Drawing.Point(40, 25);
            this.rtb2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtb2.Name = "rtb2";
            this.rtb2.Size = new System.Drawing.Size(600, 604);
            this.rtb2.TabIndex = 1;
            this.rtb2.Text = "";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(682, 703);
            this.Controls.Add(this.rtb2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form3";
            this.Text = "SecondPage";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form3_Paint);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox rtb2;
    }
}