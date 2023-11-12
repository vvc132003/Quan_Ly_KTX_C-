using ketnoicsdllan1;
using ketnoicsdllan1.BusinessLogicLayer;
using QuanLyKyTucXa.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;

internal class StudentDAL
{
    private SqlConnection connection = DBUtils.GetDBConnection();

    public List<SinhVien> GetAllStudents()
    {
        List<SinhVien> students = new List<SinhVien>();
            connection.Open();
            using (SqlCommand command = new SqlCommand("GetAllStudents", connection))
            {
            command.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SinhVien student = new SinhVien
                        {
                            id = reader["id"].ToString(),
                            tensinhvien = reader["tensinhvien"].ToString(),
                            khoahoc = reader["khoahoc"].ToString(),
                            nganhhoc = reader["nganhhoc"].ToString(),
                            email = reader["email"].ToString(),
                            sodienthoai = reader["sodienthoai"].ToString(),
                            idphong = (int)reader["idphong"],
                            gioitinh = reader["gioitinh"].ToString(),
                            quequan = reader["quequan"].ToString(),
                            trang_thai = reader["trang_thai"].ToString(),
                            solanvipham = (int)reader["solanvipham"],
                            ngaynhaphoc = (DateTime)reader["ngaynhaphoc"],
                            ngaysinh = (DateTime)reader["ngaysinh"]
                        };
                        students.Add(student);
                    }
                }
            }
            connection.Close();
        return students;
    }


    public void ThemSinhVien(SinhVien sinhVien)
    {
        connection.Open();
        string query = "INSERT INTO SinhVien (id,tensinhvien, khoahoc, nganhhoc, email, sodienthoai, idphong, gioitinh, quequan,trang_thai,solanvipham, ngaynhaphoc, ngaysinh) VALUES (@id,@tensinhvien, @khoahoc, @nganhhoc, @email, @sodienthoai, @idphong, @gioitinh, @quequan,@trang_thai,@solanvipham, @ngaynhaphoc, @ngaysinh)";
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@id", sinhVien.id);
            command.Parameters.AddWithValue("@tensinhvien", sinhVien.tensinhvien);
            command.Parameters.AddWithValue("@khoahoc", sinhVien.khoahoc);
            command.Parameters.AddWithValue("@nganhhoc", sinhVien.nganhhoc);
            command.Parameters.AddWithValue("@email", sinhVien.email);
            command.Parameters.AddWithValue("@sodienthoai", sinhVien.sodienthoai);
            command.Parameters.AddWithValue("@idphong", sinhVien.idphong);
            command.Parameters.AddWithValue("@gioitinh", sinhVien.gioitinh);
            command.Parameters.AddWithValue("@quequan", sinhVien.quequan);
            command.Parameters.AddWithValue("@trang_thai", sinhVien.trang_thai);
            command.Parameters.AddWithValue("@solanvipham", sinhVien.solanvipham);
            command.Parameters.AddWithValue("@ngaynhaphoc", sinhVien.ngaynhaphoc);
            command.Parameters.AddWithValue("@ngaysinh", sinhVien.ngaysinh);

            command.ExecuteNonQuery();
        }
        connection.Close();
    }


    public void UpdateStudent(SinhVien sinhVien)
    {
        connection.Open();
        string query = "UPDATE SinhVien SET tensinhvien = @tensinhvien, khoahoc = @khoahoc, nganhhoc = @nganhhoc, email = @email, sodienthoai = @sodienthoai, gioitinh = @gioitinh, quequan = @quequan , ngaynhaphoc = @ngaynhaphoc, ngaysinh = @ngaysinh WHERE id = @id";

        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@tensinhvien", sinhVien.tensinhvien);
            command.Parameters.AddWithValue("@khoahoc", sinhVien.khoahoc);
            command.Parameters.AddWithValue("@nganhhoc", sinhVien.nganhhoc);
            command.Parameters.AddWithValue("@email", sinhVien.email);
            command.Parameters.AddWithValue("@sodienthoai", sinhVien.sodienthoai);
            command.Parameters.AddWithValue("@idphong", sinhVien.idphong);
            command.Parameters.AddWithValue("@gioitinh", sinhVien.gioitinh);
            command.Parameters.AddWithValue("@quequan", sinhVien.quequan);
            command.Parameters.AddWithValue("@ngaynhaphoc", sinhVien.ngaynhaphoc);
            command.Parameters.AddWithValue("@ngaysinh", sinhVien.ngaysinh);
            command.Parameters.AddWithValue("@id", sinhVien.id);
            command.ExecuteNonQuery();
        }

        connection.Close();
    }

    public void UpdateTrangThaiStudent(SinhVien student, string masv)
    {
            connection.Open();
            string query = "UPDATE SinhVien SET  trang_thai = @trang_thai " +
                           " WHERE id = @id";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@trang_thai", student.trang_thai);
                command.Parameters.AddWithValue("@id", masv);
                command.ExecuteNonQuery();
            }
            connection.Close();
    }

    public Tuple<int, DateTime> LayThongTinPhongVaNgayThue(string idsv)
    {
        int idphong = 0;
        DateTime ngaynhaphoc = DateTime.MinValue;
        connection.Open();
        string query = "SELECT idphong,ngaynhaphoc FROM SinhVien WHERE id = @id";
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@id", idsv);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    idphong = reader.GetInt32(0);
                    ngaynhaphoc = reader.GetDateTime(1);
                }
            }
        }
        connection.Close();
        return Tuple.Create(idphong, ngaynhaphoc);
    }

    public void CapNhatPhongChoSinhVien(string id, int idphong)
    {
            connection.Open();
            string updateQuery = "UPDATE SinhVien SET idphong = @idphong WHERE id = @id";
            using (SqlCommand command = new SqlCommand(updateQuery, connection))
            {
                command.Parameters.AddWithValue("@idphong", idphong);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            connection.Close();
        }
    }


    public List<SinhVien> TimKiemSinhVienTheoTen(string tensinhvien)
    {
        connection.Open();
        List<SinhVien> sinhVienlist = new List<SinhVien>();
        string query = "SELECT * FROM SinhVien WHERE tensinhvien LIKE @tensinhvien AND trang_thai LIKE 'Ðã thuê'";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@tensinhvien", "%" + tensinhvien + "%");
        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                SinhVien sinhvien = new SinhVien
                {
                    tensinhvien = reader["tensinhvien"].ToString(),
                    idphong = (int)reader["idphong"]
                };
                sinhVienlist.Add(sinhvien);
            }
        }
        connection.Close();
        return sinhVienlist;
    }

}
