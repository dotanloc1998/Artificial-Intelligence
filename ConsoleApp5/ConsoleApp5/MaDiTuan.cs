using System;
using System.IO;

namespace DSA
{
    public class BanCo
    {
        public int[,] banCo;
        public BanCo()
        {
            banCo = new int[8, 8];
        }
        public BanCo(int kichThuoc)
        {
            banCo = new int[kichThuoc, kichThuoc];
        }
    }
    public class MaDiTuan
    {
        private BanCo a;
        private int kichThuoc;
        private int dongDatMa;
        private int cotDatMa;
        public MaDiTuan(int dong, int cot)
        {
            kichThuoc = 8;
            dongDatMa = dong;
            cotDatMa = cot;
            a = new BanCo(kichThuoc);
        }
        public MaDiTuan(int kichThuoc, int dong, int cot)
        {
            this.kichThuoc = kichThuoc;
            dongDatMa = dong;
            cotDatMa = cot;
            a = new BanCo(this.kichThuoc);
        }
        public void DiTuan()
        {
            //Đầu tiên là vị trí đặt mã của người dùng
            a.banCo[dongDatMa, cotDatMa] = 1;
            int i = 2;
            //8 hướng đi của quân mã
            int[,] buocDi = { { -2, -1 }, { -2, 1 }, { -1, -2 }, { -1, 2 }, { 1, -2 }, { 1, 2 }, { 2, -1 }, { 2, 1 } };
            //Lập đến hết số ô của bàn cờ
            while (i <= kichThuoc * kichThuoc)
            {
                //Thuật toán là chọn ô tiếp theo mà ô đó có số ô có thể đi tiếp là nhỏ nhất 
                int demLuotDi = 0;
                int min = int.MaxValue;
                int nhoDong = -1, nhoCot = -1;
                //Lập hết số hướng đi
                for (int j = 0; j < 8; j++)
                {
                    //Nếu như ô tiếp theo nằm ngoài bàn cờ thì loại
                    if ((dongDatMa + buocDi[j, 0] >= 0 && dongDatMa + buocDi[j, 0] < kichThuoc) && (cotDatMa + buocDi[j, 1] >= 0 && cotDatMa + buocDi[j, 1] < kichThuoc))
                    {
                        int viTriDatMaDong = dongDatMa + buocDi[j, 0];
                        int viTriDatMaCot = cotDatMa + buocDi[j, 1];
                        //Vị trí đó quân mã phải chưa đi qua
                        if (a.banCo[viTriDatMaDong, viTriDatMaCot] == 0)
                        {
                            demLuotDi = 0;
                            for (int k = 0; k < 8; k++)
                            {
                                //Đếm những ô tiếp theo mà ô đó có thể đi trừ những ô quân mã đã đi qua
                                if ((viTriDatMaDong + buocDi[k, 0] >= 0 && viTriDatMaDong + buocDi[k, 0] < kichThuoc) && (viTriDatMaCot + buocDi[k, 1] >= 0 
                                && viTriDatMaCot + buocDi[k, 1] < kichThuoc) && a.banCo[viTriDatMaDong + buocDi[k, 0], viTriDatMaCot + buocDi[k, 1]] == 0)
                                {
                                    demLuotDi++;
                                }
                            }
                            //Như thuật toán nêu trên chọn ô tiếp theo mà ô đó có số ô có thể đi tiếp là nhỏ nhất
                            if (demLuotDi < min)
                            {
                                min = demLuotDi;
                                nhoDong = viTriDatMaDong;
                                nhoCot = viTriDatMaCot;
                            }
                        }
                    }

                }
                //Đặt quân mã vào vị trí đã tìm được
                if (nhoDong != -1 && nhoCot != -1)
                {
                    dongDatMa = nhoDong;
                    cotDatMa = nhoCot;
                    a.banCo[dongDatMa, cotDatMa] = i;
                }
                i++;
            }
        }
        public void InBanCo(string duongDan)
        {
            StreamWriter sw = new StreamWriter(duongDan);
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

    public class Buoi5
    {
        public Buoi5()
        {
            MaDiTuan a = new MaDiTuan(0, 5);
            a.DiTuan();
            string output = @"C:\Users\thuyl\OneDrive\Education\Nam III\Tri tue nhan tao\Bai tap thuc hanh\ConsoleApp5\Output.txt";
            a.InBanCo(output);
        }
    }
}