using System;
using System.Collections.Generic;
using System.IO;

namespace DSA
{
    public class DoThi
    {
        private int soDinh;
        private int dinhBatDau;
        private int[,] doThiLuu;
        private bool[] isChecked;
        private List<int> duongDi ;
        public int SoDinh { get; set; }
        public int DinhBatDau { get; set; }
        public int[,] DoThiLuu { get; set; }
        public bool[] IsChecked { get; set; }
        public List<int> DuongDi { get; set; }

        public DoThi()
        {

        }
        private void NhapFile(string viTriFile)
        {
            StreamReader sr = new StreamReader(viTriFile);
            string[] mangDoc = sr.ReadLine().Split(' ');
            SoDinh = int.Parse(mangDoc[0]);
            DinhBatDau = int.Parse(mangDoc[1]);
            DoThiLuu = new int[SoDinh, SoDinh];
            IsChecked = new bool[SoDinh];
            IsChecked[DinhBatDau] = true;
            DuongDi = new List<int>();
            DuongDi.Add(DinhBatDau);
            for (int i = 0; i < SoDinh; i++)
            {
                mangDoc = sr.ReadLine().Split(' ');
                for (int j = 0; j < SoDinh; j++)
                {
                    DoThiLuu[i, j] = int.Parse(mangDoc[j]);
                }
            }
            sr.Close();
        }
        private void XuLi()
        {
            for (int i = 0; i < SoDinh; i++)
            {
                int min = int.MaxValue;
                int viTriNhoNhat = -1;
                for (int j = 0; j < SoDinh; j++)
                {
                    if (DoThiLuu[DinhBatDau, j] != 0 && DoThiLuu[DinhBatDau, j] < min && !IsChecked[j])
                    {
                        min = DoThiLuu[DinhBatDau, j];
                        viTriNhoNhat = j;
                    }
                }
                if (viTriNhoNhat!=-1)
                {
                    DuongDi.Add(viTriNhoNhat);
                    DinhBatDau = viTriNhoNhat;
                    IsChecked[viTriNhoNhat] = true;
                }
                
            }
          
        }
        private void XuatFile(string viTriXuat)
        {
            StreamWriter sw = new StreamWriter(viTriXuat);
            sw.WriteLine("Duong di theo thu tu:");
            foreach (var item in DuongDi)
            {
                sw.Write("{0} -> ", item);
            }
            sw.Close();
        }
        public void LamViec(string viTriNhap, string viTriXuat)
        {
            NhapFile(viTriNhap);
            XuLi();
            XuatFile(viTriXuat);
        }
    }
    public class ThucThi
    {
        public ThucThi()
        {
            DoThi a = new DoThi();
            a.LamViec(@"C:\Users\thuyl\OneDrive\Education\Nam III\Tri tue nhan tao\Bai tap thuc hanh\ConsoleApp1\Input.txt", @"C:\Users\thuyl\OneDrive\Education\Nam III\Tri tue nhan tao\Bai tap thuc hanh\ConsoleApp1\Output.txt");
        }

    }
}
