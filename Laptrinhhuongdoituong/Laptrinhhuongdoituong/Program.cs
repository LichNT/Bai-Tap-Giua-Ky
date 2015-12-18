using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace BaiTapGiuaKy
{
    class Program
    {
        static void Main(string[] args)
        {
            Sinhvien[] sv = new Sinhvien[100];
            for (int i = 0; i < 3; i++)
            {
                sv[i] = new Sinhvien();
                sv[i]._LayGiaTri(i+4300);
                sv[i]._XuLyDiemDauVao();
                for (int j = 0; j < 4; j++)
                        if(sv[i].Ketqua[j]>0)
                           {
                             int k = j + 1;
                             string sql = "INSERT INTO nvxt VALUES('" + sv[i].SBd + "','" + k+ "','" + sv[i].Nguyenvong[j, 0] + "','" + sv[i].Ketqua[j] + "')";
                             sv[i].Getdata(sql);
                           }
            }
            Console.WriteLine("Hoan thanh viec ghi File ");    
            Console.ReadKey();
        }
    }
}
