using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

namespace DSA
{
    public class ThapHaNoi
    {
        //Tao ra 3 cot
        private Stack<int> cotA;
        private Stack<int> cotB;
        private Stack<int> cotC;
        private int soLuongDia;
        //TH dem tat ca cac dia qua cot C theo dung thu tu
        private int[] ketQuaCuoi;

        //Luu lai cac buoc lam
        private List<string> ketQuaList = new List<string>();
        private bool XongChua()
        {
            if (cotC.Count != soLuongDia)
            {
                //Chua xong
                return false;
            }
            else
            {
                //Tao ra 1 cai List tam
                List<int> tam = new List<int>();
                //Chep cac dia co trong cotC vao
                while (cotC.Count != 0)
                {
                    tam.Add(cotC.Pop());
                }
                //Dao nguoc List tam lai
                tam.Reverse();
                //Chep dia vao cotC lai
                foreach (var VARIABLE in tam)
                {
                    cotC.Push(VARIABLE);
                }
                //So sanh voi dap an
                for (int i = 0; i < tam.Count; i++)
                {
                    if (ketQuaCuoi[i] != tam[i])
                    {
                        //Chua xong
                        return false;
                    }
                }
                return true;
            }

        }
        public ThapHaNoi(int soDia)
        {
            soLuongDia = soDia;
            cotA = new Stack<int>();
            ketQuaCuoi = new int[soDia];
            //Bo vao cot cac dia theo thu tu nho den lon tu tren xuong duoi
            for (int i = 0; i < ketQuaCuoi.Length; i++)
            {
                ketQuaCuoi[i] = ketQuaCuoi.Length - 1 - i;
                cotA.Push(ketQuaCuoi.Length - 1 - i);
            }
        }
        private int TinhH()
        {
            if (cotC.Count == 0)
            {
                return soLuongDia;
            }
            else
            {
                //Tao ra 1 cai List tam
                List<int> tam = new List<int>();
                //Chep cac dia co trong cotC vao
                while (cotC.Count != 0)
                {
                    tam.Add(cotC.Pop());
                }
                //Dao nguoc List tam lai
                tam.Reverse();
                //Chep dia vao cotC lai
                foreach (var VARIABLE in tam)
                {
                    cotC.Push(VARIABLE);
                }

                int soLuongDiaNamDung = 0;
                int soLuongDiaNamSai = 0;
                for (int i = 0; i < tam.Count; i++)
                {
                    if (ketQuaCuoi[i] != tam[i])
                    {
                        soLuongDiaNamSai++;
                    }
                    else
                    {
                        soLuongDiaNamDung++;
                    }
                }

                return soLuongDia - soLuongDiaNamDung + soLuongDiaNamSai;
            }
        }
        public void XuLy()
        {
            cotB = new Stack<int>();
            cotC = new Stack<int>();

            //g la so buoc da trai qua
            int g = 0;

            //Tranh truong hop chuyen 1 dia nao do qua lai tu 2 cot tao thanh vong lap vo tan
            int vuaDiChuyen = -1;

            //Lap den khi cotC da dung truong hop
            while (!XongChua())
            {
                //Buoc thu~

                //Ghi nho lai H cua cac truong hop 
                //Voi moi cot ta co 2 TH tong cong la 6 TH

                int[] f = { -1, -1, -1, -1, -1, -1 };

                //TH0 : Tu cot A -> B
                //TH1 : Tu cot A -> C
                //TH2 : Tu cot B -> A
                //TH3 : Tu cot B -> C
                //TH4 : Tu cot C -> A
                //TH5 : Tu cot C -> B

                //Dung de tinh H bang ham tinh H o tren
                int h;

                //B1 thuc hien TH0 : Tu cot A -> B
                //Neu cotA khac Rong
                if (cotA.Count != 0)
                {
                    //cotB Rong hoac cotA.Peek() < cotB.Peek()
                    if (cotB.Count == 0 || cotA.Peek() < cotB.Peek())
                    {
                        //Tinh H cua truong hop nay
                        h = TinhH();
                        //Gan ket qua H vua tim duoc + g vao f[0];
                        f[0] = h + g;
                    }
                }

                //B2 thuc hien TH1 : Tu cot A -> C
                //Neu cotA khac Rong
                if (cotA.Count != 0)
                {
                    //cotC Rong hoac cotA.Peek() < cotC.Peek()
                    if (cotC.Count == 0 || cotA.Peek() < cotC.Peek())
                    {
                        //Chuyen cotA.Peek() qua cotC bang cotC.Push(cotA.Pop());
                        cotC.Push(cotA.Pop());
                        //Tinh H cua truong hop nay
                        h = TinhH();
                        //Chuyen nguoc lai vi o buoc nay chi la Buoc thu~
                        cotA.Push(cotC.Pop());
                        //Gan ket qua H vua tim duoc + g vao f[1];
                        f[1] = h + g;
                    }
                }

                //B3 thuc hien TH2 : Tu cot B -> A
                //Neu cotB khac Rong
                if (cotB.Count != 0)
                {
                    //cotA Rong hoac cotB.Peek() < cotA.Peek()
                    if (cotA.Count == 0 || cotB.Peek() < cotA.Peek())
                    {
                        //Tinh H cua truong hop nay
                        h = TinhH();
                        //Gan ket qua H vua tim duoc + g vao f[2];
                        f[2] = h + g;
                    }
                }

                //B4 thuc hien TH3 : Tu cot B -> C
                //Neu cotB khac Rong
                if (cotB.Count != 0)
                {
                    //cotC Rong hoac cotB.Peek() < cotC.Peek()
                    if (cotC.Count == 0 || cotB.Peek() < cotC.Peek())
                    {
                        //Chuyen cotB.Peek() qua cotC bang cotC.Push(cotB.Pop());
                        cotC.Push(cotB.Pop());
                        //Tinh H cua truong hop nay
                        h = TinhH();
                        //Chuyen nguoc lai vi o buoc nay chi la Buoc thu~
                        cotB.Push(cotC.Pop());
                        //Gan ket qua H vua tim duoc + g vao f[3];
                        f[3] = h + g;
                    }
                }

                //B5 thuc hien TH4 : Tu cot C -> A
                //Neu cotC khac Rong
                if (cotC.Count != 0)
                {
                    //cotA Rong hoac cotC.Peek() < cotA.Peek()
                    if (cotA.Count == 0 || cotC.Peek() < cotA.Peek())
                    {
                        //Chuyen cotC.Peek() qua cotA bang cotA.Push(cotC.Pop());
                        cotA.Push(cotC.Pop());
                        //Tinh H cua truong hop nay
                        h = TinhH();
                        //Chuyen nguoc lai vi o buoc nay chi la Buoc thu~
                        cotC.Push(cotA.Pop());
                        //Gan ket qua H vua tim duoc + g vao f[4];
                        f[4] = h + g;
                    }
                }

                //B6 thuc hien TH5 : Tu cot C -> B
                //Neu cotC khac Rong
                if (cotC.Count != 0)
                {
                    //cotB Rong hoac cotC.Peek() < cotB.Peek()
                    if (cotB.Count == 0 || cotC.Peek() < cotB.Peek())
                    {
                        //Chuyen cotC.Peek() qua cotB bang cotB.Push(cotC.Pop());
                        cotB.Push(cotC.Pop());
                        //Tinh H cua truong hop nay
                        h = TinhH();
                        //Chuyen nguoc lai vi o buoc nay chi la Buoc thu~
                        cotC.Push(cotB.Pop());
                        //Gan ket qua H vua tim duoc + g vao f[5];
                        f[5] = h + g;
                    }
                }

                //Tim xem buoc di nao co f nho nhat
                int viTriMin = -1;
                int min = int.MaxValue;
                for (int i = 0; i < f.Length; i++)
                {
                    if (f[i] < min && f[i] != -1 && i != vuaDiChuyen)
                    {
                        viTriMin = i;
                        min = f[i];
                    }
                }


                //Thuc hien viec di chuyen dia thuc su
                switch (viTriMin)
                {
                    //TH0 : Tu cot A -> B
                    //TH1 : Tu cot A -> C
                    //TH2 : Tu cot B -> A
                    //TH3 : Tu cot B -> C
                    //TH4 : Tu cot C -> A
                    //TH5 : Tu cot C -> B
                    case 0:
                        //Ghi vo ket qua
                        ketQuaList.Add("A -> B");
                        cotB.Push(cotA.Pop());
                        //De khong thuc hien viec di chuyen B -> A
                        vuaDiChuyen = 2;
                        break;
                    case 1:
                        //Ghi vo ket qua
                        ketQuaList.Add("A -> C");
                        cotC.Push(cotA.Pop());
                        //De khong thuc hien viec di chuyen C -> A
                        vuaDiChuyen = 4;
                        break;
                    case 2:
                        //Ghi vo ket qua
                        ketQuaList.Add("B -> A");
                        cotA.Push(cotB.Pop());
                        //De khong thuc hien viec di chuyen A -> B
                        vuaDiChuyen = 0;
                        break;
                    case 3:
                        //Ghi vo ket qua
                        ketQuaList.Add("B -> C");
                        cotC.Push(cotB.Pop());
                        //De khong thuc hien viec di chuyen C -> B
                        vuaDiChuyen = 5;
                        break;
                    case 4:
                        //Ghi vo ket qua
                        ketQuaList.Add("C -> A");
                        cotA.Push(cotC.Pop());
                        //De khong thuc hien viec di chuyen A -> C
                        vuaDiChuyen = 1;
                        break;
                    case 5:
                        //Ghi vo ket qua
                        ketQuaList.Add("C -> B");
                        cotB.Push(cotC.Pop());
                        //De khong thuc hien viec di chuyen B -> C
                        vuaDiChuyen = 3;
                        break;
                }

                //Tang so lan thuc hien
                g++;
            }
        }

        public void InRaManHinh()
        {
            Console.WriteLine("So buoc: " + ketQuaList.Count);
            foreach (var VARIABLE in ketQuaList)
            {
                Console.WriteLine(VARIABLE);
            }
        }
    }

    public class ThucThi
    {
        public ThucThi()
        {
            ThapHaNoi a = new ThapHaNoi(3);
            a.XuLy();
            a.InRaManHinh();
        }
    }
}