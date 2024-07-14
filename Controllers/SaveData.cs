using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace faCodeAndImap.Controllers
{
    public class SaveData
    {
        SQLiteConnection _con = new SQLiteConnection();

        ReaderWriterLock locker = new ReaderWriterLock();

        public void createConection()
        {
            var CurrentDirectory = Directory.GetCurrentDirectory();
            Directory.CreateDirectory(CurrentDirectory + @"\Data");
            string _strConnect = "Data Source=" + CurrentDirectory + "\\Data\\Database";
            _con = new SQLiteConnection(_strConnect);
            _con.Open();
        }

        public void closeConnection()
        {
            _con.Close();
        }

        public void createTableAccountGmail()
        {
            string sql = "CREATE TABLE IF NOT EXISTS tbl_accountGmail (username nvarchar(50) NOT NULL PRIMARY KEY, password nvarchar(50), status nvarchar(50), proxy nvarchar(50), profile nvarchar(500), mailKP nvarchar(50), imap nvarchar(50), faKey nvarchar(50), log nvarchar(100))";
            createConection();
            SQLiteCommand command = new SQLiteCommand(sql, _con);
            command.ExecuteNonQuery();
            closeConnection();
        }

        public SQLiteDataReader loadDataAccountGmail()
        {
            createConection();
            string sql = "select * from tbl_accountGmail";
            SQLiteCommand command = new SQLiteCommand(sql, _con);
            SQLiteDataReader reader = command.ExecuteReader();
            return reader;
        }

        public void updateProfileByID(string username, string profile)
        {
            try
            {
                locker.AcquireWriterLock(int.MaxValue);
                try
                {
                    string strUpdate = string.Format("UPDATE tbl_accountGmail SET profile=\'" + profile + "\' WHERE username=\'" + username + "\'");
                    createConection();
                    SQLiteCommand command = new SQLiteCommand(strUpdate, _con);
                    command.ExecuteNonQuery();
                    closeConnection();
                }
                catch { }
            }
            finally
            {
                locker.ReleaseWriterLock();
            }
        }

        public void updateStatusByID(string username, string status)
        {
            try
            {
                locker.AcquireWriterLock(int.MaxValue);
                try
                {
                    string strUpdate = string.Format("UPDATE tbl_accountGmail SET status=\'" + status + "\' WHERE username=\'" + username + "\'");
                    createConection();
                    SQLiteCommand command = new SQLiteCommand(strUpdate, _con);
                    command.ExecuteNonQuery();
                    closeConnection();
                }
                catch { }
            }
            finally
            {
                locker.ReleaseWriterLock();
            }
        }

        public void updateIMAPByID(string username, string imap)
        {
            try
            {
                locker.AcquireWriterLock(int.MaxValue);
                try
                {
                    string strUpdate = string.Format("UPDATE tbl_accountGmail SET imap=\'" + imap + "\' WHERE username=\'" + username + "\'");
                    createConection();
                    SQLiteCommand command = new SQLiteCommand(strUpdate, _con);
                    command.ExecuteNonQuery();
                    closeConnection();
                }
                catch { }
            }
            finally
            {
                locker.ReleaseWriterLock();
            }
        }

        public void updatefaKeyByID(string username, string faKey)
        {
            try
            {
                locker.AcquireWriterLock(int.MaxValue);
                try
                {
                    string strUpdate = string.Format("UPDATE tbl_accountGmail SET faKey=\'" + faKey + "\' WHERE username=\'" + username + "\'");
                    createConection();
                    SQLiteCommand command = new SQLiteCommand(strUpdate, _con);
                    command.ExecuteNonQuery();
                    closeConnection();
                }
                catch { }
            }
            finally
            {
                locker.ReleaseWriterLock();
            }
        }

        public void updateProxyByID(string username, string proxy)
        {
            try
            {
                locker.AcquireWriterLock(int.MaxValue);
                try
                {
                    string strUpdate = string.Format("UPDATE tbl_accountGmail SET proxy=\'" + proxy + "\' WHERE username=\'" + username + "\'");
                    createConection();
                    SQLiteCommand command = new SQLiteCommand(strUpdate, _con);
                    command.ExecuteNonQuery();
                    closeConnection();
                }
                catch { }
            }
            finally
            {
                locker.ReleaseWriterLock();
            }
        }

        public void deleteAccount(string username = "")
        {
            try
            {
                locker.AcquireWriterLock(int.MaxValue);
                try
                {
                    string strDelete = string.Format("DELETE FROM tbl_accountGmail");
                    if (!string.IsNullOrEmpty(username))
                    {
                        strDelete = string.Format("DELETE FROM tbl_accountGmail WHERE username=\'" + username + "\'");
                    }
                    createConection();
                    SQLiteCommand command = new SQLiteCommand(strDelete, _con);
                    command.ExecuteNonQuery();
                    closeConnection();
                }
                catch (Exception ex) { }
            }
            finally
            {
                locker.ReleaseWriterLock();
            }
        }


        public void saveAccount(string username, string password, string status, string proxy, string profile, string mailKP, string imap, string faKey, string log)
        {
            try
            {
                locker.AcquireWriterLock(int.MaxValue);
                try
                {
                    string strInsert = string.Format("INSERT INTO tbl_accountGmail(username, password, status, proxy, profile, mailKP, imap, faKey, log) VALUES(\'" + username + "\',\'" + password + "\',\'" + status + "\',\'" + proxy + "\',\'" + profile + "\',\'" + mailKP + "\',\'" + imap + "\',\'" + faKey + "\',\'" + log + "\')");
                    createConection();
                    SQLiteCommand command = new SQLiteCommand(strInsert, _con);
                    command.ExecuteNonQuery();
                    closeConnection();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.ToString());
                }
            }
            finally
            {
                locker.ReleaseWriterLock();
            }
        }

        public void createTableKeyAPI()
        {
            string sql = "CREATE TABLE IF NOT EXISTS tbl_setting (id INTEGER NOT NULL PRIMARY KEY, keyApi nvarchar(50))";
            createConection();
            SQLiteCommand command = new SQLiteCommand(sql, _con);
            command.ExecuteNonQuery();
            closeConnection();
        }

        public void deleteKeyAPI()
        {
            try
            {
                locker.AcquireWriterLock(int.MaxValue);
                try
                {
                    string strDelete = string.Format("DELETE FROM tbl_setting WHERE id=1");
                    createConection();
                    SQLiteCommand command = new SQLiteCommand(strDelete, _con);
                    command.ExecuteNonQuery();
                    closeConnection();
                }
                catch (Exception ex) { 
                    Console.WriteLine($"Error: {ex.ToString()}");
                }
            }
            finally
            {
                locker.ReleaseWriterLock();
            }
        }

        public void updateKeyAPI(string keyApi)
        {
            try
            {
                locker.AcquireWriterLock(int.MaxValue);
                try
                {
                    string strDelete = string.Format("INSERT INTO tbl_setting(id,keyApi) VALUES(1,\'" + keyApi + "\')");
                    createConection();
                    SQLiteCommand command = new SQLiteCommand(strDelete, _con);
                    command.ExecuteNonQuery();
                    closeConnection();
                }
                catch (Exception ex) {
                    Console.WriteLine($"Error: {ex.ToString()}");
                }
            }
            finally
            {
                locker.ReleaseWriterLock();
            }
        }
        public SQLiteDataReader loadDataSetting()
        {
            createConection();
            string sql = "select keyApi from tbl_setting where id=1";
            SQLiteCommand command = new SQLiteCommand(sql, _con);
            SQLiteDataReader reader = command.ExecuteReader();
            return reader;
        }

    }
}
