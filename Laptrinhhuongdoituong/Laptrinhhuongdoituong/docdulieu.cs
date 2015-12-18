using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BaiTapGiuaKy
{
    class XuLyFile
    {/// <summary>
        /// khai bao thong tin sinh vien...
        /// </summary>
        private string sbd, kv, uutien,dantoc,ten,ngaysinh;
       private string[,] nguyenvong = new string[4,2];
       private string[] diemthi = new string[13];
       #region get _ lay gia tri cua thuoc tinh 
       public string Sbd
       {
           get { return sbd;}    
       }
       public string Ten
       {
           get { return ten; }

       }
       public string Ngaysinh
       {
           get { return ngaysinh; }

       }
       public string Khuvuc
       {
           get { return kv; }

       }
       public string Dantoc
       {
           get { return dantoc; }

       }
       public string Uutien
       {
           get { return uutien; }

       }
       public string[,] Nguyenvong
       {
           get { return nguyenvong; }
       }
       public string[] Dienthi
        {
            get { return diemthi; }
        }
       #endregion 
       /// <summary>
        /// doc gia tri tu File dang ky theo nguyen  vong cua 1 sinh vien . 
        /// </summary>
        /// <param name="stt"></param>
    
       public void _DK_NguyenVong(int stt)
        {
            string Src01 = @"C:\Users\lichnt\Desktop\Copy\lập trình hướng đối tượng\_DK_NguyenVong-bk.csv";
            string[] Str = File.ReadAllLines(Src01);
           //lay du lieu tu file nguon, sau khi lay du lieu tach du lieu bang cach phan biet dau ' " ';
            string[] sr = Str[stt + 1].Split('"');// bo het dau " va thay the bang dau , ;
            int n = sr.Length;
                        for (int i = 0; i < n;i++ )
                               if(sr[i]==",")//phan biet bang dau phay o cac phan.
                                {
                                    for (int j = i; j < n-1; j++)
                                        sr[j] = sr[j + 1];
                                    n--;
                                }
            n--;
            int dem = 0;

                        for (int i = 2; i < n; i++)
                                {
                                    int j = 0;
                                    if (i % 2 == 0)
                                        nguyenvong[dem, j] = sr[i];
                                    else
                                    { nguyenvong[dem, j + 1] = sr[i]; dem++; }
                                }
            //doc file csdl
                        string Src02 = @"C:\Users\lichnt\Desktop\Copy\lập trình hướng đối tượng\csdl-bk.csv";
            string[] Str2 = File.ReadAllLines(Src02);
            string[] tr = Str2[stt + 1].Split(',');
             int m=tr.Length;
                 sbd = tr[0];
                 ten = tr[1];
                 ngaysinh = tr[2];
                 kv = tr[3];
                 dantoc = tr[4];
                 uutien = tr[5];
           for (int i = 6; i < m; i++)
                    diemthi[i - 6] = tr[i];
        }
    }
}
