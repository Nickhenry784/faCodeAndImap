namespace faCodeAndImap.Views
{
    partial class ImportAccount
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
            label1 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            button3 = new Button();
            button5 = new Button();
            button6 = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 9);
            label1.Name = "label1";
            label1.Size = new Size(338, 23);
            label1.TabIndex = 0;
            label1.Text = "Account (Type: username|password|mailKP)";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(27, 44);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(417, 361);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(469, 44);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(394, 361);
            textBox2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(469, 9);
            label2.Name = "label2";
            label2.Size = new Size(52, 23);
            label2.TabIndex = 2;
            label2.Text = "Proxy";
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            button3.BackColor = Color.Red;
            button3.ForeColor = Color.White;
            button3.Location = new Point(27, 429);
            button3.Name = "button3";
            button3.Size = new Size(165, 55);
            button3.TabIndex = 25;
            button3.Text = "Close";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            button5.BackColor = Color.White;
            button5.ForeColor = Color.Black;
            button5.Location = new Point(459, 429);
            button5.Name = "button5";
            button5.Size = new Size(202, 55);
            button5.TabIndex = 24;
            button5.Text = "Load Proxy From File";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            button6.BackColor = Color.White;
            button6.ForeColor = Color.Black;
            button6.Location = new Point(677, 429);
            button6.Name = "button6";
            button6.Size = new Size(186, 55);
            button6.TabIndex = 23;
            button6.Text = "Import Account";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            button1.BackColor = Color.White;
            button1.ForeColor = Color.Black;
            button1.Location = new Point(214, 429);
            button1.Name = "button1";
            button1.Size = new Size(230, 55);
            button1.TabIndex = 26;
            button1.Text = "Load Account From File";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // ImportAccount
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(885, 496);
            Controls.Add(button1);
            Controls.Add(button3);
            Controls.Add(button5);
            Controls.Add(button6);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ImportAccount";
            Text = "Import Account";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button1;
    }
}