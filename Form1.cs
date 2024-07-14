

using faCodeAndImap.Controllers;
using faCodeAndImap.Models;
using faCodeAndImap.Views;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Data.SQLite;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace faCodeAndImap
{
    public partial class Form1 : Form
    {
        SaveData saveData = new SaveData();
        bool isRun = false;
        Queue<int> listRun;
        Utils utils = new Utils();

        public Form1()
        {
            InitializeComponent();
            saveData.createTableAccountGmail();
            saveData.createTableKeyAPI();
            button6.Enabled = false;
        }

        #region xử lí form
        private void frm2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Enabled = true;
            loadDataAccount();
        }

        public void loadDataAccount()
        {
            try
            {
                dataGridView1.Rows.Clear();
                SQLiteDataReader sQLiteDataReader = saveData.loadDataAccountGmail();
                int k = 1;
                while (sQLiteDataReader.Read())
                {
                    dataGridView1.Rows.Add(k, sQLiteDataReader.GetString(0), sQLiteDataReader.GetString(1), sQLiteDataReader.GetString(2), sQLiteDataReader.GetString(3), sQLiteDataReader.GetString(4), sQLiteDataReader.GetString(5), sQLiteDataReader.GetString(6), sQLiteDataReader.GetString(7));
                    k++;
                }

            }
            catch
            {
                Console.WriteLine("Error");
            }
        }

        public void loadDataKeyAPI()
        {
            try
            {
                SQLiteDataReader sQLiteDataReader = saveData.loadDataSetting();
                while (sQLiteDataReader.Read())
                {
                    textBox1.Text = sQLiteDataReader.GetString(0);
                }

            }
            catch
            {
                Console.WriteLine("Error");
            }
        }

        public void addLogTodataGridView1(int indexRow, int indexCell, string log)
        {
            dataGridView1.Invoke(new Action(() =>
            {
                dataGridView1.Rows[indexRow].Cells[indexCell].Value = log;
            }));
        }

        public void deleteThisAccount_Click(object? sender, System.EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn xoá this Account và xoá luôn profile đã tạo. Yes: Xoá Account và Profile. No: Xoá Account", "Thông báo", MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Yes)
            {
                int selectedrowindex = dataGridView1.SelectedCells[1].RowIndex;
                saveData.deleteAccount(dataGridView1.Rows[selectedrowindex].Cells[1].Value.ToString());
                string directoryProfile = dataGridView1.Rows[selectedrowindex].Cells[6].Value.ToString();
                if (!string.IsNullOrEmpty(directoryProfile))
                {
                    GPMController gPMController = new GPMController();
                    gPMController.deleteProfile(directoryProfile);
                }
                loadDataAccount();
            }
            else if (dialogResult == DialogResult.No)
            {
                int selectedrowindex = dataGridView1.SelectedCells[1].RowIndex;
                saveData.deleteAccount(dataGridView1.Rows[selectedrowindex].Cells[1].Value.ToString());
                loadDataAccount();
            }

        }

        public void deleteAccountLayPI_Click(object? sender, System.EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn xoá những Account đã lấy API và xoá luôn profile đã tạo. Yes: Xoá Account và Profile. No: Xoá Account", "Thông báo", MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Yes)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[8].Value.ToString()))
                    {
                        saveData.deleteAccount(dataGridView1.Rows[i].Cells[1].Value.ToString());
                        string directoryProfile = dataGridView1.Rows[i].Cells[6].Value.ToString();
                        if (!string.IsNullOrEmpty(directoryProfile))
                        {
                            GPMController gPMController = new GPMController();
                            gPMController.deleteProfile(directoryProfile);
                        }
                    }
                }
                loadDataAccount();
            }
            else if (dialogResult == DialogResult.No)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[8].Value.ToString()))
                    {
                        saveData.deleteAccount(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    }
                }
                loadDataAccount();
            }

        }

        public void changeProxyThisAccount_Click(object? sender, System.EventArgs e)
        {
            int selectedrowindex = dataGridView1.SelectedCells[1].RowIndex;
            this.Enabled = false;
            List<string> listChange = new List<string>();
            listChange.Add(dataGridView1.Rows[selectedrowindex].Cells[1].Value.ToString() + "|" + dataGridView1.Rows[selectedrowindex].Cells[4].Value.ToString() + "|" + dataGridView1.Rows[selectedrowindex].Cells[5].Value.ToString());
            ImportAccount form2 = new ImportAccount(true, listChange);
            form2.FormClosed += frm2_FormClosed;
            form2.ShowDialog();

        }

        public void changeProxyAccountNotRun_Click(object? sender, System.EventArgs e)
        {
            this.Enabled = false;
            List<string> listChange = new List<string>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[8].Value.ToString()))
                {
                    listChange.Add(dataGridView1.Rows[i].Cells[1].Value.ToString() + "|" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "|" + dataGridView1.Rows[i].Cells[5].Value.ToString());
                }
            }
            ImportAccount form2 = new ImportAccount(true, listChange);
            form2.FormClosed += frm2_FormClosed;
            form2.ShowDialog();

        }

        public void setAccountSuccess_Click(object? sender, System.EventArgs e)
        {
            int selectedrowindex = dataGridView1.SelectedCells[1].RowIndex;
            saveData.updateStatusByID(dataGridView1.Rows[selectedrowindex].Cells[1].Value.ToString(), "success");
            dataGridView1.Rows[selectedrowindex].Cells[3].Value = "success";
            loadDataAccount();

        }

        public void setAccountunchecked_Click(object? sender, System.EventArgs e)
        {
            int selectedrowindex = dataGridView1.SelectedCells[1].RowIndex;
            saveData.updateStatusByID(dataGridView1.Rows[selectedrowindex].Cells[1].Value.ToString(), "Unchecked");
            dataGridView1.Rows[selectedrowindex].Cells[3].Value = "Unchecked";
            loadDataAccount();

        }

        public void openBrowserThisAccount_Click(object? sender, System.EventArgs e)
        {
            int selectedrowindex = dataGridView1.SelectedCells[1].RowIndex;
            string directoryProfile = dataGridView1.Rows[selectedrowindex].Cells[5].Value.ToString();
            GPMController gPMController = new GPMController();
            string win_pos = "0,0";
            gPMController.openBrowser(directoryProfile, win_pos);
        }

        public void deleteProfileAccount(object? sender, System.EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn xoá Profile this account không?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int selectedrowindex = dataGridView1.SelectedCells[1].RowIndex;
                string directoryProfile = dataGridView1.Rows[selectedrowindex].Cells[5].Value.ToString();
                if (!string.IsNullOrEmpty(directoryProfile))
                {
                    GPMController gPMController = new GPMController();
                    gPMController.deleteProfile(directoryProfile);
                }
                try
                {
                    saveData.updateProfileByID(dataGridView1.Rows[selectedrowindex].Cells[1].Value.ToString(), "");
                    dataGridView1.Rows[selectedrowindex].Cells[5].Value = "";
                }
                catch { }

                loadDataAccount();
            }
        }
        #endregion

        #region Xử lí logic
        private void checkGPMLoginOpen()
        {
            Process[] process = Process.GetProcessesByName("GPMLogin");
            string userName = Environment.UserName;
            if (process.Length == 0)
            {
                Process.Start(@"C:\Users\" + userName + @"\AppData\Local\Programs\GPMLogin\GPMLogin.exe");
            }
        }

        private WebDriver getDriver(string idBrowser, string win_pos)
        {
            GPMController gPMController = new GPMController();
            OpenProfileResult openProfileModel = gPMController.openBrowser(idBrowser, win_pos).Result;
            if (openProfileModel != null && openProfileModel.success)
            {
                try
                {
                    ChromeDriverService cService = ChromeDriverService.CreateDefaultService();
                    cService.HideCommandPromptWindow = true;
                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments("--disable-notifications");
                    options.AddArgument("--blink-settings=imagesEnabled=false");
                    options.BinaryLocation = openProfileModel.data.browser_location;
                    options.DebuggerAddress = openProfileModel.data.remote_debugging_address;
                    var driver = new ChromeDriver(options: options, service: cService);
                    driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(90));
                    return driver;
                }
                catch
                {
                    return null;
                }

            }
            else
            {
                return null;
            }
        }

        public async void loginAndFindApi(int thread, int PosX, int PosY)
        {
            try
            {
                while (listRun.Count != 0)
                {
                    try
                    {
                        if (!isRun)
                        {
                            return;
                        }
                        Thread.Sleep(1000 * thread);
                        int index = -1;
                        try
                        {
                            index = listRun.Dequeue();
                        }
                        catch { }
                        if (index == -1)
                        {
                            return;
                        }
                        dataGridView1.Invoke(new Action(() =>
                        {
                            dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.Yellow;
                        }));
                        GPMController gPMController = new GPMController();
                        addLogTodataGridView1(index, 9, "Bắt đầu chạy");
                        if (string.IsNullOrEmpty(dataGridView1.Rows[index].Cells[5].Value.ToString()))
                        {
                            addLogTodataGridView1(index, 9, "Bắt đầu tạo profile");
                            CreateProfileResult createProfileResult = gPMController.createProfile(dataGridView1.Rows[index].Cells[4].Value.ToString(), thread).Result;
                            if (createProfileResult != null)
                            {
                                try
                                {
                                    saveData.updateProfileByID(dataGridView1.Rows[index].Cells[1].Value.ToString(), createProfileResult.data.id);
                                }
                                catch { }
                                addLogTodataGridView1(index, 5, createProfileResult.data.id);
                            }
                        }
                        addLogTodataGridView1(index, 9, "Setting Chrome");
                        string win_pos = PosX + "," + PosY;
                        WebDriver driver = getDriver(dataGridView1.Rows[index].Cells[5].Value.ToString(), win_pos);
                        Thread.Sleep(1000 * thread);
                        if (driver != null)
                        {
                            bool isSuccess = false;
                            try
                            {
                                Thread.Sleep(1000 * thread);
                                driver.Navigate().GoToUrl("https://accounts.google.com/");
                                _ = driver.Manage().Timeouts().ImplicitWait;
                                GmailController gmailController = new GmailController();
                                bool checkLogin = gmailController.checkLoginAccount(driver);
                                string isLogin = string.Empty;
                                bool statusLogin = false;
                                if (!checkLogin)
                                {
                                    addLogTodataGridView1(index, 9, "Bắt đầu Login");
                                    isLogin = gmailController.LoginAccount(driver, dataGridView1.Rows[index].Cells[1].Value.ToString(), dataGridView1.Rows[index].Cells[2].Value.ToString(), dataGridView1.Rows[index].Cells[6].Value.ToString(), (int)numericUpDown2.Value, (int)numericUpDown3.Value);
                                    Thread.Sleep(1000);
                                    if (!string.IsNullOrEmpty(isLogin))
                                    {
                                        if (isLogin.Equals("Sai UserName"))
                                        {
                                            try
                                            {
                                                saveData.updateStatusByID(dataGridView1.Rows[index].Cells[1].Value.ToString(), "Sai UserName");
                                            }
                                            catch { }
                                            addLogTodataGridView1(index, 3, "Sai UserName");
                                            dataGridView1.Invoke(new Action(() =>
                                            {
                                                dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.Red;
                                            }));
                                            utils.WriteError(dataGridView1.Rows[index].Cells[1].Value.ToString() + "|" + dataGridView1.Rows[index].Cells[2].Value.ToString() + "|" + dataGridView1.Rows[index].Cells[6].Value.ToString() + "|Login không thành công");
                                        }
                                        else if (isLogin.Equals("Sai Password"))
                                        {
                                            try
                                            {
                                                saveData.updateStatusByID(dataGridView1.Rows[index].Cells[1].Value.ToString(), "Sai Password");
                                            }
                                            catch { }
                                            addLogTodataGridView1(index, 3, "Sai Password");
                                            dataGridView1.Invoke(new Action(() =>
                                            {
                                                dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.Red;
                                            }));
                                            utils.WriteError(dataGridView1.Rows[index].Cells[1].Value.ToString() + "|" + dataGridView1.Rows[index].Cells[2].Value.ToString() + "|" + dataGridView1.Rows[index].Cells[6].Value.ToString() + "|Login không thành công");
                                        }
                                        else if (isLogin.Equals("Login Error"))
                                        {
                                            try
                                            {
                                                saveData.updateStatusByID(dataGridView1.Rows[index].Cells[1].Value.ToString(), "die");
                                            }
                                            catch { }
                                            addLogTodataGridView1(index, 3, "die");
                                            dataGridView1.Invoke(new Action(() =>
                                            {
                                                dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.Red;
                                            }));
                                            utils.WriteError(dataGridView1.Rows[index].Cells[1].Value.ToString() + "|" + dataGridView1.Rows[index].Cells[2].Value.ToString() + "|" + dataGridView1.Rows[index].Cells[6].Value.ToString() + "|Login không thành công");
                                        }
                                        else
                                        {
                                            try
                                            {
                                                saveData.updateStatusByID(dataGridView1.Rows[index].Cells[1].Value.ToString(), "success");
                                            }
                                            catch { }
                                            addLogTodataGridView1(index, 3, "success");
                                            statusLogin = true;
                                        }
                                    }
                                    else
                                    {
                                        addLogTodataGridView1(index, 9, "Có lỗi khi login");
                                        dataGridView1.Invoke(new Action(() =>
                                        {
                                            dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.White;
                                        }));
                                    }
                                }
                                else
                                {
                                    statusLogin = true;
                                }
                                if (statusLogin)
                                {
                                    addLogTodataGridView1(index, 9, "Login thành công");
                                    addLogTodataGridView1(index, 9, "Bật IMap và POP");
                                    if (string.IsNullOrEmpty(dataGridView1.Rows[index].Cells[7].Value.ToString()))
                                    {
                                        bool enableImap = gmailController.enableIMapAndPOP(driver);
                                        Thread.Sleep(2000);
                                        if (enableImap)
                                        {
                                            addLogTodataGridView1(index, 9, "Bật IMap và POP thành công");
                                            try
                                            {
                                                saveData.updateIMAPByID(dataGridView1.Rows[index].Cells[1].Value.ToString(), "Enable");
                                            }
                                            catch { }
                                            addLogTodataGridView1(index, 7, "Enable");
                                        }
                                        else
                                        {
                                            addLogTodataGridView1(index, 9, "Bật IMap và POP không thành công");
                                        }
                                    }
                                    addLogTodataGridView1(index, 9, "Bật 2FA và get pass App");
                                    viOtpController viOtpController = new viOtpController();
                                    int balance = viOtpController.getBalance(textBox1.Text).Result;
                                    if (balance > 1600 && string.IsNullOrEmpty(dataGridView1.Rows[index].Cells[8].Value.ToString()))
                                    {
                                        string enable2Fa = gmailController.enable2faAndPasswordPhone(driver, textBox1.Text);
                                        Thread.Sleep(2000);
                                        if (!string.IsNullOrEmpty(enable2Fa))
                                        {
                                            if (!enable2Fa.Equals("Err"))
                                            {
                                                addLogTodataGridView1(index, 9, "Bắt đầu get password Application");
                                                string passwordApp = gmailController.getPasswordApplication(driver, enable2Fa);
                                                Thread.Sleep(2000);
                                                if (!string.IsNullOrEmpty(passwordApp))
                                                {
                                                    addLogTodataGridView1(index, 9, "Get password Application thành công");
                                                    addLogTodataGridView1(index, 9, "Bắt đầu xoá Phone");
                                                    bool deletePhone = gmailController.deletePhone(driver, enable2Fa);
                                                    Thread.Sleep(2000);
                                                    addLogTodataGridView1(index, 9, "Bắt đầu lấy Password App");
                                                    string appPassword = gmailController.getAppPassword(driver, enable2Fa);
                                                    Thread.Sleep(1000);
                                                    try
                                                    {
                                                        saveData.updatefaKeyByID(dataGridView1.Rows[index].Cells[1].Value.ToString(), passwordApp + "| " + appPassword);
                                                    }
                                                    catch { }
                                                    addLogTodataGridView1(index, 8, passwordApp + "| " + appPassword);
                                                    Thread.Sleep(1000);
                                                    addLogTodataGridView1(index, 9, "Done!");
                                                    isSuccess = true;
                                                    utils.WriteSuccess(dataGridView1.Rows[index].Cells[1].Value.ToString() + "|" + dataGridView1.Rows[index].Cells[2].Value.ToString() + "|" + dataGridView1.Rows[index].Cells[6].Value.ToString() + "|" + dataGridView1.Rows[index].Cells[7].Value.ToString() + "|" + dataGridView1.Rows[index].Cells[8].Value.ToString());
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        addLogTodataGridView1(index, 9, "Không đủ tiền để nhận code");
                                        isRun = false;
                                    }

                                }
                            }
                            catch (Exception ex)
                            {
                                dataGridView1.Invoke(new Action(() =>
                                {
                                    dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.White;
                                }));
                                utils.WriteLogError(ex.Message.ToString());
                                try
                                {
                                    gPMController.closeBrowser(dataGridView1.Rows[index].Cells[5].Value.ToString());
                                }
                                catch { }
                            }
                            finally
                            {
                                dataGridView1.Invoke(new Action(() =>
                                {
                                    dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.White;
                                }));
                                try
                                {
                                    gPMController.closeBrowser(dataGridView1.Rows[index].Cells[5].Value.ToString());
                                }
                                catch { }
                                Thread.Sleep(5000);
                                if (isSuccess)
                                {
                                    try
                                    {
                                        gPMController.deleteProfile(dataGridView1.Rows[index].Cells[5].Value.ToString());
                                    }
                                    catch { }
                                    try
                                    {
                                        saveData.updateProfileByID(dataGridView1.Rows[index].Cells[1].Value.ToString(), "");
                                    }
                                    catch { }
                                    dataGridView1.Invoke(new Action(() =>
                                    {
                                        dataGridView1.Rows[index].Cells[5].Value = "";
                                    }));

                                }
                            }
                        }
                    }
                    catch (Exception err)
                    {
                        utils.WriteLogError(err.Message.ToString());
                    }
                }
            }
            catch (Exception err)
            {
                utils.WriteLogError(err.Message.ToString());
            }


        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            ImportAccount form2 = new ImportAccount(false, new List<string>());
            form2.FormClosed += frm2_FormClosed;
            form2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            List<string> listChange = new List<string>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                listChange.Add(dataGridView1.Rows[i].Cells[1].Value.ToString() + "|" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "|" + dataGridView1.Rows[i].Cells[5].Value.ToString());
            }
            ImportAccount form2 = new ImportAccount(true, listChange);
            form2.FormClosed += frm2_FormClosed;
            form2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn xoá hết Account và xoá luôn profile đã tạo. Yes: Xoá Account và Profile. No: Xoá Account", "Thông báo", MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Yes)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    try
                    {
                        string directoryProfile = dataGridView1.Rows[i].Cells[5].Value.ToString();
                        if (!string.IsNullOrEmpty(directoryProfile))
                        {
                            GPMController gPMController = new GPMController();
                            gPMController.deleteProfile(directoryProfile);
                        }
                    }
                    catch { }
                    try
                    {
                        saveData.deleteAccount();
                    }
                    catch { }
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    try
                    {
                        saveData.deleteAccount();
                    }
                    catch { }
                }
            }
            loadDataAccount();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            isRun = false;
            button6.Enabled = false;
            button5.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            isRun = true;
            button5.Enabled = false;
            button6.Enabled = true;
            List<List<int>> listvitri = utils.chiaViTri((int)numericUpDown3.Value, 500);
            listRun = new Queue<int>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[3].Value.ToString().Equals("success") || dataGridView1.Rows[i].Cells[3].Value.ToString().Equals("Unchecked"))
                {
                    if (string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[7].Value.ToString()) && string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[8].Value.ToString()) || !string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[7].Value.ToString()) && string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[8].Value.ToString()))
                    {
                        listRun.Enqueue(i);
                    }
                }
            }
            Task.Run(() =>
            {
                List<Task> tasks = new List<Task>();
                for (int i = 0; i < (int)numericUpDown3.Value; i++)
                {
                    int thread = i + 1;
                    List<int> vitri = listvitri[i];
                    Task task = Task.Run(async () =>
                    {
                        loginAndFindApi(thread, vitri[0], vitri[1]);
                    });
                    tasks.Add(task);
                }
                Task.WaitAll(tasks.ToArray());
                MessageBox.Show("Done", "Thông báo");
                this.Invoke(new Action(() =>
                {
                    button6.Enabled = false;
                    button5.Enabled = true;
                }));
                isRun = false;
            });
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            var dataGrid = (DataGridView)sender;
            if (e.Button == MouseButtons.Right && e.RowIndex != -1)
            {
                var row = dataGrid.Rows[e.RowIndex];
                dataGrid.CurrentCell = row.Cells[e.ColumnIndex == -1 ? 1 : e.ColumnIndex];
                row.Selected = true;
                dataGrid.Focus();
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    int selectedrowindex = dataGridView1.SelectedCells[1].RowIndex;
                    ContextMenuStrip m = new ContextMenuStrip();
                    m.Items.Add(new ToolStripMenuItem("Set Status = success This Account", null, new EventHandler(setAccountSuccess_Click)));
                    m.Items.Add(new ToolStripMenuItem("Set Status = Unchecked This Account", null, new EventHandler(setAccountunchecked_Click)));
                    m.Items.Add(new ToolStripMenuItem("Delete This Account", null, new EventHandler(deleteThisAccount_Click)));
                    m.Items.Add(new ToolStripMenuItem("Delete Profile This Account", null, new EventHandler(deleteProfileAccount)));
                    m.Items.Add(new ToolStripMenuItem("Change Proxy Account này", null, new EventHandler(changeProxyThisAccount_Click)));
                    m.Items.Add(new ToolStripMenuItem("Change Proxy Account Chưa Chạy", null, new EventHandler(changeProxyAccountNotRun_Click)));
                    m.Items.Add(new ToolStripMenuItem("Xoá account đã lấy được API", null, new EventHandler(deleteAccountLayPI_Click)));
                    m.Items.Add(new ToolStripMenuItem("Open Browser This Account", null, new EventHandler(openBrowserThisAccount_Click)));
                    m.Show(dataGridView1, new Point(e.X, e.Y));
                }
                catch { }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string filePatch = string.Empty;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.Title = "Save Files";
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePatch = saveFileDialog1.FileName;
            }
            List<string> list = new List<string>();
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn export hết Account. Yes: Export All. No: Export Success", "Thông báo", MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Yes)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string exportString = dataGridView1.Rows[i].Cells[1].Value.ToString() + "|" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "|" + dataGridView1.Rows[i].Cells[6].Value.ToString() + "|" + dataGridView1.Rows[i].Cells[7].Value.ToString() + "|" + dataGridView1.Rows[i].Cells[8].Value?.ToString();
                    list.Add(exportString);
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[8].Value.ToString()))
                    {
                        try
                        {
                            string exportString = dataGridView1.Rows[i].Cells[1].Value.ToString() + "|" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "|" + dataGridView1.Rows[i].Cells[6].Value.ToString() + "|" + dataGridView1.Rows[i].Cells[7].Value.ToString() + "|" + dataGridView1.Rows[i].Cells[8].Value?.ToString();
                            list.Add(exportString);
                        }
                        catch { }
                    }
                }
            }
            if (!string.IsNullOrEmpty(filePatch))
            {
                File.WriteAllLines(filePatch, list);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadDataAccount();
            checkGPMLoginOpen();
            loadDataKeyAPI();
            Process[] processes = Process.GetProcessesByName("chromedriver");

            foreach (Process process in processes)
            {
                process.Kill();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveData.deleteKeyAPI();
            Thread.Sleep(500);
            saveData.updateKeyAPI(textBox1.Text);
        }
    }
}
