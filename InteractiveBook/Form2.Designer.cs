namespace InteractiveBook
{
    partial class Form2
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
            this.rtb1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtb1
            // 
            this.rtb1.BackColor = System.Drawing.Color.White;
            this.rtb1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb1.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb1.Location = new System.Drawing.Point(39, 26);
            this.rtb1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtb1.Name = "rtb1";
            this.rtb1.Size = new System.Drawing.Size(602, 594);
            this.rtb1.TabIndex = 2;
            this.rtb1.Text = "";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(682, 703);
            this.Controls.Add(this.rtb1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form2";
            this.Text = "FirstPage";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form2_Paint);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox rtb1;
    }
}