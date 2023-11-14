﻿using ketnoicsdllan1;
using QuanLyKyTucXa.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKyTucXa.DataAccessLayer
{
    internal class ThuePhonhDAL
    {
        private SqlConnection connection = DBUtils.GetDBConnection();

        public void ThuePhong(ThuePhong thuePhong)
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("ThuePhongs", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idnguoidung", thuePhong.idnguoidung);
                command.Parameters.AddWithValue("@idphong", thuePhong.idphong);
                command.Parameters.AddWithValue("@trangthai", thuePhong.trangthai);
                command.Parameters.AddWithValue("@idsinhvien", thuePhong.idsinhvien);
                command.Parameters.AddWithValue("@ngaythue", thuePhong.ngaythue);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public List<ThuePhong> GetAllTinThuePhong()
        {
            List<ThuePhong> danhSachThuePhong = new List<ThuePhong>();

            connection.Open();

            using (SqlCommand command = new SqlCommand("GetAllThuePhong", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ThuePhong thuePhong = new ThuePhong
                        {
                            id = Convert.ToInt32(reader["id"]),
                            idsinhvien = reader["idsinhvien"].ToString(),
                            idphong = Convert.ToInt32(reader["idphong"]),
                            ngaythue = (DateTime)reader["ngaythue"],
                            trangthai = reader["trangthai"].ToString()
                        };
                        danhSachThuePhong.Add(thuePhong);
                    }
                }
            }

            // Đóng kết nối
            connection.Close();

            return danhSachThuePhong;
        }

        public int LayMaThuePhongTheoIDSV(string masv)
        {
            List<ThuePhong> danhSachThuePhong = new List<ThuePhong>();

            connection.Open();

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sql = "SELECT * FROM ThuePhong WHERE idsinhvien = @idsinhvien";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@idsinhvien", masv);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return (int)reader["id"];
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }     
    }
}
