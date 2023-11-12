using ketnoicsdllan1;
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
    internal class PhongDAL
    {
        private SqlConnection connection = DBUtils.GetDBConnection();
        public List<Phong> GetAllPhong()
        {
            List<Phong> phongList = new List<Phong>();
            connection.Open();
            using (SqlCommand command = new SqlCommand("GetAllPhongProcedure", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Phong phong = new Phong
                        {
                            id = Convert.ToInt32(reader["id"]),
                            loaiphong = reader["loaiphong"].ToString(),
                            sogiuong = Convert.ToInt32(reader["sogiuong"]),
                            songuoio = Convert.ToInt32(reader["songuoio"]),
                            giaphong = Convert.ToSingle(reader["giaphong"])
                        };
                        phongList.Add(phong);
                    }
                }
            }

            connection.Close();

            return phongList;
        }

        public void ThemPhong(Phong phong)
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("ThemPhongs", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@loaiphong", phong.loaiphong);
                command.Parameters.AddWithValue("@sogiuong", phong.sogiuong);
                command.Parameters.AddWithValue("@songuoio", phong.songuoio);
                if (phong.loaiphong == "VIP")
                {
                    phong.giaphong = phong.sogiuong * 200000; 
                }
                else
                {
                    phong.giaphong = phong.sogiuong * 100000; 
                }
                command.Parameters.AddWithValue("@giaphong", phong.giaphong);
                command.ExecuteNonQuery();
            }
            connection.Close();

        }
        public void CapNhatPhong(Phong phong)
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("CapNhatPhongs", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", phong.id);
                command.Parameters.AddWithValue("@loaiphong", phong.loaiphong);
                command.Parameters.AddWithValue("@sogiuong", phong.sogiuong);
                command.Parameters.AddWithValue("@songuoio", phong.songuoio);
                command.Parameters.AddWithValue("@giaphong", phong.giaphong);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
        public void XoaPhong(int id)
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("XoaPhongs", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
        public void CapNhatSoNguoiO(Phong phong, int songuoio)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            using (SqlCommand command = new SqlCommand("CapNhatSoNguoiOs", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@songuoio", songuoio);
                command.Parameters.AddWithValue("@id", phong.id);
                command.ExecuteNonQuery();
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

      

        public Phong LayPhongTheoMa(int id)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
                using (SqlCommand command = new SqlCommand("LayPhongTheoMaS", connection))
                {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Phong phong = new Phong
                            {
                                id = (int)reader["id"],
                                sogiuong = (int)reader["sogiuong"],
                                songuoio = (int)reader["songuoio"],
                            };
                            return phong;
                        }
                        else
                        {
                            return null;
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