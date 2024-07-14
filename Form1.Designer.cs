namespace faCodeAndImap
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            numericUpDown3 = new NumericUpDown();
            label4 = new Label();
            numericUpDown2 = new NumericUpDown();
            label3 = new Label();
            numericUpDown1 = new NumericUpDown();
            label2 = new Label();
            button6 = new Button();
            button5 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            groupBox2 = new GroupBox();
            dataGridView1 = new DataGridView();
            stt = new DataGridViewTextBoxColumn();
            username = new DataGridViewTextBoxColumn();
            password = new DataGridViewTextBoxColumn();
            status = new DataGridViewTextBoxColumn();
            proxy = new DataGridViewTextBoxColumn();
            profile = new DataGridViewTextBoxColumn();
            mailKP = new DataGridViewTextBoxColumn();
            imap = new DataGridViewTextBoxColumn();
            faKey = new DataGridViewTextBoxColumn();
            log = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(numericUpDown3);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(numericUpDown2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(numericUpDown1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(button6);
            groupBox1.Controls.Add(button5);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1038, 163);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Setting";
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(955, 37);
            numericUpDown3.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(50, 27);
            numericUpDown3.TabIndex = 13;
            numericUpDown3.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(891, 39);
            label4.Name = "label4";
            label4.Size = new Size(58, 20);
            label4.TabIndex = 12;
            label4.Text = "Thread:";
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(797, 37);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(50, 27);
            numericUpDown2.TabIndex = 11;
            numericUpDown2.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(763, 39);
            label3.Name = "label3";
            label3.Size = new Size(28, 20);
            label3.TabIndex = 10;
            label3.Text = "To:";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(707, 37);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(50, 27);
            numericUpDown1.TabIndex = 9;
            numericUpDown1.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(585, 39);
            label2.Name = "label2";
            label2.Size = new Size(105, 20);
            label2.TabIndex = 8;
            label2.Text = "Random Time:";
            // 
            // button6
            // 
            button6.BackColor = Color.Red;
            button6.ForeColor = Color.White;
            button6.Location = new Point(870, 100);
            button6.Name = "button6";
            button6.Size = new Size(158, 46);
            button6.TabIndex = 7;
            button6.Text = "Stop";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.Location = new Point(671, 100);
            button5.Name = "button5";
            button5.Size = new Size(158, 46);
            button5.TabIndex = 6;
            button5.Text = "Start";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(108, 110);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(247, 27);
            textBox1.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 113);
            label1.Name = "label1";
            label1.Size = new Size(87, 20);
            label1.TabIndex = 4;
            label1.Text = "viOtpToken:";
            // 
            // button4
            // 
            button4.Location = new Point(384, 100);
            button4.Name = "button4";
            button4.Size = new Size(158, 46);
            button4.TabIndex = 3;
            button4.Text = "Export All";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(384, 26);
            button3.Name = "button3";
            button3.Size = new Size(158, 46);
            button3.TabIndex = 2;
            button3.Text = "Delete All";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(197, 26);
            button2.Name = "button2";
            button2.Size = new Size(158, 46);
            button2.TabIndex = 1;
            button2.Text = "Thay Proxy";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(15, 26);
            button1.Name = "button1";
            button1.Size = new Size(158, 46);
            button1.TabIndex = 0;
            button1.Text = "Import Account";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Location = new Point(12, 185);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1037, 493);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Log";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { stt, username, password, status, proxy, profile, mailKP, imap, faKey, log });
            dataGridView1.Location = new Point(12, 25);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1016, 456);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellMouseDown += dataGridView1_CellMouseDown;
            dataGridView1.MouseClick += dataGridView1_MouseClick;
            // 
            // stt
            // 
            stt.HeaderText = "STT";
            stt.MinimumWidth = 50;
            stt.Name = "stt";
            stt.Width = 50;
            // 
            // username
            // 
            username.HeaderText = "Username";
            username.MinimumWidth = 100;
            username.Name = "username";
            username.Width = 125;
            // 
            // password
            // 
            password.HeaderText = "Password";
            password.MinimumWidth = 100;
            password.Name = "password";
            password.Width = 125;
            // 
            // status
            // 
            status.HeaderText = "Status";
            status.MinimumWidth = 70;
            status.Name = "status";
            status.Width = 70;
            // 
            // proxy
            // 
            proxy.HeaderText = "Proxy";
            proxy.MinimumWidth = 100;
            proxy.Name = "proxy";
            proxy.Width = 125;
            // 
            // profile
            // 
            profile.HeaderText = "Profile";
            profile.MinimumWidth = 100;
            profile.Name = "profile";
            profile.Width = 125;
            // 
            // mailKP
            // 
            mailKP.HeaderText = "mailKP";
            mailKP.MinimumWidth = 100;
            mailKP.Name = "mailKP";
            mailKP.Width = 125;
            // 
            // imap
            // 
            imap.HeaderText = "Imap, POP";
            imap.MinimumWidth = 100;
            imap.Name = "imap";
            imap.Width = 125;
            // 
            // faKey
            // 
            faKey.HeaderText = "2Fa Key";
            faKey.MinimumWidth = 100;
            faKey.Name = "faKey";
            faKey.Width = 125;
            // 
            // log
            // 
            log.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            log.HeaderText = "Log";
            log.MinimumWidth = 100;
            log.Name = "log";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1062, 685);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            MaximumSize = new Size(1080, 732);
            MinimumSize = new Size(1080, 732);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button button3;
        private Button button2;
        private Button button1;
        private NumericUpDown numericUpDown3;
        private Label label4;
        private NumericUpDown numericUpDown2;
        private Label label3;
        private NumericUpDown numericUpDown1;
        private Label label2;
        private Button button6;
        private Button button5;
        private TextBox textBox1;
        private Label label1;
        private Button button4;
        private GroupBox groupBox2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn stt;
        private DataGridViewTextBoxColumn username;
        private DataGridViewTextBoxColumn password;
        private DataGridViewTextBoxColumn status;
        private DataGridViewTextBoxColumn proxy;
        private DataGridViewTextBoxColumn profile;
        private DataGridViewTextBoxColumn mailKP;
        private DataGridViewTextBoxColumn imap;
        private DataGridViewTextBoxColumn faKey;
        private DataGridViewTextBoxColumn log;
    }
}
