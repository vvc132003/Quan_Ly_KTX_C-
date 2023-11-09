/*using ketnoicsdllan1.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ketnoicsdllan1.PresentationLayer
{
    internal class Program
    {
        private static StudentBLL studentBLL = new StudentBLL();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Quản lý sinh viên");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Hiển sinh viên");
                Console.WriteLine("3. Xoá sinh viên");
                Console.WriteLine("4. Cập nhật sinh viên");
                Console.WriteLine("5. Tìm kiếm sinh viên theo tên");
                Console.WriteLine("6. Sắp xếp tăng dần theo tuổi");
                Console.WriteLine("7. Sắp xếp giảm dần theo tuổi");
                Console.Write("Chọn tùy chọn: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Student student = new Student();
                        student.InputStudentDetails();
                        studentBLL.AddStudent(student);
                        Console.WriteLine("Sinh viên đã được thêm vào CSDL.");
                        break;
                    case "2":
                        studentBLL.Hienthisinhvien();
                        break;
                    case "3":
                        Console.Write("Nhập StudentID của sinh viên muốn xoá: ");
                        if (int.TryParse(Console.ReadLine(), out int studentID))
                        {
                            *//*                                studentBLL.DeleteStudent(studentID);
                            *//*
                            Console.WriteLine("Sinh viên đã được xoá khỏi CSDL.");
                        }
                        else
                        {
                            Console.WriteLine("StudentID không hợp lệ.");
                        }
                        break;
                    case "4":
                        Console.Write("Nhập StudentID của sinh viên muốn cập nhật: ");
                        Student studentToUpdate = new Student();
                        if (int.TryParse(Console.ReadLine(), out int studentIDd))
                        {
                            studentToUpdate.StudentID = studentIDd;
                            Console.Write("Nhập tên mới của sinh viên: ");
                            studentToUpdate.Name = Console.ReadLine();
                            Console.Write("Nhập tuổi mới của sinh viên: ");
                            if (int.TryParse(Console.ReadLine(), out int age))
                            {
                                studentToUpdate.Age = age;
                                *//*                                    studentBLL.UpdateStudent(studentToUpdate);
                                *//*
                            }
                            else
                            {
                                Console.WriteLine("Tuổi không hợp lệ.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("StudentID không hợp lệ.");
                        }
                        break;
                    case "5":
                        *//*                            studentBLL.SearchStudentsByName();
                        *//*
                        break;
                    case "6":
                        *//*                            studentBLL.GetStudentsSortedByNameDescending(); 
                        *//*
                        break;
                    case "7":
                        *//*                            studentBLL.GetStudentsSortedByNameAscending();
                        *//*
                        break;

                }
            }
        }
    }
}
*/