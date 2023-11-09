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
            string query = "SELECT * FROM SinhVien WHERE  trang_thai = 'Ðã thuê'";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
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
/*        string id = null;
*/        using (SqlCommand command = new SqlCommand(query, connection))
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
/*            id = sinhVien.id;
*/        }
        connection.Close();
/*        return id;
*/    }


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

    public int LayIdPhongCuaSV(string idsv)
    {
        int idphong = 0;
        connection.Open();
        string query = "SELECT idphong FROM SinhVien WHERE id = @id";
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@id", idsv);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    idphong = reader.GetInt32(0);
                }
            }
        }
        connection.Close();
        return idphong;
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
        List<SinhVien> sinhVien = new List<SinhVien>();
        string query = "SELECT * FROM SinhVien WHERE tensinhvien LIKE @tensinhvien";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@tensinhvien", "%" + tensinhvien + "%");
        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                SinhVien student = new SinhVien
                {
                    id = reader["id"].ToString(),
                    tensinhvien = reader["Name"].ToString(),
                    idphong = (int)reader["Age"]
                };
                sinhVien.Add(student);
            }
        }
        connection.Close();
        return sinhVien;
    }

}
