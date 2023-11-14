using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKyTucXa.PresentationLayer
{
    internal class Menu
    {
        public void menuktx()
        {
            Console.WriteLine("------------------QUAN LY KY TUC XA--------------");
            Console.WriteLine("|*1. Quan ly phong                              |");
            Console.WriteLine("|*2. Quan ly sinh vien                          |");
            Console.WriteLine("|*3. Quan ly thue phong                         |");
            Console.WriteLine("|*4. Doi mat khau                               |");
            Console.WriteLine("|*5. Quan ly chuyen phong                       |");
            Console.WriteLine("|*6. Quan ly tra phong                          |");
            Console.WriteLine("|*7. Dang xuat                                  |");
            Console.WriteLine("|*8. Sinh vien muon thue lai                    |");
            Console.WriteLine("|*0. Ket thuc                                   |");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("***Moi ban chon***:");
        }
        public void menuPHONG()
        {
            Console.WriteLine("------------------QUAN LY PHONG------------------");
            Console.WriteLine("|*1. Them phong                                 |");
            Console.WriteLine("|*2. Hien thi phong                             |");
            Console.WriteLine("|*3. Cap nhat phong                             |");
            Console.WriteLine("|*4. Xoa phong                                  |");
            Console.WriteLine("|*0. Ket thuc                                   |");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("***Moi ban chon***:");
        }
        public void menuSINHVIEN()
        {
            Console.WriteLine("----------------QUAN LY SINH VIEN----------------");
            Console.WriteLine("|*1. Hien thi sinh vien                         |");
            Console.WriteLine("|*2. Cap nhat sinh vien                         |");
            Console.WriteLine("|*3. Tim kiem sinh vien  	                   |");
            Console.WriteLine("|*4. Sap xep  sinh vien  	                   |");
            Console.WriteLine("|*0. Quay lại                                   |");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("***Moi ban chon***:");
        }
        public void menuSapXepSV()
        {
            Console.WriteLine("-----------------Sap xep sinh vien---------------");
            Console.WriteLine("|*1. Sap xep theo ten                           |");
            Console.WriteLine("|*2. Sap xep theo ma phong                      |");
            Console.WriteLine("|*3. Sap xep theo ngay vao                      |");
            Console.WriteLine("|*0. Quay lại                                   |");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("***Moi ban chon***:");
        }
        public void menuthuePHONG()
        {
            Console.WriteLine("------------------QUAN LY THUE PHONG-------------");
            Console.WriteLine("|*1. Thue phong                                 |");
            Console.WriteLine("|*2. Hien thi ds thue phong                     |");
            Console.WriteLine("|*3. Sinh vien quay lai thue                    |");
            Console.WriteLine("|*0. Ket thuc                                   |");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("***Moi ban chon***:");
        }
    }
}