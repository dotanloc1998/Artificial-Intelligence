using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace DSA
{
    public class Puzzel
    {
        private int[,] PuzzelArray { get; set; }
        private int[,] PerfectPuzzel { get; set; }
        private int kichThuoc { get; set; }

        private List<string> ketQua = new List<string>();
        private void Up(int soCanLen)
        {
            ketQua.Add(soCanLen + " Up");
        }
        private void Down(int soCanXuong)
        {
            ketQua.Add(soCanXuong + " Down");
        }
        private void Left(int soCanTrai)
        {
            ketQua.Add(soCanTrai + " Left");
        }
        private void Right(int soCanPhai)
        {
            ketQua.Add(soCanPhai + " Right");
        }
        private bool DaHoanThanh()
        {

            for (int i = 0; i < kichThuoc; i++)
            {
                for (int j = 0; j < kichThuoc; j++)
                {
                    if (PerfectPuzzel[i, j] != PuzzelArray[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private int[] viTriSoKhong { get; set; }
        /*
         private bool TimCapNguoc(int kichThuoc)
        {
            if (kichThuoc % 2 == 0)
            {
                int viTriSoKhong = -1;
                int soCapNguoc = 0;
                for (int i = 0; i < PuzzelArray.GetLength(0); i++)
                {
                    for (int j = 0; j < PuzzelArray.GetLength(1); j++)
                    {
                        if (j == PuzzelArray.GetLength(1) - 1)
                        {
                            for (int k = i + 1; k < PuzzelArray.GetLength(0); k++)
                            {
                                for (int l = 0; l < PuzzelArray.GetLength(1); l++)
                                {
                                    if (PuzzelArray[i, j] > PuzzelArray[k, l] && PuzzelArray[i, j] != 0 && PuzzelArray[k, l] != 0)
                                    {
                                        soCapNguoc++;
                                    }
                                    else if (PuzzelArray[i, j] == 0)
                                    {
                                        viTriSoKhong = i;
                                    }
                                    else if (PuzzelArray[k, l] != 0)
                                    {
                                        viTriSoKhong = k;
                                    }
                                }
                            }
                        }
                        else if (i == PuzzelArray.GetLength(0) && j == PuzzelArray.GetLength(1))
                        {
                            break;
                        }
                        else
                        {
                            for (int k = i; k < PuzzelArray.GetLength(0); k++)
                            {
                                for (int l = j++; l < PuzzelArray.GetLength(1); l++)
                                {
                                    if (PuzzelArray[i, j] > PuzzelArray[k, l] && PuzzelArray[i, j] != 0 && PuzzelArray[k, l] != 0)
                                    {
                                        soCapNguoc++;
                                    }
                                    else if (PuzzelArray[i, j] == 0)
                                    {
                                        viTriSoKhong = i;
                                    }
                                    else if (PuzzelArray[k, l] != 0)
                                    {
                                        viTriSoKhong = k;
                                    }
                                }
                            }
                        }
                    }
                }
                if (soCapNguoc % 2 + viTriSoKhong == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                int soCapNguoc = 0;
                for (int i = 0; i < PuzzelArray.GetLength(0); i++)
                {
                    for (int j = 0; j < PuzzelArray.GetLength(1); j++)
                    {
                        if (j == PuzzelArray.GetLength(1) - 1)
                        {
                            for (int k = i + 1; k < PuzzelArray.GetLength(0); k++)
                            {
                                for (int l = 0; l < PuzzelArray.GetLength(1); l++)
                                {
                                    if (PuzzelArray[i, j] > PuzzelArray[k, l] && PuzzelArray[i, j] != 0 && PuzzelArray[k, l] != 0)
                                    {
                                        soCapNguoc++;
                                    }
                                }
                            }
                        }
                        else if (i == PuzzelArray.GetLength(0) && j == PuzzelArray.GetLength(1))
                        {
                            break;
                        }
                        else
                        {
                            for (int k = i; k < PuzzelArray.GetLength(0); k++)
                            {
                                for (int l = j++; l < PuzzelArray.GetLength(1); l++)
                                {
                                    if (PuzzelArray[i, j] > PuzzelArray[k, l] && PuzzelArray[i, j] != 0 && PuzzelArray[k, l] != 0)
                                    {
                                        soCapNguoc++;
                                    }

                                }
                            }
                        }
                    }
                }
                if (soCapNguoc % 2 == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        */
        private bool TimCapNguoc()
        {
            int[] mang1Chieu = new int[kichThuoc * kichThuoc - 1];
            int k = 0;
            for (int i = 0; i < PuzzelArray.GetLength(0); i++)
            {
                
                for (int j = 0; j < PuzzelArray.GetLength(1);j++)
                {
                    if (PuzzelArray[i, j] != 0)
                    {
                        mang1Chieu[k] = PuzzelArray[i, j];
                        k++;
                    }
                }
            }
            int soCapNguoc = 0;

            if (kichThuoc % 2 == 0)
            {
                bool chuaKiemThaySoKhong = true;
                int viTri = -1;
                for (int i = 0; i < kichThuoc && chuaKiemThaySoKhong; i++)
                {
                    for (int j = 0; j < kichThuoc; j++)
                    {
                        if (PuzzelArray[i, j] == 0)
                        {
                            viTri = i;
                            chuaKiemThaySoKhong = false;
                            break;
                        }
                    }
                }
                for (int i = 0; i < mang1Chieu.Length - 1; i++)
                {
                    for (int j = i + 1; j < mang1Chieu.Length; j++)
                    {
                        if (mang1Chieu[i] > mang1Chieu[j])
                        {
                            soCapNguoc++;
                        }
                    }
                }
                if ((soCapNguoc + viTri) % 2 == 0)
                {
                    return true;
                    //Khong giai duoc
                }
                else
                {
                    return false;
                    //Giai duoc
                }
            }
            else
            {
                for (int i = 0; i < mang1Chieu.Length - 1; i++)
                {
                    for (int j = i + 1; j < mang1Chieu.Length; j++)
                    {
                        if (mang1Chieu[i] > mang1Chieu[j])
                        {
                            soCapNguoc++;
                        }
                    }
                }
                if (soCapNguoc % 2 == 0)
                {
                    return false;
                    //Giai duoc
                }
                else
                {
                    return true;
                    //Khong giai duoc
                }
            }
        }

        public void DocFile(string path)
        {
            StreamReader sr = new StreamReader(path);
            string[] dong = sr.ReadLine().Split(' ');
            kichThuoc = int.Parse(dong[0]);
            PuzzelArray = new int[kichThuoc, kichThuoc];
            PerfectPuzzel = new int[kichThuoc, kichThuoc];
            for (int i = 0; i < PuzzelArray.GetLength(0); i++)
            {
                dong = sr.ReadLine().Split(' ');
                for (int j = 0; j < PuzzelArray.GetLength(1); j++)
                {
                    PuzzelArray[i, j] = int.Parse(dong[j]);
                }
            }

            int dem = 0;
            for (int i = 0; i < PerfectPuzzel.GetLength(0); i++)
            {
                for (int j = 0; j < PerfectPuzzel.GetLength(1); j++)
                {
                    dem++;
                    PerfectPuzzel[i, j] = dem;
                }
            }
            PerfectPuzzel[kichThuoc - 1, kichThuoc - 1] = 0;
            sr.Close();
        }

        //Chúng ta cần nhập vào mảng vì không biết số đó nằm ở vị trí nào trong mảng
        private void TimKiemViTriSai(int soCanTim, ref int viTriDong, ref int viTriCot, int[,] mang)
        {
            for (int i = 0; i < mang.GetLength(0); i++)
            {
                for (int j = 0; j < mang.GetLength(1); j++)
                {
                    if (mang[i, j] == soCanTim)
                    {
                        viTriDong = i;
                        viTriCot = j;
                        return;
                    }
                }
            }
        }

        //Vì ở mảng PerfectPuzzel các số nằm ở vị trí đúng nên ta dùng công thức để tìm
        private void TimKiemViTriDung(int soCanTim, ref int viTriDong, ref int viTriCot)
        {
            viTriCot = (soCanTim - 1) % kichThuoc;
            viTriDong = (soCanTim - 1) / kichThuoc;
        }

        //Tính Mahattan
        private void TinhDoSaiLech(int viTri, ref int[] tongCuaCacViTri)
        {
            int sum = 0;
            int dongDung = -1, cotDung = -1, dongSai = -1, cotSai = -1;
            for (int i = 1; i <= PuzzelArray.GetLength(0) * PuzzelArray.GetLength(0) - 1; i++)
            {
                TimKiemViTriSai(i, ref dongSai, ref cotSai, PuzzelArray);
                TimKiemViTriDung(i, ref dongDung, ref cotDung);
                sum += Convert.ToInt32(Math.Abs(dongDung - dongSai) + Math.Abs(cotDung - cotSai));
            }
            tongCuaCacViTri[viTri] = sum;
        }

        /*private void TinhDoSaiLechGoc(ref int saiLechGoc)
        {
            int sum = 0;
            double dongDung = -1, cotDung = -1, dongSai = -1, cotSai = -1;
            for (int i = 1; i <= PuzzelArray.GetLength(0) * PuzzelArray.GetLength(0) - 1; i++)
            {
                TimKiem(i, ref dongSai, ref cotSai, PuzzelArray);
                TimKiem(i, ref dongDung, ref cotDung, PerfectPuzzel);
                sum += Convert.ToInt32(Math.Abs(dongDung - dongSai) + Math.Abs(cotDung - cotSai));
            }
            saiLechGoc = sum;
        }*/
        public void GiaiRoiInKetQua(string path)
        {

            if (!TimCapNguoc())
            {
                //g là tầng của cây
                int g = 0;
                //Tránh trường hợp di chuyển mãi 1 ô 
                int viTriVuaChon = -1;
                while (!DaHoanThanh())
                {
                    viTriSoKhong = new int[2];
                    //Kiem So 0
                    bool chuaKiemThaySoKhong = true;
                    for (int i = 0; i < kichThuoc && chuaKiemThaySoKhong; i++)
                    {
                        for (int j = 0; j < kichThuoc; j++)
                        {
                            if (PuzzelArray[i, j] == 0)
                            {
                                viTriSoKhong[0] = i;
                                viTriSoKhong[1] = j;
                                chuaKiemThaySoKhong = false;
                                break;
                            }
                        }
                    }

                    int[,] viTriXungQuanh = new int[4, 2];
                    //Theo thu tu la
                    /*
                     Tren dong|cot
                     Duoi dong|cot
                     Trai dong|cot
                     Phai dong|cot                     
                     */
                    for (int i = 0; i < viTriXungQuanh.GetLength(0); i++)
                    {
                        for (int j = 0; j < viTriXungQuanh.GetLength(1); j++)
                        {
                            viTriXungQuanh[i, j] = -1;
                        }
                    }

                    //Trên
                    int check = viTriSoKhong[0] - 1;
                    if (check >= 0)
                    {
                        viTriXungQuanh[0, 0] = viTriSoKhong[0] - 1;
                        viTriXungQuanh[0, 1] = viTriSoKhong[1];
                    }
                    //Dưới
                    check = viTriSoKhong[0] + 1;
                    if (check <= PuzzelArray.GetLength(0) - 1)
                    {
                        viTriXungQuanh[1, 0] = viTriSoKhong[0] + 1;
                        viTriXungQuanh[1, 1] = viTriSoKhong[1];
                    }
                    //Trái
                    check = viTriSoKhong[1] - 1;
                    if (check >= 0)
                    {
                        viTriXungQuanh[2, 0] = viTriSoKhong[0];
                        viTriXungQuanh[2, 1] = viTriSoKhong[1] - 1;
                    }
                    //Phải
                    check = viTriSoKhong[1] + 1;
                    if (check <= PuzzelArray.GetLength(1) - 1)
                    {
                        viTriXungQuanh[3, 0] = viTriSoKhong[0];
                        viTriXungQuanh[3, 1] = viTriSoKhong[1] + 1;
                    }

                    //Giai thuat Heuristic dung thuat toan Manhattan
                    int[] tongCuaCacViTri = { -1, -1, -1, -1 }; // Lan luot la Tren Duoi Trai Phai
                                                                //Gia Dinh Tren Duoi Trai Phai
                                                                // Ben tren thi chuyen xuong roi tinh doSaiLechCuaMoiSo roi tinh tong cua mang doSaiLechCuaMoiSo roi gan vao tongCuaCacViTri[0] va tuong tu
                                                                // Tim do sai lech cua ma tran
                                                                //int saiLech = 0;
                                                                //TinhDoSaiLechGoc(ref saiLech);
                                                                //Sau do tinh do sai lech khi di chuyen cac mieng ghep xung quanh
                    if (!(viTriXungQuanh[0, 0] == -1 && viTriXungQuanh[0, 1] == -1))
                    {
                        //Chuyen ben tren xuong
                        PuzzelArray[viTriSoKhong[0], viTriSoKhong[1]] = PuzzelArray[viTriXungQuanh[0, 0], viTriXungQuanh[0, 1]];
                        PuzzelArray[viTriXungQuanh[0, 0], viTriXungQuanh[0, 1]] = 0;
                        //Tinh do sai lech cua TH nay
                        TinhDoSaiLech(0, ref tongCuaCacViTri);
                        //Gan lai TH cu
                        PuzzelArray[viTriXungQuanh[0, 0], viTriXungQuanh[0, 1]] = PuzzelArray[viTriSoKhong[0], viTriSoKhong[1]];
                        PuzzelArray[viTriSoKhong[0], viTriSoKhong[1]] = 0;
                    }

                    if (!(viTriXungQuanh[1, 0] == -1 && viTriXungQuanh[1, 1] == -1))
                    {
                        //Chuyen ben duoi len
                        PuzzelArray[viTriSoKhong[0], viTriSoKhong[1]] = PuzzelArray[viTriXungQuanh[1, 0], viTriXungQuanh[1, 1]];
                        PuzzelArray[viTriXungQuanh[1, 0], viTriXungQuanh[1, 1]] = 0;
                        //Tinh do sai lech cua TH nay
                        TinhDoSaiLech(1, ref tongCuaCacViTri);
                        //Gan lai TH cu
                        PuzzelArray[viTriXungQuanh[1, 0], viTriXungQuanh[1, 1]] = PuzzelArray[viTriSoKhong[0], viTriSoKhong[1]];
                        PuzzelArray[viTriSoKhong[0], viTriSoKhong[1]] = 0;
                    }

                    if (!(viTriXungQuanh[2, 0] == -1 && viTriXungQuanh[2, 1] == -1))
                    {
                        //Chuyen ben trai qua
                        PuzzelArray[viTriSoKhong[0], viTriSoKhong[1]] = PuzzelArray[viTriXungQuanh[2, 0], viTriXungQuanh[2, 1]];
                        PuzzelArray[viTriXungQuanh[2, 0], viTriXungQuanh[2, 1]] = 0;
                        //Tinh do sai lech cua TH nay
                        TinhDoSaiLech(2, ref tongCuaCacViTri);
                        //Gan lai TH cu
                        PuzzelArray[viTriXungQuanh[2, 0], viTriXungQuanh[2, 1]] = PuzzelArray[viTriSoKhong[0], viTriSoKhong[1]];
                        PuzzelArray[viTriSoKhong[0], viTriSoKhong[1]] = 0;
                    }

                    if (!(viTriXungQuanh[3, 0] == -1 && viTriXungQuanh[3, 1] == -1))
                    {
                        //Chuyen ben phai qua
                        PuzzelArray[viTriSoKhong[0], viTriSoKhong[1]] = PuzzelArray[viTriXungQuanh[3, 0], viTriXungQuanh[3, 1]];
                        PuzzelArray[viTriXungQuanh[3, 0], viTriXungQuanh[3, 1]] = 0;
                        //Tinh do sai lech cua TH nay
                        TinhDoSaiLech(3, ref tongCuaCacViTri);
                        //Gan lai TH cu
                        PuzzelArray[viTriXungQuanh[3, 0], viTriXungQuanh[3, 1]] = PuzzelArray[viTriSoKhong[0], viTriSoKhong[1]];
                        PuzzelArray[viTriSoKhong[0], viTriSoKhong[1]] = 0;
                    }

                    //Tong cua cac vi tri cong voi so tang g
                    for (int i = 0; i < tongCuaCacViTri.Length; i++)
                    {
                        if (tongCuaCacViTri[i] != -1)
                        {
                            tongCuaCacViTri[i] += g;
                        }
                    }

                    int min = int.MaxValue;
                    int viTriMin = -1;
                    for (int i = 0; i < tongCuaCacViTri.Length; i++)
                    {
                        if (tongCuaCacViTri[i] <= min && tongCuaCacViTri[i] != -1 && viTriVuaChon != i)
                        {
                            min = tongCuaCacViTri[i];
                            viTriMin = i;
                        }
                    }
                    switch (viTriMin)
                    {
                        case 0:
                            PuzzelArray[viTriSoKhong[0], viTriSoKhong[1]] = PuzzelArray[viTriXungQuanh[0, 0], viTriXungQuanh[0, 1]];
                            PuzzelArray[viTriXungQuanh[0, 0], viTriXungQuanh[0, 1]] = 0;
                            Down(PuzzelArray[viTriSoKhong[0], viTriSoKhong[1]]);
                            viTriVuaChon = 1;
                            break;
                        case 1:
                            PuzzelArray[viTriSoKhong[0], viTriSoKhong[1]] = PuzzelArray[viTriXungQuanh[1, 0], viTriXungQuanh[1, 1]];
                            PuzzelArray[viTriXungQuanh[1, 0], viTriXungQuanh[1, 1]] = 0;
                            Up(PuzzelArray[viTriSoKhong[0], viTriSoKhong[1]]);
                            viTriVuaChon = 0;
                            break;
                        case 2:
                            PuzzelArray[viTriSoKhong[0], viTriSoKhong[1]] = PuzzelArray[viTriXungQuanh[2, 0], viTriXungQuanh[2, 1]];
                            PuzzelArray[viTriXungQuanh[2, 0], viTriXungQuanh[2, 1]] = 0;
                            Right(PuzzelArray[viTriSoKhong[0], viTriSoKhong[1]]);
                            viTriVuaChon = 3;
                            break;
                        case 3:
                            PuzzelArray[viTriSoKhong[0], viTriSoKhong[1]] = PuzzelArray[viTriXungQuanh[3, 0], viTriXungQuanh[3, 1]];
                            PuzzelArray[viTriXungQuanh[3, 0], viTriXungQuanh[3, 1]] = 0;
                            Left(PuzzelArray[viTriSoKhong[0], viTriSoKhong[1]]);
                            viTriVuaChon = 2;
                            break;
                        default:
                            break;
                    }

                    //Tang len so tang
                    g++;

                }
                StreamWriter sw = new StreamWriter(path);
                sw.WriteLine("So buoc can de ra ket qua : {0} ", ketQua.Count);
                foreach (var item in ketQua)
                {
                    sw.WriteLine(item);
                }
                sw.Close();
            }
            else
            {
                StreamWriter sw = new StreamWriter(path);
                sw.WriteLine("Khong co loi giai");
                sw.Close();
            }
        }
        public Puzzel()
        {

        }
    }
    public class ThucThi
    {
        public ThucThi()
        {
            Puzzel a = new Puzzel();
            string input = @"C:\Users\thuyl\OneDrive\Education\Nam III\Tri tue nhan tao\Bai tap thuc hanh\ConsoleApp3\Input.txt";
            string output = @"C:\Users\thuyl\OneDrive\Education\Nam III\Tri tue nhan tao\Bai tap thuc hanh\ConsoleApp3\Output.txt";
            a.DocFile(input);
            a.GiaiRoiInKetQua(output);
        }
    }
}