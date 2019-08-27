using System;
using System.IO;

namespace DSA
{
    public class BanCo
    {
        public int[,] banCo;
        private int kichThuoc;
        public int[,] BanCoNho { get; set; }
        public BanCo()
        {
            banCo = new int[8, 8];
        }
        public BanCo(int kichThuoc)
        {
            banCo = new int[kichThuoc, kichThuoc];
        }
        public void SaoChepBanCo(ref BanCo tam)
        {
            for (int i = 0; i < banCo.GetLength(0); i++)
            {
                for (int j = 0; j < banCo.GetLength(1); j++)
                {
                    tam.banCo[i, j] = banCo[i, j];
                }
            }
        }
        private int DemOTrong()
        {
            int dem = 0;
            for (int i = 0; i < banCo.GetLength(0); i++)
            {
                for (int j = 0; j < banCo.GetLength(1); j++)
                {
                    if (banCo[i, j] == 0)
                    {
                        dem++;
                    }
                }
            }
            return dem;
        }
        public void DatHau(int d, int c, int h)
        {
            banCo[d, c] = h;
        }
        public void CamHau(int d, int c)
        {
            //Cam cheo trai (trai sang phai)
            int i = d, j = c;
            while (i < banCo.GetLength(0) && j < banCo.GetLength(0))
            {
                if (banCo[i, j] > 0)
                {
                    i++;
                    j++;
                }
                else
                {
                    banCo[i, j] = -1;
                    i++;
                    j++;
                }
            }
            i = d;
            j = c;
            while (i >= 0 && j >= 0)
            {
                if (banCo[i, j] > 0)
                {
                    i--;
                    j--;
                }
                else
                {
                    banCo[i, j] = -1;
                    i--;
                    j--;
                }
            }

            //Cam cheo phai (phai sang trai)
            i = d;
            j = c;
            while (j >= 0 && i < banCo.GetLength(0))
            {
                if (banCo[i, j] > 0)
                {
                    i++;
                    j--;
                }
                else
                {
                    banCo[i, j] = -1;
                    i++;
                    j--;
                }
            }
            i = d;
            j = c;
            while (j < banCo.GetLength(0) && i >= 0)
            {
                if (banCo[i, j] > 0)
                {
                    i--;
                    j++;
                }
                else
                {
                    banCo[i, j] = -1;
                    i--;
                    j++;
                }
            }

            //Cam hang ngang
            i = d;
            j = c;
            while (j < banCo.GetLength(0))
            {
                if (banCo[i, j] > 0)
                {
                    j++;
                }
                else
                {
                    banCo[i, j] = -1;
                    j++;
                }
            }
            i = d;
            j = c;
            while (j >= 0)
            {
                if (banCo[i, j] > 0)
                {
                    j--;
                }
                else
                {
                    banCo[i, j] = -1;
                    j--;
                }
            }

            //Cam hang doc
            i = d;
            j = c;
            while (i < banCo.GetLength(0))
            {
                if (banCo[i, j] > 0)
                {
                    i++;
                }
                else
                {
                    banCo[i, j] = -1;
                    i++;
                }
            }
            i = d;
            j = c;
            while (i >= 0)
            {
                if (banCo[i, j] > 0)
                {
                    i--;
                }
                else
                {
                    banCo[i, j] = -1;
                    i--;
                }
            }
        }
        public int TimCotCoOTrongMax(int dong, int cot, int h)
        {
            DatHau(dong, cot, h);
            CamHau(dong, cot);
            return DemOTrong();
        }
    }
    public class GiaiToanDatHau
    {
        private BanCo a;
        private int d;
        private int c;
        private int h = 1;
        public GiaiToanDatHau(int dong, int cot)
        {
            d = dong;
            c = cot;
        }
        public void XuLy()
        {
            a = new BanCo();
            a.DatHau(d, c, h);
            a.CamHau(d, c);
            h++;
            for (int i = 0; i < a.banCo.GetLength(0); i++)
            {
                int max = int.MinValue;
                int viTri = -1;
                for (int j = 0; j < a.banCo.GetLength(1); j++)
                {
                    //Tao ra 1 ban co de thu
                    BanCo tam = new BanCo();
                    a.SaoChepBanCo(ref tam);
                    //Dat thu quan hau
                    if (tam.banCo[i, j] == -1 || tam.banCo[i, j] > 0)
                    {
                        continue;
                    }
                    else
                    {
                        tam.DatHau(i, j, h);
                        tam.CamHau(i, j);
                        if (tam.TimCotCoOTrongMax(i, j, h) > max)
                        {
                            max = tam.TimCotCoOTrongMax(i, j, h);
                            viTri = j;
                        }
                    }
                }
                if (viTri != -1)
                {
                    a.DatHau(i, viTri, h);
                    a.CamHau(i, viTri);
                    h++;
                }
            }
        }
        public void InKetQua(string path)
        {
            StreamWriter sw = new StreamWriter(path);
            for (int i = 0; i < a.banCo.GetLength(0); i++)
            {
                for (int j = 0; j < a.banCo.GetLength(1); j++)
                {
                    sw.Write("{0} ", a.banCo[i, j]);
                }
                sw.WriteLine();
            }
            sw.Close();
        }
    }

    public class Buoi3
    {
        public Buoi3()
        {
            GiaiToanDatHau a = new GiaiToanDatHau(1, 5);
            a.XuLy();
            string outPut = @"C:\Users\thuyl\OneDrive\Education\Nam III\Tri tue nhan tao\Bai tap thuc hanh\ConsoleApp4\Output.txt";
            a.InKetQua(outPut);
        }
    }

}