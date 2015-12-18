using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
namespace BaiTapGiuaKy
{
    class Sinhvien
    {

        #region khai bao bien thuoc tinh 
        /// <summary>
        /// khai bao cac thuoc tinh cua sinh vien
        /// </summary>
        private string sbd, kv, uutien, dantoc, ten, ngaysinh;
        private string[,] nguyenvong = new string[4, 2];
        private double[] diemthi = new double[13];
       private double[] ketqua = new double[4];
       private double diem;
       private double diemkv;

        #endregion

       #region get - Lay gia tri cua cac bien mac dinh
       public double[] Ketqua
       {
           get { return ketqua; }
       }
       public string SBd
       {
           get { return sbd; }
       }
       public string[,] Nguyenvong
           
       {
           get { return nguyenvong; }
       }
       #endregion

       #region tao ham lay gia tri cua tung sinh vien 

       /// <summary>
        /// tao ham lay gia tri cua diem thi cac mon cua 1 thi sinh .
        /// </summary>
        /// <param name="stt"></param>
        public void _LayGiaTri( int stt)
        {
            XuLyFile sv = new XuLyFile();
            sv._DK_NguyenVong(stt);
            sbd = sv.Sbd;
            kv = sv.Khuvuc;
            uutien = sv.Uutien;
            dantoc = sv.Dantoc;
            ten = sv.Ten;
            ngaysinh = sv.Ngaysinh;
            for (int i = 0; i < 4; i++)// 4 cap nguyen vong
                for (int j = 0; j < 2; j++)// 2 loai nguyen vong 
                    nguyenvong[i, j] = sv.Nguyenvong[i, j];
            for (int i = 0; i < 13; i++)// xet phan diem so 
            {

                if (sv.Dienthi[i] == "NA") diemthi[i] = -1;
                else diemthi[i] = double.Parse(sv.Dienthi[i]);
            }    
           
        }

       #endregion 

        #region xu ly diem thanh phan cac mon thi 

        private double _DiemCacMonThanhPhan( string str)
        {
            
            switch (str)
            {
                case "Toan": diem = diemthi[0]; break;
                case "Van": diem = diemthi[1]; break;
                case "Ly": diem = diemthi[2]; break;
                case "Hoa": diem = diemthi[3]; break;
                case "Sinh": diem = diemthi[4]; break;
                case "Su": diem = diemthi[5]; break;
                case "Dia": diem = diemthi[6]; break;
                case "Anh": diem = diemthi[7]; break;
                case "Nga": diem = diemthi[8]; break;
                case "Phap": diem = diemthi[9]; break;
                case "Trung": diem = diemthi[10]; break;
                case "Duc": diem = diemthi[11]; break;
                case "Nhat": diem = diemthi[12]; break;
            }
            return diem;
        }
        #endregion 

        #region Xu ly cac truong hop duoc uu tien 
       
        private double _DiemKhuVuc(string s)
        {
            switch (s)
            {
                case "\"KV1\"": diemkv = 1.5; break;
                case "\"KV2-NT\"": diemkv = 1; break;
                case "\"KV2\"": diemkv = 0.5; break;
                case "\"KV3\"": diemkv = 0; break;
            }
            return diemkv;
        }

        #endregion 
        private double diemUT;
        private double _DiemUuTien(string s)
        {
            if (s == "UT") diemUT = 1;
            else diemUT = 0;
            return diemUT;
        }

        public void _XuLyDiemDauVao()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 1; j < 2; j++)
                {
                    if (nguyenvong[i, j] ==null) ketqua[i]=-1;
                    else
                    {
                        string[] s = nguyenvong[i, j].Split(',');
                        if (s[3] == "1")
                        {
                            ketqua[i] = (_DiemCacMonThanhPhan(s[0]) * 2 + _DiemCacMonThanhPhan(s[1]) + _DiemCacMonThanhPhan(s[2]) + _DiemKhuVuc(kv)) / 4 + _DiemUuTien(uutien);
                        }
                        else
                            ketqua[i] = (_DiemCacMonThanhPhan(s[0]) + _DiemCacMonThanhPhan(s[1]) + _DiemCacMonThanhPhan(s[2]) + _DiemKhuVuc(kv)) / 3 + _DiemUuTien(uutien);
                    }
                    
                }
        }
        public void Getdata(string sql)
        {
            SQLiteConnection conn = new SQLiteConnection(@"Data Source = D:\LTHDT\test.db.sqlite");
            Console.WriteLine("bat dau mo file ");
            conn.Open();
            Console.WriteLine("mo file thanh cong ");
            SQLiteCommand cmd; //Đối tượng thuộc lớp SqlCommand
            cmd = new SQLiteCommand();
            cmd.Connection = conn; //Gán kết nối
            //string sql = "INSERT INTO ketqua VALUES('test2',1)";
            cmd.CommandText = sql; //Gán lệnh SQL
            try
            {
                cmd.ExecuteNonQuery(); //Thực hiện câu lệnh SQL
            }
            catch (Exception ex)
            {
                Console.Write("-----B");
            }
            cmd.Dispose();//Giải phóng bộ nhớ
            cmd = null;
        }
    }
}
