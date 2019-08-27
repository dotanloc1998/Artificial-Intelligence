using System;
using System.Collections.Generic;
using System.IO;

namespace DSA
{
    public class Dinh
    {
        public int tenDinh;
        public int bac;
        public int mauTo;
        public List<int> dsSachMauCamTo;
        public Dinh(int tenDinh)
        {
            this.tenDinh = tenDinh;
            bac = 0;
            mauTo = 0;
            dsSachMauCamTo = new List<int>();
        }
    }
    public class ToMauDoThi
    {
        private Dinh[] dsDinh;
        private int[,] maTranDinh;
        public ToMauDoThi()
        {

        }
        public void DocFile(string duongDan)
        {
            StreamReader sr = new StreamReader(duongDan);
            string[] dong = sr.ReadLine().Split(' ');
            dsDinh = new Dinh[int.Parse(dong[0])];
            maTranDinh = new int[int.Parse(dong[0]), int.Parse(dong[0])];
            for (int i = 0; i < maTranDinh.GetLength(0); i++)
            {
                dong = sr.ReadLine().Split(' ');
                for (int j = 0; j < maTranDinh.GetLength(1); j++)
                {
                    maTranDinh[i, j] = int.Parse(dong[j]);
                }
            }
            for (int i = 0; i < dsDinh.Length; i++)
            {
                Dinh nhap = new Dinh(i);
                int bac = 0;
                for (int j = 0; j < dsDinh.Length; j++)
                {
                    bac += maTranDinh[i, j];
                }
                nhap.bac = bac;
                dsDinh[i] = nhap;
            }
            sr.Close();
        }
        public void XuLy()
        {
            List<int> danhSachMau = new List<int>();
            danhSachMau.Add(1);
            for (int i = 0; i < dsDinh.Length; i++)
            {

                //Chon dinh co bac cao nhat
                int max = int.MinValue;
                int viTri = -1;
                for (int j = 0; j < dsDinh.Length; j++)
                {
                    if (dsDinh[i].bac > max)
                    {
                        max = dsDinh[i].bac;
                        viTri = i;
                    }
                }
                //Chon mau to cho dinh vua tim duoc
                foreach (var mauDanhSachMau in danhSachMau)
                {
                    if (dsDinh[viTri].dsSachMauCamTo.Count == 0)
                    {
                        dsDinh[viTri].mauTo = mauDanhSachMau;
                        break;
                    }
                    else
                    {
                        bool chuaCoMauDuocChon = true;
                        foreach (var mauDanhSachCam in dsDinh[viTri].dsSachMauCamTo)
                        {
                            if (mauDanhSachCam == mauDanhSachMau)
                            {
                                chuaCoMauDuocChon = false;
                            }
                        }
                        if (chuaCoMauDuocChon)
                        {
                            dsDinh[viTri].mauTo = mauDanhSachMau;
                            break;
                        }
                    }
                }
                //TH chua co mau nao thoa man
                if (dsDinh[viTri].mauTo == 0)
                {
                    dsDinh[viTri].mauTo = (danhSachMau[danhSachMau.Count - 1] + 1);
                    danhSachMau.Add(danhSachMau[danhSachMau.Count - 1] + 1);
                }

                //Cam cac dinh ke co cung mau va ha bac cac dinh ke
                for (int j = 0; j < dsDinh.Length; j++)
                {
                    if (maTranDinh[viTri, j] == 1)
                    {
                        dsDinh[j].bac = dsDinh[j].bac--;
                        dsDinh[j].dsSachMauCamTo.Add(dsDinh[viTri].mauTo);
                    }
                }

                //Bac cua dinh do thanh -1
                dsDinh[viTri].bac = -1;
            }
        }
        public void XuatFile(string duongDan)
        {
            StreamWriter sw = new StreamWriter(duongDan);
            for (int i = 0; i < dsDinh.Length; i++)
            {
                sw.WriteLine("Dinh {0} duoc to mau {1}", i + 1, dsDinh[i].mauTo);
            }
            sw.Close();
        }
    }
    public class ThucThi
    {
        public ThucThi()
        {
            ToMauDoThi a = new ToMauDoThi();
            string input = @"C:\Users\thuyl\OneDrive\Education\Nam III\Tri tue nhan tao\Bai tap thuc hanh\ConsoleApp8\Input.txt";
            string output = @"C:\Users\thuyl\OneDrive\Education\Nam III\Tri tue nhan tao\Bai tap thuc hanh\ConsoleApp8\Output.txt";
            a.DocFile(input);
            a.XuLy();
            a.XuatFile(output);
        }
    }
}