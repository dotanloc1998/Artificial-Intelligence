using System;
using System.Collections.Generic;
using System.IO;

namespace DSA
{
    public class DoThiAKT
    {
        private int[,] doThi;
        private List<int> h;
        private int diemDau;
        private int diemCuoi;
        private List<int> open;
        private List<int> closed;
        public DoThiAKT()
        {

        }
        public void NhapFile(string duongDan)
        {
            StreamReader sr = new StreamReader(duongDan);
            string[] dong = sr.ReadLine().Split(' ');
            doThi = new int[int.Parse(dong[0]), int.Parse(dong[0])];
            for (int i = 0; i < doThi.GetLength(0); i++)
            {
                dong = sr.ReadLine().Split(' ');
                for (int j = 0; j < doThi.GetLength(1); j++)
                {
                    doThi[i, j] = int.Parse(dong[j]);
                }
            }
            h = new List<int>();
            dong = sr.ReadLine().Split(' ');
            for (int i = 0; i < doThi.GetLength(0); i++)
            {
                h.Add(int.Parse(dong[i]));
            }
            dong = sr.ReadLine().Split(' ');
            diemDau = int.Parse(dong[0]);
            diemCuoi = int.Parse(dong[1]);
            sr.Close();
        }
        private int TinhF(int dinhTmax, int dinhTk, int gTmax)
        {
            int gTk = gTmax + doThi[dinhTmax, dinhTk];
            int hTk = h[dinhTk];
            int fTk = gTk + hTk;
            return fTk;
        }
        public void TimDuongDiToiUu()
        {
            open = new List<int>();
            closed = new List<int>();
            List<int> f = new List<int>();
            open.Add(diemDau);
            int g = 0;
            while (open.Count != 0)
            {
                if (g == 0)
                {
                    int tMax = open[0];
                    open.RemoveAt(0);
                    closed.Add(tMax);
                    for (int i = 0; i < doThi.GetLength(0); i++)
                    {
                        if (doThi[tMax, i] != 0 && doThi[tMax, i] != -1)
                        {
                            open.Add(i);
                        }
                    }
                    if (tMax == diemCuoi)
                    {
                        break;
                    }
                }
                else
                {
                    int min = int.MaxValue;
                    int tMax = 0;
                    for (int i = 0; i < open.Count; i++)
                    {
                        if (TinhF(closed[closed.Count - 1], open[i], g) < min)
                        {
                            min = TinhF(closed[closed.Count - 1], open[i], g);
                            tMax = open[i];
                        }
                    }
                    closed.Add(tMax);
                    open.Clear();
                    if (tMax == diemCuoi)
                    {
                        break;
                    }
                    for (int i = 0; i < doThi.GetLength(0); i++)
                    {
                        if (doThi[tMax, i] != 0 && doThi[tMax, i] != -1)
                        {
                            open.Add(i);
                        }
                    }
                }
                g++;
            }
        }
        public void InFile(string duongDan)
        {
            StreamWriter sw = new StreamWriter(duongDan);
            foreach (var item in closed)
            {
                sw.Write("{0} -> ", item);
            }
            sw.Close();
        }
    }
    public class ThucThi
    {
        public ThucThi()
        {
            DoThiAKT a = new DoThiAKT();
            string duongDan = @"C:\Users\thuyl\OneDrive\Education\Nam III\Tri tue nhan tao\Bai tap thuc hanh\ConsoleApp6\Input.txt";
            string duongDanOut = @"C:\Users\thuyl\OneDrive\Education\Nam III\Tri tue nhan tao\Bai tap thuc hanh\ConsoleApp6\Output.txt";
            a.NhapFile(duongDan);
            a.TimDuongDiToiUu();
            a.InFile(duongDanOut);
        }

    }
}