using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace faCodeAndImap.Controllers
{
    public class Utils
    {
        public static ReaderWriterLock locker = new ReaderWriterLock();

        public string getFilePath()
        {
            string filePath = "";
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "Text Document(*.txt)| *.txt";
            choofdlog.FilterIndex = 1;


            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                filePath = choofdlog.FileName.ToString();
            }

            return filePath;
        }

        public string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public void WriteLogError(string text)
        {
            try
            {
                if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\ExportData"))
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\ExportData");
                }
            }
            catch { }
            try
            {
                locker.AcquireWriterLock(int.MaxValue);
                System.IO.File.AppendAllLines(Directory.GetCurrentDirectory() + @"\ExportData\exportError.txt", new[] { text });
            }
            finally
            {
                locker.ReleaseWriterLock();
            }
        }

        public void WriteSuccess(string text)
        {
            try
            {
                locker.AcquireWriterLock(int.MaxValue);
                System.IO.File.AppendAllLines(Directory.GetCurrentDirectory() + @"\success.txt", new[] { text });
            }
            finally
            {
                locker.ReleaseWriterLock();
            }
        }

        public void WriteError(string text)
        {
            try
            {
                locker.AcquireWriterLock(int.MaxValue);
                System.IO.File.AppendAllLines(Directory.GetCurrentDirectory() + @"\error.txt", new[] { text });
            }
            finally
            {
                locker.ReleaseWriterLock();
            }
        }

        public List<List<int>> chiaViTri(int soluong, int with)
        {
            List<List<int>> list = new List<List<int>>();
            int widthScreen = Int32.Parse(Screen.PrimaryScreen.Bounds.Width.ToString());
            int height = 0;
            int heightScreen = Int32.Parse(Screen.PrimaryScreen.Bounds.Height.ToString()) / 4 + 50;
            int width = 0;
            for (int i = 0; i < soluong; i++)
            {
                List<int> listVitri = new List<int>();
                if (width * with < widthScreen)
                {
                    listVitri.Add(width * with);
                    listVitri.Add(height);
                    list.Add(listVitri);
                    width++;
                }
                else
                {
                    listVitri.Add(width * with);
                    listVitri.Add(height);
                    list.Add(listVitri);
                    width = 0;
                    height += heightScreen;
                }
            }
            return list;
        }

        public List<List<int>> chiaViTriKieuCu(int soluong)
        {
            List<List<int>> list = new List<List<int>>();
            if (soluong / 4 > 1)
            {
                // 13 luoong
                int sodu = soluong % 4;
                //luong
                int sochia = soluong / 4;
                int boiWith = Int32.Parse(Screen.PrimaryScreen.Bounds.Width.ToString()) / (sochia + sodu);
                int boiHeight = Int32.Parse(Screen.PrimaryScreen.Bounds.Height.ToString()) / 4;
                int j = 0;
                //lap theo with
                for (int i = 0; i < 4; i++)
                {
                    List<int> temp = new List<int>();
                    if (i < (sochia + sodu))
                    {
                        temp.Add(i * boiWith);
                        temp.Add(0);

                    }
                    else
                    {

                        temp.Add(j * boiWith);
                        temp.Add(boiHeight);
                        j++;
                    }
                    list.Add(temp);
                }
            }
            else
            {
                //luong
                int boiWith = Int32.Parse(Screen.PrimaryScreen.Bounds.Width.ToString()) / soluong;
                //luong
                for (int i = 0; i < soluong; i++)
                {
                    List<int> temp = new List<int>();
                    temp.Add(i * boiWith);
                    temp.Add(0);
                    list.Add(temp);
                }
            }

            return list;
        }

    }
}
