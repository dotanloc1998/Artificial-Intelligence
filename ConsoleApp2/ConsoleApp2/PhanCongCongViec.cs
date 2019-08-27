using System;
using System.Collections.Generic;
using System.IO;

namespace DSA
{
    public class CongViec
    {
        private string tenCongViec;
        private int thoiGianThucHien;
        public string TenCongViec { get; set; }
        public int ThoiGianThucHien { get; set; }

        public CongViec(string ten, int thoiGian)
        {
            TenCongViec = ten;
            ThoiGianThucHien = thoiGian;
        }

    }

    public class MayMoc
    {
        private string tenMay;
        private List<CongViec> cacCongViecs;
        private int tongThoiGian;
        public string TenMay { get; set; }
        public List<CongViec> CacCongViecs { get; set; }
        public int TongThoiGian { get; set; }
        public MayMoc(string tenMay)
        {
            TenMay = tenMay;
            CacCongViecs = new List<CongViec>();
        }

        public void ThemCongViec(CongViec a)
        {
            CacCongViecs.Add(a);
            TongThoiGian += a.ThoiGianThucHien;
        }
    }

    public class PhanCong
    {
        private MayMoc[] mays;
        private CongViec[] congViecs;
        public MayMoc[] Mays { get; set; }
        public CongViec[] CongViecs { get; set; }

        public PhanCong()
        {

        }
        public void DocFile(string duongDan)
        {
            StreamReader sr = new StreamReader(duongDan);
            int soLuong = int.Parse(sr.ReadLine());
            Mays = new MayMoc[soLuong];
            for (int i = 0; i < soLuong; i++)
            {
                Mays[i] = new MayMoc(sr.ReadLine());
            }
            soLuong = int.Parse(sr.ReadLine());
            CongViecs = new CongViec[soLuong];
            for (int i = 0; i < soLuong; i++)
            {
                string[] dong = sr.ReadLine().Split(' ');
                CongViecs[i] = new CongViec(dong[0], int.Parse(dong[1]));
            }
            sr.Close();
        }

        public void XuLiPhanCong()
        {
            //Sap xep cong viec theo thu tu giam dan ve thoi gian

            for (int i = 0; i < CongViecs.Length - 1; i++)
            {
                for (int j = i + 1; j < CongViecs.Length; j++)
                {
                    if (CongViecs[i].ThoiGianThucHien < CongViecs[j].ThoiGianThucHien)
                    {
                        CongViec tam = CongViecs[i];
                        CongViecs[i] = CongViecs[j];
                        CongViecs[j] = tam;
                    }
                }
            }

            int thuTuCongViec = 0;
            for (int i = 0; i < Mays.Length; i++)
            {
                if (Mays[i].CacCongViecs.Count == 0)
                {
                    Mays[i].ThemCongViec(CongViecs[thuTuCongViec]);
                    thuTuCongViec++;
                }
            }
            //Tim may nao co tong thoi gian lam viec it nhat roi quang cong viec vao
            for (; thuTuCongViec < CongViecs.Length; thuTuCongViec++)
            {
                int viTriMayCoCongViecItNhat = 0;
                int min = Mays[0].TongThoiGian;
                for (int i = 0; i < Mays.Length; i++)
                {
                    if (Mays[i].TongThoiGian < min)
                    {
                        min = Mays[i].TongThoiGian;
                        viTriMayCoCongViecItNhat = i;
                    }
                }
                Mays[viTriMayCoCongViecItNhat].ThemCongViec(CongViecs[thuTuCongViec]);
            }
        }

        public void InFile(string duongDan)
        {
            StreamWriter sw = new StreamWriter(duongDan);
            for (int i = 0; i < Mays.Length; i++)
            {
                sw.WriteLine(Mays[i].TenMay + " " + Mays[i].TongThoiGian);
                foreach (var VARIABLE in Mays[i].CacCongViecs)
                {
                    sw.WriteLine(" {0} {1}", VARIABLE.TenCongViec, VARIABLE.ThoiGianThucHien);
                }
            }
            sw.Close();
        }
    }

    public class ThucThi
    {
        public ThucThi()
        {
            string docFile = @"C:\Users\thuyl\OneDrive\Education\Nam III\Tri tue nhan tao\Bai tap thuc hanh\ConsoleApp2\Input.txt";
            string inFile = @"C:\Users\thuyl\OneDrive\Education\Nam III\Tri tue nhan tao\Bai tap thuc hanh\ConsoleApp2\Output.txt";
            PhanCong a = new PhanCong();
            a.DocFile(docFile);
            a.XuLiPhanCong();
            a.InFile(inFile);
        }
    }
}