using faCodeAndImap.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace faCodeAndImap.Views
{
    public partial class ImportAccount : Form
    {
        Utils utils = new Utils();
        SaveData saveData = new SaveData();

        public ImportAccount( bool changeProxy, List<string> listChangeProxy)
        {
            InitializeComponent();
            if(changeProxy )
            {
                this.Name = "Change Proxy";
                textBox1.Enabled = false;
                textBox1.Lines = listChangeProxy.ToArray();
                button1.Enabled = false;
                button6.Text = "Change";
            }
            this.StartPosition = Form1.ActiveForm.StartPosition;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string[] strings = File.ReadAllLines(utils.getFilePath());
                textBox1.Lines = strings;
            }
            catch { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string[] strings = File.ReadAllLines(utils.getFilePath());
                textBox2.Lines = strings;
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Vui lòng thêm các trường còn thiếu!", "Thông báo");
                return;
            }
            bool changeProxy = button6.Text.Equals("Change") ? true : false;
            Task.Run(() =>
            {
                saveData = new SaveData();
                List<string> proxyAdd = new List<string>();
                if (textBox2.Lines.Length < textBox1.Lines.Length)
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn có muốn sử dụng lại proxy cho các acc còn lại không? Bấm Yes để sử dụng lại proxy. Bấm No để add thêm proxy", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int k = 0;
                        for (int i = 0; i < textBox1.Lines.Length; i++)
                        {

                            if (textBox2.Lines.Length == k)
                            {
                                k = 0;
                            }
                            if (!string.IsNullOrEmpty(textBox2.Lines[k]))
                                proxyAdd.Add(textBox2.Lines[k]);
                            k++;
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
                else
                {
                    for (int i = 0; i < textBox2.Lines.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(textBox2.Lines[i]))
                            proxyAdd.Add(textBox2.Lines[i]);
                    }
                }
                for (int i = 0; i < textBox1.Lines.Length; i++)
                {
                    if (!changeProxy)
                    {
                        string[] subAccount = textBox1.Lines[i].Split(new char[] { '|' });
                        try
                        {
                            saveData.saveAccount(subAccount[0], subAccount[1], "Unchecked", proxyAdd[i], "", subAccount[2], "", "", "");
                        }
                        catch { }
                    }
                    else
                    {
                        string[] subAccount = textBox1.Lines[i].Split(new char[] { '|' });
                        try
                        {
                            saveData.updateProxyByID(subAccount[0], proxyAdd[i]);
                        }
                        catch { }
                        if (!string.IsNullOrEmpty(subAccount[2]))
                        {
                            try
                            {
                                GPMController gPMController = new GPMController();
                                bool change = gPMController.changeProxy(subAccount[2], proxyAdd[i]).Result;
                            }
                            catch { }
                        }
                    }
                    
                }
                MessageBox.Show("Đã thêm thành công!", "Thông báo");
            });
        }
    }
}
